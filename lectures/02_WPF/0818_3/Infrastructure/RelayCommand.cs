using System;
using System.Windows.Input;

namespace _0818_3.Command
{
    /// <summary>
    /// RelayCommand
    /// - ICommand 인터페이스 구현체
    /// - MVVM 패턴에서 View의 버튼, 메뉴 등의 동작을 ViewModel 메서드와 연결
    /// - 실행 로직(_execute)과 실행 가능 여부(_canExecute)를 델리게이트로 받아서 처리
    /// </summary>
    internal class RelayCommand : ICommand
    {
        // -----------------------------------------------------------
        // 1. 필드
        // -----------------------------------------------------------
        private readonly Action<object?> _execute;          // 실행할 동작
        private readonly Func<object?, bool>? _canExecute;  // 실행 가능 여부 판단 함수

        // -----------------------------------------------------------
        // 2. 생성자
        // -----------------------------------------------------------
        // - execute: 반드시 실행할 동작 (null 불가)
        // - canExecute: 선택적 (null일 경우 항상 실행 가능)
        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // -----------------------------------------------------------
        // 3. ICommand 인터페이스 구현
        // -----------------------------------------------------------

        // 실행 가능 여부 판단
        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

        // 실제 실행 동작
        public void Execute(object? parameter) => _execute(parameter);

        // 실행 가능 여부가 변경되었을 때 알림 (WPF CommandManager가 자동 호출)
        public event EventHandler? CanExecuteChanged;

        // -----------------------------------------------------------
        // 4. 수동으로 실행 가능 여부 갱신 알림 보내기
        // -----------------------------------------------------------
        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
