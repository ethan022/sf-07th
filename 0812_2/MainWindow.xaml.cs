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

namespace _0812_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            R.Value = 0;
            G.Value = 0;
            B.Value = 0;

            Update();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Update();
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (grayTone == null || invert == null) { return; }

            Update();
        }

        private void Update()
        {
            byte r = (byte)R.Value;
            byte g = (byte)G.Value;
            byte b = (byte)B.Value;

            if (grayTone.IsChecked == true)
            {
                byte gray = (byte)((r + g + b) / 3);
                r = g = b = gray;

                R.Value = r;
                G.Value = g;
                B.Value = b;
            }
            else if (invert.IsChecked == true) {
                r = (byte)(255 - r);
                g = (byte)(255 - g);
                b = (byte)(255 - b);
            }

            // Color 구조체 반환
            Color rgb = Color.FromRgb(r, g, b);

            // SolidColorBrush 클래스를 생성
            SolidColorBrush brush = new SolidColorBrush(rgb);

            ColorPreview.Background = brush;
        }


    }
}