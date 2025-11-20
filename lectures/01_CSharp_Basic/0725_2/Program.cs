// 예외 처리(Exception Handling) 완전 가이드
//
// 🎯 예외(Exception)란?
// - 프로그램 실행 중에 발생하는 예상치 못한 오류 상황
// - 예외가 발생하면 프로그램이 비정상적으로 종료될 수 있음
// - try-catch-finally 구문으로 안전하게 처리 가능
//
// 🌟 일상생활 비유:
// - 요리할 때: 재료가 떨어짐, 가스가 나가지 않음
// - 운전할 때: 타이어 펑크, 연료 부족  
// - ATM 사용: 카드 오류, 잔액 부족
// - 온라인 쇼핑: 재고 부족, 결제 실패

using System;
using System.IO;

namespace ExceptionHandlingGuide
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🎯 예외 처리 완전 가이드 🎯\n");

            // 예외 상황들 미리 보기
            ShowCommonExceptions();

            // 1. 기본 try-catch 사용법
            DemoBasicTryCatch();

            // 2. 여러 예외 타입 처리
            DemoMultipleExceptions();

            // 3. finally 블록 활용
            DemoFinallyBlock();

            // 4. 예외 정보 활용
            DemoExceptionInfo();

            // 5. 사용자 정의 예외
            //DemoCustomException();

            // 6. 실전 예제
            //DemoRealWorldExample();

            Console.WriteLine("\n🎉 예외 처리 학습 완료!");
        }

        #region 1. 일반적인 예외 상황들

        /// <summary>
        /// 일반적으로 발생하는 예외 상황들을 보여주는 메서드
        /// (실제로는 주석 처리해서 에러 방지)
        /// </summary>
        static void ShowCommonExceptions()
        {
            Console.WriteLine("📚 일반적인 예외 상황들");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("다음과 같은 상황에서 예외가 발생할 수 있습니다:");
            Console.WriteLine();

            Console.WriteLine("🔸 1. DivideByZeroException (0으로 나누기):");
            Console.WriteLine("   int result = 10 / 0; // 💥 에러!");
            Console.WriteLine("   → 수학적으로 불가능한 연산");
            Console.WriteLine();

            Console.WriteLine("🔸 2. IndexOutOfRangeException (배열 범위 초과):");
            Console.WriteLine("   int[] arr = {1, 2, 3};");
            Console.WriteLine("   int value = arr[5]; // 💥 에러! (인덱스 0~2만 유효)");
            Console.WriteLine("   → 존재하지 않는 배열 위치에 접근");
            Console.WriteLine();

            Console.WriteLine("🔸 3. NullReferenceException (null 참조 접근):");
            Console.WriteLine("   string text = null;");
            Console.WriteLine("   int length = text.Length; // 💥 에러!");
            Console.WriteLine("   → null인 객체의 속성/메서드에 접근");
            Console.WriteLine();

            Console.WriteLine("🔸 4. FormatException (잘못된 형변환):");
            Console.WriteLine("   string str = \"abc\";");
            Console.WriteLine("   int number = int.Parse(str); // 💥 에러!");
            Console.WriteLine("   → 숫자가 아닌 문자를 숫자로 변환 시도");
            Console.WriteLine();

            Console.WriteLine("✨ 이런 예외들을 try-catch로 안전하게 처리할 수 있습니다!");
            Console.WriteLine();
        }

        #endregion

        #region 2. 기본 try-catch 사용법

        /// <summary>
        /// 기본적인 try-catch 구문 사용법 데모
        /// </summary>
        static void DemoBasicTryCatch()
        {
            Console.WriteLine("1️⃣ 기본 try-catch 사용법");
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("🛡️ try-catch 구조:");
            Console.WriteLine("try {");
            Console.WriteLine("    // 위험할 수 있는 코드");
            Console.WriteLine("}");
            Console.WriteLine("catch (예외타입) {");
            Console.WriteLine("    // 예외 처리 코드");
            Console.WriteLine("}");
            Console.WriteLine();

            // 안전한 나눗셈 예제
            Console.WriteLine("🔸 예제 1: 안전한 나눗셈");

            try
            {
                Console.Write("첫 번째 숫자를 입력하세요: ");
                string input1 = Console.ReadLine();
                int number1 = int.Parse(input1);

                Console.Write("두 번째 숫자를 입력하세요: ");
                string input2 = Console.ReadLine();
                int number2 = int.Parse(input2);

                Console.WriteLine($"\n📊 계산 중: {number1} ÷ {number2}");
                int result = number1 / number2;
                Console.WriteLine($"✅ 결과: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("❌ 오류: 숫자가 아닌 값을 입력했습니다!");
                Console.WriteLine("💡 힌트: 정수만 입력해주세요. (예: 10, 5)");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("❌ 오류: 0으로 나눌 수 없습니다!");
                Console.WriteLine("💡 힌트: 두 번째 숫자는 0이 아닌 값을 입력해주세요.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ 예상치 못한 오류: {ex.Message}");
            }

            Console.WriteLine("\n✨ 핵심 포인트:");
            Console.WriteLine("   try: '이 코드를 실행해봐, 위험할 수도 있어'");
            Console.WriteLine("   catch: '문제가 생기면 이렇게 처리해줘'");
            Console.WriteLine("   → 프로그램이 죽지 않고 안전하게 계속 실행!");
            Console.WriteLine();
        }

        #endregion

        #region 3. 여러 예외 타입 처리

        /// <summary>
        /// 여러 종류의 예외를 각각 다르게 처리하는 데모
        /// </summary>
        static void DemoMultipleExceptions()
        {
            Console.WriteLine("2️⃣ 여러 예외 타입 처리하기");
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("🎯 목표: 다양한 예외 상황을 각각 다르게 처리");
            Console.WriteLine("📝 시나리오: 사용자 입력으로 다양한 연산 수행");
            Console.WriteLine();

            try
            {
                Console.Write("숫자를 입력하세요 (특별한 경우: 1 입력 시 사용자 정의 예외): ");
                string input = Console.ReadLine();

                Console.WriteLine($"📥 입력받은 값: '{input}'");

                // 1. 형변환 예외 발생 가능
                int number = int.Parse(input);
                Console.WriteLine($"✅ 형변환 성공: {number}");

                // 2. 사용자 정의 예외 발생 (1 입력 시)
                if (number == 1)
                {
                    throw new Exception($"사용자가 특별한 값 '{input}'를 입력했습니다!");
                }

                // 3. 0으로 나누기 예외 발생 가능
                Console.WriteLine($"📊 계산 중: 10 ÷ {number}");
                int result = 10 / number;
                Console.WriteLine($"✅ 계산 결과: {result}");

                // 4. 배열 인덱스 예외 (주석 처리 - 필요시 활성화)
                // int[] arr = { 1, 2, 3 };
                // int value = arr[number]; // number가 3보다 크면 예외

                // 5. null 참조 예외 (주석 처리 - 필요시 활성화)
                // string text = null;
                // int length = text.Length;

                // 6. 다른 형변환 예외
                Console.WriteLine("📊 추가 테스트: 'abc'를 숫자로 변환 시도");
                string testStr = "abc";
                int testNumber = int.Parse(testStr); // FormatException 발생!
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("❌ DivideByZeroException 포착!");
                Console.WriteLine("   → 0으로 나누려고 했습니다.");
                Console.WriteLine("   💡 해결책: 0이 아닌 숫자를 입력하세요.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("❌ IndexOutOfRangeException 포착!");
                Console.WriteLine("   → 배열의 범위를 벗어났습니다.");
                Console.WriteLine("   💡 해결책: 올바른 인덱스 범위를 확인하세요.");
            }
            catch (FormatException)
            {
                Console.WriteLine("❌ FormatException 포착!");
                Console.WriteLine("   → 문자를 숫자로 변환할 수 없습니다.");
                Console.WriteLine("   💡 해결책: 숫자 형태의 문자만 입력하세요.");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("❌ NullReferenceException 포착!");
                Console.WriteLine("   → null 객체에 접근하려고 했습니다.");
                Console.WriteLine("   💡 해결책: 객체가 null인지 먼저 확인하세요.");
            }
            catch (Exception ex) // 모든 예외를 잡는 일반적인 처리 (가장 마지막에!)
            {
                Console.WriteLine("❌ Exception 포착!");
                Console.WriteLine($"   → 예상치 못한 오류: {ex.Message}");
                Console.WriteLine("   💡 이는 위에서 처리하지 못한 모든 예외를 잡습니다.");
            }

            Console.WriteLine("\n✨ 핵심 포인트:");
            Console.WriteLine("   🔹 구체적인 예외부터 먼저 catch");
            Console.WriteLine("   🔹 Exception은 가장 마지막에 (모든 예외의 부모)");
            Console.WriteLine("   🔹 각 예외마다 적절한 처리와 사용자 안내 제공");
            Console.WriteLine();
        }

        #endregion

        #region 4. finally 블록 활용

        /// <summary>
        /// finally 블록의 동작과 활용법 데모
        /// </summary>
        static void DemoFinallyBlock()
        {
            Console.WriteLine("3️⃣ finally 블록 활용하기");
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("🎯 finally 블록이란?");
            Console.WriteLine("   → 예외 발생 여부와 상관없이 '무조건' 실행되는 블록");
            Console.WriteLine("   → 리소스 정리, 로그 기록, 마무리 작업에 사용");
            Console.WriteLine();

            Console.WriteLine("🔸 예제: 파일 처리 시뮬레이션");

            // 파일 처리 시뮬레이션
            string fileName = "test.txt";
            bool fileOpened = false;

            try
            {
                Console.WriteLine("📂 1단계: 파일 열기 시도");
                Console.WriteLine($"   → '{fileName}' 파일을 여는 중...");

                // 파일 열기 시뮬레이션 (실제로는 열지 않음)
                fileOpened = true;
                Console.WriteLine("   ✅ 파일 열기 성공!");

                Console.WriteLine("\n📝 2단계: 파일 작업 수행");
                Console.WriteLine("   → 데이터를 파일에 쓰는 중...");

                // 사용자에게 선택하게 하기
                Console.Write("   예외를 발생시킬까요? (y/n): ");
                string choice = Console.ReadLine();

                if (choice?.ToLower() == "y")
                {
                    Console.WriteLine("   💥 인위적으로 예외 발생!");
                    throw new IOException("파일 쓰기 중 오류 발생!");
                }

                Console.WriteLine("   ✅ 파일 작업 완료!");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"\n❌ IOException 포착: {ex.Message}");
                Console.WriteLine("   → 파일 처리 중 문제가 발생했습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ 예상치 못한 오류: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\n🔧 finally 블록 실행!");
                Console.WriteLine("   → 예외 발생 여부와 관계없이 실행됩니다.");

                if (fileOpened)
                {
                    Console.WriteLine("   📂 파일 닫기 작업 수행");
                    Console.WriteLine("   🧹 리소스 정리 완료");
                    fileOpened = false;
                }

                Console.WriteLine("   📋 로그 기록: 파일 처리 작업 종료");
                Console.WriteLine("   ✅ 마무리 작업 완료!");
            }

            Console.WriteLine("\n✨ 핵심 포인트:");
            Console.WriteLine("   🔹 finally는 예외 발생 여부와 무관하게 항상 실행");
            Console.WriteLine("   🔹 파일, 데이터베이스 연결 등 리소스 정리에 필수");
            Console.WriteLine("   🔹 using 문을 사용하면 finally를 자동으로 처리");
            Console.WriteLine();
        }

        #endregion

        #region 5. 예외 정보 활용

        /// <summary>
        /// 예외 객체의 정보를 활용하는 방법 데모
        /// </summary>
        static void DemoExceptionInfo()
        {
            Console.WriteLine("4️⃣ 예외 정보 활용하기");
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("🎯 예외 객체에서 얻을 수 있는 정보들:");
            Console.WriteLine("   🔹 Message: 오류 메시지");
            Console.WriteLine("   🔹 StackTrace: 오류 발생 위치 추적");
            Console.WriteLine("   🔹 Source: 오류 발생 어셈블리");
            Console.WriteLine("   🔹 InnerException: 내부 예외 정보");
            Console.WriteLine();

            try
            {
                Console.WriteLine("📝 시나리오: 복잡한 계산 과정에서 예외 발생");

                // 복잡한 계산 시뮬레이션
                PerformComplexCalculation();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n❌ 예외 발생! 상세 정보:");
                Console.WriteLine(new string('-', 40));

                Console.WriteLine($"🔸 예외 타입: {ex.GetType().Name}");
                Console.WriteLine($"🔸 오류 메시지: {ex.Message}");
                Console.WriteLine($"🔸 발생 위치: {ex.Source}");

                Console.WriteLine("\n📋 스택 트레이스 (오류 발생 경로):");
                Console.WriteLine(ex.StackTrace);

                // 내부 예외 확인
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"\n🔗 내부 예외: {ex.InnerException.Message}");
                }

                Console.WriteLine("\n💡 개발자를 위한 디버깅 정보:");
                Console.WriteLine($"   → 오류 타입을 보고 적절한 예외 처리 추가");
                Console.WriteLine($"   → 스택 트레이스로 정확한 오류 위치 파악");
                Console.WriteLine($"   → 메시지로 오류 원인 분석");
            }

            Console.WriteLine("\n✨ 핵심 포인트:");
            Console.WriteLine("   🔹 Exception 객체는 오류에 대한 풍부한 정보 제공");
            Console.WriteLine("   🔹 개발 중에는 상세 정보를, 운영 중에는 사용자 친화적 메시지를");
            Console.WriteLine("   🔹 로그 파일에 예외 정보를 기록하여 문제 해결에 활용");
            Console.WriteLine();
        }

        /// <summary>
        /// 복잡한 계산 과정에서 예외를 발생시키는 메서드
        /// </summary>
        static void PerformComplexCalculation()
        {
            Console.WriteLine("   1단계: 초기 데이터 준비");
            int[] data = { 10, 20, 30, 0, 50 };

            Console.WriteLine("   2단계: 데이터 처리 중...");
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine($"      처리 중: data[{i}] = {data[i]}");

                if (i == 3) // 0 값에서 예외 발생
                {
                    int result = 100 / data[i]; // DivideByZeroException 발생!
                }
            }
        }
        #endregion
    }

}

// 📚 예외 처리 핵심 정리:
//
// 1. 기본 구조:
//    try { /* 위험한 코드 */ }
//    catch (예외타입) { /* 처리 코드 */ }
//    finally { /* 무조건 실행 */ }
//
// 2. 예외 처리 원칙:
//    - 구체적인 예외부터 먼저 catch
//    - Exception은 가장 마지막에 배치
//    - 사용자에게 의미 있는 오류 메시지 제공
//    - 리소스는 finally에서 정리
//
// 3. 사용자 정의 예외:
//    - Exception 클래스 상속
//    - 비즈니스 로직에 특화된 예외 생성
//    - throw 키워드로 예외 발생
//
// 4. 실전 팁:
//    - 예외는 예외적인 상황에서만 사용
//    - TryParse 같은 안전한 메서드 활용