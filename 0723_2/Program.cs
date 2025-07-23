using System;

namespace _0723_2
{
    // ===========================================
    // 🌱 상속이란?
    // ===========================================
    // 기존(부모) 클래스의 속성과 메서드를
    // 새로운(자식) 클래스가 물려받는 것

    // 예시 구조:
    //
    //   Animal (부모 클래스)
    //     ├─ Dog     (자식 클래스)
    //     ├─ Cat     (자식 클래스)
    //     └─ Lion    (자식 클래스)
    //
    // Animal 클래스는 공통 속성/기능 보유:
    // - 이름(name), 나이(age)
    // - Eat(), Sleep()

    // Dog 클래스는 Animal의 기능 + 짖기(Bark)
    // Cat 클래스는 Animal의 기능 + 야옹(Meow)

    // ===========================================
    // ✅ 상속의 장점
    // ===========================================
    // 1. **코드 재사용성**:
    //    - 공통 기능을 부모 클래스에 한 번만 작성하면 됨
    // 2. **유지 보수성**:
    //    - 공통 로직 수정 시 부모 클래스만 수정하면 됨
    // 3. **확장성**:
    //    - 기존 기능을 유지한 채 새로운 기능 추가 가능

    // ===========================================
    // ✅ 접근 제한자 (Access Modifiers)
    // ===========================================
    // - public: 어디서든 접근 가능
    // - protected: 자식 클래스에서 접근 가능
    // - private: 해당 클래스 내에서만 접근 가능



    // 매서드 재정의 (override, virtual)
    // 모든 동물은 소리를 내지만, 각 동물마다 다른 소리를 냅니다.
    // 개 : 멍멍
    // 고양이 : 야옹
    // 소: 음메



    // ===========================================
    // ▶ 실행 예제 (Main)
    // ===========================================
    internal class Program
    {
        static void Main(string[] args)
        {
            // 🐶 Dog 객체 생성 (부모 생성자 + 자식 생성자 호출)
            Dog dog = new Dog("강아지", 3, "잡종");

            // 🔹 부모 클래스 기능 사용
            //dog.Eat();    // Animal → Eat()
            //dog.Sleep();  // Animal → Sleep()

            // 🔹 자식 클래스 고유 기능 사용
            //dog.Bark();   // Dog → Bark()

            Console.WriteLine();

            //// 🐱 Cat 객체 생성 (부모 생성자 + 자식 생성자 호출)
            Cat cat = new Cat("고양이", 5);

            //// 🔹 부모 클래스 기능 사용
            //cat.Eat();    // Animal → Eat()
            //cat.Sleep();  // Animal → Sleep()

            //// 🔹 자식 클래스 고유 기능 사용
            //cat.Meow();   // Cat → Meow()


            dog.MakeSound();
            cat.MakeSound();


            Fruit fruit = new Fruit("바나나", "노랑색");
            Apple apple = new Apple("사과", "빨간색", 8);
            Lemon lemon = new Lemon("레몬", "노랑색", 9);

            fruit.ShowInfo();
            fruit.Taste();

            apple.ShowInfo();
            apple.Taste();

            lemon.ShowInfo();
            lemon.Taste();


            Console.ReadKey(); // 콘솔 창 닫힘 방지
        }
    }
}
