using System;

namespace _0721_2
{
    internal class Program
    {
        // ------------------------
        // 📌 함수 오버로딩(Method Overloading) 예시
        // 같은 이름의 함수라도 매개변수의 '개수' 또는 '자료형'이 다르면 정의 가능합니다.
        // 컴파일러가 호출 시 전달된 인수의 타입과 개수를 보고 적절한 함수를 선택합니다.
        // ------------------------

        // 📌 기본 Add 함수: 두 개의 정수를 받아 합을 반환
        static int Add(int x, int y)
        {
            return x + y;  // 두 정수의 합을 반환
        }

        // 📌 매개변수 개수가 다른 경우 → 오버로딩 가능
        // 하나의 정수를 받아 1을 더한 값을 반환
        static int Add(int a)
        {
            return a + 1;  // 입력값에 1을 더해서 반환
        }

        // 📌 매개변수 개수가 다른 경우 → 오버로딩 가능
        // 세 개의 정수를 받아 합을 반환
        static int Add(int a, int b, int c)
        {
            return a + b + c;  // 세 정수의 합을 반환
        }

        // 📌 매개변수 자료형이 다른 경우 → 오버로딩 가능
        // 두 개의 double 타입을 받아 합을 반환
        static double Add(double x, double y)
        {
            return x + y;  // 두 실수의 합을 반환 (double 타입)
        }

        // 📌 매개변수 자료형이 다른 경우 → 오버로딩 가능
        // 두 개의 float 타입을 받아 합을 반환
        static float Add(float x, float y)
        {
            return x + y;  // 두 실수의 합을 반환 (float 타입)
        }

        // ⚠️ 주의: 매개변수 이름만 다르고 타입/개수가 같으면 중복 정의 불가능
        // 아래 코드는 컴파일 오류가 발생합니다 (이미 위에 같은 시그니처의 함수가 있음)
        /*
        static int Add(int a, int b)  // 매개변수 이름만 다름 (x,y → a,b) → 오류!
        {
            return a + b;
        }
        */

        // ------------------------
        // 🙋‍♀️ 인사 메시지 출력 함수
        // void 타입: 반환값이 없는 함수 (출력만 수행)
        // ------------------------
        static void greet(string name)
        {
            Console.WriteLine($"안녕하세요. {name}님!");  // 문자열 보간을 사용한 인사 메시지 출력
        }

        // ------------------------
        // ✅ 나이 유효성 검사 함수
        // 조건문과 return을 사용한 함수 제어 예제
        // ------------------------
        static void CheckAge(int age)
        {
            if (age < 0)  // 나이가 음수인 경우 (잘못된 입력)
            {
                Console.WriteLine("나이가 잘못되었습니다.");
                return; // 함수를 강제로 종료하고 호출한 곳으로 돌아감
            }
            // 위의 if문에서 return이 실행되지 않았다면 여기가 실행됨
            Console.WriteLine("입력된 나이: " + age);
        }

        // ------------------------
        // 🔄 짝수 판별 함수 (true / false 반환)
        // bool 타입을 반환하는 함수 예제
        // ------------------------
        static bool isEven(int num)
        {
            return num % 2 == 0;  // num을 2로 나눈 나머지가 0이면 짝수이므로 true, 아니면 false 반환
        }

        // ------------------------
        // 👤 자기소개 함수
        // 여러 개의 매개변수를 받아 조합하여 출력하는 함수
        // ------------------------
        static void Introduce(string name, int age)
        {
            Console.WriteLine($"안녕하세요. 저는 {name}이고, 나이는 {age} 입니다.");
        }

        // ------------------------
        // 📊 평균 계산 함수
        // 정수를 받아 실수로 반환하는 함수 (타입 변환 예제)
        // ------------------------
        static double Avg(int x, int y)
        {
            return (x + y) / 2.0;  // 정수 나눗셈이 아닌 실수 나눗셈을 위해 2.0으로 나눔
            // 또는 return (double)(x + y) / 2; 로도 가능
        }

        // ------------------------
        // 🔍 문자열 확인 함수
        // 삼항 연산자를 사용한 조건부 반환 예제
        // ------------------------
        static bool IsEmpty(string str)
        {
            // 📌 삼항 연산자 사용: 조건 ? 참일때값 : 거짓일때값
            return str == "" ? true : false;

            // 위 코드는 아래 if-else문과 동일한 동작을 합니다:
            /*
            if (str == "")
            {
                return true;    // 빈 문자열이면 true 반환
            } 
            else
            {
                return false;   // 빈 문자열이 아니면 false 반환
            }
            */

            // 참고: 더 간단하게 return str == ""; 로도 작성 가능
        }

        // ------------------------
        // 🚀 프로그램 시작 지점 (Main 함수)
        // 모든 C# 프로그램의 진입점이 되는 함수
        // ------------------------
        static void Main(string[] args)
        {
            Console.WriteLine("=== C# 함수 오버로딩과 메서드 예제 ===\n");

            // 📌 함수 오버로딩 테스트
            Console.WriteLine("📌 함수 오버로딩 테스트:");

            // 덧셈 함수 호출 - 컴파일러가 인수 타입에 따라 적절한 함수를 선택
            int num = Add(1, 2);                // int Add(int x, int y) 호출
            int num3 = Add(5);                  // int Add(int a) 호출
            int num4 = Add(1, 2, 3);            // int Add(int a, int b, int c) 호출
            double num5 = Add(1.5, 2.5);        // double Add(double x, double y) 호출
            float num2 = Add(1.1f, 2.2f);       // float Add(float x, float y) 호출 (f를 붙여야 float)

            Console.WriteLine($"Add(1, 2) = {num}");           // 출력: 3
            Console.WriteLine($"Add(5) = {num3}");             // 출력: 6
            Console.WriteLine($"Add(1, 2, 3) = {num4}");       // 출력: 6
            Console.WriteLine($"Add(1.5, 2.5) = {num5}");      // 출력: 4
            Console.WriteLine($"Add(1.1f, 2.2f) = {num2}");    // 출력: 3.3000002 (float 정밀도 문제)
            Console.WriteLine();

            // 📌 인사 함수 호출
            Console.WriteLine("📌 인사 함수 테스트:");
            greet("에단");  // "안녕하세요. 에단님!" 출력
            greet("김철수");
            Console.WriteLine();

            // 📌 나이 확인 함수 호출
            Console.WriteLine("📌 나이 확인 함수 테스트:");
            CheckAge(-1);   // "나이가 잘못되었습니다." 출력 후 함수 종료
            CheckAge(25);   // "입력된 나이: 25" 출력
            CheckAge(0);    // "입력된 나이: 0" 출력
            Console.WriteLine();

            // 📌 반복문 + 함수 결합: 0부터 9까지 짝수 여부 출력
            Console.WriteLine("📌 짝수 판별 함수 테스트:");
            for (int i = 0; i < 10; i++)
            {
                // isEven 함수를 호출하여 각 숫자의 짝수 여부를 확인
                Console.WriteLine($"{i} is even? {isEven(i)}");
            }
            Console.WriteLine();

            // ------------------------
            // ✍️ 추가 함수 예제 테스트
            // ------------------------

            Console.WriteLine("📌 추가 함수 예제 테스트:");

            // 1. 자기소개 함수: 이름과 나이를 매개변수로 받아 출력
            Introduce("에단", 30);      // "안녕하세요. 저는 에단이고, 나이는 30 입니다." 출력
            Introduce("김영희", 25);

            // 2. 평균 계산 함수: 두 수를 받아 평균을 반환
            double numAvg = Avg(30, 20);  // (30 + 20) / 2.0 = 25.0
            Console.WriteLine($"30과 20의 평균: {numAvg}");

            double numAvg2 = Avg(10, 15);
            Console.WriteLine($"10과 15의 평균: {numAvg2}");

            // 3. 문자열이 비었는지 확인하는 함수: 빈 문자열이면 true 반환
            Console.WriteLine($"'aaa'가 빈 문자열인가? {IsEmpty("aaa")}");      // false 출력
            Console.WriteLine($"''가 빈 문자열인가? {IsEmpty("")}");           // true 출력
            Console.WriteLine($"'hello'가 빈 문자열인가? {IsEmpty("hello")}");  // false 출력

            Console.WriteLine("\n프로그램이 종료되었습니다. 아무 키나 누르세요...");
            Console.ReadKey();
        }
    }
}