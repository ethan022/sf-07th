using _0818_3.Command;
using _0818_3.Infrastructure;
using _0818_3.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace _0818_3.ViewModels
{
    /// <summary>
    /// MainWindow에 바인딩될 ViewModel
    /// - MVVM 패턴에서 View와 Model 사이를 연결
    /// - TodoItem을 관리하는 로직 담당
    /// </summary>
    internal class MainWindowViewModel : ObservableObject
    {
        // -----------------------------------------------------------
        // 1. 속성 (Property)
        // -----------------------------------------------------------

        // 새로운 Todo의 제목을 입력받는 속성
        private string _newTitle = "";
        public string NewTitle
        {
            get { return _newTitle; }
            set
            {
                // ObservableObject.SetProperty() → 값 변경 + INotifyPropertyChanged 이벤트 발생
                if (SetProperty(ref _newTitle, value))
                {
                    // NewTitle 값이 바뀔 때마다 AddCommand 실행 가능 여부 갱신
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }

        // TodoItem 목록 (컬렉션)
        // ObservableCollection → 추가/삭제 시 UI에 자동 반영
        public ObservableCollection<TodoItem> Todos { get; } = new();

        // -----------------------------------------------------------
        // 2. 커맨드 (Command)
        // -----------------------------------------------------------
        // 버튼 등 UI 이벤트를 ViewModel 메서드와 연결하기 위해 RelayCommand 사용
        public RelayCommand AddCommand { get; }
        public RelayCommand RemoveCommand { get; }
        public RelayCommand ClearCommand { get; }

        // -----------------------------------------------------------
        // 3. 생성자 (Command 초기화)
        // -----------------------------------------------------------
        public MainWindowViewModel()
        {
            // AddCommand: NewTitle이 비어있지 않을 때만 실행 가능
            AddCommand = new RelayCommand(_ => Add(), _ => !string.IsNullOrEmpty(NewTitle));

            // RemoveCommand: 특정 TodoItem을 삭제
            RemoveCommand = new RelayCommand(item => Remove(item as TodoItem));

            // ClearCommand: 전체 목록 초기화
            ClearCommand = new RelayCommand(_ => Clear());
        }

        // -----------------------------------------------------------
        // 4. 메서드 (비즈니스 로직)
        // -----------------------------------------------------------

        // Todo 추가
        private void Add()
        {
            Todos.Insert(0, new TodoItem { Title = NewTitle, IsCompleted = false });
            NewTitle = ""; // 입력칸 초기화
        }

        // Todo 삭제
        private void Remove(TodoItem? item)
        {
            if (item == null) return;
            Todos.Remove(item);
        }

        // 전체 삭제
        private void Clear()
        {
            Todos.Clear();
        }
    }
}
