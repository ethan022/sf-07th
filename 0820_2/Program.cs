// ROI(Region of Interest)와 픽셀 접근 실습 코드
// -----------------------------------------------------------
// OpenCV에서 ROI는 '이미지에서 특정 영역만 선택'하는 개념으로,
// 전체 이미지를 처리하지 않고 필요한 부분만 다룰 수 있게 해줍니다.
// 이로 인해 성능 향상과 메모리 절약 효과가 있습니다.
//
// 추가적으로, 픽셀 단위 접근 방법(GetGenericIndexer, At, Set 등)을 통해
// 이미지의 개별 픽셀 값을 읽고 쓸 수 있습니다.
// -----------------------------------------------------------


using OpenCvSharp;

namespace _0820_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -----------------------------------------------------------
            // 1. Rect를 사용한 ROI
            // Rect(x, y, width, height) : 좌표 (x,y)에서 너비, 높이를 갖는 사각형 지정
            // -----------------------------------------------------------
            Rect region1 = new Rect(100, 100, 200, 200);

            // 테스트용 이미지 (파란색 배경 생성)
            using (Mat original1 = new Mat(500, 500, MatType.CV_8UC3, new Scalar(255, 0, 0)))
            // ROI 설정 (원본을 잘라내지 않고 '가리킴')
            using (Mat roi1 = new Mat(original1, region1))
            {
                // ROI는 원본 데이터를 복사하지 않고 같은 메모리를 참조합니다.
                // 따라서 roi1을 수정하면 original1도 같이 바뀝니다.
                roi1.SetTo(new Scalar(0, 0, 255));  // ROI 영역을 빨간색으로 채움

                Cv2.ImShow("original", original1);
                Cv2.ImShow("roi", roi1);
            }

            // -----------------------------------------------------------
            // 2. Range를 사용한 ROI
            // Range(start, end) : 행/열의 구간 지정
            // original[rowRange, colRange] 형태로 ROI 선택
            // -----------------------------------------------------------
            OpenCvSharp.Range rowRange = new OpenCvSharp.Range(50, 200);    // 행 50~199
            OpenCvSharp.Range colRange = new OpenCvSharp.Range(100, 300);   // 열 100~299

            using (Mat original = Cv2.ImRead("img1.jpg"))
            using (Mat roi2 = original[rowRange, colRange])
            {
                Cv2.ImShow("original", original);
                Cv2.ImShow("roi", roi2);
                Cv2.WaitKey(0);
                Cv2.DestroyAllWindows();
            }

            // -----------------------------------------------------------
            // 3. 픽셀 단위 접근 (GetGenericIndexer)
            // [행, 열] 순서에 주의! (y, x)
            // -----------------------------------------------------------
            Mat image1 = new Mat(500, 500, MatType.CV_8UC3);
            var indexer = image1.GetGenericIndexer<Vec3b>();

            int x = 0;
            int y = 1;

            // 픽셀 읽기
            Vec3b pixel = indexer[y, x];   // (행=y, 열=x)
            byte blue = pixel.Item0;       // B
            byte green = pixel.Item1;      // G
            byte red = pixel.Item2;        // R

            // 픽셀 쓰기
            indexer[y, x] = new Vec3b(255, 0, 0);  // 파란색으로 변경

            // -----------------------------------------------------------
            // 4. At(), Set() 함수 사용
            // Mat의 기본 제공 메서드를 통한 접근
            // -----------------------------------------------------------
            Mat image2 = new Mat(500, 500, MatType.CV_8UC3);

            // 픽셀 읽기
            Vec3b pixel2 = image2.At<Vec3b>(y, x);

            // 픽셀 쓰기
            image2.Set<Vec3b>(y, x, new Vec3b(255, 0, 0));

            // -----------------------------------------------------------
            // 5. 이미지 중심부 ROI 설정
            // 중심 좌표를 기준으로 사각형 ROI를 지정
            // -----------------------------------------------------------
            using (Mat original = Cv2.ImRead("img2.jpg"))
            {
                int width = original.Width;
                int height = original.Height;

                // 중심을 기준으로 300x300 크기의 영역 추출
                Rect centerRegion = new Rect(width / 2 - 150, height / 2 - 150, 300, 300);
                Mat roiCenter = new Mat(original, centerRegion);

                roiCenter.SetTo(new Scalar(0, 0, 255));  // ROI 영역을 빨간색으로 채움

                Cv2.ImShow("original", original);
                Cv2.ImShow("roi", roiCenter);

                Cv2.WaitKey(0);
                Cv2.DestroyAllWindows();
            }

            // -----------------------------------------------------------
            // 6. 패턴 이미지 생성 예제
            // -----------------------------------------------------------
            using (Mat checkBoard = CreateCheckBoard(400, 600))
            {
                Cv2.ImShow("CheckBoard", checkBoard);
                Cv2.WaitKey(0);
                Cv2.DestroyAllWindows();
            }

            using (Mat crossPattern = CreateCrossPattern(400, 600, 50))
            {
                Cv2.ImShow("CrossPattern", crossPattern);
                Cv2.WaitKey(0);
                Cv2.DestroyAllWindows();
            }

            using (Mat quadrant = CreateQuadrantPattern(400, 600))
            {
                Cv2.ImShow("QuadrantPattern", quadrant);
                Cv2.WaitKey(0);
                Cv2.DestroyAllWindows();
            }
        }

        // -----------------------------------------------------------
        // 체크보드 패턴 생성
        // -----------------------------------------------------------
        private static Mat CreateCheckBoard(int height, int width)
        {
            Mat board = new Mat(height, width, MatType.CV_8UC3);
            var indexer = board.GetGenericIndexer<Vec3b>();

            int squareSize = 50; // 사각형 크기

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bool isWhite = ((x / squareSize) + (y / squareSize)) % 2 == 0;

                    if (isWhite)
                        indexer[y, x] = new Vec3b(255, 255, 255);  // 흰색
                    else
                        indexer[y, x] = new Vec3b(0, 0, 0);        // 검정색
                }
            }
            return board;
        }

        // -----------------------------------------------------------
        // 십자가 패턴 생성
        // -----------------------------------------------------------
        private static Mat CreateCrossPattern(int height, int width, int thickness = 5)
        {
            Mat crossPattern = new Mat(height, width, MatType.CV_8UC3);
            var indexer = crossPattern.GetGenericIndexer<Vec3b>();

            int midX = width / 2;
            int midY = height / 2;

            // 가로선
            for (int t = -thickness / 2; t <= thickness / 2; t++)
            {
                int y = midY + t;
                for (int i = 0; i < width; i++)
                {
                    indexer[y, i] = new Vec3b(255, 255, 255);
                }
            }

            // 세로선
            for (int t = -thickness / 2; t <= thickness / 2; t++)
            {
                int x = midX + t;
                for (int i = 0; i < height; i++)
                {
                    indexer[i, x] = new Vec3b(255, 255, 255);
                }
            }
            return crossPattern;
        }

        // -----------------------------------------------------------
        // 사분면 색상 패턴 생성
        // 좌상단: 빨강 / 우상단: 파랑 / 좌하단: 초록 / 우하단: 흰색
        // -----------------------------------------------------------
        private static Mat CreateQuadrantPattern(int height, int width)
        {
            Mat img = new Mat(height, width, MatType.CV_8UC3);

            int midX = width / 2;
            int midY = height / 2;
            var indexer = img.GetGenericIndexer<Vec3b>();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y <= midY && x <= midX) indexer[y, x] = new Vec3b(0, 0, 255);   // 빨강
                    else if (y <= midY && x > midX) indexer[y, x] = new Vec3b(255, 0, 0);   // 파랑
                    else if (y > midY && x <= midX) indexer[y, x] = new Vec3b(0, 255, 0);   // 초록
                    else indexer[y, x] = new Vec3b(255, 255, 255); // 흰색
                }
            }
            return img;
        }
    }
}


// -----------------------------------------------------------
// [정리]
// 1. ROI(관심영역)
//   - Rect 사용: new Mat(original, rect)
//   - Range 사용: original[rowRange, colRange]
//   - ROI는 원본 데이터와 메모리를 공유하므로 수정 시 원본도 함께 변함.
//   - 메모리 효율적이지만, 원본이 의도치 않게 변경될 수 있음.

// 2. 픽셀 접근
//   - GetGenericIndexer<T>() 사용 (빠르고 권장)
//   - At<T>(), Set<T>() 사용 (직관적이지만 느림)
//   - 인덱스는 [행(y), 열(x)] 순서

// 3. 주의사항
//   - ROI는 원본 공유: 복사가 필요하면 Clone()을 사용
//   - 배열 인덱스 범위 초과 방지 필요
//   - 색상은 BGR 순서 (OpenCV 기본)
// -----------------------------------------------------------
