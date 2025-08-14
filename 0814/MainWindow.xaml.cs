using ScottPlot;
using ScottPlot.TickGenerators.TimeUnits;
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

// 라이브러리
// 재사용 가능한 코드의 집합
// 개발자가 필요할 때  호출해서 사용
// 제어의 주도권이 개발자한테 있음

// 프레임워크
// 애플리케이션의 기본 구조를 제공
// 개발자의 코드가 프레임워크 안에서 실행
// 제어의 주도권이 프레임워크한테 있음 (제어의 역전)


// NuGet
// .Net 생태계의 패키지 관리자
// 전 세계 개발자들이 만든 라이브러리를 쉽게 설치
// 버전 관리 자동화
// 의존성 관리 자동화

//scottplot.WPF

// 디지털 그래프 용지

namespace _0814
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 

            // 기본 설정
            SetupPlot();
        }

        //private void CreateFristGraph()
        //{
        //    // 간단한 데이터 준비
        //    double[] xData = { 1, 2, 3, 4, 5 };
        //    double[] yData = { 2, 4, 6, 8, 10 };

        //    // 그래프에 데이터 추가
        //    myPlot.Plot.Add.Scatter(xData, yData);

        //    // 그래프 새로고침
        //    myPlot.Refresh();
        //}

        private void SetupPlot()
        {
            myPlot.Plot.Axes.Title.Label.FontName = "맑은 고딕";
            myPlot.Plot.Axes.Bottom.Label.FontName = "맑은 고딕";
            myPlot.Plot.Axes.Left.Label.FontName = "맑은 고딕";
            myPlot.Plot.Axes.Bottom.TickLabelStyle.FontName = "맑은 고딕";
            myPlot.Plot.Legend.FontName = "맑은 고딕";

        }

        private void btnLine_Click(object sender, RoutedEventArgs e)
        {
            // 기존 그래프 지우기
            myPlot.Plot.Clear();

            // 간단한 데이터 준비
            double[] days = { 1, 2, 3, 4, 5, 6, 7 };
            double[] time = { 30, 45, 0, 60, 30, 90, 120 };

            var line = myPlot.Plot.Add.Scatter(days, time);
            line.LineWidth = 3; // 선 두께
            line.MarkerSize = 0; // 점 숨기기


            myPlot.Plot.Title("일주인간 운동 그래프");
            myPlot.Plot.XLabel("요일");
            myPlot.Plot.YLabel("시간(분)");


            double[] ticks = days;
            string[] lables = { "월", "화", "수", "목", "금", "토", "일" };

            // x축 눈금에 요일 이름 붙이기
            myPlot.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual
                (ticks, lables);


            // 그래프 새로고침
            myPlot.Refresh();
        }

        private void btnScatter_Click(object sender, RoutedEventArgs e)
        {
            // 기존 그래프 지우기
            myPlot.Plot.Clear();

            // 간단한 데이터 준비
            double[] xData = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            double[] yData = { 2, 4, 6, 8, 10, 22, 33, 25, 53, 63 };

            var line = myPlot.Plot.Add.Scatter(xData, yData);
            line.LineWidth = 0; // 선 두께
            line.MarkerSize = 10; // 점 숨기기

            myPlot.Plot.Title("점 그래프");
            myPlot.Plot.XLabel("x축");
            myPlot.Plot.YLabel("y축");

            // 그래프 새로고침
            myPlot.Refresh();
        }

        private void btnBar_Click(object sender, RoutedEventArgs e)
        {
            // 기존 그래프 지우기
            myPlot.Plot.Clear();

            // 간단한 데이터 준비
            double[] xData = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            double[] yData = { 2, 4, 6, 8, 10, 22, 33, 25, 53, 63 };

            var bars = myPlot.Plot.Add.Bars(xData, yData);
            //bars.

            myPlot.Plot.Title("막대 그래프");
            myPlot.Plot.XLabel("x축");
            myPlot.Plot.YLabel("y축");


            // 그래프 새로고침
            myPlot.Refresh();
        }

        private void btnMultiLine_Click(object sender, RoutedEventArgs e)
        {
            // 기존 그래프 지우기
            myPlot.Plot.Clear();

            // 간단한 데이터 준비
            double[] xData = { 1, 2, 3};
            double[] yData1 = { 100, 80, 120 };
            double[] yData2 = { 120, 90, 110 };
            double[] yData3 = { 140, 95, 130 };


            var line1 = myPlot.Plot.Add.Scatter(xData, yData1);
            line1.LineWidth = 3;
            line1.MarkerSize = 0;
            line1.LegendText = "강남점";

            var line2 = myPlot.Plot.Add.Scatter(xData, yData2);
            line2.LineWidth = 3;
            line2.MarkerSize = 0;
            line2.LegendText = "홍대점";

            var line3 = myPlot.Plot.Add.Scatter(xData, yData3);
            line3.LineWidth = 3;
            line3.MarkerSize = 0;
            line3.LegendText = "잠실점";

            myPlot.Plot.ShowLegend();

            myPlot.Plot.Title("지점별 매출 그래프");
            myPlot.Plot.XLabel("지점");
            myPlot.Plot.YLabel("매출");

            double[] ticks = xData;
            string[] lables = { "강남점", "홍대점", "잠실점"};

            // x축 눈금에 요일 이름 붙이기
            myPlot.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual
                (ticks, lables);


            // 그래프 새로고침
            myPlot.Refresh();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            // 기존 그래프 지우기
            myPlot.Plot.Clear();

            // 그래프 새로고침
            myPlot.Refresh();
        }
    }
}