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

namespace _0812
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

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // lblSiderValue가 아직 생성되지 않았을 수도 있으므로
            if (lblSiderValue != null)
            {
                lblSiderValue.Text = $"값: {slider.Value:F0}";
                // 진행률 바도 함께 업데이트
                progressBar.Value = slider.Value;
            }
        }

        private void btnNormal_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("일반 버튼 클릭!");
        }

        private void btnToggle_Checked(object sender, RoutedEventArgs e)
        {
            btnToggle.Content = "토글 ON";
            btnDisabled.IsEnabled = false;
        }

        private void btnToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            btnToggle.Content = "토글 OFF";
            btnDisabled.IsEnabled = true;
        }
    }
}