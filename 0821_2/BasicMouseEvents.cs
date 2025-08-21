using OpenCvSharp;
using System;
using System.Collections.Generic;

namespace _0821_2
{
    internal class BasicMouseEvents
    {
        // 👉 마우스로 찍은 좌표를 저장하는 리스트 (기록용)
        private static List<Point> points = new List<Point>();

        // 👉 그림을 그릴 캔버스 (Mat = 이미지 저장 객체)
        private static Mat canvas;

        /// <summary>
        /// 마우스 이벤트 데모 실행
        /// </summary>
        public static void BasicMouseDemo()
        {
            // (1) 500x800 크기의 흰색 캔버스 생성
            // Mat(rows, cols, type, color)
            canvas = new Mat(500, 800, MatType.CV_8UC3, Scalar.White);

            // (2) "Mouse Demo"라는 이름의 윈도우 생성
            Cv2.NamedWindow("Mouse Demo");

            // (3) 마우스 이벤트 콜백 함수 등록
            // 사용자가 마우스를 클릭/드래그/휠 조작할 때마다 OnMouseEvent 호출
            Cv2.SetMouseCallback("Mouse Demo", OnMouseEvent);

            // (4) 메인 루프
            while (true)
            {
                // 현재 캔버스를 윈도우에 출력
                Cv2.ImShow("Mouse Demo", canvas);

                // 300ms 동안 키 입력 대기
                int key = Cv2.WaitKey(300);

                // ESC(27) 입력 시 프로그램 종료
                if (key == 27) break;
            }

            // (5) 자원 해제 (메모리 누수 방지)
            canvas.Dispose();
            Cv2.DestroyAllWindows();
        }

        /// <summary>
        /// 마우스 이벤트 콜백 함수
        /// </summary>
        /// <param name="eventType">발생한 마우스 이벤트 종류</param>
        /// <param name="x">마우스 X 좌표</param>
        /// <param name="y">마우스 Y 좌표</param>
        /// <param name="flags">추가 플래그 (Shift, Ctrl 같은 보조키 상태)</param>
        /// <param name="userData">사용자 데이터 (SetMouseCallback에 전달 가능)</param>
        private static void OnMouseEvent(MouseEventTypes eventType, int x, int y,
            MouseEventFlags flags, IntPtr userData)
        {
            // 현재 마우스 위치를 Point 객체로 저장
            Point currentPoint = new Point(x, y);

            switch (eventType)
            {
                case MouseEventTypes.LButtonDown:
                    // 👉 마우스 왼쪽 버튼 클릭
                    // 빨간 점 찍기
                    points.Add(currentPoint); // 좌표 기록
                    DrawPoint(currentPoint, new Scalar(0, 0, 255));
                    break;

                case MouseEventTypes.RButtonDown:
                    // 👉 마우스 오른쪽 버튼 클릭
                    // 초록 점 찍기
                    points.Add(currentPoint);
                    DrawPoint(currentPoint, new Scalar(0, 255, 0));
                    break;

                case MouseEventTypes.LButtonDoubleClick:
                    // 👉 왼쪽 더블 클릭
                    // 파란색 원 그리기
                    Cv2.Circle(canvas, currentPoint, 30, new Scalar(255, 0, 0), 3);
                    break;

                case MouseEventTypes.RButtonDoubleClick:
                    // 👉 오른쪽 더블 클릭
                    // 초록색 원 그리기
                    Cv2.Circle(canvas, currentPoint, 30, new Scalar(0, 255, 0), 3);
                    break;

                case MouseEventTypes.MouseMove:
                    // 👉 마우스 이동
                    // 현재 좌표를 실시간으로 화면에 표시
                    ShowCurrentCoordinates(currentPoint);
                    break;

                case MouseEventTypes.MouseWheel:
                    // 👉 마우스 휠 스크롤
                    // 캔버스 초기화 (모든 그림 지우기)
                    ClearCanvas();
                    break;
            }
        }

        /// <summary>
        /// 특정 좌표에 점 + 좌표 텍스트 출력
        /// </summary>
        private static void DrawPoint(Point point, Scalar color)
        {
            // (1) 해당 좌표에 반지름 5px 원 찍기
            Cv2.Circle(canvas, point, 5, color, -1);

            // (2) 좌표 값 텍스트 출력
            string coordText = $"{point.X}, {point.Y}";
            Cv2.PutText(canvas, coordText, point,
                HersheyFonts.HersheyScriptSimplex, 0.5, Scalar.Black, 1);
        }

        /// <summary>
        /// 캔버스를 흰색으로 초기화
        /// </summary>
        private static void ClearCanvas()
        {
            canvas.SetTo(Scalar.White);
        }

        /// <summary>
        /// 마우스 이동 시 현재 좌표를 임시로 표시
        /// (캔버스를 복제해서 원본을 유지)
        /// </summary>
        private static void ShowCurrentCoordinates(Point point)
        {
            // (1) 원본 캔버스를 복제 (임시 표시용)
            Mat temp = canvas.Clone();

            // (2) 현재 좌표 텍스트 출력 (마우스 위치 옆에 표시)
            string coordText = $"{point.X}:{point.Y}";
            Cv2.PutText(temp, coordText, new Point(point.X + 15, point.Y),
                HersheyFonts.HersheyScriptSimplex, 0.5, Scalar.Black, 1);

            // (3) 복제본을 윈도우에 출력
            Cv2.ImShow("Mouse Demo", temp);

            // (4) 복제본 메모리 해제
            temp.Dispose();
        }
    }
}
