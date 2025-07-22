using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0722
{
    public partial class Person
    {
        public string name;
        public int age;

        // 생성자
        public Person()
        {
            this.name = "홍길동";
            this.age = 20;
            Console.WriteLine("첫번째 생성자");
        }
        public Person(string name)
        {
            this.name = name;
            this.age = 34;
            Console.WriteLine("두번째 이름 생성자");
        }
        public Person(int age)
        {
            this.name = "마크";
            this.age = age;
            Console.WriteLine("세번째 나이 생성자");
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            Console.WriteLine("네번째 이름 나이 생성자");
        }
        ~Person()
        {
            Console.WriteLine("소멸자 호출");
        }

        public void PrintInfo()
        {
            Console.WriteLine($"이름: {name} 나이: {age}");
        }
    }

}
