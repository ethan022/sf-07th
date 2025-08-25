using System;
using OpenCvSharp;

namespace _0825_4
{
    internal class BasicContour
    {
        public static void BasiContourDemo()
        {
            // 1. 원본 이미지 불러오기
            Mat src = Cv2.ImRead("1.jpg");
            Mat gray = new Mat();
            Mat binary = new Mat();

            // 2. 전처리
            // - 컬러 이미지를 그레이스케일로 변환
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

            // - 이진화(Thresholding) 적용: 픽셀값이 127 이상 → 255, 아니면 0
            Cv2.Threshold(gray, binary, 127, 255, ThresholdTypes.Binary);

            // 3. Contour(윤곽선) 검출
            // - contours: 검출된 윤곽선 점들의 배열
            // - hierarchy: 윤곽선 계층 정보 (부모-자식 관계)
            Point[][] contours;
            HierarchyIndex[] hierarchy;

            Cv2.FindContours(binary, out contours, out hierarchy,
                RetrievalModes.Tree,              // 모든 계층 구조를 추적
                ContourApproximationModes.ApproxSimple); // 점 개수를 줄여 간단히 근사

            Console.WriteLine($"검출된 contours 개수 : {contours.Length}");

            // 4. 결과 이미지에 Contour 그리기
            Mat result = src.Clone();
            Random rand = new Random();

            for (int i = 0; i < contours.Length; i++)
            {
                // 무작위 색상 지정
                Scalar color = new Scalar(
                    rand.Next(0, 256),
                    rand.Next(0, 256),
                    rand.Next(0, 256)
                );

                // 윤곽선 그리기 (두께 2px)
                Cv2.DrawContours(result, contours, i, color, 2);
            }

            // 5. 결과 출력
            Cv2.ImShow("Original", src);   // 원본 이미지
            Cv2.ImShow("Binary", binary);  // 이진화된 이미지
            Cv2.ImShow("Contours", result);// 윤곽선 검출 결과

            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
