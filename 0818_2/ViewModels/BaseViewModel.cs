using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _0818_2.ViewModels
{
    /// <summary>
    /// MVVM 기반 앱에서 공통으로 사용하는 ViewModel 베이스 클래스.
    ///
    /// 핵심 기능
    /// 1) INotifyPropertyChanged 구현:
    ///    - ViewModel 속성 값이 바뀌면 PropertyChanged 이벤트를 발생시켜
    ///      WPF 바인딩 엔진이 UI를 자동 갱신하도록 함.
    ///
    /// 2) SetProperty 헬퍼:
    ///    - (1) 값 변경 감지 → (2) 내부 필드 갱신 → (3) PropertyChanged 발생 을
    ///      한 줄로 처리. over-notify(불필요한 갱신) 방지와 가독성 향상.
    ///
    /// 3) onChanged 콜백:
    ///    - 값이 실제 변경된 경우에만 후속 작업(예: 커맨드 재평가, 캐시 무효화)을 실행.
    ///
    /// 4) 확장 유틸(선택):
    ///    - Notify(params string[]): 여러 의존 속성 한 번에 알림
    ///    - SetProperty<T>(..., IEqualityComparer<T>): 사용자 정의 비교로 변경 여부 판단
    ///    - RaisePropertyChangedIf 등 조건부 알림
    ///
    /// 설계 메모
    /// - thread-safety: WPF 바인딩은 기본적으로 UI 스레드 기준. 이 클래스는
    ///   스레드 전환을 수행하지 않으므로, 백그라운드 작업에서 설정 시 Dispatcher 사용 권장.
    /// - 성능: EqualityComparer<T>.Default 비교로 동일 값 재할당을 방지 → 불필요 렌더/계산 최소화.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// 속성 변경 알림 이벤트.
        /// WPF 바인딩 엔진이 이 이벤트를 구독하여 해당 속성 바인딩을 다시 조회합니다.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// 지정한 속성 이름으로 PropertyChanged 이벤트를 발생시킵니다.
        /// 일반적으로 [CallerMemberName] 덕분에 호출부에서 인자를 생략합니다.
        /// </summary>
        /// <param name="propertyName">변경된 속성 이름(자동 주입)</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            // (성능 메모) Multi-binding, DataTrigger가 많은 화면에서 너무 잦은 알림은
            // 불필요한 Measure/Arrange를 유발할 수 있습니다. 반드시 변경 시에만 호출하세요.
            if (propertyName is not null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 필드 값을 설정하고, 실제로 값이 바뀐 경우에만 PropertyChanged를 발생시킵니다.
        /// EqualityComparer&lt;T&gt;.Default로 값/참조 타입 모두 안전 비교합니다.
        /// </summary>
        /// <typeparam name="T">속성 타입</typeparam>
        /// <param name="field">백킹 필드(ref)</param>
        /// <param name="value">새 값</param>
        /// <param name="propertyName">속성 이름(자동 주입)</param>
        /// <returns>값이 변경되었으면 true, 아니면 false</returns>
        protected virtual bool SetProperty<T>(
            ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false; // 동일값 재할당 방지 → 불필요한 UI 갱신/연산 차단

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// 필드 값을 설정하고, 값이 변경된 경우에만 지정한 추가 작업(onChanged)을 실행합니다.
        /// (예: CommandManager.InvalidateRequerySuggested 호출, 관련 캐시 무효화 등)
        /// </summary>
        /// <typeparam name="T">속성 타입</typeparam>
        /// <param name="field">백킹 필드(ref)</param>
        /// <param name="value">새 값</param>
        /// <param name="onChanged">값 변경 시 추가로 실행할 동작(옵셔널)</param>
        /// <param name="propertyName">속성 이름(자동 주입)</param>
        /// <returns>값이 변경되었으면 true, 아니면 false</returns>
        protected virtual bool SetProperty<T>(
            ref T field, T value, Action? onChanged, [CallerMemberName] string? propertyName = null)
        {
            if (!SetProperty(ref field, value, propertyName))
                return false;

            // 값이 정말 바뀌었을 때만 실행 → 콜백 남용에 의한 성능 문제 예방
            onChanged?.Invoke();
            return true;
        }

        // ───────────────────────────── 확장 유틸(선택) ─────────────────────────────

        /// <summary>
        /// 커스텀 동등성 비교자를 사용하여 변경 여부를 판단하고 알림을 발생시킵니다.
        /// 예) 대소문자 무시 문자열 비교, 컬렉션의 순서 무시 비교 등.
        /// </summary>
        protected bool SetProperty<T>(
            ref T field, T value, IEqualityComparer<T> comparer,
            Action? onChanged = null, [CallerMemberName] string? propertyName = null)
        {
            if (comparer.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            onChanged?.Invoke();
            return true;
        }

        /// <summary>
        /// 하나의 변경으로 여러 "의존 속성"을 함께 알릴 때 사용합니다.
        /// 예) FirstName/LastName 변경 시 FullName도 변경되므로 함께 알림.
        /// </summary>
        /// <param name="propertyNames">함께 갱신을 알릴 속성 이름들</param>
        protected void Notify(params string[] propertyNames)
        {
            foreach (var name in propertyNames)
            {
                if (!string.IsNullOrEmpty(name))
                    OnPropertyChanged(name);
            }
        }

        /// <summary>
        /// 조건부 알림을 보냅니다. (복잡한 조건에서의 가독성 향상용)
        /// </summary>
        protected void RaisePropertyChangedIf(bool condition, [CallerMemberName] string? propertyName = null)
        {
            if (condition)
                OnPropertyChanged(propertyName);
        }
    }
}
