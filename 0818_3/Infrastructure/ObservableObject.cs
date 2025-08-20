using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _0818_3.Infrastructure
{
    /// <summary>
    /// ObservableObject
    /// - MVVM 패턴에서 자주 사용하는 Base 클래스
    /// - INotifyPropertyChanged 구현 → 속성 값이 바뀌면 UI(View)에 자동 알림
    /// - View와 ViewModel 간 데이터 바인딩을 가능하게 해줌
    /// </summary>
    internal class ObservableObject : INotifyPropertyChanged
    {
        // -----------------------------------------------------------
        // 1. INotifyPropertyChanged 이벤트
        // -----------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;

        // -----------------------------------------------------------
        // 2. OnPropertyChanged
        // -----------------------------------------------------------
        // - 속성이 변경되었음을 알리는 메서드
        // - CallerMemberName 속성 덕분에 호출한 프로퍼티 이름을 자동으로 전달
        protected void OnPropertyChaged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        // -----------------------------------------------------------
        // 3. SetProperty<T>
        // -----------------------------------------------------------
        // - 속성 값을 안전하게 설정하고, 값이 변경되었을 때만 UI에 알림 발생
        // - 사용 예시: 
        //   private string _title;
        //   public string Title {
        //       get => _title;
        //       set => SetProperty(ref _title, value);
        //   }
        //
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            // 값이 같으면 변경할 필요 없음 → false 반환
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            // 값이 바뀌었으면 저장 후 알림 발생
            storage = value;
            OnPropertyChaged(propertyName);
            return true;
        }
    }
}
