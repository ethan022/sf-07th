using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace _0825
{
    internal class BlurringComparison
    {
        // 🔹 메인 실행 메서드: 노이즈가 있는 이미지를 만들고 화면에 보여줌
        public static void CompareBlurring()
        {
            // using 블록: Mat 객체(이미지 메모리) 자동 해제
            using (Mat original = CreateNoisyTestImage())
            {
                using (Mat gaussian = new Mat())
                using (Mat box = new Mat())
                using (Mat median = new Mat())
                using (Mat bilateral = new Mat())
                {
                    ApplyBlurringMethods(original, gaussian, box, median, bilateral);

                    // 이미지 출력
                    DisplayBlur(original, gaussian, box, median, bilateral);

                    // 키 입력 대기 (0은 무한정 대기)
                    Cv2.WaitKey(0);

                    // 모든 창 닫기
                    Cv2.DestroyAllWindows();
                }
            }
        }

        // 🔹 노이즈가 포함된 테스트 이미지를 생성하는 메서드
        private static Mat CreateNoisyTestImage()
        {
            // 400x600 크기의 흰색 배경 이미지 생성
            Mat image = Cv2.ImRead("1.jpg");


            //// 빨간색 사각형 그리기
            //Cv2.Rectangle(image, new Rect(350, 150, 150, 100), Scalar.Red, -1);

            //// 노란색 원 그리기
            //Cv2.Circle(image, new Point(150, 50), 60, Scalar.Yellow, -1);

            //// 연한 파란색 직선 그리기
            //Cv2.Line(image, new Point(100, 150), new Point(250, 350), Scalar.LightBlue, 1);

            // 소금-후추 노이즈 추가
            AddNoise(image);

            return image;
        }

        // 🔹 이미지에 소금-후추 노이즈를 추가하는 메서드
        private static void AddNoise(Mat image)
        {
            Random rand = new Random();

            // Mat의 각 픽셀 접근을 위해 GetGenericIndexer 사용
            var indexer = image.GetGenericIndexer<Vec3b>();

            // 무작위 좌표에 10000개 픽셀을 선택하여 흑/백 점 찍기
            for (int i = 0; i < 10000; i++)
            {
                // 무작위 (x, y) 좌표 선택
                int x = rand.Next(0, image.Width);
                int y = rand.Next(0, image.Height);

                // 50% 확률로 흰색(255,255,255), 나머지 50%는 검은색(0,0,0)
                if (rand.NextDouble() < 0.5)
                {
                    indexer[y, x] = new Vec3b(255, 255, 255); // 소금 노이즈
                }
                else
                {
                    indexer[y, x] = new Vec3b(0, 0, 0);       // 후추 노이즈
                }
            }
        }

        private static void ApplyBlurringMethods(Mat original, 
            Mat gaussian, Mat box, Mat median, Mat bilateral)
        {
            // 커널
            // 이미지를 처리할 때 한 픽셀만 보는게 아니라 주변 픽셀까지 포함한 작은 영역
            // 값이 클수록 -> 주변 픽셀을 더 많이 고려 -> 더 강한 블러 효과
            // 값이 작을수록 -> 세밀한 블러링
            Size kernelSize = new Size(15, 15);

            // 가우시안 블러
            Cv2.GaussianBlur(original, gaussian, kernelSize, 0);

            // 박스 필터
            Cv2.BoxFilter(original, box, MatType.CV_8UC3, kernelSize);

            // 메디안 필터
            Cv2.MedianBlur(original, median, 15);

            // 양방향 필터
            Cv2.BilateralFilter(original, bilateral, 15, 80, 80);
        }

        private static void DisplayBlur (Mat original,
            Mat gaussian, Mat box, Mat median, Mat bilateral)
        {
            Cv2.ImShow("original", original);
            Cv2.ImShow("gaussian", gaussian);
            Cv2.ImShow("box", box);
            Cv2.ImShow("median", median);
            Cv2.ImShow("bilateral", bilateral);
        }
    }
}
