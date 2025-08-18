using _0818_2.Commands;
using _0818_2.Models;
using System;
using System.Globalization;
using System.Windows.Input;

namespace _0818_2.ViewModels
{
    /// <summary>
    /// 계산기 ViewModel
    /// 
    /// 이 클래스는 WPF의 MVVM 패턴에서 "ViewModel" 역할을 수행합니다.
    /// - View(XAML)와 Data Binding으로 연결되어, 사용자가 TextBox에 입력한 값이
    ///   ViewModel 속성(FirstNumber, SecondNumber)에 반영됩니다(Mode=TwoWay).
    /// - 버튼 클릭은 Code-behind 이벤트가 아니라 ICommand(RelayCommand)로 처리합니다.
    ///   (Add/Subtract/Multiply/Divide/Clear 5가지 명령을 노출)
    /// - CanExecute를 통해 "버튼 활성/비활성"을 동적으로 제어합니다.
    /// - 속성 변경 시, BaseViewModel의 SetProperty → OnPropertyChanged가 호출되어
    ///   WPF 바인딩 엔진이 UI를 자동으로 갱신합니다.
    /// 
    /// [XAML 바인딩 예시]
    ///   TextBox Text="{Binding FirstNumber, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
    ///   - Mode=TwoWay: UI ↔ ViewModel 양방향 갱신
    ///   - UpdateSourceTrigger=PropertyChanged: 입력할 때마다 즉시 ViewModel에 전달
    /// </summary>
    public class CalculatorViewModel : BaseViewModel
    {
        // ------------------------------------------------------------
        // 1) 의존 모델(Model)
        // ------------------------------------------------------------
        // 실제 계산 및 숫자 검증 로직은 Model(Calculator)에 위임합니다.
        //  - IsValidNumber(string): 문자열이 숫자로 유효한지 검사
        //  - ParseNumber(string): 문자열을 double로 변환(예외 처리 포함)
        //  - Calculate(double, double, string op): 사칙연산 수행
        private readonly Calculator _calculator = new Calculator();

        // ------------------------------------------------------------
        // 2) 바인딩 대상 속성(Backing Field)
        // ------------------------------------------------------------
        // TextBox는 문자열과 바인딩하는 경우가 많아 string으로 관리합니다.
        //  - 초기값을 string.Empty로 두어 NRE 방지 및 UI 초기 상태 일관성 확보
        private string _firstNumber = string.Empty;
        private string _secondNumber = string.Empty;
        private string _resultNumber = string.Empty;

        /// <summary>
        /// 첫 번째 입력 값(TextBox와 TwoWay 바인딩)
        /// - SetProperty: 값 변경 시에만 내부 필드 갱신 + PropertyChanged 발생
        /// - 값이 실제로 바뀐 경우에만 onChanged 콜백 실행
        /// - onChanged 안에서 CommandManager.InvalidateRequerySuggested() 호출:
        ///   → 모든 커맨드의 CanExecute 재평가를 트리거하여 버튼 활성 상태를 즉시 갱신
        /// </summary>
        public string FirstNumber
        {
            get => _firstNumber;
            set => SetProperty(ref _firstNumber, value, () =>
            {
                // 사용자가 입력을 바꿀 때마다 "지금 이 명령을 실행해도 되는가?"
                // (CanExecute) 재평가가 필요하므로 WPF에 요청합니다.
                // 주의: 너무 잦은 호출은 성능에 영향 가능 → 여기선 TextBox 입력이라 허용 범위.
                CommandManager.InvalidateRequerySuggested();
            });
        }

        /// <summary>
        /// 두 번째 입력 값(TextBox와 TwoWay 바인딩)
        /// - 동작은 FirstNumber와 동일하며, 입력 변경 시 명령 재평가를 요청
        /// </summary>
        public string SecondNumber
        {
            get => _secondNumber;
            set => SetProperty(ref _secondNumber, value, () =>
            {
                CommandManager.InvalidateRequerySuggested();
            });
        }

        /// <summary>
        /// 결과 표시용 문자열
        /// - 읽기 전용으로 운용하는 것이 UX에 유리(사용자가 임의 수정하지 못하도록)
        /// - XAML에서 IsReadOnly="True" 설정 권장
        ///   예) <TextBox Text="{Binding ResultNumber}" IsReadOnly="True" ... />
        /// </summary>
        public string ResultNumber
        {
            get => _resultNumber;
            private set => SetProperty(ref _resultNumber, value);
        }

        // ------------------------------------------------------------
        // 3) 커맨드(ICommand) – 버튼과 바인딩되는 실행 단위
        // ------------------------------------------------------------
        // 각 버튼은 아래 명령과 연결됩니다.
        // - AddCommand: 더하기
        // - SubtractCommand: 빼기
        // - MultiplyCommand: 곱하기
        // - DivideCommand: 나누기
        // - ClearCommand: 입력/결과 초기화
        //
        // RelayCommand는 두 개의 델리게이트를 받습니다.
        // - execute(object?): 실제 실행할 동작
        // - canExecute(object?): 실행 가능 여부(버튼 활성/비활성). null이면 항상 가능.
        public ICommand AddCommand { get; }
        public ICommand SubtractCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }
        public ICommand ClearCommand { get; }

        /// <summary>
        /// 생성자
        /// - 모든 명령을 초기화합니다.
        /// - Add/Sub/Mul/Div는 공통 CanExecute(두 입력이 숫자로 유효해야만 실행 가능)
        /// - Clear는 언제나 실행 가능
        /// </summary>
        public CalculatorViewModel()
        {
            // 공통 CanExecute: 두 입력이 모두 숫자로 파싱 가능한가?
            bool CanExec(object? _) => CanCalculate();

            AddCommand = new RelayCommand(_ => Calculate("+"), CanExec);
            SubtractCommand = new RelayCommand(_ => Calculate("-"), CanExec);
            MultiplyCommand = new RelayCommand(_ => Calculate("*"), CanExec);
            DivideCommand = new RelayCommand(_ => Calculate("/"), CanExec);

            // Clear는 항상 실행 가능하므로 canExecute 생략(null)
            ClearCommand = new RelayCommand(_ => Clear());
        }

        // ------------------------------------------------------------
        // 4) 유효성 검사/활성화 조건
        // ------------------------------------------------------------
        /// <summary>
        /// 현재 입력(FirstNumber, SecondNumber)이 "계산 가능한 상태"인지 판정
        /// - 여기서는 Model의 유효성 검사 메서드 사용(일관된 규칙 유지)
        /// - 대안: double.TryParse(… CultureInfo …)로 직접 검사 가능
        /// </summary>
        private bool CanCalculate()
        {
            return _calculator.IsValidNumber(_firstNumber)
                && _calculator.IsValidNumber(_secondNumber);

            // (대안 예시)
            // return double.TryParse(_firstNumber, NumberStyles.Float, CultureInfo.CurrentCulture, out _)
            //     && double.TryParse(_secondNumber, NumberStyles.Float, CultureInfo.CurrentCulture, out _);
        }

        // ------------------------------------------------------------
        // 5) 비즈니스 로직 – 실제 계산
        // ------------------------------------------------------------
        /// <summary>
        /// 사칙연산 수행
        /// - 문자열 입력을 숫자로 변환 → Model.Calculate 호출 → 결과 문자열 구성
        /// - 예외를 개별적으로 분기하여 사용자 친화적 메시지 제공
        /// - 문화권(Culture)에 따라 소수점 기호가 다르므로 Parse/ToString 정책을 통일하고 싶다면
        ///   CultureInfo.InvariantCulture 사용을 고려(로깅/네트워크 전송 시 유용)
        /// </summary>
        private void Calculate(string operation)
        {
            try
            {
                // 문자열 → 숫자 변환(유효성 검사는 CanExecute에서 선행되지만,
                // 안전을 위해 Parse에서도 예외 처리를 가정)
                double num1 = _calculator.ParseNumber(_firstNumber);
                double num2 = _calculator.ParseNumber(_secondNumber);

                // Model에 실제 연산 위임(관심사 분리)
                double result = _calculator.Calculate(num1, num2, operation);

                // 화면에 보기 좋은 포맷으로 결과 구성
                ResultNumber = $"{num1} {operation} {num2} = {result}";
            }
            catch (DivideByZeroException)
            {
                // 0으로 나누기 예외 → 사용자에게 명확히 안내
                ResultNumber = "오류: 0으로 나눌 수 없습니다.";
            }
            catch (FormatException)
            {
                // 숫자 형식 문제(예: 알파벳/특수문자 입력)
                ResultNumber = "오류: 숫자 형식이 올바르지 않습니다.";
            }
            catch (Exception ex)
            {
                // 그 외 예외(예상치 못한 상황) → 메시지 노출
                // 실무에서는 로깅(파일/텔레메트리)도 함께 수행 권장
                ResultNumber = $"오류: {ex.Message}";
            }
        }

        // ------------------------------------------------------------
        // 6) 초기화
        // ------------------------------------------------------------
        /// <summary>
        /// 입력/결과 초기화
        /// - 속성 세터를 통해 OnPropertyChanged를 발생시키므로 UI도 함께 초기화됨
        /// - 마지막에 InvalidateRequerySuggested 호출로 버튼 활성 상태 재평가
        /// </summary>
        private void Clear()
        {
            FirstNumber = string.Empty;
            SecondNumber = string.Empty;
            ResultNumber = string.Empty;

            // Clear 직후에도 버튼 비활성화가 즉시 반영되도록 재평가 요청
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
