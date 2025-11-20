// -----------------------------------------------------------
// OpenCV 기본 데이터 구조
// -----------------------------------------------------------
// OpenCV는 다양한 기하학적 객체와 데이터 구조를 제공하여
// 이미지 처리 연산을 메모리 효율적이고 빠르게 수행할 수 있도록 합니다.
//
// 대표적인 구조체: Point, Size, Scalar, Range, Rect, Mat
// -----------------------------------------------------------

using OpenCvSharp;
using Range = OpenCvSharp.Range;

namespace _0819_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -----------------------------------------------------------
            // 1. Point (좌표 표현)
            // -----------------------------------------------------------
            // - 2D 또는 3D 좌표를 표현하는 기본 구조체
            // - 정수형, 실수형, double형 등 다양한 타입 제공

            // 2D 정수 좌표
            Point point = new Point(100, 200);       // (x=100, y=200)
            Point point2 = new Point(x: 150, y: 210);

            // 2D 실수 좌표
            Point2f ptf1 = new Point2f(100.5f, 200.0f);

            // 3D 좌표
            Point3d pt3d = new Point3d(10.0f, 20.0f, 30.0f);

            // -----------------------------------------------------------
            // 2. Size (크기 표현)
            // -----------------------------------------------------------
            // - 이미지의 너비(width), 높이(height) 또는 사각형 크기 표현
            Size imageSize = new Size(1920, 1080);

            // -----------------------------------------------------------
            // 3. Scalar (색상 표현)
            // -----------------------------------------------------------
            // - 4채널 벡터 형태 (기본: BGR + 알파)
            // - 단일 픽셀값 또는 색상을 표현할 때 사용
            // - OpenCV는 기본적으로 RGB가 아닌 BGR 순서를 사용

            Scalar blue = new Scalar(255, 0, 0);        // 파랑 (BGR)
            Scalar green = new Scalar(0, 255, 0);       // 초록
            Scalar red = new Scalar(0, 0, 255);         // 빨강
            Scalar gray = new Scalar(125);              // 회색 (단일 채널)
            Scalar transparentRed = new Scalar(0, 0, 255, 128); // 반투명 빨강 (Alpha=128)

            // -----------------------------------------------------------
            // 4. Range (범위)
            // -----------------------------------------------------------
            // - 배열 슬라이싱, ROI, 히스토그램 계산 등에 사용
            // - Range(start, end): start ~ end-1 범위
            Range range = new Range(40, 200); // 40~199 까지

            // -----------------------------------------------------------
            // 5. Rect (사각형 영역)
            // -----------------------------------------------------------
            // - 좌표 (x, y)와 너비(width), 높이(height)로 정의
            // - ROI(관심영역) 지정 시 자주 사용
            Rect rect1 = new Rect(10, 20, 100, 80); // (10,20)에서 시작, 100x80 크기

            // -----------------------------------------------------------
            // 6. Mat (OpenCV 핵심 데이터 구조)
            // -----------------------------------------------------------
            // - 이미지 및 행렬 데이터 저장
            // - 다차원 배열을 효율적으로 관리
            // - 헤더(메타정보) + 데이터(픽셀값) 구조

            Mat image = new Mat(480, 640, MatType.CV_8UC1); // 480x640, 1채널(흑백)

            // Mat의 속성 출력
            Console.WriteLine($"Rows (행, 높이): {image.Rows}");
            Console.WriteLine($"Cols (열, 너비): {image.Cols}");
            Console.WriteLine($"Channels (채널 수): {image.Channels()}");
            Console.WriteLine($"Depth (픽셀당 비트 깊이): {image.Depth()}");
            Console.WriteLine($"Type (데이터 타입): {image.Type()}");
            Console.WriteLine($"ElemSize (원소 크기, 바이트): {image.ElemSize()}");
            Console.WriteLine($"Total (전체 원소 개수): {image.Total()}");
            Console.WriteLine($"Size (행렬 크기): {image.Size()}");
        }
    }
}
