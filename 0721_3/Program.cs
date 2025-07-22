namespace _0721_3
{
    // 1. 구조체 정의
    struct Point
    {
        // x좌표
        public int x;
        // y좌표
        public int y;
        // z좌표
        public int z;

        // 2. 생성자: 구조체를 만들 떄 기본값을 넣는 방법
        public Point(int a, int b, int c)
        {
            x = a; y = b; z = c;
        }

        // 3. 구조체 안에 함수
        public void PrintInfo()
        { 
            Console.WriteLine("구조체 안");
            Console.WriteLine("x:" + x + ", y: " + y + ", z:" + z);
        }
    }

    //struct Student { 
    
    //    // 구조체 변수명은 파스칼 케이스를 쓰는걸 권장합니다.
    //    // 속성
    //    public int Age;
    //    public string Name;
    //    public string Gender;

    //    // 생성자
    //    public Student(int age, string name, string gender)
    //    {
    //        Age = age;
    //        Name = name;
    //        Gender = gender;
    //    }

    //    // 동작
    //    public void PrintInfo()
    //    {
    //        Console.WriteLine($"나이는 {Age}살, 이름은 {Name}, 성별은 {Gender} 입니다.");
    //    }


    //}


    // 1. 학생이라는 구조체를 만들고

    // 2. 나이 이름 성별을 생성자에서 입력 받기

    // 3. 이후 PrintInfo 함수를 만들어 나이 이름 성별 출력하기 


    // 클래스
    public class Person { 
    
        public string name;
        private int age;

        //this는 클래스 내부에서 자기 자신을 가리키는 키워드
        public Person(string name, int age) {
            this.name = name;
            this.age = age;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{this.name} , {this.age}");
        }

    }

    // 계산기 클래스
    public class Calculator {

        // 속성 x


        // 동작? 매소드
        // 더하기
        public int Add(int x, int y)
        {
            return x + y;
        }

        // 빼기
        public int Sub(int x, int y)
        {
            return x - y;
        }
        // 곱하기
        public int Mul(int x, int y)
        {
            return x * y;
        }
        // 나누기 return (double) 
        public double Div(int x, int y)
        {
            return (double)x / y;
        }
    }

    public class Student
    {
        private string name;
        private int age;

        public string Name
        {
            get
            {
                Console.WriteLine("이름을 내보냅니다.");
                return name;
            }
            set
            { 
                name = value;
            }
        }

        public int Age
        {
            get
            {
                Console.WriteLine("나이를 내보냅니다.");
                return age; 
            }
            set 
            {
                if (value < 0) {
                    Console.WriteLine("잘못되었습니다.");
                    return;
                }
                age = value; 
            }
        }

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{name}, {age}");
        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {
            // 구조체를 생성
            Point p = new Point(5, 60, 23);
            p.PrintInfo();

            p.x = 20;
            p.y = 30;
            p.z = 20;

            p.PrintInfo();

            // 학생 객체를 생성
            //Student st = new Student(30, "에단", "남성");
            //st.PrintInfo();


            Person p1 = new Person("에단", 30);
            p1.PrintInfo();

            p1.name = "홍길동";
            p1.PrintInfo();
            //p1.Age = 20;
            p1.PrintInfo();

            Calculator cal = new Calculator();
            Console.WriteLine( cal.Add(3, 4));
            Console.WriteLine( cal.Sub(3, 4));
            Console.WriteLine( cal.Mul(3, 4));
            Console.WriteLine( cal.Div(3, 4));


            Student st1 = new Student("에단", 30);

            //string name = st1.Name;
            //int  age = st1.Age;
            st1.Age = -1;
        }
    }
}






// ㅅ