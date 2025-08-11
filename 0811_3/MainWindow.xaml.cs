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

namespace _0811_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string id = txtId.Text;
            string pw = pwdPw.Password;

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(pw))
            {
                MessageBox.Show("아이디와 비밀번호를 모두 입력해주세요.","경고",
                    MessageBoxButton.OK, MessageBoxImage.Warning);

                return;
            }

            MessageBox.Show($"로그인 시도: {id} / {pw}", "로그인 정보",
              MessageBoxButton.OK, MessageBoxImage.Information);

            if (id == "admin" && pw == "1234") {

                MessageBox.Show($"로그인 성공! 환영합니다.", "로그인 성공",
                  MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                MessageBox.Show($"아이디 또는 비밀번호가 올바르지 않습니다.", "로그인 실패",
               MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}