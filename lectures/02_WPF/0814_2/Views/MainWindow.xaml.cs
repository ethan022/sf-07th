using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


// MVVM 패턴

// 요리사 ( Model )
// 주문서 ( ViewModel )
// 웨이터 ( View )

// 1. 고객(사용자)이 웨이터 (View) 에게 주문
// 2. 웨이터(View) 가 주문서 (ViewModel) 에 기록
// 3. 주문서 (ViewModel) 보고 요리사 ( Model ) 음식 준비
// 4. 음식이 준비되면 반대 경로로 고객에게 전달

// Model : 데이터와 비즈니스 로직
// View : 사용자 인터페이스( XAML )
// ViewModel : View 와 Model 사이의 중간 연결자


using _0814_2.ViewModels;

namespace _0814_2.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this StudentViewModel();
        }
    }
}

// 코드가 뒤섞임 : UI로직 + 데이터 로직 + 비즈니스 로직
// 테스트 어려움 
// 재사용이 어려움
// 유지보수 어려움
// 팀 협업 어려움

// MVVM 

//📱 MainWindow.xaml(View)
//├── 사용자가 보는 화면만 담당
//└── 버튼, 텍스트박스, 그리드 등

//📋 StudentViewModel.cs (ViewModel)  
//├── View와 Model 사이 중간 역할
//├── 사용자 입력 처리
//└── 화면에 보여줄 데이터 준비

//👨‍💼 Student.cs (Model)
//├── 순수한 데이터와 비즈니스 로직
//└── UI와 완전히 독립적

// 명확한 역할 분담
// 쉬운 테스트
// 높은 재사용성
// 쉬운 유지보수
// 팀 협업 용이