using OpenCvSharp;
using System;
using System.IO;

//
// ========================== 이론 설명 ==========================
//
// 📌 디지털 이미지 파일 형식
// 컴퓨터에서 이미지를 저장하는 방법은 여러 가지가 있으며,
// 각 형식은 서로 다른 특징과 용도를 가지고 있습니다.
//
// 1) JPEG(.jpg, .jpeg)
//   - 압축 방식: 손실 압축
//   - 파일 크기: 작음 (압축률 높음)
//   - 품질: 압축 시 일부 정보 손실
//   - 투명도: 지원 안함
//   - 사용처: 웹사이트 이미지, 소셜미디어 업로드, 파일 크기가 중요한 경우
//
// 2) PNG(.png)
//   - 압축 방식: 무손실 압축
//   - 파일 크기: JPEG보다 크지만 품질 손실 없음
//   - 품질: 원본과 동일
//   - 투명도: 지원 (Alpha 채널)
//   - 사용처: 로고, 아이콘, 스크린샷, 투명 배경이 필요한 이미지
//
// 3) BMP(.bmp)
//   - 압축 방식: 주로 비압축
//   - 파일 크기: 매우 큼
//   - 품질: 최고 (무손실)
//   - 호환성: 거의 모든 시스템에서 지원
//   - 사용처: 의료 영상 분석, 정밀한 이미지처리, 임시 작업 파일
//
// 4) TIFF(.tif, .tiff)
//   - 압축 방식: 무손실 압축 가능
//   - 파일 크기: 큼
//   - 품질: 최고
//   - 메타데이터: 풍부한 정보 저장 가능
//   - 사용처: 과학/의료 영상, 인쇄용 고품질 이미지, 아카이브 저장용
//
// ===============================================================
//

namespace _0821
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string imagePath = "img1.jpg";

            // 항상 파일 존재 확인
            if (!File.Exists(imagePath))
            {
                Console.WriteLine($"이미지 파일을 찾을 수 없습니다. {imagePath}");
                return;
            }

            // 📌 이미지 읽기 (3가지 모드 비교)
            using (Mat unChangedImage = Cv2.ImRead(imagePath, ImreadModes.Unchanged)) // 원본 그대로
            using (Mat colorImage = Cv2.ImRead(imagePath, ImreadModes.Color))        // 컬러
            using (Mat grayImage = Cv2.ImRead(imagePath, ImreadModes.Grayscale))    // 흑백
            {
                if (unChangedImage.Empty())
                {
                    Console.WriteLine("이미지를 읽을 수 없습니다.");
                }

                Cv2.ImShow("UnChanged Image", unChangedImage);
                Cv2.ImShow("Color Image", colorImage);
                Cv2.ImShow("Gray Image", grayImage);

                Cv2.WaitKey(0);
                Cv2.DestroyAllWindows();
            }

            // 📌 이미지 저장하기 (여러 포맷)
            using (Mat testImage = CreateTestImage())
            {
                Console.WriteLine($"=== 이미지 저장 실습 ===\n");

                Cv2.ImShow("Test Image", testImage);

                // 저장 폴더 준비
                string outputDir = "saved_images";
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                    Console.WriteLine($"출력 폴더 생성 : {outputDir}");
                }

                // 여러 포맷으로 저장
                Console.WriteLine($"파일 저장을 시작합니다....");
                SaveMulipleFormaters(testImage, outputDir);
                Console.WriteLine($"파일 저장을 완료하였습니다.");

                // 파일 크기 비교
                CompareFileSizes(outputDir);

                Cv2.WaitKey(0);
                Cv2.DestroyAllWindows();
            }
        }

        /// <summary>
        /// 📌 테스트용 그라데이션 이미지 생성
        /// </summary>
        private static Mat CreateTestImage()
        {
            Mat image = new Mat(400, 600, MatType.CV_8UC3, Scalar.White);

            // 픽셀 직접 접근 (BGR 값 변경)
            var indexer = image.GetGenericIndexer<Vec3b>();
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    byte blue = (byte)(j * 255 / image.Width);   // 가로 → Blue
                    byte green = (byte)(i * 255 / image.Height); // 세로 → Green
                    indexer[i, j] = new Vec3b(blue, green, 128); // Red = 128 고정
                }
            }

            return image;
        }

        /// <summary>
        /// 📌 여러 포맷으로 이미지 저장
        /// </summary>
        private static void SaveMulipleFormaters(Mat image, string outputDir)
        {
            // PNG (무손실 압축)
            string pngPath = Path.Combine(outputDir, "test_image.png");
            Cv2.ImWrite(pngPath, image);

            // BMP (비압축)
            string bmpPath = Path.Combine(outputDir, "test_image.bmp");
            Cv2.ImWrite(bmpPath, image);

            // JPEG (고품질)
            string jpegHighPath = Path.Combine(outputDir, "test_image_high.jpg");
            Cv2.ImWrite(jpegHighPath, image, new int[] { (int)ImwriteFlags.JpegQuality, 95 });

            // JPEG (중간 품질)
            string jpegMedPath = Path.Combine(outputDir, "test_image_medium.jpg");
            Cv2.ImWrite(jpegMedPath, image, new int[] { (int)ImwriteFlags.JpegQuality, 50 });

            // JPEG (저품질)
            string jpegLowPath = Path.Combine(outputDir, "test_image_low.jpg");
            Cv2.ImWrite(jpegLowPath, image, new int[] { (int)ImwriteFlags.JpegQuality, 10 });

            Console.WriteLine("PNG, BMP, JPEG(3종) 저장 완료");
        }

        /// <summary>
        /// 📌 저장된 이미지 파일 크기 비교
        /// </summary>
        private static void CompareFileSizes(string outputDir)
        {
            Console.WriteLine($"=== 파일 크기 비교 ===");

            var files = new[]
            {
                "test_image.png",
                "test_image.bmp",
                "test_image_high.jpg",
                "test_image_medium.jpg",
                "test_image_low.jpg"
            };

            foreach (string file in files)
            {
                string fullPath = Path.Combine(outputDir, file);
                if (File.Exists(fullPath))
                {
                    FileInfo fileInfo = new FileInfo(fullPath);
                    Console.WriteLine($"{file} : {fileInfo.Length:N0} bytes ({fileInfo.Length / 1024.0:F1} KB)");
                }
            }
        }
    }
}
