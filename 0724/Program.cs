using System;
using System.Text;

/*
 ================================================================================================
 캐스팅(Casting) - 한 타입의 객체를 다른 타입으로 변환하는 것
 ================================================================================================

 1. 업캐스팅 (Upcasting)
    - 방향: 자식 클래스 → 부모 클래스
    - 특징: 자식 타입의 객체를 부모 타입으로 참조
    - 방법: 암시적(자동)으로 수행됨 - 별도 캐스팅 연산자 불필요
    - 안전성: 안전한 변환 - 항상 성공함
    - 역할: 다형성의 핵심 개념

 2. 다운캐스팅 (Downcasting)
    - 방향: 부모 클래스 → 자식 클래스
    - 방법: 명시적으로 수행해야 함
    - 안전성: 위험한 변환 - 실패할 수 있음

 ================================================================================================
 컴파일타임 vs 런타임
 ================================================================================================

 컴파일타임 (Compile Time)
 - 정의: 코드를 기계어로 번역하는 시점
 - 과정: 작성한 C# 코드를 컴퓨터가 이해할 수 있는 언어로 변환
 - 시점: 프로그램 실행 전
 - 역할: 문법 검사, 타입 검사, 메서드 존재 확인

 런타임 (Runtime)
 - 정의: 프로그램이 실제로 실행되는 시점
 - 과정: 프로그램 실행 중에 일어나는 모든 일
 - 시점: 프로그램 실행 중
 - 역할: 사용자 입력, 실제 계산, 메모리 관리, 예외 처리

 ================================================================================================
 */

namespace _0724
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 콘솔 출력 인코딩을 UTF-8로 설정
            Console.OutputEncoding = Encoding.UTF8;


            // ==========================================
            // 업캐스팅 (Upcasting) 예제
            // ==========================================
            Console.WriteLine("=== 업캐스팅 예제 ===");
            Console.WriteLine();

            // 1단계: Dog 객체 생성 (객체 초기화자 사용)
            Dog myDog = new Dog { Name = "바둑이", Breed = "진돗개" };
            Console.WriteLine($"Dog 객체 생성: {myDog.Name} ({myDog.Breed})");

            // 2단계: 업캐스팅 - Dog(자식) → Animal(부모)
            // 암시적 변환으로 자동 수행됨 (안전함)
            Animal animal = myDog;
            Console.WriteLine("업캐스팅 완료: Dog → Animal");
            Console.WriteLine();

            // 3단계: 업캐스팅 후 접근 가능한 멤버 확인
            Console.WriteLine("업캐스팅 후 속성 접근:");
            Console.WriteLine($"myDog.Name: {myDog.Name}");     // ✅ Dog 타입으로 접근
            Console.WriteLine($"myDog.Breed: {myDog.Breed}");   // ✅ Dog 고유 속성 접근 가능
            Console.WriteLine($"animal.Name: {animal.Name}");   // ✅ Animal 타입으로 접근 (같은 객체!)
            // Console.WriteLine($"animal.Breed: {animal.Breed}"); // ❌ 컴파일 에러! Animal에는 Breed 없음
            Console.WriteLine();

            // 4단계: 다형성 동작 확인
            Console.WriteLine("다형성 동작 확인:");
            Console.WriteLine("myDog.MakeSound() 호출:");
            myDog.MakeSound();   // Dog의 MakeSound() 호출

            Console.WriteLine("animal.MakeSound() 호출:");
            animal.MakeSound();  // 여전히 Dog의 MakeSound() 호출! (다형성의 핵심)

            Console.WriteLine("animal.Sleep() 호출:");
            animal.Sleep();      // 부모 클래스의 공통 메서드 호출
            Console.WriteLine();

            // 5단계: 참조와 타입 정보 확인
            Console.WriteLine("참조와 타입 정보:");
            Console.WriteLine($"같은 객체 참조? {ReferenceEquals(myDog, animal)}"); // True
            Console.WriteLine($"myDog의 실제 타입: {myDog.GetType()}");           // Dog
            Console.WriteLine($"animal이 가리키는 실제 타입: {animal.GetType()}"); // Dog (Animal이 아님!)
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine();

            // ==========================================
            // 다운캐스팅 (Downcasting) 예제
            // ==========================================
            Console.WriteLine("=== 다운캐스팅 예제 ===");
            Console.WriteLine();
            Console.WriteLine("다운캐스팅: 부모 타입으로 참조된 객체를 다시 자식 타입으로 변환");
            Console.WriteLine("특징: 명시적으로 수행해야 함, 위험한 변환 (실패 가능)");
            Console.WriteLine();

            // 테스트용 객체들 준비
            Animal animal1 = new Dog { Name = "검둥이", Breed = "진돗개" };  // Dog 객체를 Animal로 업캐스팅
            Animal animal2 = new Cat { Name = "나비", isIndoor = true };    // Cat 객체를 Animal로 업캐스팅
            Animal animal3 = new Animal { Name = "일반동물" };               // 순수 Animal 객체

            // 각 객체의 실제 타입 확인
            Console.WriteLine("테스트 객체들:");
            Console.WriteLine($"animal1 - 변수타입: Animal, 실제타입: {animal1.GetType().Name}, 이름: {((Dog)animal1).Name}");
            Console.WriteLine($"animal2 - 변수타입: Animal, 실제타입: {animal2.GetType().Name}, 이름: {((Cat)animal2).Name}");
            Console.WriteLine($"animal3 - 변수타입: Animal, 실제타입: {animal3.GetType().Name}, 이름: {animal3.Name}");
            Console.WriteLine();

            // ==========================================
            // 방법 1: 직접 캐스팅 (위험한 방법)
            // ==========================================
            Console.WriteLine("=== 방법 1: 직접 캐스팅 (위험!) ===");
            Console.WriteLine("문법: (타입)객체");
            Console.WriteLine();

            try
            {
                Console.WriteLine("1-1. animal1 (실제 Dog)을 Dog로 캐스팅 시도:");
                Dog dog1 = (Dog)animal1; // ✅ 성공! 실제로 Dog 객체이므로
                Console.WriteLine($"✅ 성공: {dog1.Name}, 품종: {dog1.Breed}");
                dog1.Fetch(); // Dog 고유 메서드 사용 가능
                Console.WriteLine();

                Console.WriteLine("1-2. animal2 (실제 Cat)을 Dog로 캐스팅 시도:");
                Console.WriteLine("🚨 주의: Cat 객체를 Dog로 변환하려고 시도 중...");
                Dog dog2 = (Dog)animal2; // ❌ 실패! Cat을 Dog로 변환 불가
                Console.WriteLine("이 줄은 실행되지 않습니다.");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"💥 런타임 에러 발생!");
                Console.WriteLine($"에러 타입: InvalidCastException");
                Console.WriteLine($"에러 메시지: {ex.Message}");
                Console.WriteLine();
                Console.WriteLine("🔍 실패 이유:");
                Console.WriteLine("  • animal2는 실제로 Cat 객체");
                Console.WriteLine("  • Cat을 Dog로 변환하려고 시도");
                Console.WriteLine("  • Cat과 Dog는 형제 관계라서 서로 변환 불가능");
                Console.WriteLine("  • 런타임에 타입 안전성을 위해 예외 발생");
                Console.WriteLine();
            }

            // ==========================================
            // 방법 2: as 연산자 (안전한 방법)
            // ==========================================
            Console.WriteLine("=== 방법 2: as 연산자 (안전!) ===");
            Console.WriteLine("문법: 객체 as 타입");
            Console.WriteLine("특징: 실패 시 예외 대신 null 반환");
            Console.WriteLine();

            Console.WriteLine("2-1. animal1 (실제 Dog)을 Dog로 변환:");
            Dog dog3 = animal1 as Dog;
            if (dog3 != null)
            {
                Console.WriteLine($"✅ 성공: {dog3.Name}, 품종: {dog3.Breed}");
                dog3.Guard();
            }
            else
            {
                Console.WriteLine("❌ 변환 실패: null 반환됨");
            }
            Console.WriteLine();

            Console.WriteLine("2-2. animal2 (실제 Cat)을 Dog로 변환:");
            Dog dog4 = animal2 as Dog;
            if (dog4 != null)
            {
                Console.WriteLine($"✅ 성공: {dog4.Name}, 품종: {dog4.Breed}");
                dog4.Guard();
            }
            else
            {
                Console.WriteLine("❌ 변환 실패: null 반환됨 (Cat을 Dog로 변환 불가)");
            }
            Console.WriteLine();

            // ==========================================
            // 방법 3: is 연산자 (타입 체크 후 캐스팅)
            // ==========================================
            Console.WriteLine("=== 방법 3: is 연산자 (타입 체크) ===");
            Console.WriteLine("문법: if (객체 is 타입) { 캐스팅 }");
            Console.WriteLine("특징: 타입 체크 후 안전하게 캐스팅");
            Console.WriteLine();

            Console.WriteLine("3-1. animal1이 Dog인지 확인 후 변환:");
            if (animal1 is Dog)
            {
                Dog dog5 = (Dog)animal1;
                Console.WriteLine($"✅ Dog 타입 확인됨: {dog5.Name}");
                dog5.Fetch();
            }
            else
            {
                Console.WriteLine("❌ Dog 타입이 아닙니다.");
            }
            Console.WriteLine();

            Console.WriteLine("3-2. animal2가 Dog인지 확인 후 변환:");
            if (animal2 is Dog)
            {
                Dog dog6 = (Dog)animal2;
                Console.WriteLine($"✅ Dog 타입 확인됨: {dog6.Name}");
            }
            else
            {
                Console.WriteLine("❌ Dog 타입이 아닙니다. (실제로는 Cat)");
            }
            Console.WriteLine();

            // ==========================================
            // 방법 4: 패턴 매칭 (가장 현대적이고 권장되는 방법)
            // ==========================================
            Console.WriteLine("=== 방법 4: 패턴 매칭 (C# 7.0+, 권장!) ===");
            Console.WriteLine("문법: if (객체 is 타입 변수명) { 변수명 사용 }");
            Console.WriteLine("특징: 타입 체크와 변수 선언을 한 번에 처리");
            Console.WriteLine();

            Console.WriteLine("4-1. animal1 패턴 매칭:");
            if (animal1 is Dog dog7)
            {
                Console.WriteLine($"✅ Dog로 확인됨: {dog7.Name} ({dog7.Breed})");
                dog7.Fetch();
                dog7.Guard();
            }
            else
            {
                Console.WriteLine("❌ Dog가 아닙니다.");
            }
            Console.WriteLine();

            Console.WriteLine("4-2. animal2 패턴 매칭 (Cat으로 시도):");
            if (animal2 is Cat cat1)
            {
                Console.WriteLine($"✅ Cat으로 확인됨: {cat1.Name} (실내묘: {cat1.isIndoor})");
                cat1.Climb();
            }
            else
            {
                Console.WriteLine("❌ Cat이 아닙니다.");
            }
            Console.WriteLine();

            Console.WriteLine("4-3. animal2를 Dog로 시도 (실패 예상):");
            if (animal2 is Dog dog8)
            {
                Console.WriteLine($"✅ Dog로 확인됨: {dog8.Name}");
            }
            else
            {
                Console.WriteLine("❌ Dog가 아닙니다. (예상된 결과)");
            }
            Console.WriteLine();

            // ==========================================
            // switch 패턴 매칭 (고급 활용)
            // ==========================================
            Console.WriteLine("=== 고급: switch 패턴 매칭 ===");
            Console.WriteLine();

            Animal[] animals = { animal1, animal2, animal3 };

            for (int i = 0; i < animals.Length; i++)
            {
                Console.WriteLine($"animals[{i}] 처리:");

                switch (animals[i])
                {
                    case Dog dog:
                        Console.WriteLine($"  🐕 Dog 발견: {dog.Name} ({dog.Breed})");
                        dog.Fetch();
                        break;

                    case Cat cat:
                        Console.WriteLine($"  🐱 Cat 발견: {cat.Name} (실내묘: {cat.isIndoor})");
                        cat.Climb();
                        break;

                    case Animal animal4 when animal.GetType() == typeof(Animal):
                        Console.WriteLine($"  🐾 일반 Animal: {animal.Name}");
                        animal.MakeSound();
                        break;

                    default:
                        Console.WriteLine("  ❓ 알 수 없는 타입");
                        break;
                }
                Console.WriteLine();
            }

            // ==========================================
            // 핵심 정리
            // ==========================================
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("🎯 캐스팅 핵심 정리");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine();
            Console.WriteLine("📈 업캐스팅 (자식 → 부모):");
            Console.WriteLine("  • 항상 안전함 (자동 수행)");
            Console.WriteLine("  • 다형성의 기반");
            Console.WriteLine("  • 부모 타입의 멤버만 접근 가능");
            Console.WriteLine();
            Console.WriteLine("📉 다운캐스팅 (부모 → 자식):");
            Console.WriteLine("  • 위험할 수 있음 (수동 수행)");
            Console.WriteLine("  • 실제 객체 타입과 일치할 때만 성공");
            Console.WriteLine("  • 반드시 안전장치 사용 권장");
            Console.WriteLine();
            Console.WriteLine("🛡️ 안전한 다운캐스팅 방법:");
            Console.WriteLine("  1. as 연산자 + null 체크");
            Console.WriteLine("  2. is 연산자 + 타입 체크");
            Console.WriteLine("  3. 패턴 매칭 (권장)");
            Console.WriteLine("  4. try-catch 예외 처리");
            Console.WriteLine();
            Console.WriteLine("⚠️ 피해야 할 것:");
            Console.WriteLine("  • 타입 체크 없는 직접 캐스팅");
            Console.WriteLine("  • 형제 클래스 간 변환 시도");
        }
    }
}