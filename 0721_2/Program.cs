namespace _0721_2
{
    internal class Program
    {
        // ------------------------
        // 📌 함수 오버로딩 예시
        // 같은 이름의 함수라도 매개변수의 '개수' 또는 '자료형'이 다르면 정의 가능
        // ------------------------

        static int Add(int x, int y)
        {
            return x + y;
        }

        // 매개변수 개수가 다른 경우 → 오버로딩 가능
        static int Add(int a)
        {
            return a + 1;
        }

        static int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        // 매개변수 자료형이 다른 경우 → 오버로딩 가능
        static double Add(double x, double y)
        {
            return x + y;
        }

        static float Add(float x, float y)
        {
            return x + y;
        }

        // ⚠️ 주의: 매개변수 이름만 다르고 타입/개수가 같으면 중복 정의 불가능
        /*
        static int Add(int a, int b)
        {
            return a + b;
        }
        */

        // ------------------------
        // 🙋‍♀️ 인사 메시지 출력 함수
        // ------------------------
        static void greet(string name)
        {
            Console.WriteLine($"안녕하세요. {name}님!");
        }

        // ------------------------
        // ✅ 나이 유효성 검사 함수
        // ------------------------
        static void CheckAge(int age)
        {
            if (age < 0)
            {
                Console.WriteLine("나이가 잘못되었습니다.");
                return; // 함수 강제 종료
            }

            Console.WriteLine("입력된 나이: " + age);
        }

        // ------------------------
        // 🔄 짝수 판별 함수 (true / false 반환)
        // ------------------------
        static bool isEven(int num)
        {
            return num % 2 == 0;
        }

        // ------------------------
        // 🚀 프로그램 시작 지점 (Main 함수)
        // ------------------------
        static void Main(string[] args)
        {
            // 덧셈 함수 호출
            int num = Add(1, 2);                // int 버전
            float num2 = Add(1.1f, 2.2f);       // float 버전

            Console.WriteLine(num);             // 출력: 3
            Console.WriteLine(num2);            // 출력: 3.3

            // 인사 함수 호출
            greet("에단");

            // 나이 확인 함수 호출
            CheckAge(-1);                       // 나이가 잘못되었습니다.

            // 반복문 + 함수 결합: 0부터 9까지 짝수 여부 출력
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i} is even? {isEven(i)}");
            }

            // ------------------------
            // ✍️ 연습 문제 아이디어 (추가 예정)
            // ------------------------

            // 1. 자기소개 함수: 이름과 나이를 매개변수로 받아 출력

            // 2. 평균 계산 함수: 두 수를 받아 평균을 반환

            // 3. 문자열이 비었는지 확인하는 함수: 빈 문자열이면 true 반환
        }
    }
}
