using OpenCvSharp;
using static System.Net.Mime.MediaTypeNames;

// -----------------------------------------------------------
// Mat 클래스
// -----------------------------------------------------------
// - Mat = Matrix(행렬)의 줄임말
// - OpenCV에서 모든 이미지는 Mat 객체로 표현됨
// - 이미지는 결국 "숫자들의 격자판(행렬)" 구조로 저장됨
//
// Mat 내부 구조
// 1) 헤더(Header): 이미지 메타정보 (가벼움)
//    - 이미지 크기 (행/열)
//    - 데이터 타입 (비트수, 채널 수)
//    - 데이터 포인터(메모리 위치)
// 2) 데이터(Data): 실제 픽셀 값들 (무거움)
// -----------------------------------------------------------

namespace _0820_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -----------------------------------------------------------
            // 1. Mat 기본 생성
            // Mat 변수명 = new Mat(높이, 너비, MatType, 초기 색상)
            // MatType: CV_<비트수><데이터형><채널수>
            //   예) CV_8UC3 → 8비트, Unsigned, 3채널 (BGR 컬러)
            // -----------------------------------------------------------
            Mat img = new Mat(480, 600, MatType.CV_8UC1, new Scalar(128));

            // -----------------------------------------------------------
            // 2. 행렬 생성 함수들
            // -----------------------------------------------------------

            // 영행렬 (모든 값 = 0 → 검정색)
            Mat zeros = Mat.Zeros(300, 300, MatType.CV_8UC1);
            Cv2.ImShow("Zero", zeros);

            // 일행렬 (모든 값 = 1 → 255 곱해주면 흰색)
            Mat ones = Mat.Ones(300, 300, MatType.CV_8UC1) * 255;
            Cv2.ImShow("Ones", ones);

            // 단위행렬 (대각선 = 1 → 흰색)
            Mat eye = Mat.Eye(300, 300, MatType.CV_8UC1) * 255;
            Cv2.ImShow("Eye", eye);

            // 난수 행렬 (0~255 범위의 랜덤 값으로 채움)
            Mat random = new Mat(300, 300, MatType.CV_8UC3);
            Cv2.Randu(random, 0, 255);
            Cv2.ImShow("Random", random);

            // Mat 정보 출력
            Console.WriteLine($"Rows(행): {random.Rows}");
            Console.WriteLine($"Cols(열): {random.Cols}");
            Console.WriteLine($"Channels(채널): {random.Channels()}");
            Console.WriteLine($"Depth(데이터 깊이): {random.Depth()}");
            Console.WriteLine($"Type(타입): {random.Type()}");
            Console.WriteLine($"ElemSize(원소 크기): {random.ElemSize()} 바이트");
            Console.WriteLine($"Total(전체 원소 개수): {random.Total()}");
            Console.WriteLine($"Size(행렬 크기): {random.Size()}");

            // -----------------------------------------------------------
            // 3. Scalar 클래스 (색상 표현)
            // -----------------------------------------------------------
            // Scalar(값1, 값2, 값3)
            // - OpenCV는 기본적으로 BGR 순서 (Blue, Green, Red)
            // 1채널 : 회색조
            new Scalar(128);   // 회색
            new Scalar(0);     // 검정
            new Scalar(255);   // 흰색

            // 3채널 : 컬러
            new Scalar(255, 0, 0);   // 파랑
            new Scalar(0, 255, 0);   // 초록
            new Scalar(0, 0, 255);   // 빨강

            // -----------------------------------------------------------
            // 4. Mat 복사 개념
            // -----------------------------------------------------------
            using (Mat myImg = new Mat(300, 400, MatType.CV_8UC3, new Scalar(255, 0, 0))) // 파란 배경
            {
                Mat copy1 = myImg;         // 얕은 복사 (헤더만 복사, 데이터 공유)
                Mat copy2 = myImg.Clone(); // 깊은 복사 (데이터까지 완전히 복제)

                // 원본 색상 변경 → copy1도 같이 바뀜 (데이터 공유)
                myImg.SetTo(new Scalar(0, 0, 255));  // 빨강으로 변경

                Cv2.ImShow("Image copy1", copy1);
                Cv2.ImShow("Image copy2", copy2);

                // Mat 기본 정보 출력
                Console.WriteLine("이미지 정보");
                Console.WriteLine($"높이 : {myImg.Height}");
                Console.WriteLine($"너비 : {myImg.Width}");
                Console.WriteLine($"채널 : {myImg.Channels()}");

                // -----------------------------------------------------------
                // 5. 도형 & 텍스트 그리기
                // -----------------------------------------------------------

                // 텍스트 추가
                Cv2.PutText(myImg,
                    "Hello OpenCV!",                // 문자열
                    new Point(100, 50),             // 위치 (x=100, y=50)
                    HersheyFonts.HersheySimplex,    // 폰트
                    1.5,                            // 글자 크기
                    new Scalar(0),                  // 색상 (검정)
                    3);                             // 두께

                // 원 그리기
                Cv2.Circle(myImg,
                        new Point(300, 200),        // 원 중심 좌표
                        50,                         // 반지름
                        new Scalar(0),              // 색상 (검정)
                        -1);                        // 두께 (-1: 내부 채움)

                // 사각형 그리기
                Cv2.Rectangle(myImg,
                    new Point(10, 50),              // 좌상단 좌표
                    new Point(100, 200),            // 우하단 좌표
                    new Scalar(0),                  // 색상
                    -1);                            // 두께 (-1: 내부 채움)

                // 화면에 표시
                Cv2.ImShow("Image Test", myImg);

                // 키 입력 대기
                Cv2.WaitKey(0);

                // 창 닫기
                Cv2.DestroyAllWindows();
            } // using 종료 → Mat 자동 메모리 해제
        }
    }
}
