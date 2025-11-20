using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace _0822_1
{
    internal class BasicColorConversion
    {
        public static void BasicColorConversionDemo()
        {
            // 테스트용 컬러 이미지 생성 (빨강, 초록, 파랑, 노랑, 시안 블록 포함)
            using (Mat colorImage = CreateColorTestImage())
            {
                // 변환된 결과를 저장할 Mat 객체 생성
                using (Mat grayImage = new Mat())  // 흑백 이미지 저장
                using (Mat hsvImage = new Mat())   // HSV 변환 결과 저장
                using (Mat labImage = new Mat())   // Lab 변환 결과 저장
                {
                    // 1. BGR → Grayscale 변환
                    //   - 3채널(BGR) 이미지를 1채널(Gray)로 변환
                    //   - 색상 정보는 사라지고 밝기(Luminance) 정보만 남음
                    Cv2.CvtColor(colorImage, grayImage, ColorConversionCodes.BGR2GRAY);

                    // 2. BGR → HSV 변환
                    //   - 색상을 Hue(색상), Saturation(채도), Value(명도)로 분리
                    //   - 색상(H)은 0~179 범위 (OpenCV는 0~360 대신 0~180 사용)
                    //   - 채도(S), 명도(V)는 0~255 범위
                    Cv2.CvtColor(colorImage, hsvImage, ColorConversionCodes.BGR2HSV);

                    // 3. BGR → Lab 변환
                    //   - Lab 색 공간: 사람의 시각 특성을 반영한 색 공간
                    //   - L: 밝기(0~100), a: 녹색~적색(-128~127), b: 청색~황색(-128~127)
                    //   - 색차 계산이나 색상 균일성 비교에서 자주 사용
                    Cv2.CvtColor(colorImage, labImage, ColorConversionCodes.BGR2Lab);

                    // 윈도우 창에 각각의 영상 출력
                    Cv2.ImShow("1. Origin", colorImage);   // 원본 컬러 이미지 (BGR)
                    Cv2.ImShow("2. Gray", grayImage);      // 흑백 변환 이미지
                    Cv2.ImShow("3. HSV", hsvImage);        // HSV 변환 이미지
                    Cv2.ImShow("4. Lab", labImage);        // Lab 변환 이미지

                    // 키 입력 대기 (0 = 무한 대기)
                    Cv2.WaitKey(0);
                    // 모든 윈도우 닫기
                    Cv2.DestroyAllWindows();
                }
            }

        }

        // ==============================
        // 테스트용 컬러 이미지 생성 함수
        // ==============================
        private static Mat CreateColorTestImage()
        {
            // 크기: 400x600, 타입: 8비트 3채널(BGR), 초기 색상: 흰색
            Mat image = new Mat(400, 600, MatType.CV_8UC3, Scalar.White);

            // 다섯 가지 색상 블록 정의 (좌표, 색상(BGR), 이름)
            var colorBlocks = new[]
            {
                new {Rect = new Rect(50,50,100,100), Color = new Scalar(0,0,255), Name = "Red"},     // 빨강
                new {Rect = new Rect(200,50,100,100), Color = new Scalar(0,255,0), Name = "Green"},  // 초록
                new {Rect = new Rect(350,50,100,100), Color = new Scalar(255,0,0), Name = "Blue"},   // 파랑
                new {Rect = new Rect(50,150,100,100), Color = new Scalar(0,255,255), Name = "Yellow"}, // 노랑
                new {Rect = new Rect(250,250,100,100), Color = new Scalar(255,255,0), Name = "Cyan"},  // 시안
            };

            // 각 블록 그리기
            foreach (var block in colorBlocks)
            {
                // 사각형 내부를 지정한 색상으로 채우기 (-1 = 내부 채우기)
                Cv2.Rectangle(image, block.Rect, block.Color, -1);

                // 블록 이름 텍스트 추가
                Point textPos = new Point(block.Rect.X + 10, block.Rect.Y + 20);
                Cv2.PutText(image, block.Name, textPos,
                    HersheyFonts.HersheySimplex, 0.6, Scalar.Black, 2);
            }

            // 제목 표시
            Cv2.PutText(image, "Color Conversion Test Image", new Point(150, 30),
                    HersheyFonts.HersheySimplex, 0.6, Scalar.Black, 2);

            return image;
        }
    }
}
