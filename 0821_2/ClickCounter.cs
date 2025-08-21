using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0821_2
{
    internal class ClickCounter
    {
        private static int clickCount = 0;

        private static Mat canvas;

        public static void ClickCounterPractice()
        {
            // TODO: 학생들이 구현할 내용

            // 1. 캔버스 생성 (400x600)
            canvas = new Mat(400, 600, MatType.CV_8UC3, Scalar.White);

            // 2. 마우스 콜백 등록
            Cv2.NamedWindow("Click Counter");
            Cv2.SetMouseCallback("Click Counter", OnMouseEvent);

            while (true)
            {
                Cv2.ImShow("Click Counter", canvas);

                int key = Cv2.WaitKey(30);
                if (key == 27) break;
            }
            Console.WriteLine("=== 클릭 카운터 실습 ===");
            Console.WriteLine("TODO: 마우스 이벤트로 클릭 횟수 세기");
            Console.WriteLine("왼쪽 클릭: 카운트 증가");
            Console.WriteLine("오른쪽 클릭: 카운트 리셋");

            canvas.Dispose();
            Cv2.DestroyAllWindows();
        }

        private static void OnMouseEvent ( MouseEventTypes type, int x, int y, MouseEventFlags flag, IntPtr userData)
        {
            // 3. 왼쪽 클릭 시 카운터 증가
            // 4. 오른쪽 클릭 시 카운터 리셋
            switch (type)
            {
                case MouseEventTypes.LButtonDown:
                    clickCount++;
                    DrawClickInfo(new Point(x, y));
                    break;
                case MouseEventTypes.RButtonDown:
                    clickCount = 0;
                    canvas.SetTo(Scalar.White);

                    break;
            }
        }

        private static void DrawClickInfo(Point point)
        {
            Cv2.Circle(canvas, point, 5, Scalar.Black, -1);

            // 5. 현재 카운트를 화면에 표시
            // 6. 클릭한 위치에 숫자 표시
            string str = $"Count {clickCount}";
            Cv2.PutText(canvas, str, point, HersheyFonts.HersheyScriptSimplex, 
                0.7, Scalar.Black, 1);
        }
    }
}
