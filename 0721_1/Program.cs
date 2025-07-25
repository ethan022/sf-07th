using System;

/*
 ================================================================================================
 C# 메서드(함수) 기초 - 원본 코드 분석 및 개선
 ================================================================================================
 
 📚 원본 코드에서 학습할 내용:
 1. 메서드의 기본 구조 (매개변수, 반환값)
 2. static 키워드의 필요성
 3. 메서드 오버로딩 개념
 4. void 메서드 (반환값이 없는 메서드)
 5. 메서드 호출과 결과 활용
 6. 메서드 조합을 통한 계산
 
 🎯 원본 코드의 문제점을 파악하고 개선해보자!
 
 ================================================================================================
 */

namespace CSharpMethodsBasic
{
    class Program
    {
        /*
         ============================================================================================
         원본 코드 분석
         ============================================================================================
         
         원본 코드의 주요 문제점들:
         1. Main 메서드 외부에 정의된 메서드들이 static이 아님 → 호출 불가
         2. 주석 처리된 오버로딩 메서드들 → 오버로딩 예제 확인 불가
         3. 호출했지만 결과를 사용하지 않는 메서드들
         4. 형변환 문제 (float 값을 int 메서드에 전달)
         
         개선 방향:
         - 모든 메서드에 static 키워드 추가
         - 주석 처리된 오버로딩 메서드들 활성화
         - 메서드 호출 결과를 적절히 활용
         - 타입별 메서드 오버로딩 정상 동작 확인
         
         ============================================================================================
         */

        // ==========================================
        // 기본 산술 연산 메서드들
        // ==========================================

        /// <summary>
        /// 두 정수를 더하는 메서드
        /// </summary>
        /// <param name="x">첫 번째 정수</param>
        /// <param name="y">두 번째 정수</param>
        /// <returns>두 정수의 합</returns>
        static int Add(int x, int y)
        {
            /*
             * 원본 코드에 있던 기본 Add 메서드
             * - static 키워드: Main에서 직접 호출하기 위해 필요
             * - int 반환 타입: 계산 결과를 호출자에게 반환
             * - 매개변수 x, y: 더할 두 수를 입력받음
             */
            return x + y;
        }

        /// <summary>
        /// 두 실수(float)를 더하는 메서드 - 메서드 오버로딩
        /// 원본에서는 주석 처리되어 있었음
        /// </summary>
        /// <param name="x">첫 번째 실수</param>
        /// <param name="y">두 번째 실수</param>
        /// <returns>두 실수의 합</returns>
        static float Add(float x, float y)
        {
            /*
             * 메서드 오버로딩 (Method Overloading):
             * - 같은 이름 'Add'이지만 매개변수 타입이 다름 (int vs float)
             * - 컴파일러가 호출 시 매개변수 타입을 보고 적절한 메서드 선택
             * - 원본에서는 주석 처리되어 있어서 동작하지 않았음
             */
            return x + y;
        }

        /// <summary>
        /// 두 문자열을 연결하는 메서드 - 메서드 오버로딩
        /// 원본에서는 Main 메서드 내부에 정의되어 있었음 (잘못된 위치)
        /// </summary>
        /// <param name="x">첫 번째 문자열</param>
        /// <param name="y">두 번째 문자열</param>
        /// <returns>연결된 문자열</returns>
        static string Add(string x, string y)
        {
            /*
             * 문자열 오버로딩:
             * - 같은 'Add' 이름이지만 string 타입 매개변수
             * - + 연산자가 문자열에서는 연결(concatenation) 의미
             * - 원본에서는 Main 내부에 있어서 호출할 수 없었음
             */
            return x + y;
        }

        /// <summary>
        /// 두 정수를 빼는 메서드
        /// </summary>
        /// <param name="x">피감수 (빼이는 수)</param>
        /// <param name="y">감수 (빼는 수)</param>
        /// <returns>뺄셈 결과</returns>
        static int Sub(int x, int y)
        {
            /*
             * 원본 코드에 있던 Sub 메서드
             * - 기본적인 뺄셈 연산 수행
             * - static 키워드 추가하여 Main에서 호출 가능
             */
            return x - y;
        }

        /// <summary>
        /// 출력 메서드 - 반환값이 없는 void 메서드
        /// </summary>
        static void Print()
        {
            /*
             * void 메서드의 특징:
             * - 반환값이 없음 (return 문 없음)
             * - 단순히 어떤 작업을 수행하고 끝남
             * - 주로 출력, 로깅, 상태 변경 등에 사용
             */
            Console.WriteLine("출력");
        }

        /// <summary>
        /// 두 정수를 곱하는 메서드
        /// 원본에서는 Main 외부에 있었지만 static이 없어서 호출 불가였음
        /// </summary>
        /// <param name="x">첫 번째 정수</param>
        /// <param name="y">두 번째 정수</param>
        /// <returns>곱셈 결과</returns>
        static int Mul(int x, int y)
        {
            /*
             * 원본 코드 문제점:
             * - Main 메서드 외부에 정의되어 있었음
             * - static 키워드가 없어서 Main에서 호출할 수 없었음
             * 
             * 해결책:
             * - static 키워드 추가
             * - Main에서 정상적으로 호출 가능
             */
            return x * y;
        }

        /// <summary>
        /// 두 정수를 나누는 메서드 (실수 결과 반환)
        /// 원본에서는 Main 외부에 있었지만 static이 없어서 호출 불가였음
        /// </summary>
        /// <param name="x">피제수 (나누어지는 수)</param>
        /// <param name="y">제수 (나누는 수)</param>
        /// <returns>나눗셈 결과 (실수)</returns>
        static double Div(int x, int y)
        {
            /*
             * 나눗셈의 중요한 개념:
             * - 매개변수는 int이지만 반환 타입은 double
             * - 정확한 소수점 계산을 위해 형변환 필요
             * - 0으로 나누기 방지를 위한 예외 처리 권장
             */
            if (y == 0)
            {
                Console.WriteLine("오류: 0으로 나눌 수 없습니다!");
                return 0;
            }
            return (double)x / y;  // 명시적 형변환으로 정확한 나눗셈
        }

        // ==========================================
        // Main 메서드 - 프로그램 진입점
        // ==========================================

        static void Main(string[] args)
        {
            /*
             * Main 메서드에서 원본 코드의 동작을 재현하고 개선
             * 원본 코드의 각 줄을 분석하여 올바르게 동작하도록 수정
             */

            Console.WriteLine("C# 메서드 기초 학습 - 원본 코드 개선 버전");
            Console.WriteLine("Hello, World!");
            Console.WriteLine();

            // ==========================================
            // 원본 코드 라인별 분석 및 개선
            // ==========================================

            Console.WriteLine("=== 원본 코드 동작 재현 ===");

            /*
             * 원본: string Add(string x, string y) { return x + y; }
             * 문제: Main 메서드 내부에 정의되어 있었음 (C#에서는 불가능)
             * 해결: 클래스 레벨로 이동하고 static 추가
             */

            /*
             * 원본: Add(1.1f, 2.2f);
             * 문제: 결과를 사용하지 않음, float 오버로딩 메서드가 주석 처리됨
             * 해결: float 오버로딩 메서드 활성화하고 결과 출력
             */
            Console.WriteLine("🔸 float 오버로딩 테스트:");
            float floatResult = Add(1.1f, 2.2f);
            Console.WriteLine($"Add(1.1f, 2.2f) = {floatResult}");

            /*
             * 원본: //Console.WriteLine(Add("aaa","bbb"));
             * 문제: 주석 처리되어 실행되지 않음
             * 해결: 주석 해제하고 정상 실행
             */
            Console.WriteLine("🔸 string 오버로딩 테스트:");
            string stringResult = Add("aaa", "bbb");
            Console.WriteLine($"Add(\"aaa\", \"bbb\") = \"{stringResult}\"");

            /*
             * 원본: Console.WriteLine(Sub(5, 2));
             * 상태: 정상 동작 (static 추가 후)
             */
            Console.WriteLine("🔸 Sub 메서드 테스트:");
            int subResult = Sub(5, 2);
            Console.WriteLine($"Sub(5, 2) = {subResult}");

            /*
             * 원본: Print();
             * 상태: 정상 동작
             */
            Console.WriteLine("🔸 Print 메서드 테스트:");
            Print();

            /*
             * 원본: Console.WriteLine(Add(3, 2) - Sub(5, 2));
             * 분석: Add(3, 2) = 5, Sub(5, 2) = 3, 결과 = 5 - 3 = 2
             */
            Console.WriteLine("🔸 메서드 조합 테스트:");
            int combinedResult = Add(3, 2) - Sub(5, 2);
            Console.WriteLine($"Add(3, 2) - Sub(5, 2) = {Add(3, 2)} - {Sub(5, 2)} = {combinedResult}");

            /*
             * 원본: int num1 = Add(10, 3); // 13
             *       int num2 = Sub(16, 3); // 13
             *       Console.WriteLine(num1 + num2); // 26
             */
            Console.WriteLine("🔸 변수에 결과 저장 후 활용:");
            int num1 = Add(10, 3);    // 13
            int num2 = Sub(16, 3);    // 13
            Console.WriteLine($"num1 = Add(10, 3) = {num1}");
            Console.WriteLine($"num2 = Sub(16, 3) = {num2}");
            Console.WriteLine($"num1 + num2 = {num1} + {num2} = {num1 + num2}");

            /*
             * 원본: int num = 200;
             *       num1 = Add(num, 3); //203
             *       int num3 = 50;
             *       num2 = Sub(num, num3); // 150
             */
            Console.WriteLine("🔸 변수를 매개변수로 사용:");
            int num = 200;
            num1 = Add(num, 3);       // 203
            int num3 = 50;
            num2 = Sub(num, num3);    // 150
            Console.WriteLine($"num = {num}");
            Console.WriteLine($"num1 = Add(num, 3) = Add({num}, 3) = {num1}");
            Console.WriteLine($"num3 = {num3}");
            Console.WriteLine($"num2 = Sub(num, num3) = Sub({num}, {num3}) = {num2}");

            // ==========================================
            // 원본에서 정의되었지만 사용되지 않은 메서드들 테스트
            // ==========================================

            Console.WriteLine();
            Console.WriteLine("=== 원본에 정의된 미사용 메서드들 테스트 ===");

            /*
             * 원본에서 Mul, Div 메서드가 정의되어 있었지만 호출되지 않았음
             * static 추가 후 정상 동작 확인
             */
            Console.WriteLine("🔸 Mul 메서드 테스트:");
            int mulResult = Mul(6, 7);
            Console.WriteLine($"Mul(6, 7) = {mulResult}");

            Console.WriteLine("🔸 Div 메서드 테스트:");
            double divResult = Div(15, 4);
            Console.WriteLine($"Div(15, 4) = {divResult}");

            // 0으로 나누기 테스트
            Console.WriteLine("🔸 Div 메서드 예외 처리 테스트:");
            double divByZero = Div(10, 0);
            Console.WriteLine($"Div(10, 0) = {divByZero}");

            // ==========================================
            // 메서드 오버로딩 완전 테스트
            // ==========================================

            Console.WriteLine();
            Console.WriteLine("=== 메서드 오버로딩 완전 테스트 ===");

            /*
             * 같은 이름 'Add'이지만 매개변수 타입에 따라 다른 메서드 호출
             * 컴파일러가 자동으로 적절한 메서드 선택
             */
            Console.WriteLine("🔸 Add 메서드 오버로딩 비교:");

            int intAdd = Add(5, 3);              // int 버전
            float floatAdd2 = Add(5.5f, 3.2f);  // float 버전
            string stringAdd2 = Add("Hello", " World");  // string 버전

            Console.WriteLine($"Add(5, 3) [int] = {intAdd}");
            Console.WriteLine($"Add(5.5f, 3.2f) [float] = {floatAdd2}");
            Console.WriteLine($"Add(\"Hello\", \" World\") [string] = \"{stringAdd2}\"");

            // ==========================================
            // 학습 정리
            // ==========================================

            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("📚 원본 코드에서 배운 주요 개념들");
            Console.WriteLine("========================================");

            Console.WriteLine("✅ 1. static 키워드의 중요성:");
            Console.WriteLine("   - Main에서 다른 메서드를 호출하려면 static 필요");
            Console.WriteLine("   - 원본의 Mul, Div 메서드가 호출되지 않은 이유");

            Console.WriteLine();
            Console.WriteLine("✅ 2. 메서드 오버로딩:");
            Console.WriteLine("   - 같은 이름, 다른 매개변수 타입으로 여러 메서드 정의");
            Console.WriteLine("   - Add(int, int), Add(float, float), Add(string, string)");

            Console.WriteLine();
            Console.WriteLine("✅ 3. 매개변수와 반환값:");
            Console.WriteLine("   - 메서드에 값을 전달하고 결과를 받아오는 방법");
            Console.WriteLine("   - void 메서드는 반환값 없음 (Print 메서드)");

            Console.WriteLine();
            Console.WriteLine("✅ 4. 메서드 조합:");
            Console.WriteLine("   - 한 메서드의 결과를 다른 메서드의 입력으로 사용");
            Console.WriteLine("   - Add(3, 2) - Sub(5, 2) 같은 복합 계산");

            Console.WriteLine();
            Console.WriteLine("✅ 5. 형변환과 타입 안전성:");
            Console.WriteLine("   - Div 메서드: int 매개변수 → double 반환");
            Console.WriteLine("   - (double) 명시적 형변환으로 정확한 나눗셈");

            Console.WriteLine();
            Console.WriteLine("프로그램을 종료하려면 아무 키나 누르세요...");
            Console.ReadKey();

            /*
             ================================================================================================
             원본 코드 분석 완료!
             ================================================================================================
             
             🎯 원본 코드의 핵심 학습 포인트:
             
             📝 주요 문제점들과 해결책:
             1. static 키워드 누락 → 메서드 호출 불가
             2. 메서드 정의 위치 문제 → 클래스 레벨로 이동
             3. 주석 처리된 오버로딩 → 활성화하여 동작 확인
             4. 결과 미사용 → 적절한 출력과 활용
             
             🔧 메서드 기본 구조:
             - static 반환타입 메서드명(매개변수)
             - return 문으로 값 반환 (void 제외)
             - 매개변수를 통한 데이터 전달
             
             🎭 오버로딩 개념:
             - 같은 이름, 다른 매개변수
             - 타입별로 적절한 메서드 자동 선택
             - Add(int), Add(float), Add(string)
             
             💡 실무 활용:
             - 코드 재사용성 (같은 기능을 여러 곳에서 사용)
             - 모듈화 (복잡한 작업을 작은 단위로 분리)
             - 가독성 (메서드명으로 코드 의도 명확히 표현)
             
             ================================================================================================
             */
        }
    }
}