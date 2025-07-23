using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0723_2
{
    // 상속 없이 만들기

    //public class Dog 
    //{
    //    public string name;
    //    public string age;

    //    public void Eat() { }
    //    public void Sleep() { }
    //    public void Brak() { }
    //}

    //public class Cat
    //{
    //    public string name;
    //    public string age;

    //    public void Eat() { }
    //    public void Sleep() { }
    //    public void Meow() { }
    //}

    // 부모 클래스
    public class Animal
    {
        public string Name; // 어디서든 접근 가능
        protected int Age; // 부모,자식 클래스에서만 접근 가능
        private int Birth; // 현재 클래스에서만 접근 가능

        // 생성자
        // 상속 되지 않음 (필요시 별도로 호출 필요)
        public Animal(string name, int age) 
        {
            Console.WriteLine($"Animal 기본 생성장 호출됨");
            Name = name;
            Age = age;
        }

        public void Eat() {
            Console.WriteLine($"{Name}가 먹이를 먹다.");
        }
        public void Sleep() {
            Console.WriteLine($"{Name}가 잠을 잔다.");
        }
    }

    // 자식 클래스
    // 단일 상속만 지원 
    public class Dog : Animal
    {
        private string Breed;


        public Dog (string name, int age, string breed) : base(name, age) // 부모 생성자
        {
            Console.WriteLine($"Dog 생성자 호출됨");
            Console.WriteLine($"Dog {Name} {Age}살 ");
            Breed = breed;
        }

        public void Bark()
        {
            Console.WriteLine($"짖는다.");
        }

        public void ShowInfo()
        {
            Console.WriteLine(Name); // 접근 가능
            Console.WriteLine(Age); // protected 자식 클래스 접근 가능
            //Console.WriteLine(Birth); private 접근 불가
        }
    }

    public class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age) // 부모 생성자
        {
            Console.WriteLine($"Cat 생성자 호출됨");
            Console.WriteLine($"Cat {Name} {Age}살 ");
        }

        public void Meow()
        {
            Console.WriteLine($"야옹하다.");
        }
    }
}
