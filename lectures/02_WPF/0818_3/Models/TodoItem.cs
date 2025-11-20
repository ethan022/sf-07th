using _0818_3.Infrastructure;

namespace _0818_3.Models
{
    /// <summary>
    /// TodoItem (할 일 항목)
    /// - MVVM 패턴의 Model 역할
    /// - Title(제목), IsCompleted(완료 여부) 속성을 가짐
    /// - ObservableObject 상속 → 속성 값이 바뀌면 INotifyPropertyChanged 이벤트 발생
    ///   → 바인딩된 View(XAML UI)가 자동으로 업데이트됨
    /// </summary>
    internal class TodoItem : ObservableObject
    {
        // -----------------------------------------------------------
        // 1. Title (할 일 제목)
        // -----------------------------------------------------------
        private string _title = "";
        public string Title
        {
            get { return _title; }
            set => SetProperty(ref _title, value);
            // SetProperty: 값이 바뀌면 자동으로 PropertyChanged 이벤트 발생
        }

        // -----------------------------------------------------------
        // 2. IsCompleted (완료 여부)
        // -----------------------------------------------------------
        private bool _isCompleted;
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set => SetProperty(ref _isCompleted, value);
            // true/false 값 변경 시 UI의 체크박스 등과 자동 동기화 가능
        }
    }
}
