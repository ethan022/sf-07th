using System;

namespace _0721_3
{
    // ------------------------
    // 📌 1. 구조체(Struct) 정의
    // 구조체는 값 타입으로, 관련된 데이터를 하나로 묶어서 관리할 수 있습니다.
    // Stack 메모리에 저장되며, 복사 시 새로운 값이 생성됩니다.
    // ------------------------
    struct Point
    {
        // 📌 필드(Field): 구조체의 데이터를 저장하는 변수들
        public int x;  // x좌표
        public int y;  // y좌표  
        public int z;  // z좌표

        // 📌 생성자(Constructor): 구조체를 만들 때 기본값을 설정하는 특별한 함수
        // 구조체나 클래스의 이름과 동일하며, 반환 타입이 없습니다.
        public Point(int a, int b, int c)
        {
            x = a;  // 매개변수 a 값을 x에 할당
            y = b;  // 매개변수 b 값을 y에 할당
            z = c;  // 매개변수 c 값을 z에 할당
        }

        // 📌 메서드(Method): 구조체 안에 정의된 함수
        // 구조체의 데이터를 사용하여 특정 작업을 수행합니다.
        public void PrintInfo()
        {
            Console.WriteLine("구조체 안");
            Console.WriteLine("x:" + x + ", y: " + y + ", z:" + z);
        }
    }

    // ------------------------
    // 📌 주석 처리된 Student 구조체 예제 (연습용)
    // 구조체 변수명은 파스칼 케이스(첫 글자 대문자)를 사용하는 것을 권장합니다.
    // ------------------------
    /*
    struct Student 
    { 
        // 📌 속성(Properties) - 학생의 정보를 저장
        public int Age;        // 나이
        public string Name;    // 이름
        public string Gender;  // 성별

        // 📌 생성자 - 학생 객체 생성 시 초기값 설정
        public Student(int age, string name, string gender)
        {
            Age = age;
            Name = name;
            Gender = gender;
        }

        // 📌 동작(메서드) - 학생 정보 출력
        public void PrintInfo()
        {
            Console.WriteLine($"나이는 {Age}살, 이름은 {Name}, 성별은 {Gender} 입니다.");
        }
    }
    */

    // ------------------------
    // 📌 2. 클래스(Class) 정의 - Person
    // 클래스는 참조 타입으로, Heap 메모리에 저장됩니다.
    // 객체 지향 프로그래밍의 핵심 개념입니다.
    // ------------------------
    public class Person
    {
        // 📌 필드 선언
        public string name;     // public: 외부에서 직접 접근 가능
        private int age;        // private: 클래스 내부에서만 접근 가능

        // 📌 생성자 - this 키워드 사용 예제
        // this는 클래스 내부에서 자기 자신(현재 인스턴스)을 가리키는 키워드입니다.
        public Person(string name, int age)
        {
            this.name = name;   // this.name은 클래스의 필드, name은 매개변수
            this.age = age;     // this.age는 클래스의 필드, age는 매개변수
        }

        // 📌 메서드 - 객체의 정보를 출력
        public void PrintInfo()
        {
            Console.WriteLine($"{this.name} , {this.age}");
        }
    }

    // ------------------------
    // 📌 3. 계산기 클래스 - 메서드 오버로딩과 기본 연산 예제
    // 클래스 내부에 관련된 기능들을 그룹화하여 관리합니다.
    // ------------------------
    public class Calculator
    {
        // 📌 속성(필드)는 현재 없음 - 순수하게 계산 기능만 제공

        // 📌 메서드들 - 사칙연산 기능 구현

        // 더하기 연산
        public int Add(int x, int y)
        {
            return x + y;  // 두 정수의 합을 반환
        }

        // 빼기 연산
        public int Sub(int x, int y)
        {
            return x - y;  // 첫 번째 수에서 두 번째 수를 뺀 결과 반환
        }

        // 곱하기 연산
        public int Mul(int x, int y)
        {
            return x * y;  // 두 정수의 곱을 반환
        }

        // 나누기 연산 - double 타입 반환 (소수점 결과)
        public double Div(int x, int y)
        {
            return (double)x / y;  // 정수를 double로 캐스팅하여 실수 나눗셈 수행
        }
    }

    // ------------------------
    // 📌 4. 프로퍼티(Property)를 사용한 Student 클래스
    // 프로퍼티는 필드에 대한 안전한 접근을 제공하는 C#의 특별한 기능입니다.
    // get/set 접근자를 통해 데이터 유효성 검사와 접근 제어가 가능합니다.
    // ------------------------
    public class Student
    {
        // 📌 private 필드 - 외부에서 직접 접근 불가능
        private string name;
        private int age;

        // 📌 Name 프로퍼티 - name 필드에 대한 안전한 접근 제공
        public string Name
        {
            get  // 값을 읽을 때 실행되는 접근자
            {
                Console.WriteLine("이름을 내보냅니다.");  // 접근 로그 출력
                return name;  // private 필드 name의 값을 반환
            }
            set  // 값을 설정할 때 실행되는 접근자
            {
                name = value;  // value는 설정하려는 값을 나타내는 키워드
            }
        }

        // 📌 Age 프로퍼티 - 유효성 검사가 포함된 프로퍼티
        public int Age
        {
            get  // 값을 읽을 때 실행
            {
                Console.WriteLine("나이를 내보냅니다.");  // 접근 로그 출력
                return age;  // private 필드 age의 값을 반환
            }
            set  // 값을 설정할 때 실행
            {
                if (value < 0)  // 유효성 검사: 나이가 음수인지 확인
                {
                    Console.WriteLine("잘못되었습니다.");  // 오류 메시지 출력
                    return;  // 잘못된 값이면 설정하지 않고 종료
                }
                age = value;  // 유효한 값이면 필드에 저장
            }
        }

        // 📌 생성자 - 초기값 설정
        public Student(string name, int age)
        {
            this.name = name;  // private 필드에 직접 접근 (같은 클래스 내부이므로 가능)
            this.age = age;    // private 필드에 직접 접근
        }

        // 📌 메서드 - 학생 정보 출력
        public void PrintInfo()
        {
            Console.WriteLine($"{name}, {age}");  // private 필드에 직접 접근
        }
    }

    // ------------------------
    // 📌 프로그램 진입점
    // ------------------------
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== C# 구조체와 클래스 예제 ===\n");

            // 📌 구조체 사용 예제
            Console.WriteLine("📌 구조체(Point) 사용 예제:");

            // 구조체를 생성자를 통해 생성
            Point p = new Point(5, 60, 23);  // x=5, y=60, z=23으로 초기화
            p.PrintInfo();  // 구조체의 PrintInfo 메서드 호출

            // 구조체의 필드값 직접 변경
            p.x = 20;
            p.y = 30;
            p.z = 20;

            p.PrintInfo();  // 변경된 값 출력
            Console.WriteLine();

            // 📌 주석 처리된 Student 구조체 사용 예제
            /*
            Student st = new Student(30, "에단", "남성");
            st.PrintInfo();
            */

            // 📌 Person 클래스 사용 예제
            Console.WriteLine("📌 클래스(Person) 사용 예제:");

            Person p1 = new Person("에단", 30);  // Person 객체 생성
            p1.PrintInfo();  // "에단 , 30" 출력

            p1.name = "홍길동";  // public 필드이므로 직접 접근 가능
            p1.PrintInfo();     // "홍길동 , 30" 출력

            // p1.age = 20;     // private 필드이므로 외부에서 접근 불가능 (컴파일 오류)
            p1.PrintInfo();     // "홍길동 , 30" 출력 (age는 변경되지 않음)
            Console.WriteLine();

            // 📌 Calculator 클래스 사용 예제
            Console.WriteLine("📌 계산기 클래스 사용 예제:");

            Calculator cal = new Calculator();  // Calculator 객체 생성
            Console.WriteLine($"3 + 4 = {cal.Add(3, 4)}");    // 7 출력
            Console.WriteLine($"3 - 4 = {cal.Sub(3, 4)}");    // -1 출력
            Console.WriteLine($"3 * 4 = {cal.Mul(3, 4)}");    // 12 출력
            Console.WriteLine($"3 / 4 = {cal.Div(3, 4)}");    // 0.75 출력 (실수 나눗셈)
            Console.WriteLine();

            // 📌 프로퍼티를 사용한 Student 클래스 예제
            Console.WriteLine("📌 프로퍼티를 사용한 Student 클래스 예제:");

            Student st1 = new Student("에단", 30);  // Student 객체 생성

            // 프로퍼티를 통한 접근 (get 접근자 실행)
            // string name = st1.Name;  // "이름을 내보냅니다." 출력 후 값 반환
            // int age = st1.Age;       // "나이를 내보냅니다." 출력 후 값 반환

            // 프로퍼티를 통한 유효성 검사 (set 접근자 실행)
            st1.Age = -1;  // "잘못되었습니다." 출력 후 값이 설정되지 않음

            Console.WriteLine("현재 학생 정보:");
            st1.PrintInfo();  // "에단, 30" 출력 (나이는 -1로 변경되지 않음)

            Console.WriteLine("\n프로그램이 종료되었습니다. 아무 키나 누르세요...");
            Console.ReadKey();
        }
    }
}