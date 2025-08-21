using System;
using OpenCvSharp;

//
// ============================= 이론 설명 =============================
//
// 📌 OpenCvSharp 키보드 이벤트 처리
// OpenCV에서는 `Cv2.WaitKey()` 함수를 이용해 키보드 입력을 받을 수 있다.
//
// 1. 함수 원리
//   - `int key = Cv2.WaitKey(delay);`
//   - delay = 0 : 무한 대기 (키가 눌릴 때까지 프로그램 멈춤)
//   - delay > 0 : 해당 밀리초(ms) 동안만 대기 후 다음 코드 실행
//
// 2. 반환값
//   - 누른 키의 ASCII 코드 (정수 값)
//   - 소문자/대문자 구분 있음 ('r' != 'R')
//
// 3. 주요 키 코드 예시
//   - 27  : ESC (프로그램 종료에 자주 사용)
//   - 13  : Enter
//   - 32  : Space
//   - 8   : BackSpace
//   - 'r' = 114, 'R' = 82 (대소문자 차이)
//
// 4. 활용
//   - 특정 키에 따라 이미지 색상 바꾸기
//   - 랜덤 색상 적용
//   - 스크린샷 저장
//   - ESC 키로 프로그램 종료
//
// ======================================================================
//

namespace _0821_2
{
    internal class BasicKeyBoardEvents
    {
        /// <summary>
        /// 키보드 이벤트 데모 실행
        /// </summary>
        public static void KeyBoardDemo()
        {
            // 캔버스 크기 지정 (600x400)
            Size canvasSize = new Size(600, 400);

            // Mat : OpenCV의 기본 이미지 컨테이너
            // CV_8UC3 : 8비트, 3채널(BGR)
            // Scalar.White : 초기값은 흰색으로 설정
            using (Mat canvas = new Mat(canvasSize, MatType.CV_8UC3, Scalar.White))
            {
                while (true) // 무한 루프
                {
                    // 1. 현재 캔버스를 "Keyboard Demo" 창에 출력
                    Cv2.ImShow("Keyboard Demo", canvas);

                    // 2. 키 입력 대기
                    // delay = 0 → 키가 눌릴 때까지 무한 대기
                    int key = Cv2.WaitKey(0);

                    // 3. ESC 키(27) 입력 시 프로그램 종료
                    if (key == 27) break;

                    // 4. 입력된 키를 이벤트 처리 함수로 전달
                    bool handled = HandleKeyEvent(key, canvas);

                    // 5. 지정되지 않은 키라면 콘솔에 ASCII 코드 출력
                    if (!handled)
                    {
                        Console.WriteLine($"알 수 없는 키 입력 : {key}");
                    }
                }

                // 모든 윈도우 닫기 (리소스 정리)
                Cv2.DestroyAllWindows();
            }
        }

        /// <summary>
        /// 키보드 입력 이벤트 처리
        /// key : Cv2.WaitKey()의 반환값 (ASCII 코드)
        /// canvas : 현재 그림이 그려진 Mat 객체
        /// </summary>
        private static bool HandleKeyEvent(int key, Mat canvas)
        {
            switch (key)
            {
                // ---------------- 색상 변경 (단축키) ----------------
                case (int)'r': // 소문자 r
                case (int)'R': // 대문자 R
                    canvas.SetTo(Scalar.Red); // 캔버스를 빨간색으로 채움
                    return true;

                case (int)'g':
                case (int)'G':
                    canvas.SetTo(Scalar.Green); // 초록색
                    return true;

                case (int)'b':
                case (int)'B':
                    canvas.SetTo(Scalar.Blue); // 파랑색
                    return true;

                // ---------------- 숫자키 (프리셋 색상) ----------------
                case (int)'1':
                    canvas.SetTo(Scalar.Black); // 검정
                    return true;
                case (int)'2':
                    canvas.SetTo(Scalar.Yellow); // 노랑
                    return true;
                case (int)'3':
                    canvas.SetTo(Scalar.SkyBlue); // 하늘색
                    return true;
                case (int)'4':
                    canvas.SetTo(Scalar.LightBlue); // 연한 파랑
                    return true;
                case (int)'5':
                    canvas.SetTo(Scalar.LightPink); // 연분홍
                    return true;

                // ---------------- 기능키 ----------------
                case (int)'c':
                case (int)'C':
                    // C : 캔버스를 흰색으로 초기화
                    canvas.SetTo(Scalar.White);
                    return true;

                case (int)'z':
                case (int)'Z':
                    // Z : 랜덤 색상으로 채우기
                    SetRandomColor(canvas);
                    return true;

                case (int)'x':
                case (int)'X':
                    // X : 스크린샷 저장
                    SaveScreenShot(canvas);
                    return true;

                // ---------------- 그 외 ----------------
                default:
                    // 처리하지 않은 키
                    return false;
            }
        }

        /// <summary>
        /// 랜덤 색상 생성 후 캔버스 채우기
        /// </summary>
        private static void SetRandomColor(Mat canvas)
        {
            Random rand = new Random();

            // 0~255 범위의 무작위 값 생성
            byte b = (byte)rand.Next(0, 256); // Blue
            byte g = (byte)rand.Next(0, 256); // Green
            byte r = (byte)rand.Next(0, 256); // Red

            // OpenCV의 색상 순서는 (B, G, R)
            Scalar randColor = new Scalar(b, g, r);

            // 캔버스를 해당 색상으로 채움
            canvas.SetTo(randColor);

            Console.WriteLine($"랜덤 색상 적용: B={b}, G={g}, R={r}");
        }

        /// <summary>
        /// 현재 캔버스를 PNG 파일로 저장
        /// </summary>
        private static void SaveScreenShot(Mat canvas)
        {
            // 파일명 : 날짜_시간 기반으로 생성
            string filename = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";

            try
            {
                // ImWrite : Mat → 파일로 저장
                bool success = Cv2.ImWrite(filename, canvas);

                if (success)
                {
                    // 저장 성공 메시지 콘솔 출력
                    Console.WriteLine($"스크린샷 저장 완료: {filename}");

                    // 안내 메시지를 이미지에 출력 후 1초 보여주기
                    Mat temp = canvas.Clone();
                    Cv2.PutText(temp, $"Saved: {filename}",
                        new Point(10, canvas.Height - 30), // 왼쪽 아래 위치
                        HersheyFonts.HersheyTriplex,       // 글꼴
                        0.6,                               // 글자 크기
                        Scalar.White, 2);                  // 글자 색상/두께

                    Cv2.ImShow("Keyboard Demo", temp);
                    Cv2.WaitKey(1000); // 1초 대기
                    temp.Dispose();
                }
                else
                {
                    Console.WriteLine("스크린샷 저장 실패!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"저장 오류 발생: {ex}");
            }
        }
    }
}
