using System;
using System.Windows.Input;

namespace _0818_2.Commands
{
    /// <summary>
    /// 가장 널리 쓰이는 간단한 ICommand 구현체.
    /// 
    /// 목적:
    /// - 버튼/메뉴 등의 UI 상호작용(요청)을 "객체(명령)"로 캡슐화하여
    ///   View(이벤트 핸들러)와 비즈니스 로직(메서드 호출)을 분리합니다.
    /// - MVVM에서 View → ViewModel로 동작을 위임하는 표준 수단입니다.
    /// 
    /// 구성:
    /// - <see cref="Action{Object}"/> execute : 실제 실행 로직(필수)
    /// - <see cref="Func{Object, Boolean}"/> canExecute : 실행 가능 여부(선택)
    ///   → null이면 항상 실행 가능으로 간주
    /// 
    /// WPF와의 상호작용:
    /// - <see cref="CommandManager.RequerySuggested"/> 이벤트와 연동하여
    ///   UI가 "버튼/메뉴 활성화 상태"를 자동으로 다시 평가(CanExecute)하도록 합니다.
    /// - ViewModel에서 <see cref="CommandManager.InvalidateRequerySuggested"/>를 호출하면
    ///   즉시 재평가가 트리거되어 버튼 상태가 반영됩니다.
    /// 
    /// 참고:
    /// - 아주 빈번한 입력(예: TextBox 타이핑)마다 InvalidateRequerySuggested를 호출하면
    ///   성능에 영향이 있을 수 있습니다. 필요한 지점에서만 호출하세요.
    /// </summary>
    class RelayCommand : ICommand
    {
        /// <summary>
        /// 실제로 실행할 메서드를 보관합니다.
        /// <para>형태: <c>void Execute(object? parameter)</c></para>
        /// </summary>
        private readonly Action<object?> _execute;

        /// <summary>
        /// 실행 가능 여부를 판단하는 메서드를 보관합니다(선택).
        /// <para>형태: <c>bool CanExecute(object? parameter)</c></para>
        /// </summary>
        private readonly Func<object?, bool>? _canExecute;

        /// <summary>
        /// 항상 실행 가능한 명령을 생성합니다.
        /// </summary>
        /// <param name="execute">실제 실행 로직(필수)</param>
        /// <exception cref="ArgumentNullException"><paramref name="execute"/>가 null인 경우</exception>
        public RelayCommand(Action<object?> execute) : this(execute, null)
        {
        }

        /// <summary>
        /// 조건부 실행 가능한 명령을 생성합니다.
        /// </summary>
        /// <param name="execute">실제 실행 로직(필수)</param>
        /// <param name="canExecute">실행 가능 여부 판단 로직(선택, null이면 항상 가능)</param>
        /// <exception cref="ArgumentNullException"><paramref name="execute"/>가 null인 경우</exception>
        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute)
        {
            // execute는 반드시 필요. 없으면 명령 자체가 의미가 없음.
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute; // null이면 항상 실행 가능으로 처리
        }

        /// <summary>
        /// 현재 상태에서 명령을 실행할 수 있는지 질의합니다.
        /// </summary>
        /// <param name="parameter">명령에 전달될 매개변수(없으면 null)</param>
        /// <returns>실행 가능하면 true, 불가능하면 false</returns>
        public bool CanExecute(object? parameter)
        {
            // _canExecute가 없으면 항상 true
            // 있으면 그 결과에 따름
            return _canExecute?.Invoke(parameter) ?? true;
        }

        /// <summary>
        /// 명령을 실행합니다.
        /// </summary>
        /// <param name="parameter">명령에 전달될 매개변수(없으면 null)</param>
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        /// <summary>
        /// 실행 가능 상태가 바뀌었음을 WPF에 알리는 이벤트.
        /// 
        /// 구현 포인트:
        /// - 여기서는 WPF의 <see cref="CommandManager.RequerySuggested"/>에
        ///   핸들러를 연결/해제하는 전형적인 패턴을 사용합니다.
        /// - ViewModel 코드에서 <see cref="CommandManager.InvalidateRequerySuggested"/>를
        ///   호출하면 WPF가 이 이벤트를 통해 CanExecute를 다시 물어보고,
        ///   그 결과에 따라 버튼/메뉴의 활성화 상태를 즉시 갱신합니다.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}

/* ────────────────────────────── 사용 가이드 / 예시 ──────────────────────────────

[ViewModel에서 사용 예]

public ICommand AddCommand { get; }
public ICommand RemoveCommand { get; }

public MyViewModel()
{
    // (1) 항상 실행 가능한 명령
    AddCommand = new RelayCommand(_ => AddItem());

    // (2) 조건부 실행 가능한 명령 (목록에 선택된 항목이 있을 때만 삭제 가능)
    RemoveCommand = new RelayCommand(
        execute: _ => RemoveSelected(),
        canExecute: _ => SelectedItem != null
    );
}

// 속성이 바뀌어 CanExecute 조건이 달릴 수 있는 지점에서 호출
// → 버튼 활성/비활성 즉시 반영
SelectedItem = item;
CommandManager.InvalidateRequerySuggested();


[WPF XAML 바인딩 예]

<Button Content="추가"  Command="{Binding AddCommand}" />
<Button Content="삭제"  Command="{Binding RemoveCommand}" />


[참고 사항]

1) RaiseCanExecuteChanged 직접 구현 패턴
   - WPF(Desktop)에서는 CommandManager 사용이 일반적이지만,
     .NET MAUI/WinUI/WPF 혼용 등 멀티 플랫폼을 고려한다면
     직접 event를 노출하고 수동으로 RaiseCanExecuteChanged()를 호출하는
     RelayCommand 변형을 별도로 두기도 합니다.

2) 성능 주의
   - TextBox 타이핑마다 InvalidateRequerySuggested()를 호출하면
     호출 빈도가 매우 높아질 수 있습니다.
     필요한 지점(검증 완료/포커스 아웃 등)에만 호출하는 것도 고려하세요.

3) 파라미터 사용
   - XAML에서 CommandParameter로 값을 넘길 수 있습니다.
     예) <Button Command="{Binding RemoveCommand}" CommandParameter="{Binding SelectedItem}" />

────────────────────────────────────────────────────────────────────────────── */
