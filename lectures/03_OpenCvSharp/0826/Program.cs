using System;
using System.Linq;
using OpenCvSharp;

namespace _0826
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 이미지 로드
                Mat image = Cv2.ImRead("1.webp");
                if (image.Empty())
                {
                    Console.WriteLine("이미지를 로드할 수 없습니다. 파일 경로를 확인하세요.");
                    return;
                }

                // 이미지 크기 조정
                Mat dst = new Mat();
                Cv2.Resize(image, dst, new Size(800, 600), 0, 0, InterpolationFlags.LinearExact);

                Console.WriteLine("=== 명함 검출 시스템 시작 ===");
                Console.WriteLine($"원본 이미지 크기: {image.Size()}");
                Console.WriteLine($"처리 이미지 크기: {dst.Size()}");

                // 1단계: 전처리
                Console.WriteLine("\n--- 1단계: 전처리 ---");
                Mat processed = PreprocessForCardDetection.PreprocessForCardDetectionDemo(dst);

                // 2단계: 후보 검출
                Console.WriteLine("\n--- 2단계: 후보 검출 ---");
                var candidates = PreprocessForCardDetection.FindCardCandidates(processed, dst);

                if (!candidates.Any())
                {
                    Console.WriteLine("명함 후보를 찾을 수 없습니다.");
                    Console.WriteLine("다른 이미지를 시도하거나 전처리 파라미터를 조정하세요.");
                    Cv2.ImShow("Original", dst);
                    Cv2.WaitKey(0);
                    return;
                }

                // 3단계: 최고 후보 선택
                Console.WriteLine("\n--- 3단계: 최적 후보 선택 ---");
                var bestCandidate = PreprocessForCardDetection.SelectBestCandidate(candidates);

                Console.WriteLine($"검출된 총 후보 수: {candidates.Count}");
                Console.WriteLine($"최적 후보: {bestCandidate}");

                // 상위 3개 후보 출력
                var topCandidates = candidates.OrderByDescending(c => c.Confidence).Take(3);
                Console.WriteLine("\n상위 3개 후보:");
                int rank = 1;
                foreach (var candidate in topCandidates)
                {
                    Console.WriteLine($"{rank}. {candidate}");
                    rank++;
                }

                // 4단계: 명함 추출
                Console.WriteLine("\n--- 4단계: 명함 추출 ---");
                Mat extractedCard = PreprocessForCardDetection.ExtractCard(dst, bestCandidate);

                // 5단계: 결과 표시
                Console.WriteLine("\n--- 5단계: 결과 표시 ---");
                PreprocessForCardDetection.DrawDetectionResults(dst, candidates, bestCandidate);

                // 결과 이미지들 표시
                Cv2.ImShow("Original", dst);
                Cv2.ImShow("Extracted Card", extractedCard);

                string str = PreprocessForCardDetection.OCR(extractedCard);
                Console.WriteLine($"카드 글자  {str}");

                Console.WriteLine("\n=== 처리 완료 ===");
                Console.WriteLine("아무 키나 누르면 종료됩니다...");

                // 키 입력 대기
                Cv2.WaitKey(0);

                // 메모리 정리
                image.Dispose();
                dst.Dispose();
                processed.Dispose();
                extractedCard.Dispose();

                // 모든 창 닫기
                Cv2.DestroyAllWindows();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
                Console.WriteLine($"스택 트레이스: {ex.StackTrace}");
            }
        }
    }
}