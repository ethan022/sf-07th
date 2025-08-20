using OpenCvSharp;
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
using Point = OpenCvSharp.Point;  // System.Windows.Point와 충돌 방지

namespace _0819
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // -----------------------------------------------------------
            // 1. OpenCV 버전 출력
            // -----------------------------------------------------------
            textBox.Text = Cv2.GetVersionString();

            // -----------------------------------------------------------
            // 2. 이미지 읽기
            // -----------------------------------------------------------
            Mat image = Cv2.ImRead("img3.jpg");  // 로컬 이미지 불러오기

            // -----------------------------------------------------------
            // 3. 이미지에 텍스트 추가
            // -----------------------------------------------------------
            Cv2.PutText(image,
                "Hello OpenCV",                     // 문자열
                new Point(50, 150),                 // 좌표 (x=50, y=150)
                HersheyFonts.HersheySimplex,        // 폰트
                1.0,                                // 크기
                new Scalar(0, 0, 255),              // 색상 (빨강, BGR 순서)
                2);                                 // 두께

            // -----------------------------------------------------------
            // 4. OpenCV 창에 표시
            // -----------------------------------------------------------
            Cv2.ImShow("Image Test", image);

            // -----------------------------------------------------------
            // 5. WPF Image 컨트롤에 표시
            // -----------------------------------------------------------
            // OpenCvSharp의 WPF 확장 기능 이용
            // Mat → BitmapSource 변환 후 WPF ImageBox.Source에 할당
            ImageBox.Source = OpenCvSharp.WpfExtensions
                .BitmapSourceConverter.ToBitmapSource(image);

            // -----------------------------------------------------------
            // 6. 키 입력 대기 및 창 닫기
            // -----------------------------------------------------------
            Cv2.WaitKey(0);             // 키 입력 대기
            Cv2.DestroyAllWindows();    // OpenCV 창 닫기
        }
    }
}
