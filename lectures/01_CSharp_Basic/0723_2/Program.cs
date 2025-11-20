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
    // 메서드 재정의 (override, virtual)
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
            Console.WriteLine("========================================");
            Console.WriteLine("🌱 상속(Inheritance) 예제 프로그램");
            Console.WriteLine("========================================");
            Console.WriteLine();

            // ==========================================
            // Part 1: 동물 클래스 상속 테스트
            // ==========================================

            Console.WriteLine("=== Part 1: 동물 클래스 상속 테스트 ===");
            Console.WriteLine();

            /*
             * 🐶 Dog 객체 생성 과정 분석:
             * 
             * new Dog("강아지", 3, "잡종") 호출 시 일어나는 일:
             * 1. Dog 생성자가 호출됨
             * 2. Dog 생성자에서 base(name, age) 실행
             * 3. Animal 부모 생성자가 먼저 실행됨
             * 4. Animal 생성자 완료 후 Dog 생성자 본문 실행
             * 5. Dog 고유 속성(breed) 초기화
             * 6. Dog 객체 생성 완료
             * 
             * 이 과정에서 "Animal 생성자 호출" → "Dog 생성자 호출" 순서로 출력됨
             */
            Console.WriteLine("🐶 Dog 객체 생성 (부모 생성자 + 자식 생성자 호출):");
            Dog dog = new Dog("강아지", 3, "잡종");
            Console.WriteLine();

            /*
             * Dog 객체의 다양한 기능 테스트:
             * 
             * 상속받은 기능들:
             * - dog.Eat()   : Animal 클래스에서 상속받은 메서드
             * - dog.Sleep() : Animal 클래스에서 상속받은 메서드
             * 
             * Dog 고유 기능:
             * - dog.Bark()  : Dog 클래스에서만 정의된 메서드
             * 
             * 재정의된 기능:
             * - dog.MakeSound() : Animal의 virtual 메서드를 Dog에서 override
             */
            Console.WriteLine("🔹 Dog의 상속받은 기능 사용:");
            dog.Eat();    // Animal에서 상속받은 메서드 → "강아지이(가) 음식을 먹습니다"
            dog.Sleep();  // Animal에서 상속받은 메서드 → "강아지이(가) 잠을 잡니다"

            Console.WriteLine("🔹 Dog의 고유 기능 사용:");
            dog.Bark();   // Dog만의 고유 메서드 → "강아지이(가) 큰 소리로 짖습니다"

            Console.WriteLine("🔹 Dog의 재정의된 기능 사용:");
            dog.MakeSound(); // Animal의 MakeSound()를 Dog에서 재정의 → "강아지: 멍멍!"

            Console.WriteLine();

            /*
             * 🐱 Cat 객체 생성 과정:
             * Dog와 동일한 상속 구조를 가지지만 Cat만의 고유한 특성을 가짐
             * - Animal 부모 생성자 호출 → Cat 생성자 호출
             */
            Console.WriteLine("🐱 Cat 객체 생성 (부모 생성자 + 자식 생성자 호출):");
            Cat cat = new Cat("고양이", 5);
            Console.WriteLine();

            /*
             * Cat 객체의 기능 테스트:
             * - 상속받은 기능은 Dog와 동일 (Eat, Sleep)
             * - 고유 기능은 Cat만의 것 (Meow)
             * - 재정의된 기능은 Cat만의 구현 (MakeSound → "야옹!")
             */
            Console.WriteLine("🔹 Cat의 상속받은 기능 사용:");
            cat.Eat();    // Animal에서 상속 → "고양이이(가) 음식을 먹습니다"
            cat.Sleep();  // Animal에서 상속 → "고양이이(가) 잠을 잡니다"

            Console.WriteLine("🔹 Cat의 고유 기능 사용:");
            cat.Meow();   // Cat만의 고유 메서드 → "고양이이(가) 부드럽게 야옹거립니다"

            Console.WriteLine("🔹 Cat의 재정의된 기능 사용:");
            cat.MakeSound(); // Animal의 MakeSound()를 Cat에서 재정의 → "고양이: 야옹!"

            Console.WriteLine();

            // ==========================================
            // Part 2: 다형성(Polymorphism) 동작 확인
            // ==========================================

            Console.WriteLine("=== Part 2: 다형성 동작 확인 ===");
            Console.WriteLine();

            /*
             * 다형성의 핵심 개념 실증:
             * 
             * 같은 메서드(MakeSound) 호출이지만:
             * - Dog 객체: "멍멍!" 출력
             * - Cat 객체: "야옹!" 출력
             * 
             * 이는 런타임에 실제 객체의 타입을 확인하여
             * 해당 클래스에서 재정의된 메서드를 호출하기 때문
             * 
             * 컴파일타임: MakeSound() 메서드 존재 확인
             * 런타임: 실제 객체 타입에 따른 적절한 구현 실행
             */
            Console.WriteLine("🎭 다형성: 같은 메서드, 다른 동작");
            Console.WriteLine("두 동물이 소리를 내봅시다:");

            dog.MakeSound();  // Dog에서 재정의된 MakeSound() 실행 → "강아지: 멍멍!"
            cat.MakeSound();  // Cat에서 재정의된 MakeSound() 실행 → "고양이: 야옹!"

            Console.WriteLine("→ 같은 MakeSound() 호출이지만 각각 다른 소리!");
            Console.WriteLine();

            // ==========================================
            // Part 3: 과일 클래스 상속 테스트
            // ==========================================

            Console.WriteLine("=== Part 3: 과일 클래스 상속 테스트 ===");
            Console.WriteLine();

            /*
             * 과일 클래스 계층 구조 테스트:
             * 
             * Fruit (부모 클래스)
             * ├─ Apple (자식 클래스) - 사과, 당도 정보 추가
             * └─ Lemon (자식 클래스) - 레몬, 신맛 정보 추가
             * 
             * 각 과일은 공통 기능(ShowInfo, Taste)을 상속받으면서도
             * 자신만의 고유한 특성과 구현을 가짐
             */
            Console.WriteLine("🍎 과일 객체들 생성:");

            /*
             * Fruit 기본 객체:
             * - 과일의 기본 특성만 가짐 (이름, 색상)
             * - 기본 구현된 ShowInfo(), Taste() 메서드 사용
             */
            Fruit fruit = new Fruit("바나나", "노랑색");

            /*
             * Apple 객체:
             * - Fruit의 기본 특성 + 당도(sweetness) 정보
             * - ShowInfo()와 Taste() 메서드를 Apple에 맞게 재정의
             * - 당도에 따른 다른 맛 표현
             */
            Apple apple = new Apple("사과", "빨간색", 8);

            /*
             * Lemon 객체:
             * - Fruit의 기본 특성 + 신맛(sourness) 정보  
             * - ShowInfo()와 Taste() 메서드를 Lemon에 맞게 재정의
             * - 신맛에 따른 다른 맛 표현
             */
            Lemon lemon = new Lemon("레몬", "노랑색", 9);

            Console.WriteLine();

            /*
             * 각 과일의 정보 출력 및 맛 테스트:
             * 
             * 다형성 동작 확인:
             * - 모든 과일이 ShowInfo(), Taste() 메서드를 가짐
             * - 하지만 각각 다른 구현으로 다른 결과 출력
             */
            Console.WriteLine("🔹 과일별 정보 출력 및 맛 테스트:");
            Console.WriteLine();

            /*
             * 바나나 (기본 Fruit):
             * - ShowInfo(): 기본 정보만 출력 (이름, 색상)
             * - Taste(): 일반적인 맛 표현
             */
            Console.WriteLine("[🍌 바나나 테스트]");
            fruit.ShowInfo();  // Fruit의 기본 ShowInfo() 실행
            fruit.Taste();     // Fruit의 기본 Taste() 실행
            Console.WriteLine();

            /*
             * 사과 (Apple):
             * - ShowInfo(): 기본 정보 + 당도 정보 출력
             * - Taste(): 당도에 따른 구체적인 맛 표현
             */
            Console.WriteLine("[🍎 사과 테스트]");
            apple.ShowInfo();  // Apple에서 재정의된 ShowInfo() 실행 (당도 포함)
            apple.Taste();     // Apple에서 재정의된 Taste() 실행 (당도별 표현)
            Console.WriteLine();

            /*
             * 레몬 (Lemon):
             * - ShowInfo(): 기본 정보 + 신맛 정보 출력
             * - Taste(): 신맛에 따른 구체적인 맛 표현
             */
            Console.WriteLine("[🍋 레몬 테스트]");
            lemon.ShowInfo();  // Lemon에서 재정의된 ShowInfo() 실행 (신맛 포함)
            lemon.Taste();     // Lemon에서 재정의된 Taste() 실행 (신맛별 표현)
            Console.WriteLine();

            // ==========================================
            // Part 4: 상속의 핵심 개념 정리
            // ==========================================

            Console.WriteLine("========================================");
            Console.WriteLine("🎓 상속의 핵심 개념 정리");
            Console.WriteLine("========================================");
            Console.WriteLine();

            Console.WriteLine("✅ 1. 코드 재사용성 확인:");
            Console.WriteLine("   • Animal의 Eat(), Sleep() → Dog, Cat 모두 사용");
            Console.WriteLine("   • Fruit의 기본 구조 → Apple, Lemon이 확장하여 사용");
            Console.WriteLine();

            Console.WriteLine("✅ 2. 확장성 확인:");
            Console.WriteLine("   • Dog = Animal 기능 + Bark() 고유 기능");
            Console.WriteLine("   • Apple = Fruit 기능 + 당도 정보 + 특화된 맛 표현");
            Console.WriteLine();

            Console.WriteLine("✅ 3. 다형성 확인:");
            Console.WriteLine("   • 같은 MakeSound() 호출 → Dog: 멍멍, Cat: 야옹");
            Console.WriteLine("   • 같은 Taste() 호출 → Apple: 당도별, Lemon: 신맛별 표현");
            Console.WriteLine();

            Console.WriteLine("✅ 4. 메서드 재정의 확인:");
            Console.WriteLine("   • virtual (부모): 재정의 가능한 메서드 선언");
            Console.WriteLine("   • override (자식): 부모 메서드를 새롭게 구현");
            Console.WriteLine();

            Console.WriteLine("✅ 5. 생성자 체이닝 확인:");
            Console.WriteLine("   • 자식 객체 생성 시 부모 생성자 먼저 호출");
            Console.WriteLine("   • base() 키워드로 부모 생성자에 매개변수 전달");
            Console.WriteLine();

            /*
             * 상속을 통해 얻을 수 있는 실무적 이점들:
             * 
             * 1. 개발 효율성:
             *    - 공통 기능을 한 번만 작성하면 여러 클래스에서 재사용
             *    - 중복 코드 제거로 개발 시간 단축
             * 
             * 2. 유지보수성:
             *    - 공통 로직 변경 시 부모 클래스만 수정
             *    - 버그 수정이나 기능 개선이 모든 자식 클래스에 자동 반영
             * 
             * 3. 확장성:
             *    - 기존 코드 수정 없이 새로운 자식 클래스 추가 가능
             *    - 새로운 동물, 새로운 과일 클래스를 쉽게 확장
             * 
             * 4. 다형성 지원:
             *    - 부모 타입으로 여러 자식 객체를 일관되게 처리
             *    - 배열이나 컬렉션에 다양한 타입을 함께 저장 가능
             */

            Console.WriteLine("🚀 실무에서의 상속 활용 예시:");
            Console.WriteLine("   • 게임: Character ← Warrior, Mage, Archer");
            Console.WriteLine("   • UI: Control ← Button, TextBox, Label");
            Console.WriteLine("   • 데이터: Person ← Customer, Employee, Supplier");
            Console.WriteLine("   • 파일: Document ← TextDocument, ImageDocument");

            Console.WriteLine("\n프로그램을 종료하려면 아무 키나 누르세요...");
            Console.ReadKey(); // 콘솔 창 닫힘 방지

            /*
             ================================================================================================
             상속 학습 완료! 
             ================================================================================================
             
             이 프로그램을 통해 학습한 주요 개념들:
             
             🏗️ 상속의 기본 개념:
             - 부모 클래스의 기능을 자식 클래스가 물려받음
             - class Child : Parent 문법
             - IS-A 관계 (Dog IS-A Animal)
             
             🔧 생성자와 상속:
             - 자식 객체 생성 시 부모 생성자 먼저 호출
             - base() 키워드로 부모 생성자 호출
             - 생성자 체이닝을 통한 올바른 초기화
             
             🎭 메서드 재정의:
             - virtual (부모): 재정의 가능
             - override (자식): 새로운 구현 제공
             - 다형성을 통한 런타임 메서드 결정
             
             🔐 접근 제한자:
             - public: 모든 곳에서 접근 가능
             - protected: 자식 클래스에서만 접근 가능
             - private: 해당 클래스에서만 접근 가능
             
             💡 실무 활용:
             - 코드 재사용성 향상
             - 유지보수성 개선  
             - 시스템 확장성 제공
             - 다형성을 통한 유연한 설계
             
             ================================================================================================
             */
        }
    }
}