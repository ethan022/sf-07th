using System;
using System.IO; // File.Exists() 사용
using OpenCvSharp; // OpenCV 라이브러리 (.NET 바인딩)

namespace _0822
{
    internal class BasicVideoPlayerDemo
    {
        public static void PlayVideoFile()
        {
            // ==========================================
            // 📌 1️⃣ 재생할 비디오 파일 경로 지정
            // ==========================================
            string videoPath = "video1.mp4"; // 같은 프로젝트 실행폴더에 둔 영상

            // 파일 존재 확인
            if (!File.Exists(videoPath))
            {
                Console.WriteLine("❌ 비디오 파일이 존재하지 않습니다.");
                return;
            }

            // ==========================================
            // 📌 2️⃣ VideoCapture 객체 생성
            // ==========================================
            // - OpenCV에서 비디오/카메라 입력을 다루는 핵심 클래스
            // - 파일 경로를 넣으면 비디오 파일 열기
            // - 숫자(0, 1, 2)를 넣으면 웹캠 장치 열기
            using (VideoCapture cap = new VideoCapture(videoPath))
            {
                // 비디오 정상 열렸는지 확인
                if (!cap.IsOpened())
                {
                    Console.WriteLine("❌ 비디오를 열 수 없습니다.");
                    return;
                }

                // ==========================================
                // 📌 3️⃣ 비디오 기본 정보 가져오기
                // ==========================================
                double fps = cap.Get(VideoCaptureProperties.Fps);             // 초당 프레임 수
                double totalFrames = cap.Get(VideoCaptureProperties.FrameCount); // 전체 프레임 수
                double width = cap.Get(VideoCaptureProperties.FrameWidth);    // 해상도(가로)
                double height = cap.Get(VideoCaptureProperties.FrameHeight);  // 해상도(세로)
                double duration = totalFrames / fps;                          // 전체 영상 길이(초)

                Console.WriteLine($"해상도: {width} x {height}");
                Console.WriteLine($"FPS: {fps}");
                Console.WriteLine($"총 프레임: {totalFrames}");
                Console.WriteLine($"재생시간: {duration}초");
                Console.WriteLine("Space: 일시정지/재생 | A: 뒤로 10초 | D: 앞으로 10초 | ESC: 종료");

                // ==========================================
                // 📌 4️⃣ Mat 객체 준비 (비디오 프레임 저장용)
                // ==========================================
                using (Mat frame = new Mat())
                {
                    int frameDelay = (int)(1000 / fps); // 각 프레임 사이 대기(ms)
                    bool isPaused = false;              // 일시정지 상태
                    int currentFrame = 0;               // 현재 프레임 번호

                    // ==========================================
                    // 📌 5️⃣ 메인 루프 (영상 재생)
                    // ==========================================
                    while (true)
                    {
                        // (⏯️) 일시정지가 아닐 때만 프레임 읽기
                        if (!isPaused)
                        {
                            cap.Read(frame); // 다음 프레임 읽기
                            if (frame.Empty()) break; // 끝까지 읽으면 종료
                            currentFrame = (int)cap.Get(VideoCaptureProperties.PosFrames);
                        }

                        // 6️⃣ 현재 프레임 위에 진행 정보(시간/퍼센트/프레임 번호) 표시
                        AddVideoPlayerInfo(frame, currentFrame, totalFrames, fps, isPaused);

                        // 7️⃣ 영상 출력
                        Cv2.ImShow("Video Player", frame);

                        // 8️⃣ 키 입력 처리
                        int waitTime = isPaused ? 0 : frameDelay; // 일시정지 시 무한 대기
                        int key = Cv2.WaitKey(waitTime);

                        if (key == 27) break; // ESC → 종료

                        // 9️⃣ 키보드 이벤트 처리 (SPACE, A, D)
                        bool shouldContinue = HandleVideoPlayerKeys(key, cap, ref isPaused, totalFrames, fps);
                        if (!shouldContinue) break;
                    }
                }

                // ==========================================
                // 📌 6️⃣ 모든 창 닫기
                // ==========================================
                Cv2.DestroyAllWindows();
            }
        }

        // ==========================================================
        // 🎨 영상 위에 정보 표시 함수
        // ==========================================================
        private static void AddVideoPlayerInfo(Mat frame, int currentFrame,
            double totalFrame, double fps, bool isPaused)
        {
            // 진행률 계산
            double progress = (currentFrame / totalFrame) * 100; // %
            double currentTime = currentFrame / fps;             // 현재 시간(초)
            double totalTime = totalFrame / fps;                 // 총 길이(초)

            // (1) 상단 검은 박스
            Cv2.Rectangle(frame, new Rect(0, 0, frame.Width, 80), Scalar.Black, -1);

            // (2) 시간 정보 (mm:ss / mm:ss)
            string timeText = $"{TimeSpan.FromSeconds(currentTime):mm\\:ss} / {TimeSpan.FromSeconds(totalTime):mm\\:ss}";
            Cv2.PutText(frame, timeText, new Point(10, 30),
                        HersheyFonts.HersheySimplex, 0.8, Scalar.White, 2);

            // (3) 진행률 및 프레임 번호
            string progressText = $"Progress: {progress:F1}% ({currentFrame} / {totalFrame})";
            Cv2.PutText(frame, progressText, new Point(10, 60),
                        HersheyFonts.HersheySimplex, 0.8, Scalar.White, 2);

            // (4) 일시정지 상태 표시
            if (isPaused)
            {
                Cv2.PutText(frame, "PAUSED", new Point(frame.Width - 150, 40),
                    HersheyFonts.HersheySimplex, 0.8, Scalar.Red, 2);
            }

            // (5) 하단 진행률 바
            int barWidth = frame.Width - 40;
            int barHeight = 8;
            Point barStart = new Point(20, frame.Height - 30);
            Point barEnd = new Point(barStart.X + barWidth, barStart.Y + barHeight);

            // 전체 바 (회색)
            Cv2.Rectangle(frame, barStart, barEnd, Scalar.Gray, -1);

            // 현재 위치 바 (초록색)
            int progressWidth = (int)(barWidth * progress / 100);
            Point progressEnd = new Point(barStart.X + progressWidth, barEnd.Y);
            Cv2.Rectangle(frame, barStart, progressEnd, Scalar.Green, -1);
        }

        // ==========================================================
        // ⌨️ 키보드 이벤트 처리 함수
        // ==========================================================
        private static bool HandleVideoPlayerKeys(int key, VideoCapture capture,
            ref bool isPaused, double totalFrames, double fps)
        {
            switch (key)
            {
                case 32: // SPACE → 일시정지/재생
                    isPaused = !isPaused;
                    return true;

                case 'a': // A → 10초 뒤로
                case 'A':
                    {
                        double currentFrame = capture.Get(VideoCaptureProperties.PosFrames);
                        double newFrame = Math.Max(0, currentFrame - (fps * 10));
                        capture.Set(VideoCaptureProperties.PosFrames, newFrame);
                        return true;
                    }

                case 'd': // D → 10초 앞으로
                case 'D':
                    {
                        double currentFrame = capture.Get(VideoCaptureProperties.PosFrames);
                        double newFrame = Math.Min(totalFrames - 1, currentFrame + (fps * 10));
                        capture.Set(VideoCaptureProperties.PosFrames, newFrame);
                        return true;
                    }

                default:
                    return true; // 다른 키는 무시
            }
        }
    }
}
