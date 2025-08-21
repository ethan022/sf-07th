using System;
using OpenCvSharp;

namespace _0821_2
{
    internal class BasicDragDrawing
    {
        // -------------------------------
        // [필드 영역: 프로그램 전역 상태]
        // -------------------------------

        // 캔버스 (이미지를 담을 공간)
        // OpenCV에서 Mat은 '행렬'이자 '이미지 버퍼' 역할을 함.
        private static Mat canvas;

        // 현재 드래그 상태 여부
        // true → 마우스 왼쪽 버튼이 눌린 상태에서 이동 중
        private static bool isDrawing = false;

        // 마지막 좌표 (이전 마우스 위치 저장 → 선 연결 시 필요)
        private static Point lastPoint;

        // 현재 브러시 색상 (기본 검정색)
        // OpenCV의 Scalar = (Blue, Green, Red) 순서
        private static Scalar currentColor = Scalar.Black;

        // 현재 브러시 크기 (픽셀 단위)
        private static int brushSize = 3;

        /// <summary>
        /// 드래그 드로잉 데모 실행 메서드
        /// </summary>
        public static void DragDrawingDemo()
        {
            // 콘솔 안내 메시지
            Console.WriteLine("=== 드래그 그리기 실습 ===");
            Console.WriteLine("마우스 드래그 : 자유롭게 그림 그리기");
            Console.WriteLine("키보드 조작:");
            Console.WriteLine("  1-9 → 브러시 크기 조절");
            Console.WriteLine("  R/G/B → 색상 변경 (빨강/초록/파랑)");
            Console.WriteLine("  C → 캔버스 초기화 (지우개 효과)");
            Console.WriteLine("  ESC → 종료");

            // 1. 캔버스 초기화
            // 600x800 크기, 3채널(RGB), 8비트 unsigned, 초기 색상 = 흰색
            canvas = new Mat(600, 800, MatType.CV_8UC3, Scalar.White);

            // 2. 윈도우 생성
            // NamedWindow는 OpenCV의 GUI 창을 만듦
            Cv2.NamedWindow("Drag Drawing");

            // 3. 마우스 이벤트 콜백 등록
            // 마우스 이벤트(LButtonDown, MouseMove, LButtonUp 등)를 감지하여 처리
            Cv2.SetMouseCallback("Drag Drawing", OnDrawingMouseEvenet);

            // 4. 메인 루프
            while (true)
            {
                // 캔버스를 창에 출력
                Cv2.ImShow("Drag Drawing", canvas);

                // 키 입력 감지 (30ms 동안 대기)
                int key = Cv2.WaitKey(30);

                // ESC(27) 입력 시 프로그램 종료
                if (key == 27) break;

                // 키 이벤트 처리 (색상 변경, 브러시 크기 조정 등)
                HandleDrawingKeyEvent(key);
            }

            // 프로그램 종료 전 자원 해제
            canvas.Dispose();
            Cv2.DestroyAllWindows();
        }

        /// <summary>
        /// 마우스 이벤트 처리 함수
        /// - eventType : 발생한 이벤트 종류 (클릭, 이동, 떼기 등)
        /// - x, y : 현재 마우스 좌표
        /// - flags : 추가 플래그(Shift, Ctrl 키 상태 등)
        /// - userData : 사용자 정의 데이터 (여기서는 사용 안 함)
        /// </summary>
        private static void OnDrawingMouseEvenet(MouseEventTypes eventType,
            int x, int y,
            MouseEventFlags flags, IntPtr userData)
        {
            // 현재 마우스 좌표
            Point currentPoint = new Point(x, y);

            switch (eventType)
            {
                // [마우스 왼쪽 버튼 눌렀을 때]
                case MouseEventTypes.LButtonDown:
                    isDrawing = true;               // 드래그 시작
                    lastPoint = currentPoint;       // 시작 좌표 저장
                    // 클릭한 지점에 브러시 찍기 (원)
                    Cv2.Circle(canvas, currentPoint, brushSize, currentColor, -1);
                    break;

                // [마우스 이동할 때]
                case MouseEventTypes.MouseMove:
                    if (isDrawing) // 드래그 중이라면
                    {
                        // 이전 좌표와 현재 좌표를 직선으로 연결
                        Cv2.Line(canvas, lastPoint, currentPoint, currentColor, brushSize);

                        // 마지막 좌표 갱신
                        lastPoint = currentPoint;
                    }
                    break;

                // [마우스 왼쪽 버튼에서 손을 뗐을 때]
                case MouseEventTypes.LButtonUp:
                    isDrawing = false; // 드래그 종료
                    break;
            }
        }

        /// <summary>
        /// 키보드 입력 처리 함수
        /// </summary>
        private static void HandleDrawingKeyEvent(int key)
        {
            // 상태 변경 발생 여부
            bool needUpdate = false;

            // 1~9 숫자 입력 → 브러시 크기 변경
            if (key >= (int)'1' && key <= (int)'9')
            {
                brushSize = key - (int)'0'; // '문자 코드' → 숫자로 변환
                needUpdate = true;
            }

            // 색상 변경 및 캔버스 초기화
            switch (key)
            {
                case (int)'r':
                case (int)'R':
                    currentColor = Scalar.Red;   // 빨강
                    needUpdate = true;
                    break;

                case (int)'g':
                case (int)'G':
                    currentColor = Scalar.Green; // 초록
                    needUpdate = true;
                    break;

                case (int)'b':
                case (int)'B':
                    currentColor = Scalar.Blue;  // 파랑
                    needUpdate = true;
                    break;

                case (int)'c':
                case (int)'C':
                    // 캔버스를 흰색으로 리셋
                    canvas.SetTo(Scalar.White);
                    needUpdate = true;
                    break;
            }

            // (추가 확장 가능)
            // 상태 업데이트 메시지나 HUD 출력
            //if (needUpdate)
            //{
            //    UpdateStatusDisplay();
            //}
        }

        // 추후 브러시 상태(크기, 색상)를 HUD로 표시할 수 있음
        //private static void UpdateStatusDisplay()
        //{
        //    Cv2.PutText(canvas, $"Brush: {brushSize}, Color: {currentColor}", 
        //        new Point(10, 20), HersheyFonts.HersheySimplex, 0.5, Scalar.Black, 1);
        //}
    }
}
