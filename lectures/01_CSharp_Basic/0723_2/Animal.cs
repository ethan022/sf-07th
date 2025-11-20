using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0723_2
{
    /*
     ================================================================================================
     상속 없이 클래스를 만들 때의 문제점 (주석 처리된 코드 분석)
     ================================================================================================
     
     아래 주석 처리된 코드는 상속을 사용하지 않았을 때의 문제점을 보여줍니다:
     
     ❌ 문제점들:
     1. 코드 중복: Dog와 Cat 클래스에서 name, age, Eat(), Sleep() 중복
     2. 유지보수 어려움: 공통 기능 수정 시 모든 클래스를 일일이 수정해야 함
     3. 일관성 부족: 같은 기능이지만 구현 방식이 달라질 수 있음
     4. 확장성 부족: 새로운 동물 추가 시 또 다시 중복 코드 작성
     
     💡 해결책:
     상속을 통해 공통 기능을 부모 클래스(Animal)에 정의하고,
     자식 클래스들이 이를 상속받아 중복을 제거하고 일관성을 확보
     
     ================================================================================================
     */

    // [상속을 사용하지 않은 경우 - 문제점 예시]
    /*
    // 🐶 강아지 클래스 (상속 없는 버전)
    public class Dog
    {
        public string name;   // 이름 - 다른 동물 클래스와 중복
        public string age;    // 나이 - 다른 동물 클래스와 중복
        
        // 공통 기능들 - 모든 동물 클래스에서 중복 구현
        public void Eat()     // 먹기 - 중복 코드!
        {
            Console.WriteLine($"{name}가 먹습니다.");
        }
        public void Sleep()   // 자기 - 중복 코드!
        {
            Console.WriteLine($"{name}가 잠을 잡니다.");
        }
        
        // Dog 고유 기능
        public void Bark()
        {
            Console.WriteLine("멍멍!");
        }
    }

    // 🐱 고양이 클래스 (상속 없는 버전)
    public class Cat
    {
        public string name;   // 이름 - Dog 클래스와 중복!
        public string age;    // 나이 - Dog 클래스와 중복!
        
        // 공통 기능들 - Dog 클래스와 완전히 동일한 코드 중복!
        public void Eat()     // 먹기 - 중복 코드!
        {
            Console.WriteLine($"{name}가 먹습니다.");
        }
        public void Sleep()   // 자기 - 중복 코드!
        {
            Console.WriteLine($"{name}가 잠을 잡니다.");
        }
        
        // Cat 고유 기능
        public void Meow()
        {
            Console.WriteLine("야옹~");
        }
    }
    */

    // ==========================================
    // 상속을 사용한 해결책
    // ==========================================

    /// <summary>
    /// Animal 부모 클래스 - 모든 동물의 공통 특성과 행동을 정의
    /// 개와 고양이 같이 공통된 특성과 행동을 가지는 클래스들의 기반
    /// </summary>
    public class Animal
    {
        // ========================================
        // 필드 선언 - 접근 제한자별로 구분
        // ========================================

        /*
         * 접근 제한자 (Access Modifiers) 상세 설명:
         * 
         * public: 어디서든 접근 가능
         * - 다른 클래스, 다른 네임스페이스에서도 접근 가능
         * - 외부에 공개되어야 하는 정보에 사용
         */
        public string Name;      // 동물 이름 - 어디서든 접근 가능

        /*
         * protected: 자식 클래스에서는 접근 가능, 외부에서는 접근 불가
         * - 상속 관계에서만 공유되는 정보
         * - 캡슐화를 유지하면서도 상속의 이점을 활용
         */
        protected int Age;       // 동물 나이 - 자식 클래스에서만 접근 가능

        /*
         * private: 오직 해당 클래스 내부에서만 접근 가능
         * - 완전히 숨겨져야 하는 내부 구현 정보
         * - 캡슐화의 핵심 원칙
         */
        private int BirthYear;   // 출생년도 - Animal 클래스 내부에서만 접근 가능

        // ========================================
        // 생성자 (Constructor)
        // ========================================

        /// <summary>
        /// Animal 클래스 생성자
        /// 객체 생성 시 반드시 호출되며, 기본 정보를 초기화
        /// </summary>
        /// <param name="name">동물의 이름</param>
        /// <param name="age">동물의 나이</param>
        public Animal(string name, int age)
        {
            /*
             * 생성자 실행 순서:
             * 1. 자식 클래스에서 new 키워드로 객체 생성 요청
             * 2. 자식 클래스 생성자에서 base() 호출
             * 3. 이 부모 클래스 생성자가 먼저 실행됨
             * 4. 부모 클래스 초기화 완료 후 자식 클래스 생성자 실행
             */
            Console.WriteLine("🐾 Animal 생성자 호출됨");

            Name = name;                           // public 필드 초기화
            Age = age;                             // protected 필드 초기화
            BirthYear = DateTime.Now.Year - age;   // private 필드 계산 및 초기화
        }

        // ========================================
        // 공통 메서드들 - 모든 동물이 공유하는 기능
        // ========================================

        /// <summary>
        /// 먹기 행동 - 모든 동물이 공통으로 가지는 행동
        /// 상속을 통해 모든 자식 클래스에서 사용 가능
        /// </summary>
        public void Eat()
        {
            /*
             * 공통 기능의 장점:
             * - 한 번만 구현하면 모든 자식 클래스에서 사용
             * - 수정이 필요할 때 이곳만 수정하면 모든 자식에 자동 반영
             * - 일관된 동작 보장
             */
            Console.WriteLine($"{Name}이(가) 먹이를 먹습니다. 🍽️");
        }

        /// <summary>
        /// 잠자기 행동 - 모든 동물이 공통으로 가지는 행동
        /// </summary>
        public void Sleep()
        {
            Console.WriteLine($"{Name}이(가) 잠을 잡니다. 😴");
        }

        // ========================================
        // 가상 메서드 (Virtual Method)
        // ========================================

        /// <summary>
        /// 소리내기 가상 메서드
        /// virtual 키워드로 자식 클래스에서 재정의(override) 가능
        /// </summary>
        public virtual void MakeSound()
        {
            /*
             * 가상 메서드의 특징:
             * - 기본 구현을 제공하면서도 자식에서 재정의 가능
             * - 자식 클래스에서 override하지 않으면 이 기본 구현 사용
             * - 다형성의 핵심 메커니즘
             */
            Console.WriteLine($"{Name}이(가) 어떤 소리를 냅니다. 🔊");
        }

        // ========================================
        // 내부 정보 접근 메서드 (선택사항)
        // ========================================

        /// <summary>
        /// 출생년도 조회 메서드 - private 필드에 안전하게 접근
        /// </summary>
        /// <returns>계산된 출생년도</returns>
        public int GetBirthYear()
        {
            return BirthYear;  // private 필드를 public 메서드를 통해 안전하게 노출
        }
    }

    // ==========================================
    // 자식 클래스 1 - Dog
    // ==========================================

    /// <summary>
    /// Dog 클래스 - Animal 클래스를 상속받아 강아지의 특성을 구현
    /// Animal의 모든 기능 + Dog만의 고유 기능
    /// </summary>
    public class Dog : Animal
    {
        // ========================================
        // Dog 고유 속성
        // ========================================

        /*
         * private 접근 제한자 사용:
         * - Dog 클래스 내부에서만 사용되는 정보
         * - 외부에서 직접 접근하지 못하도록 캡슐화
         */
        private string Breed; // 강아지의 품종 정보 (Dog 전용)

        // ========================================
        // 생성자 체이닝 (Constructor Chaining)
        // ========================================

        /// <summary>
        /// Dog 클래스 생성자
        /// base() 키워드를 통해 부모 클래스 생성자를 먼저 호출
        /// </summary>
        /// <param name="name">강아지 이름</param>
        /// <param name="age">강아지 나이</param>
        /// <param name="breed">강아지 품종</param>
        public Dog(string name, int age, string breed) : base(name, age)
        {
            /*
             * 생성자 체이닝 과정:
             * 1. Dog 생성자 시작
             * 2. : base(name, age) 실행 → Animal 생성자 호출
             * 3. Animal 생성자 완료 (Name, Age, BirthYear 초기화)
             * 4. 아래 Dog 생성자 본문 실행 (Breed 초기화)
             * 5. Dog 객체 생성 완료
             */
            Console.WriteLine("🐶 Dog 생성자 호출됨");
            Breed = breed;

            // 초기화 완료 메시지 (선택사항)
            // Console.WriteLine($"강아지 생성 완료: {Name} ({Age}살, {Breed})");
        }

        // ========================================
        // 메서드 재정의 (Method Override)
        // ========================================

        /// <summary>
        /// MakeSound 메서드 재정의 - 강아지만의 고유한 소리
        /// override 키워드로 부모의 virtual 메서드를 새롭게 구현
        /// </summary>
        public override void MakeSound()
        {
            /*
             * 메서드 재정의의 효과:
             * - Animal의 일반적인 "어떤 소리" → Dog의 구체적인 "멍멍!"
             * - 다형성을 통해 Dog 객체는 항상 이 메서드가 호출됨
             * - 부모 타입으로 참조되어도 Dog의 구현이 실행됨
             */
            Console.WriteLine($"{Name}이(가) 멍멍! 짖습니다. 🐕");
        }

        // ========================================
        // Dog 고유 메서드들
        // ========================================

        /// <summary>
        /// 짖기 메서드 - Dog만의 고유한 행동
        /// Animal에는 없는 Dog 전용 기능
        /// </summary>
        public void Bark()
        {
            Console.WriteLine($"{Name}이(가) 큰 소리로 짖습니다! 멍멍멍! 🔊🐕");
        }

        /// <summary>
        /// 품종 정보 출력 메서드
        /// </summary>
        public void ShowBreed()
        {
            Console.WriteLine($"{Name}의 품종: {Breed}");
        }

        // ========================================
        // 접근 제한자 테스트 메서드
        // ========================================

        /// <summary>
        /// 접근 가능한 정보 출력 - 접근 제한자별 접근 가능성 확인
        /// 상속 관계에서 어떤 멤버에 접근할 수 있는지 보여주는 예제
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine("=== Dog 정보 출력 ===");

            /*
             * public 필드 접근:
             * - 어디서든 접근 가능
             * - 자식 클래스에서도 당연히 접근 가능
             */
            Console.WriteLine($"이름: {Name}");   // ✅ public: 접근 가능

            /*
             * protected 필드 접근:
             * - 외부에서는 접근 불가하지만 자식 클래스에서는 접근 가능
             * - 상속의 장점을 활용하면서도 캡슐화 유지
             */
            Console.WriteLine($"나이: {Age}살");     // ✅ protected: 자식 클래스에서 접근 가능

            /*
             * private 필드 접근 시도:
             * - 부모 클래스의 private 멤버는 자식에서도 접근 불가
             * - 다음 줄의 주석을 해제하면 컴파일 에러 발생
             */
            // Console.WriteLine($"출생년도: {BirthYear}"); // ❌ private: 접근 불가능 (컴파일 에러)

            /*
             * private 필드에 안전하게 접근:
             * - public 메서드를 통해 간접 접근
             * - 캡슐화 원칙을 지키면서도 필요한 정보 제공
             */
            Console.WriteLine($"출생년도: {GetBirthYear()}년"); // ✅ public 메서드를 통한 안전한 접근

            Console.WriteLine($"품종: {Breed}");
        }
    }

    // ==========================================
    // 자식 클래스 2 - Cat
    // ==========================================

    /// <summary>
    /// Cat 클래스 - Animal 클래스를 상속받아 고양이의 특성을 구현
    /// Dog와 같은 부모를 가지지만 완전히 다른 고유 특성을 가짐
    /// </summary>
    public class Cat : Animal
    {
        // ========================================
        // 생성자
        // ========================================

        /// <summary>
        /// Cat 클래스 생성자
        /// Dog와 동일한 상속 구조이지만 Cat만의 초기화 수행
        /// </summary>
        /// <param name="name">고양이 이름</param>
        /// <param name="age">고양이 나이</param>
        public Cat(string name, int age) : base(name, age)
        {
            /*
             * Cat 생성자의 특징:
             * - Dog와 달리 별도의 고유 속성이 없음 (품종 정보 없음)
             * - 부모 클래스 생성자만 호출하고 추가 초기화는 최소화
             * - 필요에 따라 나중에 Cat 고유 속성 추가 가능
             */
            Console.WriteLine("🐱 Cat 생성자 호출됨");

            // Cat 전용 초기화 작업이 있다면 여기에 추가
            // 현재는 부모 클래스 초기화만으로 충분
        }

        // ========================================
        // 메서드 재정의 (선택사항)
        // ========================================

        /// <summary>
        /// MakeSound 메서드 재정의 - 고양이만의 고유한 소리
        /// Dog와 다른 Cat만의 소리 구현
        /// </summary>
        public override void MakeSound()
        {
            /*
             * Cat의 MakeSound() 구현:
             * - Dog의 "멍멍!"과 구별되는 "야옹!" 소리
             * - 같은 MakeSound() 메서드지만 완전히 다른 동작
             * - 다형성의 핵심: 같은 인터페이스, 다른 구현
             */
            Console.WriteLine($"{Name}이(가) 야옹! 하고 웁니다. 🐱");
        }

        // ========================================
        // Cat 고유 메서드들
        // ========================================

        /// <summary>
        /// 야옹거리기 메서드 - Cat만의 고유한 행동
        /// MakeSound()와는 별개의 Cat 전용 기능
        /// </summary>
        public void Meow()
        {
            Console.WriteLine($"{Name}이(가) 부드럽게 야옹거립니다. 😸");
        }

        /// <summary>
        /// 그루밍하기 메서드 - 고양이의 특별한 행동
        /// </summary>
        public void Groom()
        {
            Console.WriteLine($"{Name}이(가) 자신을 깨끗하게 그루밍합니다. 🧼🐱");
        }

        /// <summary>
        /// 높은 곳 올라가기 - 고양이만의 특별한 능력
        /// </summary>
        public void ClimbHigh()
        {
            Console.WriteLine($"{Name}이(가) 높은 곳으로 재빠르게 올라갑니다. 🏔️🐱");
        }
    }

    /*
     ================================================================================================
     상속 구조 정리 및 학습 포인트
     ================================================================================================
     
     🏗️ 클래스 계층 구조:
        Animal (부모)
        ├─ 공통 속성: Name(public), Age(protected), BirthYear(private)
        ├─ 공통 메서드: Eat(), Sleep(), GetBirthYear()
        └─ 가상 메서드: MakeSound() (재정의 가능)
        
        ↓ 상속
        
        Dog (자식)                     Cat (자식)
        ├─ 고유 속성: Breed           ├─ 고유 속성: (현재 없음)
        ├─ 재정의: MakeSound()        ├─ 재정의: MakeSound()
        └─ 고유 메서드: Bark(),       └─ 고유 메서드: Meow(),
           ShowBreed(), ShowInfo()       Groom(), ClimbHigh()
     
     ✅ 상속의 장점 확인:
     1. 코드 재사용: Eat(), Sleep() 메서드를 Dog, Cat이 공유
     2. 일관성: 모든 동물이 동일한 방식으로 기본 행동 수행
     3. 확장성: 새로운 동물 클래스(예: Bird, Fish) 쉽게 추가 가능
     4. 다형성: 같은 MakeSound() 호출이지만 각각 다른 소리
     
     🔐 접근 제한자 활용:
     - public Name: 모든 곳에서 접근 가능
     - protected Age: 자식 클래스에서만 접근 가능
     - private BirthYear: Animal 클래스 내부에서만 접근 가능
     
     🎭 다형성 구현:
     - virtual (Animal): MakeSound() 재정의 가능
     - override (Dog/Cat): 각각 다른 소리로 구현
     - 런타임에 실제 객체 타입에 따라 적절한 메서드 호출
     
     🔧 생성자 체이닝:
     - 자식 객체 생성 시 부모 생성자 먼저 호출
     - base() 키워드로 부모에게 매개변수 전달
     - 올바른 초기화 순서 보장
     
     💡 실무 적용:
     - 게임 개발: Character ← Warrior, Mage, Archer
     - UI 개발: Control ← Button, TextBox, Label
     - 비즈니스 로직: Person ← Customer, Employee
     - 데이터 처리: Document ← TextDoc, ImageDoc
     
     ================================================================================================
     */
}