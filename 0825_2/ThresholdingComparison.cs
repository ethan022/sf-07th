using OpenCvSharp;
using System;

namespace _0825_2
{
    internal class ThresholdingComparison
    {
        // 🔹 다양한 임계값(Thresholding) 기법을 비교하는 메서드
        public static void CompareThrsholding()
        {
            // 테스트 이미지 생성 (노이즈 포함)
            using (Mat testImage = CreateNoisyTestImage())
            {
                // 결과 이미지를 저장할 Mat 객체
                using (Mat simpleThresh = new Mat())      // 단순 이진화
                using (Mat adaptiveMean = new Mat())      // 적응형 평균 임계값
                using (Mat adaptiveGaussian = new Mat())  // 적응형 가우시안 임계값
                using (Mat otsuThresh = new Mat())        // 오츠(Otsu) 이진화
                {
                    // 1️⃣ 단순 이진화 (Simple Thresholding)
                    // - 픽셀 값이 128 이상이면 255(흰색), 아니면 0(검정)
                    Cv2.Threshold(testImage, simpleThresh, 128, 255, ThresholdTypes.Binary);

                    // 2️⃣ 적응형 이진화 - 평균 (Adaptive Mean Thresholding)
                    // - 국소 영역(작은 블록)마다 평균값을 기준으로 임계값 결정
                    // - 조명 변화가 심한 이미지에 유리
                    Cv2.AdaptiveThreshold(testImage, adaptiveMean, 255,
                        AdaptiveThresholdTypes.MeanC, ThresholdTypes.Binary, 11, 2);

                    // 3️⃣ 적응형 이진화 - 가우시안 (Adaptive Gaussian Thresholding)
                    // - 국소 영역에서 가우시안 가중치로 평균 계산 후 임계값 결정
                    // - Adaptive Mean보다 더 부드러운 경계 생성
                    Cv2.AdaptiveThreshold(testImage, adaptiveGaussian, 255,
                        AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 11, 2);

                    // 4️⃣ 오츠 이진화 (Otsu's Thresholding)
                    // - 히스토그램을 분석해서 자동으로 최적의 임계값 결정
                    // - bimodal(이중 봉우리) 분포를 가진 이미지에 효과적
                    Cv2.Threshold(testImage, otsuThresh, 0, 255,
                        ThresholdTypes.Binary | ThresholdTypes.Otsu);

                    // 결과 출력
                    Cv2.ImShow("Original (Noisy)", testImage);
                    Cv2.ImShow("Simple Threshold", simpleThresh);
                    Cv2.ImShow("Adaptive Mean Threshold", adaptiveMean);
                    Cv2.ImShow("Adaptive Gaussian Threshold", adaptiveGaussian);
                    Cv2.ImShow("Otsu Threshold", otsuThresh);

                    Cv2.WaitKey(0);
                    Cv2.DestroyAllWindows();
                }
            }
        }

        // 🔹 노이즈가 포함된 테스트 이미지를 생성하는 메서드
        private static Mat CreateNoisyTestImage()
        {
            // 흰색 배경의 400x600 크기 이미지 생성
            Mat image = new Mat(400, 600, MatType.CV_8UC1, Scalar.White);
            // ※ Thresholding은 보통 단일 채널(그레이스케일)에서 적용됨

            // 빨간 사각형 (흑백 변환 시 어두운 값으로 반영됨)
            Cv2.Rectangle(image, new Rect(350, 150, 150, 100), new Scalar(100), -1);

            // 회색 원
            Cv2.Circle(image, new Point(150, 50), 60, new Scalar(180), -1);

            // 어두운 직선
            Cv2.Line(image, new Point(100, 150), new Point(250, 350), new Scalar(50), 2);

            // 소금-후추 노이즈 추가
            AddNoise(image);

            return image;
        }

        // 🔹 소금-후추 노이즈 추가
        // - 일부 픽셀을 흰색(255) 또는 검정(0)으로 무작위 변경
        private static void AddNoise(Mat image)
        {
            Random rand = new Random();
            var indexer = image.GetGenericIndexer<byte>(); // 단일 채널(그레이스케일)

            for (int i = 0; i < 10000; i++)
            {
                int x = rand.Next(0, image.Width);
                int y = rand.Next(0, image.Height);

                if (rand.NextDouble() < 0.5)
                    indexer[y, x] = 255; // 소금
                else
                    indexer[y, x] = 0;   // 후추
            }
        }
    }
}