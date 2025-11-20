using System;

/*
 ================================================================================================
 🎓 C# 메서드(함수) 기초 - 메서드 작성법 완전 가이드
 ================================================================================================
 
 📚 이 코드에서 배울 내용:
 1. 메서드란 무엇인가?
 2. 메서드는 어떻게 작성하는가?
 3. 메서드의 각 구성 요소 이해하기
 4. 매개변수는 어떻게 사용하는가?
 5. 반환값은 어떻게 처리하는가?
 6. 실제 메서드 작성 연습하기
 
 💡 메서드란? 
    특정한 일을 하는 코드 덩어리입니다.
    마치 계산기의 버튼처럼, 버튼을 누르면(호출하면) 정해진 일을 합니다!
 
 ================================================================================================
 */

namespace CSharpMethodsBasic
{
    class Program
    {
        // ==========================================
        // 📌 메서드 작성법 1단계: 가장 간단한 메서드
        // ==========================================

        /// <summary>
        /// 🎯 가장 간단한 메서드 - 인사말 출력하기
        /// </summary>
        static void SayHello()
        {
            /*
             * 📝 메서드 작성 기본 형태:
             * 
             * [접근제한자] [static] [반환타입] [메서드이름]()
             * {
             *     // 실행할 코드
             * }
             * 
             * 🔍 각 부분 설명:
             * static : Main에서 바로 호출할 수 있게 해주는 키워드
             * void   : 아무것도 돌려주지 않겠다는 의미
             * SayHello : 메서드의 이름 (동사로 짓는 것이 좋음)
             * ()     : 괄호 안에는 매개변수가 들어감 (지금은 비어있음)
             * { }    : 중괄호 안에 실제 실행할 코드 작성
             */
            Console.WriteLine("안녕하세요!");
        }

        /// <summary>
        /// 🎯 숫자를 출력하는 메서드
        /// </summary>
        static void PrintNumber()
        {
            /*
             * 🎪 연습: 다른 간단한 메서드 만들어보기
             * 
             * 이 메서드도 void 타입 - 화면에 출력만 하고 끝
             * 매개변수 없음 - 괄호가 비어있음
             */
            Console.WriteLine("숫자: 100");
        }

        // ==========================================
        // 📌 메서드 작성법 2단계: 매개변수가 있는 메서드
        // ==========================================

        /// <summary>
        /// 🎯 이름을 받아서 인사하는 메서드
        /// </summary>
        /// <param name="name">인사할 사람의 이름</param>
        static void SayHelloTo(string name)
        {
            /*
             * 📝 매개변수가 있는 메서드 작성법:
             * 
             * static void 메서드이름(타입 변수명)
             * 
             * 🔍 매개변수 설명:
             * string name - string 타입의 name이라는 매개변수
             * 
             * 💡 매개변수란?
             * 메서드가 일을 하기 위해 필요한 재료입니다.
             * 요리를 할 때 재료가 필요한 것처럼!
             * 
             * 🔄 사용 방법:
             * SayHelloTo("철수") → name에 "철수"가 들어감
             */
            Console.WriteLine($"안녕하세요, {name}님!");
        }

        /// <summary>
        /// 🎯 숫자를 받아서 출력하는 메서드
        /// </summary>
        /// <param name="number">출력할 숫자</param>
        static void PrintMyNumber(int number)
        {
            /*
             * 🎪 연습: 정수 매개변수 사용하기
             * 
             * int number - 정수 타입의 매개변수
             * 호출할 때: PrintMyNumber(50) → number에 50이 들어감
             */
            Console.WriteLine($"내가 좋아하는 숫자: {number}");
        }

        /// <summary>
        /// 🎯 두 개의 매개변수를 받는 메서드
        /// </summary>
        /// <param name="name">이름</param>
        /// <param name="age">나이</param>
        static void IntroducePerson(string name, int age)
        {
            /*
             * 📝 여러 매개변수가 있는 메서드 작성법:
             * 
             * static void 메서드이름(타입1 변수명1, 타입2 변수명2)
             * 
             * 💡 주의사항:
             * - 매개변수들은 쉼표(,)로 구분
             * - 각각 타입과 이름을 써야 함
             * - 순서가 중요함!
             * 
             * 🔄 호출 예시:
             * IntroducePerson("영희", 20) → name="영희", age=20
             */
            Console.WriteLine($"이름: {name}, 나이: {age}세");
        }

        // ==========================================
        // 📌 메서드 작성법 3단계: 값을 돌려주는 메서드
        // ==========================================

        /// <summary>
        /// 🎯 두 수를 더해서 결과를 돌려주는 메서드
        /// </summary>
        /// <param name="a">첫 번째 수</param>
        /// <param name="b">두 번째 수</param>
        /// <returns>두 수의 합</returns>
        static int AddNumbers(int a, int b)
        {
            /*
             * 📝 값을 돌려주는 메서드 작성법:
             * 
             * static [반환타입] 메서드이름(매개변수들)
             * {
             *     // 계산 코드
             *     return 결과값;
             * }
             * 
             * 🔍 새로운 부분들:
             * int     - void 대신 int (정수를 돌려주겠다는 의미)
             * return  - 계산한 결과를 호출한 곳으로 돌려주는 명령어
             * 
             * 💡 return의 역할:
             * 1. 계산 결과를 호출한 곳으로 전달
             * 2. 메서드 실행 즉시 종료
             * 
             * 🔄 사용 방법:
             * int result = AddNumbers(3, 5); → result에 8이 저장됨
             */
            int result = a + b;
            return result;  // 계산 결과를 돌려줌
        }

        /// <summary>
        /// 🎯 문자열을 만들어서 돌려주는 메서드
        /// </summary>
        /// <param name="firstName">이름</param>
        /// <param name="lastName">성</param>
        /// <returns>완성된 전체 이름</returns>
        static string MakeFullName(string firstName, string lastName)
        {
            /*
             * 🎪 연습: 문자열을 돌려주는 메서드
             * 
             * string - 문자열을 돌려주겠다는 의미
             * return으로 만든 문자열을 돌려줌
             */
            string fullName = lastName + firstName;
            return fullName;
        }

        /// <summary>
        /// 🎯 간단한 계산 메서드 - 제곱 구하기
        /// </summary>
        /// <param name="number">제곱할 숫자</param>
        /// <returns>제곱 결과</returns>
        static int GetSquare(int number)
        {
            /*
             * 🎪 연습: 더 간단하게 작성하기
             * 
             * 변수 없이 바로 return할 수도 있음
             */
            return number * number;
        }

        // ==========================================
        // 📌 메서드 작성법 4단계: 다양한 타입 연습
        // ==========================================

        /// <summary>
        /// 🎯 실수 계산 메서드
        /// </summary>
        /// <param name="radius">원의 반지름</param>
        /// <returns>원의 넓이</returns>
        static double GetCircleArea(double radius)
        {
            /*
             * 📝 실수(double) 타입 메서드 작성:
             * 
             * double - 소수점이 있는 숫자를 돌려줌
             * Math.PI - 원주율 상수 (3.14159...)
             */
            return Math.PI * radius * radius;
        }

        /// <summary>
        /// 🎯 참/거짓을 판단하는 메서드
        /// </summary>
        /// <param name="number">확인할 숫자</param>
        /// <returns>짝수이면 true, 홀수이면 false</returns>
        static bool IsEven(int number)
        {
            /*
             * 📝 bool 타입 메서드 작성:
             * 
             * bool - true 또는 false를 돌려줌
             * % 연산자 - 나머지를 구하는 연산자
             * number % 2 == 0 - 2로 나눈 나머지가 0이면 짝수
             */
            return number % 2 == 0;
        }

        // ==========================================
        // 🚀 Main 메서드 - 작성한 메서드들 테스트하기
        // ==========================================

        static void Main(string[] args)
        {
            Console.WriteLine("🎓 C# 메서드 작성법 학습 프로그램");
            Console.WriteLine("=================================");
            Console.WriteLine();

            // ==========================================
            // 📚 1단계: 간단한 메서드 호출하기
            // ==========================================

            Console.WriteLine("📚 1단계: 간단한 메서드 호출하기");
            Console.WriteLine("-------------------------------");

            /*
             * 🔄 메서드 호출 방법:
             * 
             * 메서드이름();  ← 매개변수가 없는 경우
             * 
             * 그냥 메서드 이름 뒤에 ()를 붙이면 됩니다!
             */

            Console.WriteLine("🎯 SayHello() 메서드 호출:");
            SayHello();  // "안녕하세요!" 출력

            Console.WriteLine();
            Console.WriteLine("🎯 PrintNumber() 메서드 호출:");
            PrintNumber();  // "숫자: 100" 출력

            Console.WriteLine();

            // ==========================================
            // 📚 2단계: 매개변수가 있는 메서드 호출하기
            // ==========================================

            Console.WriteLine("📚 2단계: 매개변수가 있는 메서드 호출하기");
            Console.WriteLine("------------------------------------");

            /*
             * 🔄 매개변수가 있는 메서드 호출 방법:
             * 
             * 메서드이름(값);  ← 매개변수가 1개인 경우
             * 메서드이름(값1, 값2);  ← 매개변수가 2개인 경우
             * 
             * 괄호 안에 필요한 값들을 넣어주면 됩니다!
             */

            Console.WriteLine("🎯 SayHelloTo() 메서드 호출:");
            SayHelloTo("철수");    // name에 "철수"가 들어감
            SayHelloTo("영희");    // name에 "영희"가 들어감

            Console.WriteLine();
            Console.WriteLine("🎯 PrintMyNumber() 메서드 호출:");
            PrintMyNumber(42);     // number에 42가 들어감
            PrintMyNumber(100);    // number에 100이 들어감

            Console.WriteLine();
            Console.WriteLine("🎯 IntroducePerson() 메서드 호출:");
            IntroducePerson("김철수", 25);  // name="김철수", age=25
            IntroducePerson("이영희", 30);  // name="이영희", age=30

            Console.WriteLine();

            // ==========================================
            // 📚 3단계: 값을 돌려주는 메서드 사용하기
            // ==========================================

            Console.WriteLine("📚 3단계: 값을 돌려주는 메서드 사용하기");
            Console.WriteLine("----------------------------------");

            /*
             * 🔄 값을 돌려주는 메서드 사용 방법:
             * 
             * 변수 = 메서드이름(값들);
             * 
             * 메서드가 계산한 결과를 변수에 저장할 수 있습니다!
             */

            Console.WriteLine("🎯 AddNumbers() 메서드 사용:");
            int sum1 = AddNumbers(10, 20);  // 10 + 20 = 30
            int sum2 = AddNumbers(5, 7);    // 5 + 7 = 12
            Console.WriteLine($"AddNumbers(10, 20) = {sum1}");
            Console.WriteLine($"AddNumbers(5, 7) = {sum2}");

            Console.WriteLine();
            Console.WriteLine("🎯 MakeFullName() 메서드 사용:");
            string fullName1 = MakeFullName("철수", "김");
            string fullName2 = MakeFullName("영희", "이");
            Console.WriteLine($"MakeFullName(\"철수\", \"김\") = {fullName1}");
            Console.WriteLine($"MakeFullName(\"영희\", \"이\") = {fullName2}");

            Console.WriteLine();
            Console.WriteLine("🎯 GetSquare() 메서드 사용:");
            int square1 = GetSquare(5);     // 5 * 5 = 25
            int square2 = GetSquare(8);     // 8 * 8 = 64
            Console.WriteLine($"GetSquare(5) = {square1}");
            Console.WriteLine($"GetSquare(8) = {square2}");

            Console.WriteLine();

            // ==========================================
            // 📚 4단계: 다양한 타입의 메서드 사용하기
            // ==========================================

            Console.WriteLine("📚 4단계: 다양한 타입의 메서드 사용하기");
            Console.WriteLine("--------------------------------");

            Console.WriteLine("🎯 GetCircleArea() 메서드 사용 (double 타입):");
            double area1 = GetCircleArea(3.0);
            double area2 = GetCircleArea(5.5);
            Console.WriteLine($"반지름 3.0인 원의 넓이: {area1:F2}");  // :F2는 소수점 2자리
            Console.WriteLine($"반지름 5.5인 원의 넓이: {area2:F2}");

            Console.WriteLine();
            Console.WriteLine("🎯 IsEven() 메서드 사용 (bool 타입):");
            bool isEven1 = IsEven(10);      // true (10은 짝수)
            bool isEven2 = IsEven(7);       // false (7은 홀수)
            Console.WriteLine($"10이 짝수인가? {isEven1}");
            Console.WriteLine($"7이 짝수인가? {isEven2}");

            Console.WriteLine();

            // ==========================================
            // 📚 5단계: 메서드 결과를 바로 사용하기
            // ==========================================

            Console.WriteLine("📚 5단계: 메서드 결과를 바로 사용하기");
            Console.WriteLine("------------------------------");

            /* x
             * 💡 고급 사용법:
             * 
             * 메서드의 결과를 변수에 저장하지 않고
             * 바로 다른 곳에 사용할 수도 있습니다!
             */

            Console.WriteLine("🎯 메서드 결과를 바로 출력하기:");
            Console.WriteLine($"AddNumbers(100, 200) = {AddNumbers(100, 200)}");
            Console.WriteLine($"GetSquare(12) = {GetSquare(12)}");

            Console.WriteLine();
            Console.WriteLine("🎯 메서드 결과를 조건문에 바로 사용하기:");
            if (IsEven(20))
            {
                Console.WriteLine("20은 짝수입니다!");
            }

            if (!IsEven(15))  // !는 반대를 의미 (true → false, false → true)
            {
                Console.WriteLine("15는 홀수입니다!");
            }

            Console.WriteLine();

            // ==========================================
            // 🎯 메서드 작성 핵심 정리
            // ==========================================

            Console.WriteLine("🎯 메서드 작성 핵심 정리");
            Console.WriteLine("====================");

            Console.WriteLine("✅ 메서드 작성 기본 형태:");
            Console.WriteLine("   static [반환타입] 메서드이름(매개변수들)");
            Console.WriteLine("   {");
            Console.WriteLine("       // 실행할 코드");
            Console.WriteLine("       return 결과;  // 반환타입이 void가 아닌 경우");
            Console.WriteLine("   }");

            Console.WriteLine();
            Console.WriteLine("✅ 반환 타입 종류:");
            Console.WriteLine("   void     - 아무것도 돌려주지 않음");
            Console.WriteLine("   int      - 정수를 돌려줌");
            Console.WriteLine("   string   - 문자열을 돌려줌");
            Console.WriteLine("   double   - 실수를 돌려줌");
            Console.WriteLine("   bool     - true/false를 돌려줌");

            Console.WriteLine();
            Console.WriteLine("✅ 매개변수 작성법:");
            Console.WriteLine("   매개변수 없음: ()");
            Console.WriteLine("   매개변수 1개: (int number)");
            Console.WriteLine("   매개변수 2개: (string name, int age)");

            Console.WriteLine();
            Console.WriteLine("✅ 메서드 호출법:");
            Console.WriteLine("   void 메서드: 메서드이름(값들);");
            Console.WriteLine("   반환 메서드: 변수 = 메서드이름(값들);");

            Console.WriteLine();
            Console.WriteLine("🎉 축하합니다! 메서드 작성법을 완전히 마스터했습니다!");
            Console.WriteLine();
            Console.WriteLine("프로그램을 종료하려면 아무 키나 누르세요...");
            Console.ReadKey();
        }
    }
}