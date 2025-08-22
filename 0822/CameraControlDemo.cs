using OpenCvSharp;
using System;

namespace _0822
{
    internal class CameraControlDemo
    {
        public static void CameraWithControls()
        {
            // ==========================================
            // 📌 1️⃣ 카메라 열기
            // ==========================================
            // - VideoCapture(0) → 기본 카메라 장치(웹캠) 사용
            // - 인덱스 0, 1, 2 ... → 여러 개의 카메라가 있을 경우 장치 번호
            using (VideoCapture cap = new VideoCapture(0))
            {
                if (!cap.IsOpened())
                {
                    Console.WriteLine("❌ 카메라를 열 수 없습니다.");
                    return; // 카메라가 없거나 다른 프로그램이 점유 중이면 종료
                }

                // ==========================================
                // 📌 2️⃣ 해상도 설정
                // ==========================================
                // - 기본적으로 카메라는 디폴트 해상도로 켜짐
                // - 아래 코드를 사용해 해상도 강제 변경 가능
                cap.Set(VideoCaptureProperties.FrameWidth, 800);
                cap.Set(VideoCaptureProperties.FrameHeight, 600);

                // ==========================================
                // 📌 제어 변수 (사용자 조작 상태 저장)
                // ==========================================
                bool showInfo = true;       // (F키) 영상 정보 표시 여부
                bool showCrosshair = false; // (C키) 십자선 표시 여부
                int frameCount = 0;         // 현재까지 읽은 프레임 수
                DateTime startTime = DateTime.Now; // 시작 시간 (FPS 계산용)

                using (Mat frame = new Mat())
                {
                    while (true)
                    {
                        // ==========================================
                        // 📌 3️⃣ 프레임 읽기
                        // ==========================================
                        // - cap.Read(frame) → 카메라에서 한 장의 프레임 읽어오기
                        // - frame.Empty() → 더 이상 읽을 수 없으면 true
                        cap.Read(frame);
                        if (frame.Empty()) break;

                        frameCount++; // 읽은 프레임 수 누적

                        // ==========================================
                        // 📌 4️⃣ 정보 표시 (FPS, 프레임 수, 경과 시간)
                        // ==========================================
                        if (showInfo)
                        {
                            AddFrameInfo(frame, frameCount, startTime);
                        }

                        // ==========================================
                        // 📌 5️⃣ 십자선 표시
                        // ==========================================
                        if (showCrosshair)
                        {
                            AddCrosshair(frame);
                        }

                        // ==========================================
                        // 📌 6️⃣ 하단에 조작 안내 표시
                        // ==========================================
                        AddControlGuide(frame);

                        // ==========================================
                        // 📌 7️⃣ 영상 출력
                        // ==========================================
                        Cv2.ImShow("Camera Control", frame);

                        // ==========================================
                        // 📌 8️⃣ 키 입력 처리
                        // ==========================================
                        int key = Cv2.WaitKey(30); // 30ms 대기 = 약 33fps
                        if (key == 27) break; // ESC 키 → 프로그램 종료

                        // 9️⃣ 키보드 제어 (S/F/C)
                        HandleControlKeys(key, frame, ref showInfo, ref showCrosshair);
                    }
                }

                // ==========================================
                // 📌 10️⃣ 모든 창 닫기
                // ==========================================
                Cv2.DestroyAllWindows();
            }
        }

        // ==========================================================
        // 🎨 영상에 정보 표시 함수 (FPS, 프레임 수, 시간)
        // ==========================================================
        private static void AddFrameInfo(Mat frame, int frameCount, DateTime startTime)
        {
            // 검은색 사각형 → 글씨 배경 (가독성 향상)
            Cv2.Rectangle(frame, new Rect(10, 10, 300, 120), Scalar.Black, -1);

            // (1) 경과 시간
            TimeSpan elapsed = DateTime.Now - startTime;
            string timeText = $"Time : {elapsed:mm\\:ss}";
            Cv2.PutText(frame, timeText, new Point(20, 40),
                HersheyFonts.HersheySimplex, 0.7, Scalar.White, 2);

            // (2) 누적 프레임 수
            string frameText = $"Frame : {frameCount}";
            Cv2.PutText(frame, frameText, new Point(20, 70),
                HersheyFonts.HersheySimplex, 0.7, Scalar.White, 2);

            // (3) FPS 계산
            // FPS = 지금까지 읽은 프레임 수 ÷ 경과 시간(초)
            double fps = frameCount / elapsed.TotalSeconds;
            string fpsText = $"FPS : {fps:F1}";
            Cv2.PutText(frame, fpsText, new Point(20, 100),
                HersheyFonts.HersheySimplex, 0.7, Scalar.White, 2);
        }

        // ==========================================================
        // 🎯 영상에 십자선 표시
        // ==========================================================
        private static void AddCrosshair(Mat frame)
        {
            Point center = new Point(frame.Width / 2, frame.Height / 2);
            int lineLength = 50; // 십자선 길이

            // 가로선 (빨간색)
            Cv2.Line(frame,
                new Point(center.X - lineLength, center.Y),
                new Point(center.X + lineLength, center.Y),
                Scalar.Red, 2);

            // 세로선 (빨간색)
            Cv2.Line(frame,
                new Point(center.X, center.Y - lineLength),
                new Point(center.X, center.Y + lineLength),
                Scalar.Red, 2);

            // 중심점 (작은 원)
            Cv2.Circle(frame, center, 3, Scalar.Red, -1);
        }

        // ==========================================================
        // 📋 하단에 조작 안내 표시 (단축키 가이드)
        // ==========================================================
        private static void AddControlGuide(Mat frame)
        {
            int y = frame.Height - 60; // 화면 하단 기준 위치
            Cv2.Rectangle(frame, new Rect(0, y, frame.Width, 60), Scalar.Black, -1);

            string guide = "S: Screenshot | F: Info | C: Crosshair | ESC: Exit";
            Cv2.PutText(frame, guide, new Point(10, y + 35),
                HersheyFonts.HersheySimplex, 0.7, Scalar.White, 2);
        }

        // ==========================================================
        // ⌨️ 키보드 입력 처리
        // ==========================================================
        private static void HandleControlKeys(int key, Mat frame,
            ref bool showInfo, ref bool showCrosshair)
        {
            switch (key)
            {
                case (int)'s': // 스크린샷 저장
                case (int)'S':
                    SaveScreenshot(frame);
                    break;

                case (int)'f': // 정보 표시 토글
                case (int)'F':
                    showInfo = !showInfo;
                    break;

                case (int)'c': // 십자선 표시 토글
                case (int)'C':
                    showCrosshair = !showCrosshair;
                    break;
            }
        }

        // ==========================================================
        // 💾 스크린샷 저장 기능
        // ==========================================================
        private static void SaveScreenshot(Mat frame)
        {
            // 현재 시각을 이용해 파일명 생성
            string filename = $"camera_capture_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";

            try
            {
                bool success = Cv2.ImWrite(filename, frame);
                if (success)
                {
                    Console.WriteLine($"✅ 스크린샷 저장 성공: {filename}");
                }
                else
                {
                    Console.WriteLine("❌ 스크린샷 저장 실패");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"⚠️ 오류 발생: {e.Message}");
            }
        }
    }
}
