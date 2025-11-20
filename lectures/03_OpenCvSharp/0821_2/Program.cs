/// 마우스와 키보드 이벤트 처리
/// 
/// 🖱️ 이벤트 기반 프로그래밍(Event-driven Programming)
/// - "이벤트"란? 사용자의 입력이나 시스템의 변화(예: 마우스 클릭, 키보드 입력, 윈도우 크기 변경 등)를 의미
/// - "이벤트 처리(Event Handling)"란? 특정 이벤트가 발생했을 때, 미리 등록해 둔 함수(핸들러)를 실행하는 것
/// 
/// ✅ 특징:
/// - 프로그램이 무한 루프를 돌면서 사용자 입력을 기다림
/// - 입력(이벤트)이 들어오면 → 이벤트 핸들러(콜백 함수)가 실행됨
/// - GUI 프로그램, 게임, 그래픽/영상 처리 프로그램에서 많이 활용됨
/// 
/// 📌 OpenCV와 이벤트:
/// - OpenCV에서는 키보드 입력: Cv2.WaitKey()
/// - OpenCV에서는 마우스 입력: Cv2.SetMouseCallback()
///   → 이벤트가 발생할 때마다 지정된 콜백 함수가 호출됨
/// 
/// 이 프로그램은 키보드/마우스 이벤트를 처리하는 3가지 예제를 실행할 수 있음.
/// - BasicMouseEvents.BasicMouseDemo();     → 마우스 좌표 및 클릭 이벤트
/// - BasicKeyBoardEvents.KeyBoardDemo();    → 키보드 입력 이벤트
/// - BasicDragDrawing.DragDrawingDemo();    → 마우스로 그림 그리기
/// 
/// Main()에서는 원하는 예제를 주석 처리/해제하여 실행 가능함.
namespace _0821_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 📌 1. 마우스 이벤트 실습
            // 좌클릭/우클릭, 더블클릭, 마우스 이동/휠 이벤트 처리
            //BasicMouseEvents.BasicMouseDemo();

            // 📌 2. 키보드 이벤트 실습
            // 키보드 입력(문자, 방향키 등)을 받아 특정 동작 수행
            //BasicKeyBoardEvents.KeyBoardDemo();

            // 📌 3. 드래그 그림판 실습
            // 마우스를 드래그하여 그림을 그리고,
            // 키보드로 색상과 브러시 크기를 바꾸거나 캔버스를 초기화 가능
            //BasicDragDrawing.DragDrawingDemo();


            ClickCounter.ClickCounterPractice();
        }
    }
}
