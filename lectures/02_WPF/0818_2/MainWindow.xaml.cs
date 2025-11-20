using System.Text;
using System.Windows;
using _0818_2.ViewModels;

namespace _0818_2
{
    /// <summary>
    /// MainWindow.xaml의 상호작용 로직
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // ✅ View와 ViewModel 연결
            // - MainWindow.xaml의 DataContext를 CalculatorViewModel로 설정
            // - 이로 인해 XAML에서 {Binding ...} 구문이 CalculatorViewModel 속성/커맨드와 연결됨
            this.DataContext = new CalculatorViewModel();
        }

        /*
        ❌ Code-behind 패턴 (예전 방식)
        - UI 이벤트(Button 클릭 등)에서 직접 로직을 처리
        - 하나의 메서드가 "UI 이벤트 처리 + 계산 로직"이라는
          여러 책임을 동시에 갖게 되어 유지보수성이 떨어짐
        - UI와 비즈니스 로직이 강하게 결합되어 재사용이 어려움
        - 코드 수정 시 다른 부분에도 영향을 줄 가능성이 큼

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    double num1 = double.Parse(txtFirst.Text);
        //    double num2 = double.Parse(txtSecond.Text);  // 오타 수정

        //    string op = (sender as Button).Content.ToString();
        //    double result = 0;

        //    // 계산 로직 (UI 코드 안에 섞여 있음)
        //    switch (op) {
        //        case "+": result = num1 + num2; break;
        //        case "-": result = num1 - num2; break;
        //        case "*": result = num1 * num2; break;
        //        case "/": result = num2 != 0 ? num1 / num2 : 0; break;
        //    }

        //    txtResult.Text = result.ToString();
        //}
        */

        // ✅ MVVM 패턴 (현재 적용된 방식)
        // - 계산 로직은 CalculatorViewModel에만 존재
        // - 버튼 클릭 → Command 실행 → ViewModel이 로직 처리
        // - UI는 ViewModel과 Data Binding만 담당
        // - 관심사 분리가 잘 되어 재사용성과 유지보수성이 높아짐
    }
}
