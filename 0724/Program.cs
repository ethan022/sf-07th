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
            // 콘솔 인코딩 설정 (이모지 및 특수문자 지원)
            Console.OutputEncoding = Encoding.UTF8;

            // ==========================================
            // 컴파일타임 vs 런타임 개념 설명 및 예제
            // ==========================================
            Console.WriteLine("========================================");
            Console.WriteLine("    컴파일타임 vs 런타임 개념 설명");
            Console.WriteLine("========================================");
            Console.WriteLine();

            // 컴파일타임에 결정되는 것들
            Console.WriteLine("■ 컴파일타임에 결정되는 것들 (코드 작성 시점):");
            Console.WriteLine("  1. 문법 검사 - 코드가 올바르게 작성되었는가?");
            Console.WriteLine("  2. 타입 검사 - 변수 타입이 올바른가?");
            Console.WriteLine("  3. 메서드 존재 확인 - 호출하는 메서드가 있는가?");
            Console.WriteLine("  4. 메서드 오버로딩 결정 - 어떤 오버로딩 메서드를 사용할까?");
            Console.WriteLine();

            // 컴파일타임 예제
            Console.WriteLine("[컴파일타임 예제]");
            int a = 10;                         // 컴파일타임: int 타입 확인
            double b = 20.5;                    // 컴파일타임: double 타입 확인  
            Console.WriteLine("Hello World");   // 컴파일타임: WriteLine 메서드 존재 확인
            Console.WriteLine("위 코드들은 컴파일타임에 검사되어 통과했습니다.");
            Console.WriteLine();

            // 런타임에 결정되는 것들
            Console.WriteLine("■ 런타임에 결정되는 것들 (프로그램 실행 중):");
            Console.WriteLine("  1. 사용자 입력 처리");
            Console.WriteLine("  2. 실제 계산 수행");
            Console.WriteLine("  3. 메모리 할당/해제");
            Console.WriteLine("  4. 예외 처리");
            Console.WriteLine("  5. 가상 메서드 호출 결정 (다형성)");
            Console.WriteLine();

            // 런타임 예제 - 사용자 입력
            Console.WriteLine("[런타임 예제 - 사용자 입력]");
            Console.WriteLine("숫자를 입력하세요 (런타임에 결정됨):");
            string input = Console.ReadLine();  // 런타임: 실제 사용자 입력

            try
            {
                int number = int.Parse(input);           // 런타임: 문자열을 숫자로 변환 시도
                int result = a + number;                 // 런타임: 실제 덧셈 계산 수행
                Console.WriteLine($"결과: {a} + {number} = {result}");
                Console.WriteLine("성공: 런타임에 정상 처리되었습니다.");
            }
            catch (FormatException)
            {
                Console.WriteLine("실패: 런타임에 변환 에러가 발생했습니다!");  // 런타임: 예외 처리
            }
            Console.WriteLine();

            Console.WriteLine("========================================");
            Console.WriteLine();

            // ==========================================
            // 업캐스팅에서 컴파일타임 vs 런타임
            // ==========================================
            Console.WriteLine("=== 업캐스팅에서 컴파일타임 vs 런타임 ===");
            Console.WriteLine();

            // 컴파일타임 과정 설명
            Console.WriteLine("■ 컴파일타임 과정:");
            Console.WriteLine("  1. Dog 클래스가 Animal을 상속하는지 확인");
            Console.WriteLine("  2. 업캐스팅이 가능한지 검사");
            Console.WriteLine("  3. Animal.MakeSound() 메서드 존재 확인");
            Console.WriteLine("  4. virtual 키워드 확인");
            Console.WriteLine("  → 컴파일 성공!");
            Console.WriteLine();

            // 실제 업캐스팅 수행
            Console.WriteLine("■ 실제 업캐스팅 수행:");
            Dog myDog = new Dog { Name = "바둑이", Breed = "진돗개" };
            Console.WriteLine($"Dog 객체 생성: {myDog.Name} ({myDog.Breed})");

            Animal animal = myDog; // 업캐스팅 (컴파일타임에 허용, 런타임에 실행)
            Console.WriteLine("업캐스팅 완료: Dog → Animal");
            Console.WriteLine();

            // 런타임 과정 설명  
            Console.WriteLine("■ 런타임 과정:");
            Console.WriteLine("  1. 실제 Dog 객체가 메모리에 생성됨");
            Console.WriteLine("  2. animal 변수가 Dog 객체를 참조하게 됨");
            Console.WriteLine("  3. MakeSound() 호출 시:");
            Console.WriteLine("     - 컴파일타임: Animal.MakeSound() 확인");
            Console.WriteLine("     - 런타임: 실제 객체(Dog) 타입 확인");
            Console.WriteLine("     - 런타임: Dog.MakeSound() 실행!");
            Console.WriteLine();

            // 다형성 동작 확인
            Console.WriteLine("■ 다형성 동작 확인:");
            Console.WriteLine("animal.MakeSound() 호출 → ");
            animal.MakeSound();  // 런타임에 Dog의 MakeSound() 호출됨!
            Console.WriteLine("→ 런타임에 Dog의 MakeSound()가 실행되었습니다!");
            Console.WriteLine();

            Console.WriteLine("========================================");
            Console.WriteLine();

            // ==========================================
            // 다운캐스팅에서 컴파일타임 vs 런타임
            // ==========================================
            Console.WriteLine("=== 다운캐스팅에서 컴파일타임 vs 런타임 ===");
            Console.WriteLine();

            // 테스트용 객체들 준비
            Animal animal1 = new Dog { Name = "검둥이", Breed = "진돗개" };  // 실제: Dog
            Animal animal2 = new Cat { Name = "나비", isIndoor = true };    // 실제: Cat

            Console.WriteLine("■ 테스트 객체 준비:");
            Console.WriteLine($"animal1: Animal 타입, 실제로는 {animal1.GetType().Name}");
            Console.WriteLine($"animal2: Animal 타입, 실제로는 {animal2.GetType().Name}");
            Console.WriteLine();

            // ==========================================
            // 방법 1: 직접 캐스팅에서 컴파일타임 vs 런타임
            // ==========================================
            Console.WriteLine("■ 방법 1: 직접 캐스팅에서 컴파일타임 vs 런타임");
            Console.WriteLine();

            Console.WriteLine("코드: Dog dog1 = (Dog)animal1;");
            Console.WriteLine("▶ 컴파일타임:");
            Console.WriteLine("  - Animal을 Dog로 캐스팅하는 문법 확인");
            Console.WriteLine("  - Dog 클래스가 Animal을 상속하는지 확인");
            Console.WriteLine("  - 문법적으로 가능하므로 컴파일 성공");
            Console.WriteLine();

            try
            {
                Console.WriteLine("▶ 런타임:");
                Console.WriteLine("  - animal1이 가리키는 실제 객체 타입 확인");
                Console.WriteLine($"  - 실제 타입: {animal1.GetType().Name}");
                Console.WriteLine("  - Dog 타입이므로 캐스팅 가능");

                Dog dog1 = (Dog)animal1; // 런타임에 성공
                Console.WriteLine($"  ✅ 성공: {dog1.Name} ({dog1.Breed})");
                dog1.Fetch();
                Console.WriteLine();

                Console.WriteLine("코드: Dog dog2 = (Dog)animal2;");
                Console.WriteLine("▶ 컴파일타임:");
                Console.WriteLine("  - 동일한 문법이므로 컴파일 성공");
                Console.WriteLine();
                Console.WriteLine("▶ 런타임:");
                Console.WriteLine("  - animal2가 가리키는 실제 객체 타입 확인");
                Console.WriteLine($"  - 실제 타입: {animal2.GetType().Name}");
                Console.WriteLine("  - Cat을 Dog로 변환하려고 시도...");

                Dog dog2 = (Dog)animal2; // 런타임에 실패!
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("  ❌ 런타임 에러 발생!");
                Console.WriteLine($"  - 에러 타입: InvalidCastException");
                Console.WriteLine("  - 이유: Cat 객체를 Dog로 변환 불가능");
                Console.WriteLine("  - 형제 클래스는 서로 변환 불가");
            }
            Console.WriteLine();

            // ==========================================
            // 방법 2: as 연산자에서 컴파일타임 vs 런타임
            // ==========================================
            Console.WriteLine("■ 방법 2: as 연산자에서 컴파일타임 vs 런타임");
            Console.WriteLine();

            Console.WriteLine("코드: Dog dog3 = animal1 as Dog;");
            Console.WriteLine("▶ 컴파일타임:");
            Console.WriteLine("  - as 연산자 문법 확인");
            Console.WriteLine("  - 타입 호환성 확인");
            Console.WriteLine("  - 컴파일 성공");
            Console.WriteLine();

            Console.WriteLine("▶ 런타임:");
            Dog dog3 = animal1 as Dog; // 런타임에 타입 확인
            if (dog3 != null)
            {
                Console.WriteLine("  - 실제 타입 확인: Dog");
                Console.WriteLine("  - 변환 가능하므로 Dog 객체 반환");
                Console.WriteLine($"  ✅ 성공: {dog3.Name}");
            }
            else
            {
                Console.WriteLine("  - 변환 불가능하므로 null 반환");
            }

            Dog dog4 = animal2 as Dog; // Cat을 Dog로 변환 시도
            if (dog4 != null)
            {
                Console.WriteLine($"  ✅ 성공: {dog4.Name}");
            }
            else
            {
                Console.WriteLine("  - 실제 타입: Cat");
                Console.WriteLine("  - Dog로 변환 불가능");
                Console.WriteLine("  ❌ null 반환 (예외 없이 안전하게 실패)");
            }
            Console.WriteLine();

            // ==========================================
            // 방법 3: is 연산자에서 컴파일타임 vs 런타임
            // ==========================================
            Console.WriteLine("■ 방법 3: is 연산자에서 컴파일타임 vs 런타임");
            Console.WriteLine();

            Console.WriteLine("코드: if (animal1 is Dog)");
            Console.WriteLine("▶ 컴파일타임:");
            Console.WriteLine("  - is 연산자 문법 확인");
            Console.WriteLine("  - 타입 비교 가능성 확인");
            Console.WriteLine("  - 컴파일 성공");
            Console.WriteLine();

            Console.WriteLine("▶ 런타임:");
            if (animal1 is Dog) // 런타임에 실제 타입 검사
            {
                Console.WriteLine("  - 실제 객체 타입 확인: Dog");
                Console.WriteLine("  - 조건문 true");
                Dog dog5 = (Dog)animal1; // 안전하게 캐스팅
                Console.WriteLine($"  ✅ 안전한 캐스팅 성공: {dog5.Name}");
            }
            else
            {
                Console.WriteLine("  - Dog 타입이 아님");
            }

            if (animal2 is Dog)
            {
                Console.WriteLine("  - 이 줄은 실행되지 않음");
            }
            else
            {
                Console.WriteLine("  - 실제 객체 타입 확인: Cat");
                Console.WriteLine("  - Dog가 아니므로 조건문 false");
                Console.WriteLine("  ✅ 안전하게 타입 불일치 감지");
            }
            Console.WriteLine();

            // ==========================================
            // 방법 4: 패턴 매칭에서 컴파일타임 vs 런타임
            // ==========================================
            Console.WriteLine("■ 방법 4: 패턴 매칭에서 컴파일타임 vs 런타임");
            Console.WriteLine();

            Console.WriteLine("코드: if (animal1 is Dog dog7)");
            Console.WriteLine("▶ 컴파일타임:");
            Console.WriteLine("  - 패턴 매칭 문법 확인 (C# 7.0+)");
            Console.WriteLine("  - 변수 선언과 타입 체크 조합 확인");
            Console.WriteLine("  - 컴파일 성공");
            Console.WriteLine();

            Console.WriteLine("▶ 런타임:");
            if (animal1 is Dog dog7) // 런타임에 타입 체크 + 변수 할당
            {
                Console.WriteLine("  - 실제 타입 확인: Dog");
                Console.WriteLine("  - 타입 일치하므로 dog7 변수에 할당");
                Console.WriteLine($"  - dog7 사용 가능: {dog7.Name} ({dog7.Breed})");
                Console.WriteLine("  ✅ 타입 체크와 변수 할당을 한 번에 처리");
                dog7.Fetch();
            }

            if (animal2 is Cat cat1) // Cat으로 패턴 매칭
            {
                Console.WriteLine("  - 실제 타입 확인: Cat");
                Console.WriteLine("  - 타입 일치하므로 cat1 변수에 할당");
                Console.WriteLine($"  - cat1 사용 가능: {cat1.Name}");
                Console.WriteLine("  ✅ Cat 전용 기능 사용 가능");
                cat1.Climb();
            }
            Console.WriteLine();

            // ==========================================
            // 핵심 정리
            // ==========================================
            Console.WriteLine("========================================");
            Console.WriteLine("             핵심 정리");
            Console.WriteLine("========================================");
            Console.WriteLine();

            Console.WriteLine("■ 컴파일타임 (Compile Time):");
            Console.WriteLine("  - 시점: 코드 작성 후, 실행 전");
            Console.WriteLine("  - 역할: 문법 검사, 타입 검사, 메서드 존재 확인");
            Console.WriteLine("  - 캐스팅: 문법적 가능성만 확인");
            Console.WriteLine("  - 에러: 컴파일 에러 (코드 수정 필요)");
            Console.WriteLine();

            Console.WriteLine("■ 런타임 (Runtime):");
            Console.WriteLine("  - 시점: 프로그램 실행 중");
            Console.WriteLine("  - 역할: 실제 객체 타입 확인, 메모리 관리, 계산 수행");
            Console.WriteLine("  - 캐스팅: 실제 타입 일치 여부 확인");
            Console.WriteLine("  - 에러: 런타임 에러/예외 (try-catch로 처리)");
            Console.WriteLine();

            Console.WriteLine("■ 다형성에서의 동작:");
            Console.WriteLine("  - 컴파일타임: 부모 타입 메서드 존재 확인");
            Console.WriteLine("  - 런타임: 실제 객체 타입의 메서드 호출");
            Console.WriteLine("  → 같은 코드, 다른 동작! (다형성의 핵심)");
            Console.WriteLine();

            Console.WriteLine("■ 안전한 다운캐스팅:");
            Console.WriteLine("  1. as 연산자: 실패 시 null 반환");
            Console.WriteLine("  2. is 연산자: 타입 체크 후 안전 캐스팅");
            Console.WriteLine("  3. 패턴 매칭: 체크 + 할당 한 번에 (권장)");
            Console.WriteLine("  4. try-catch: 예외 처리로 안전성 확보");
            Console.WriteLine();


            // 객체 생성
            Console.WriteLine($"=== 1단계 객체 생성 ===");
            Bird myBird = new Bird { Name = "참새" };

            Console.WriteLine($"Bird 생성 : {myBird.Name}");
            Console.WriteLine();

            Console.WriteLine($"=== 2단계 업 캐스팅 ===");
            Animal animal4 = myBird;
            Console.WriteLine($"업캐스팅 완료");
            Console.WriteLine($"animal4: Bird => Animal");
            Console.WriteLine();

            Console.WriteLine($"=== 3단계 업 캐스팅된 객체의 호출 가능 매서드들 ===");
            animal4.MakeSound();
            animal4.Sleep();
            Console.WriteLine();

            Console.WriteLine($"=== 4단계 다운 캐스팅 ===");
            if (animal4 is Bird bird)
            {
                Console.WriteLine($"{bird.Name}을 Bird로 다운 캐스팅 성공!");
                bird.Fly();
            }
            Console.WriteLine();


        }
    }
}