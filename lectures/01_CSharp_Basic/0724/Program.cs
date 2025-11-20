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
            // ==========================================
            // 콘솔 설정 및 프로그램 시작
            // ==========================================

            /*
             * 콘솔 인코딩 설정:
             * - UTF-8 인코딩으로 설정하여 한글 및 특수문자 지원
             * - 이모지나 특수 기호들이 제대로 출력되도록 함
             */
            Console.OutputEncoding = Encoding.UTF8;

            // ==========================================
            // Part 1: 컴파일타임 vs 런타임 개념 설명 및 예제
            // ==========================================
            Console.WriteLine("========================================");
            Console.WriteLine("    컴파일타임 vs 런타임 개념 설명");
            Console.WriteLine("========================================");
            Console.WriteLine();

            /*
             * 컴파일타임에 결정되는 것들:
             * - 프로그램이 실행되기 전, 코드를 기계어로 변환하는 과정에서 검사되는 사항들
             * - 개발자가 코드를 작성한 후 빌드할 때 수행됨
             */
            Console.WriteLine("■ 컴파일타임에 결정되는 것들 (코드 작성 시점):");
            Console.WriteLine("  1. 문법 검사 - 코드가 올바르게 작성되었는가?");
            Console.WriteLine("  2. 타입 검사 - 변수 타입이 올바른가?");
            Console.WriteLine("  3. 메서드 존재 확인 - 호출하는 메서드가 있는가?");
            Console.WriteLine("  4. 메서드 오버로딩 결정 - 어떤 오버로딩 메서드를 사용할까?");
            Console.WriteLine();

            /*
             * 컴파일타임 예제:
             * - 아래 코드들은 모두 컴파일타임에 검사됨
             */
            Console.WriteLine("[컴파일타임 예제]");
            int a = 10;                         // 컴파일타임: int 타입 확인
            double b = 20.5;                    // 컴파일타임: double 타입 확인  
            Console.WriteLine("Hello World");   // 컴파일타임: WriteLine 메서드 존재 확인
            Console.WriteLine("위 코드들은 컴파일타임에 검사되어 통과했습니다.");
            Console.WriteLine();

            /*
             * 런타임에 결정되는 것들:
             * - 프로그램이 실제로 실행되는 동안 처리되는 사항들
             * - 사용자의 입력이나 실제 데이터에 따라 결과가 달라짐
             */
            Console.WriteLine("■ 런타임에 결정되는 것들 (프로그램 실행 중):");
            Console.WriteLine("  1. 사용자 입력 처리");
            Console.WriteLine("  2. 실제 계산 수행");
            Console.WriteLine("  3. 메모리 할당/해제");
            Console.WriteLine("  4. 예외 처리");
            Console.WriteLine("  5. 가상 메서드 호출 결정 (다형성)");
            Console.WriteLine();

            /*
             * 런타임 예제 - 사용자 입력:
             * - 사용자가 실제로 무엇을 입력할지는 런타임에만 알 수 있음
             * - 입력값에 따라 프로그램 동작이 달라짐
             */
            Console.WriteLine("[런타임 예제 - 사용자 입력]");
            Console.WriteLine("숫자를 입력하세요 (런타임에 결정됨):");
            string input = Console.ReadLine();  // 런타임: 실제 사용자 입력

            try
            {
                /*
                 * 런타임 처리 과정:
                 * 1. 사용자 입력 문자열을 숫자로 변환 시도
                 * 2. 변환 성공 시 계산 수행
                 * 3. 변환 실패 시 예외 발생 → catch 블록으로 이동
                 */
                int number = int.Parse(input);           // 런타임: 문자열을 숫자로 변환 시도
                int result = a + number;                 // 런타임: 실제 덧셈 계산 수행
                Console.WriteLine($"결과: {a} + {number} = {result}");
                Console.WriteLine("성공: 런타임에 정상 처리되었습니다.");
            }
            catch (FormatException)
            {
                /*
                 * 런타임 예외 처리:
                 * - 사용자가 숫자가 아닌 문자를 입력했을 때 발생
                 * - 컴파일타임에는 문제없지만 런타임에 에러 발생
                 */
                Console.WriteLine("실패: 런타임에 변환 에러가 발생했습니다!");  // 런타임: 예외 처리
            }
            Console.WriteLine();

            Console.WriteLine("========================================");
            Console.WriteLine();

            // ==========================================
            // Part 2: 업캐스팅에서 컴파일타임 vs 런타임
            // ==========================================
            Console.WriteLine("=== 업캐스팅에서 컴파일타임 vs 런타임 ===");
            Console.WriteLine();

            /*
             * 업캐스팅의 컴파일타임 과정:
             * - 컴파일러가 업캐스팅이 가능한지 검사하는 단계
             */
            Console.WriteLine("■ 컴파일타임 과정:");
            Console.WriteLine("  1. Dog 클래스가 Animal을 상속하는지 확인");
            Console.WriteLine("  2. 업캐스팅이 가능한지 검사");
            Console.WriteLine("  3. Animal.MakeSound() 메서드 존재 확인");
            Console.WriteLine("  4. virtual 키워드 확인");
            Console.WriteLine("  → 컴파일 성공!");
            Console.WriteLine();

            /*
             * 실제 업캐스팅 수행:
             * - 컴파일타임에 허용된 업캐스팅을 런타임에 실행
             */
            Console.WriteLine("■ 실제 업캐스팅 수행:");
            Dog myDog = new Dog { Name = "바둑이", Breed = "진돗개" };
            Console.WriteLine($"Dog 객체 생성: {myDog.Name} ({myDog.Breed})");

            /*
             * 업캐스팅 실행:
             * - Dog 타입의 myDog를 Animal 타입의 animal로 참조
             * - 실제 객체는 여전히 Dog이지만, Animal 타입으로 접근
             */
            Animal animal = myDog; // 업캐스팅 (컴파일타임에 허용, 런타임에 실행)
            Console.WriteLine("업캐스팅 완료: Dog → Animal");
            Console.WriteLine();

            /*
             * 업캐스팅의 런타임 과정:
             * - 실제 메모리에서 일어나는 일들
             */
            Console.WriteLine("■ 런타임 과정:");
            Console.WriteLine("  1. 실제 Dog 객체가 메모리에 생성됨");
            Console.WriteLine("  2. animal 변수가 Dog 객체를 참조하게 됨");
            Console.WriteLine("  3. MakeSound() 호출 시:");
            Console.WriteLine("     - 컴파일타임: Animal.MakeSound() 확인");
            Console.WriteLine("     - 런타임: 실제 객체(Dog) 타입 확인");
            Console.WriteLine("     - 런타임: Dog.MakeSound() 실행!");
            Console.WriteLine();

            /*
             * 다형성 동작 확인:
             * - animal.MakeSound() 호출 시 실제로는 Dog.MakeSound()가 실행됨
             * - 이것이 다형성의 핵심!
             */
            Console.WriteLine("■ 다형성 동작 확인:");
            Console.WriteLine("animal.MakeSound() 호출 → ");
            animal.MakeSound();  // 런타임에 Dog의 MakeSound() 호출됨!
            Console.WriteLine("→ 런타임에 Dog의 MakeSound()가 실행되었습니다!");
            Console.WriteLine();

            Console.WriteLine("========================================");
            Console.WriteLine();

            // ==========================================
            // Part 3: 다운캐스팅에서 컴파일타임 vs 런타임
            // ==========================================
            Console.WriteLine("=== 다운캐스팅에서 컴파일타임 vs 런타임 ===");
            Console.WriteLine();

            /*
             * 다운캐스팅 테스트용 객체들 준비:
             * - 각각 다른 타입의 객체를 Animal 타입으로 업캐스팅하여 저장
             * - 실제 객체 타입은 다르지만 모두 Animal로 참조됨
             */
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

                /*
                 * 성공적인 다운캐스팅:
                 * - animal1이 실제로 Dog 객체이므로 캐스팅 성공
                 * - Dog의 고유 기능(Fetch()) 사용 가능
                 */
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

                /*
                 * 실패하는 다운캐스팅:
                 * - animal2는 실제로 Cat 객체
                 * - Cat을 Dog로 변환하려 시도 → 런타임 에러 발생
                 */
                Dog dog2 = (Dog)animal2; // 런타임에 실패!
            }
            catch (InvalidCastException ex)
            {
                /*
                 * InvalidCastException 처리:
                 * - 호환되지 않는 타입 간 캐스팅 시도 시 발생
                 * - Cat과 Dog는 형제 관계라서 서로 변환 불가능
                 */
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

            /*
             * as 연산자의 런타임 동작:
             * - 캐스팅 시도 후 성공하면 해당 타입 객체 반환
             * - 실패하면 예외 대신 null 반환 (안전함)
             */
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

            /*
             * as 연산자의 실패 케이스:
             * - Cat을 Dog로 변환 시도
             * - 변환 불가능하므로 null 반환 (예외 발생 안 함)
             */
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

            /*
             * is 연산자의 런타임 동작:
             * - 객체가 특정 타입인지 검사
             * - true/false 반환으로 안전한 타입 체크 제공
             */
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

            /*
             * is 연산자의 타입 불일치 케이스:
             * - animal2는 Cat이므로 Dog가 아님
             * - 조건문이 false가 되어 안전하게 처리
             */
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

            /*
             * 패턴 매칭의 런타임 동작:
             * - 타입 체크와 변수 할당을 한 번에 처리
             * - 가장 현대적이고 권장되는 방법
             */
            Console.WriteLine("▶ 런타임:");
            if (animal1 is Dog dog7) // 런타임에 타입 체크 + 변수 할당
            {
                Console.WriteLine("  - 실제 타입 확인: Dog");
                Console.WriteLine("  - 타입 일치하므로 dog7 변수에 할당");
                Console.WriteLine($"  - dog7 사용 가능: {dog7.Name} ({dog7.Breed})");
                Console.WriteLine("  ✅ 타입 체크와 변수 할당을 한 번에 처리");
                dog7.Fetch();
            }

            /*
             * 패턴 매칭의 다른 타입 처리:
             * - Cat 타입으로 패턴 매칭
             * - 각 타입에 맞는 처리 가능
             */
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
            // Part 4: 핵심 정리
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

            // ==========================================
            // Part 5: 추가 실습 예제
            // ==========================================

            /*
             * 추가 실습: 단계별 업캐스팅과 다운캐스팅 과정
             * - 학습을 위한 단계별 상세 과정 시연
             */
            Console.WriteLine("=== 추가 실습: 단계별 캐스팅 과정 ===");
            Console.WriteLine();

            /*
             * 1단계: 객체 생성
             * - 구체적인 타입(Bird)으로 객체 생성
             * - 객체 초기화자를 사용하여 속성 설정
             */
            Console.WriteLine("=== 1단계: 객체 생성 ===");
            Bird myBird = new Bird { Name = "참새" };
            Console.WriteLine($"Bird 생성: {myBird.Name}");
            Console.WriteLine();

            /*
             * 2단계: 업캐스팅 수행
             * - Bird 타입을 Animal 타입으로 업캐스팅
             * - 암시적 변환으로 자동 수행됨
             */
            Console.WriteLine("=== 2단계: 업캐스팅 ===");
            Animal animal4 = myBird;  // Bird → Animal 업캐스팅
            Console.WriteLine("업캐스팅 완료");
            Console.WriteLine("animal4: Bird → Animal");
            Console.WriteLine();

            /*
             * 3단계: 업캐스팅된 객체의 호출 가능한 메서드들
             * - Animal 타입으로는 Animal 클래스의 메서드만 호출 가능
             * - 하지만 가상 메서드는 실제 객체(Bird)의 구현이 호출됨
             */
            Console.WriteLine("=== 3단계: 업캐스팅된 객체의 호출 가능한 메서드들 ===");

            /*
             * MakeSound() 호출:
             * - Animal 타입으로 호출하지만
             * - 실제로는 Bird.MakeSound()가 실행됨 (다형성)
             */
            animal4.MakeSound();  // 다형성으로 Bird.MakeSound() 실행

            /*
             * Sleep() 호출:
             * - Animal 클래스의 일반 메서드
             * - 모든 자식 클래스가 공통으로 사용
             */
            animal4.Sleep();      // Animal.Sleep() 실행
            Console.WriteLine();

            /*
             * 4단계: 다운캐스팅
             * - Animal 타입을 다시 Bird 타입으로 변환
             * - 패턴 매칭을 사용한 안전한 다운캐스팅
             */
            Console.WriteLine("=== 4단계: 다운캐스팅 ===");
            if (animal4 is Bird bird)
            {
                /*
                 * 다운캐스팅 성공:
                 * - animal4가 실제로 Bird 객체이므로 변환 성공
                 * - Bird의 고유 메서드(Fly()) 사용 가능
                 */
                Console.WriteLine($"{bird.Name}을 Bird로 다운캐스팅 성공!");
                bird.Fly();  // Bird 고유 메서드 호출 가능
            }
            Console.WriteLine();

            // ==========================================
            // Part 6: 다형성 종합 예제
            // ==========================================

            /*
             * 다형성 종합 예제:
             * - 여러 다른 타입의 객체들을 Animal 배열에 저장
             * - 모든 객체를 동일한 방식으로 처리하면서도
             * - 각각의 고유한 동작이 실행되는 것을 확인
             */
            Console.WriteLine("=== 다형성 종합 예제 ===");
            Console.WriteLine();

            /*
             * 다양한 동물 객체들을 Animal 타입 배열에 저장:
             * - 각각 다른 구체적인 타입이지만 모두 Animal로 업캐스팅됨
             * - 배열을 통해 일관된 방식으로 처리 가능
             */
            Animal animal5 = new Dog { Name = "바둑이", Breed = "진돗개" };
            Animal animal6 = new Cat { Name = "나비", isIndoor = false };
            Animal animal7 = new Bird { Name = "참새" };

            Console.WriteLine("다양한 동물들의 소리:");
            Console.WriteLine($"1. {animal5.Name} ({animal5.GetType().Name}):");
            animal5.MakeSound();  // Dog.MakeSound() 실행

            Console.WriteLine($"2. {animal6.Name} ({animal6.GetType().Name}):");
            animal6.MakeSound();  // Cat.MakeSound() 실행

            Console.WriteLine($"3. {animal7.Name} ({animal7.GetType().Name}):");
            animal7.MakeSound();  // Bird.MakeSound() 실행

            Console.WriteLine();

            // ==========================================
            // Part 7: 배열을 통한 일괄 처리 예제
            // ==========================================

            /*
             * 배열을 통한 다형성 활용:
             * - 서로 다른 타입의 객체들을 하나의 배열에 저장
             * - foreach 루프로 일괄 처리
             * - 각 객체의 실제 타입에 따라 다른 동작 수행
             */
            Console.WriteLine("=== 배열을 통한 일괄 처리 ===");

            Animal[] allAnimals = { animal5, animal6, animal7 };

            Console.WriteLine("모든 동물들의 이동:");
            foreach (Animal animalItem in allAnimals)
            {
                /*
                 * 다형성을 통한 일괄 처리:
                 * - 같은 코드 animalItem.MakeSound()
                 * - 하지만 각 객체의 실제 타입에 따라 다른 동작
                 * - Dog → "멍멍!", Cat → "야옹!", Bird → "짹짹!"
                 */
                Console.Write($"{animalItem.Name}: ");
                animalItem.MakeSound();
            }
            Console.WriteLine();

            // ==========================================
            // Part 8: 고급 다형성 활용 - 타입별 특별 처리
            // ==========================================

            /*
             * 고급 다형성 활용:
             * - 공통 처리와 타입별 특별 처리를 조합
             * - switch 패턴 매칭을 활용한 타입별 분기
             */
            Console.WriteLine("=== 타입별 특별 처리 ===");

            foreach (Animal animalItem in allAnimals)
            {
                Console.WriteLine($"\n--- {animalItem.Name} ({animalItem.GetType().Name}) 처리 ---");

                // 공통 동작: 모든 동물이 소리내기
                animalItem.MakeSound();

                /*
                 * 타입별 특별 동작:
                 * - switch 패턴 매칭을 사용하여 각 타입별로 고유한 동작 수행
                 * - 다운캐스팅을 통해 각 타입의 고유 메서드 호출
                 */
                switch (animalItem)
                {
                    case Dog dog:
                        /*
                         * Dog 타입일 때의 특별 처리:
                         * - Dog 고유의 Fetch() 메서드 호출
                         * - Breed 정보 출력
                         */
                        Console.WriteLine($"품종: {dog.Breed}");
                        dog.Fetch();
                        break;

                    case Cat cat:
                        /*
                         * Cat 타입일 때의 특별 처리:
                         * - Cat 고유의 Climb() 메서드 호출
                         * - 실내묘 여부 정보 출력
                         */
                        Console.WriteLine($"실내묘: {(cat.isIndoor ? "예" : "아니오")}");
                        cat.Climb();
                        break;

                    case Bird bird1:
                        /*
                         * Bird 타입일 때의 특별 처리:
                         * - Bird 고유의 Fly() 메서드 호출
                         */
                        bird1.Fly();
                        break;

                    default:
                        /*
                         * 알 수 없는 타입일 때:
                         * - 새로운 Animal 하위 클래스가 추가되었을 때 대비
                         */
                        Console.WriteLine("알 수 없는 동물 타입입니다.");
                        break;
                }
            }

            // ==========================================
            // Part 9: 프로그램 마무리 및 최종 정리
            // ==========================================

            Console.WriteLine("\n========================================");
            Console.WriteLine("           프로그램 완료!");
            Console.WriteLine("========================================");
            Console.WriteLine();

            /*
             * 최종 학습 정리:
             * 이 프로그램을 통해 학습한 핵심 개념들
             */
            Console.WriteLine("🎓 학습한 핵심 개념들:");
            Console.WriteLine();

            Console.WriteLine("1. 📊 컴파일타임 vs 런타임:");
            Console.WriteLine("   • 컴파일타임: 문법 검사, 타입 검사");
            Console.WriteLine("   • 런타임: 실제 실행, 동적 타입 결정");
            Console.WriteLine();

            Console.WriteLine("2. ⬆️ 업캐스팅 (자식 → 부모):");
            Console.WriteLine("   • 자동으로 수행됨 (암시적)");
            Console.WriteLine("   • 항상 안전함");
            Console.WriteLine("   • 다형성의 기반");
            Console.WriteLine();

            Console.WriteLine("3. ⬇️ 다운캐스팅 (부모 → 자식):");
            Console.WriteLine("   • 명시적으로 수행해야 함");
            Console.WriteLine("   • 실패할 수 있음 (위험)");
            Console.WriteLine("   • 안전한 방법: is, as, 패턴 매칭");
            Console.WriteLine();

            Console.WriteLine("4. 🔄 다형성 (Polymorphism):");
            Console.WriteLine("   • 같은 코드, 다른 동작");
            Console.WriteLine("   • 런타임에 실제 타입 확인");
            Console.WriteLine("   • virtual/override 키워드 활용");
            Console.WriteLine();

            Console.WriteLine("5. 🎯 실무 활용:");
            Console.WriteLine("   • 배열/컬렉션을 통한 일괄 처리");
            Console.WriteLine("   • 타입별 특별 처리 (switch 패턴 매칭)");
            Console.WriteLine("   • 확장 가능한 시스템 설계");
            Console.WriteLine();

            /*
             * 프로그램 종료 메시지:
             * - 사용자가 프로그램 완료를 인식할 수 있도록
             */
            Console.WriteLine("프로그램을 종료하려면 아무 키나 누르세요...");
            Console.ReadKey();

            /*
             ==========================================
             전체 프로그램에서 다룬 주요 내용 요약
             ==========================================
             
             이 프로그램은 C#의 핵심 객체지향 개념들을 종합적으로 다루었습니다:
             
             🏗️ 기본 개념:
             - 상속 (Inheritance): Animal ← Dog, Cat, Bird
             - 다형성 (Polymorphism): 같은 메서드 호출, 다른 실행
             - 캐스팅 (Casting): 타입 변환 (업캐스팅/다운캐스팅)
             
             ⏰ 시점별 구분:
             - 컴파일타임: 코드 검증, 문법 확인
             - 런타임: 실제 실행, 동적 결정
             
             🛡️ 안전성:
             - 업캐스팅: 항상 안전 (자동)
             - 다운캐스팅: 주의 필요 (수동, 안전장치 사용)
             
             💡 실무 패턴:
             - 배열/컬렉션을 통한 다형성 활용
             - 패턴 매칭을 통한 안전한 타입 처리
             - 확장 가능한 객체지향 설계
             
             이러한 개념들은 실제 소프트웨어 개발에서 매우 중요하며,
             특히 대규모 시스템 설계 시 유연성과 확장성을 제공합니다.
             ==========================================
             */
        }
    }
}