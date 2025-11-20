using System;
using OpenCvSharp;

namespace _0825_3
{
    internal class EdgeDetection
    {
        public static void EdgeDetectionDemo()
        {
            // 원본 이미지 불러오기
            Mat src = Cv2.ImRead("1.jpg");

            if (src.Empty())
            {
                return; // 이미지가 없으면 종료
            }

            // 결과 저장용 Mat 객체 생성
            Mat sobelX = new Mat();     // Sobel X방향
            Mat sobelY = new Mat();     // Sobel Y방향
            Mat sobel = new Mat();      // Sobel 최종 결합
            Mat scharr = new Mat();     // Scharr 결과
            Mat laplacian = new Mat();  // Laplacian 결과
            Mat canny = new Mat();      // Canny 결과

            // ==============================================
            // 1️⃣ Sobel 연산자
            // - 이미지의 그래디언트(기울기)를 이용한 엣지 검출
            // - X, Y 방향을 각각 검출 후 결합
            // - ksize: 커널 크기 (보통 3 사용)
            // ==============================================

            // X방향 Sobel
            Cv2.Sobel(src, sobelX, MatType.CV_64F, 1, 0, ksize: 3);

            // Y방향 Sobel
            Cv2.Sobel(src, sobelY, MatType.CV_64F, 0, 1, ksize: 3);

            // X, Y 방향 결과를 결합하여 최종 엣지 영상 생성
            Cv2.Magnitude(sobelX, sobelY, sobel);
            sobel.ConvertTo(sobel, MatType.CV_8U);

            // ==============================================
            // 2️⃣ Scharr 연산자
            // - Sobel의 개선된 버전
            // - 커널 크기를 3x3으로 고정, 더 정확한 미분 연산 제공
            // - 미세한 엣지를 더 잘 검출
            // ==============================================

            Mat scharrX = new Mat();
            Mat scharrY = new Mat();

            // X방향 Scharr
            Cv2.Scharr(src, scharrX, MatType.CV_64F, 1, 0);

            // Y방향 Scharr
            Cv2.Scharr(src, scharrY, MatType.CV_64F, 0, 1);

            // X, Y 결합
            Cv2.Magnitude(scharrX, scharrY, scharr);
            scharr.ConvertTo(scharr, MatType.CV_8U);

            // ==============================================
            // 3️⃣ Laplacian 연산자
            // - 2차 미분 기반 엣지 검출
            // - 이미지의 밝기 변화가 급격한 부분을 검출
            // - 노이즈에 민감하다는 단점이 있음
            // ==============================================
            Cv2.Laplacian(src, laplacian, MatType.CV_64F, ksize: 3);
            laplacian.ConvertTo(laplacian, MatType.CV_8U);

            // ==============================================
            // 4️⃣ Canny 에지 검출기
            // - 가장 많이 사용되는 엣지 검출 알고리즘
            // - 다단계 처리(가우시안 블러 → 그래디언트 계산 → 비최대 억제 → 이중 임계값 → 히스테리시스 에지 연결)
            // - 결과가 깔끔하고 잡음에 강함
            // ==============================================
            Cv2.Canny(src, canny, 0, 70); // 하한선: 50, 상한선: 150

            // ==============================================
            // 결과 출력
            // ==============================================
            Cv2.ImShow("Original", src);       // 원본
            Cv2.ImShow("Sobel", sobel);        // Sobel
            Cv2.ImShow("Scharr", scharr);      // Scharr
            Cv2.ImShow("Laplacian", laplacian);// Laplacian
            Cv2.ImShow("Canny", canny);        // Canny

            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
