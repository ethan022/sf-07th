using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0723
{
    // 정적 멤버 
    // 객체를 만들지 않고도 사용할수 있는 멤버

    //              일반 멤버           정적 멤버
    // 객체 생성    필수                불필요
    // 접근 방법    객체이름            클래스이름
    // 메모리       객체마다 개별공간   프로그램에서 하나만

    internal class Person
    {
        public string name;
        public int age;

        public void PrintInfo()
        {
            Console.WriteLine($"{name}, {age}");
        }
    }

    public class Math 
    {
        public static double PI = 3.1415;

        public static double GetCircleArea(double radius)
        {
            return PI * radius * radius;
        }
    }

}


