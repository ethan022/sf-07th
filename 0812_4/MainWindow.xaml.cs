using System.ComponentModel;
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

// ─────────────────────────────────────────────────────────────────────────────
// 이 파일의 목적
// - 버튼 클릭 시 Image 컨트롤의 그림과 버튼 배경 이미지를 서로 번갈아 바꾼다.
// - WPF의 Pack URI를 사용해 프로젝트 리소스(어셈블리 내부 파일)를 로드한다.
// ─────────────────────────────────────────────────────────────────────────────
//
// [Pack URI란?]
// - WPF에서 어셈블리 내부 리소스에 접근하기 위한 특별한 URI 스킴.
// - 'Build Action: Resource' 로 포함된 파일을 참조할 때 사용.
//
// [Pack URI 형식 요약]
//  1) 절대 형식(가장 안전, 코드에서 권장):
//     pack://application:,,,/어셈블리명;component/폴더/파일
//     (같은 어셈블리이면 어셈블리명;component 생략 가능 → pack://application:,,,/폴더/파일)
//
//  2) XAML에서의 단축 표기(같은 어셈블리):
//     /폴더/파일
//
// ※ 이 예제는 같은 어셈블리 내 Resources 폴더의 이미지로 가정.
//    → 프로젝트에서 img1.jpg, img3.jpg의 속성은 반드시
//      [Build Action = Resource], [Copy to Output Directory = Do not copy]
//    로 설정하세요. (리소스는 어셈블리 안에 포함되므로 복사 불필요)
//
// ─────────────────────────────────────────────────────────────────────────────

namespace _0812_4
{
    /// <summary>
    /// MainWindow: 버튼 클릭 시 이미지/배경 이미지를 토글하는 샘플
    /// </summary>
    public partial class MainWindow : Window
    {
        // 현재 토글 상태를 기억하는 플래그(true면 img1이 버튼 배경, img3이 Image.Source)
        bool btn_image1 = true;

        // 리소스 이미지를 가리키는 Pack URI (절대 URI 사용)
        Uri urlImg1;
        Uri urlImg2;

        public MainWindow()
        {
            InitializeComponent();

            // 같은 어셈블리 내 Resources/img1.jpg, img3.jpg를 가리키는 Pack 절대 URI
            // UriKind.Absolute: "pack://..." 같은 절대 스킴을 명확히 선언
            this.urlImg1 = new Uri(@"pack://application:,,,/Resources/img1.jpg", UriKind.Absolute);
            this.urlImg2 = new Uri(@"pack://application:,,,/Resources/img3.jpg", UriKind.Absolute);

            // 참고:
            // - btnImage  : x:Name="btnImage" 로 선언된 Button 컨트롤(또는 ButtonBase 파생)
            // - imgBox    : x:Name="imgBox"   로 선언된 Image 컨트롤
            // - XAML에서 Click="btnImage_Click" 로 이 핸들러가 연결되어 있어야 한다.
        }

        // 버튼 클릭 시 호출되는 이벤트 핸들러
        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            // (참고) 상대 URI 예시: "/_0812_4;component/Resources/img3.jpg"
            // var uriSource = new Uri(@"/_0812_4;component/Resources/img3.jpg", UriKind.Relative);
            // imgBox.Source = new BitmapImage(uriSource);

            // 토글 플래그에 따라 버튼 배경과 Image.Source를 교차 변경
            if (this.btn_image1)
            {
                // 버튼 배경을 img1로, 이미지 박스는 img3로
                btnImage.Background = new ImageBrush(new BitmapImage(this.urlImg1));
                imgBox.Source = new BitmapImage(this.urlImg2);
                this.btn_image1 = false;
            }
            else
            {
                // 버튼 배경을 img3로, 이미지 박스는 img1로
                btnImage.Background = new ImageBrush(new BitmapImage(this.urlImg2));
                imgBox.Source = new BitmapImage(this.urlImg1);
                this.btn_image1 = true;
            }

            // 팁:
            // - BitmapImage를 매 클릭마다 새로 만드는 대신, 생성해 둔 ImageSource를 재사용하면 성능/메모리에 유리.
            // - 파일/스트림에서 로드한다면 BeginInit/EndInit + CacheOption=OnLoad 로 잠김 방지 가능.
            // - 리소스(팩 URI) 방식은 보통 잠김 이슈가 거의 없다.
        }
    }
}
