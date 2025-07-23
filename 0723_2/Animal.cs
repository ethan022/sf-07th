using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0723_2
{
    // [상속을 사용하지 않은 경우]

    //// 🐶 강아지 클래스
    //public class Dog
    //{
    //    public string name;   // 이름
    //    public string age;    // 나이

    //    // 공통 기능
    //    public void Eat()     // 먹기
    //    {
    //        Console.WriteLine($"{name}가 먹습니다.");
    //    }

    //    public void Sleep()   // 자기
    //    {
    //        Console.WriteLine($"{name}가 잡니다.");
    //    }

    //    // Dog 고유 기능
    //    public void Bark()
    //    {
    //        Console.WriteLine("멍멍!");
    //    }
    //}

    //// 🐱 고양이 클래스
    //public class Cat
    //{
    //    public string name;   // 이름
    //    public string age;    // 나이

    //    // 공통 기능
    //    public void Eat()     // 먹기
    //    {
    //        Console.WriteLine($"{name}가 먹습니다.");
    //    }

    //    public void Sleep()   // 자기
    //    {
    //        Console.WriteLine($"{name}가 잡니다.");
    //    }

    //    // Cat 고유 기능
    //    public void Meow()
    //    {
    //        Console.WriteLine("야옹~");
    //    }
    //}

    // ================================
    // 부모 클래스 (Animal)
    // ================================
    // 개와 고양이와 같이 공통된 특성과 행동을 가지는 클래스
    public class Animal
    {
        public string Name;      // 어디서든 접근 가능한 필드
        protected int Age;       // 자식 클래스에서는 접근 가능하지만 외부에서는 접근 불가
        private int BirthYear;   // 오직 Animal 클래스 내부에서만 접근 가능

        // 생성자: 객체 생성 시 이름과 나이를 초기화
        public Animal(string name, int age)
        {
            Console.WriteLine("Animal 생성자 호출됨");
            Name = name;
            Age = age;
        }

        // 모든 동물이 공통적으로 가지는 행동 정의
        public void Eat()
        {
            Console.WriteLine($"{Name}가 먹이를 먹습니다.");
        }

        public void Sleep()
        {
            Console.WriteLine($"{Name}가 잠을 잡니다.");
        }
        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name}이(가) 어떤 소리를 냅니다.");
        }
    }

    // ================================
    // 자식 클래스 (Dog)
    // ================================
    // Animal 클래스를 상속받아 Dog 클래스 생성
    public class Dog : Animal
    {
        private string Breed; // 강아지의 품종 정보 (Dog 전용)

        // Dog 생성자
        // base(name, age)를 통해 부모 클래스 생성자 호출
        public Dog(string name, int age, string breed) : base(name, age)
        {
            Console.WriteLine("Dog 생성자 호출됨");
            //Console.WriteLine($"이름: {Name}, 나이: {Age}살, 품종: {breed}");
            Breed = breed;
        }

        // Dog만의 행동: 짖는 기능
        //public void Bark()
        //{
        //    Console.WriteLine("강아지가 짖습니다. 멍멍!");
        //}

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} 이(가) 멍멍! 짖습니다.");
        }



        // 접근 가능한 정보 출력
        public void ShowInfo()
        {
            Console.WriteLine($"이름: {Name}");   // public: 접근 가능
            Console.WriteLine($"나이: {Age}");     // protected: 자식 클래스에서 접근 가능
            // Console.WriteLine(BirthYear);      // ❌ private: 접근 불가능 (오류 발생)
        }
    }

    // ================================
    // 자식 클래스 (Cat)
    // ================================
    // Animal 클래스를 상속받아 Cat 클래스 생성
    public class Cat : Animal
    {
        // Cat 생성자
        public Cat(string name, int age) : base(name, age)
        {
            Console.WriteLine("Cat 생성자 호출됨");
            //Console.WriteLine($"이름: {Name}, 나이: {Age}살");
        }

        // Cat만의 행동: 야옹
        public void Meow()
        {
            Console.WriteLine("고양이가 야옹하고 웁니다.");
        }
    }
}
