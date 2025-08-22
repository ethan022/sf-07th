using OpenCvSharp;
using System;

namespace _0822
{
    internal class BasicCameraDemo
    {
        public static void BasicCameraUsage()
        {
            Console.WriteLine("=== 기본 카메라 사용법 ===");

            // 1️⃣ 카메라 초기화
            // VideoCapture(0) → 시스템에 연결된 첫 번째 카메라 (웹캠)
            // VideoCapture(1) → 두 번째 카메라
            using (VideoCapture capture = new VideoCapture(0))
            {
                // 카메라 열기 실패 시 예외 처리
                if (!capture.IsOpened())
                {
                    Console.WriteLine("❌ 카메라를 열 수 없습니다.");
                    return;
                }

                // 2️⃣ 카메라 속성 설정
                // 해상도(Width=640, Height=480)
                capture.Set(VideoCaptureProperties.FrameWidth, 640);
                capture.Set(VideoCaptureProperties.FrameHeight, 480);

                // 3️⃣ 실제 적용된 값 확인
                double width = capture.Get(VideoCaptureProperties.FrameWidth);   // 640
                double height = capture.Get(VideoCaptureProperties.FrameHeight); // 480
                double fps = capture.Get(VideoCaptureProperties.Fps);            // 장치 지원 여부에 따라 값 다름 (예: 30)

                Console.WriteLine($"해상도: {width} x {height}");
                Console.WriteLine($"FPS: {fps}");

                // 4️⃣ Mat 객체 생성
                // Mat → OpenCV에서 한 장의 이미지(프레임)를 담는 자료형
                using (Mat frame = new Mat())
                {
                    while (true)
                    {
                        // 5️⃣ 프레임 읽기
                        bool success = capture.Read(frame);

                        // 카메라가 닫혔거나 프레임 읽기 실패 → 종료
                        if (!success || frame.Empty())
                        {
                            return;
                        }

                        // 6️⃣ 현재 시간 출력 (영상에 오버레이)
                        string timeText = DateTime.Now.ToString("HH:mm:ss");

                        Cv2.PutText(
                            frame,                      // 출력할 대상 Mat
                            timeText,                   // 문자열 (현재 시간)
                            new Point(10, 30),          // 좌표 (왼쪽 상단)
                            HersheyFonts.HersheyScriptSimplex, // 폰트 종류
                            1,                          // 글자 크기
                            Scalar.Yellow,              // 글자 색상 (노란색)
                            2                           // 두께
                        );

                        // 7️⃣ 영상 창에 출력
                        Cv2.ImShow("Camera", frame);

                        // 8️⃣ 키 입력 대기
                        int key = Cv2.WaitKey(30); // 30ms 대기 (약 33FPS)
                        if (key == 27) break;      // ESC(27) 입력 시 종료
                    }
                }

                // 9️⃣ 모든 창 닫기
                Cv2.DestroyAllWindows();
            }
        }
    }
}
