namespace _0721_2
{
    internal class Program
    {
        // 함수 오버로딩
        // (같은 이름, 다른 매개변수)
        static int Add(int x, int y )
        {
            return x + y;
        }
        // 매개 변수의 이름만 다르면 사용 불가능
        //static int Add(int a, int b)
        //{
        //    return x + y;
        //}
        // 매개 변수의 개수가 다르면 사용 가능 
        static int Add(int a)
        {
            return a +1;
        }
        // 매개 변수의 개수가 다르면 사용 가능 
        static int Add(int a, int b, int c) {
            return a + b + c;
        }
        // 매개 변수의 자료형이 다르면 사용 가능
        static double Add(double x, double y) {
            return x + y;
        }
        static float Add(float x, float y) 
        {
            return x + y;
        }

        // greet 함수 만들어서 출력
        static void greet(string name)
        {
            // 출력
            // 안녕하세요 {이름} 님!
            Console.WriteLine($"안녕하세요. {name}님!");
        }

        // return 키워드
        static void CheckAge(int age) // 10
        {
            if (age < 0)
            {
                Console.WriteLine("나이가 잘못되었습니다.");
                return;
            }
            Console.WriteLine("입력된 나이: " + age);
        }

        // 짝수인지 홀수인지 검사하는 함수
        static bool isEven(int num)
        {
            return num % 2 == 0;
        }

        // 메인 함수 안에서만 작동
        static void Main(string[] args)
        {
            int num = Add(1, 2);
            Console.WriteLine(num);
            float num2 = Add(1.1f, 2.2f);
            Console.WriteLine(num2);

            // 이름을 입력 해주세요.
            greet("에단");

            CheckAge(-1);

            // 메서드와 반복문/ 조건문 결합
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(isEven(i));
            }


            // 자기소개 출력 함수
            // 이름, 나이를 출력하세요.


            // 두 수의 평균을 반환하는 함수


            // 입력한 문자열이 비었는지 확인 함수


        }
    }
}
