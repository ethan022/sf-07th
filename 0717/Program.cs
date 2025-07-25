using System;
using System.Text;

/*
 ================================================================================================
 C# 입문: 변수, 자료형, 연산자, 조건문 완전 정복
 ================================================================================================
 
 📚 이 프로그램에서 학습할 내용:
 1. 변수 선언과 출력
 2. C#의 기본 자료형들
 3. 형변환 (캐스팅)
 4. 다양한 연산자들
 5. 조건문 (if, else if, else)
 6. 삼항 연산자
 7. 랜덤 함수 활용
 
 🎯 초보자를 위한 단계별 학습 프로그램
 
 ================================================================================================
 */

namespace CSharpBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // ==========================================
            // 프로그램 시작 - Hello World!
            // ==========================================

            /*
             * 전통적인 첫 번째 프로그램
             * Console.WriteLine(): 콘솔에 텍스트를 출력하고 줄바꿈
             */
            Console.WriteLine("Hello, World!");
            Console.WriteLine("C# 기초 학습을 시작합니다! 🚀");
            Console.WriteLine();

            // ==========================================
            // 📌 변수 선언 및 출력
            // ==========================================

            Console.WriteLine("=== 1. 변수 선언 및 출력 ===");

            /*
             * 변수 선언과 초기화:
             * - int: 정수형 데이터 타입
             * - 한 줄에 여러 변수를 동시에 선언 가능
             * - 각 변수는 쉼표(,)로 구분
             */
            int a = 10, b = 20, c = 30;

            /*
             * Console.WriteLine()을 사용한 변수 출력:
             * - 변수명을 그대로 사용하면 변수의 값이 출력됨
             */
            Console.WriteLine($"변수 a: {a}");
            Console.WriteLine($"변수 b: {b}");
            Console.WriteLine($"변수 c: {c}");
            Console.WriteLine();

            // ==========================================
            // 📌 다양한 기본 자료형
            // ==========================================

            Console.WriteLine("=== 2. 다양한 기본 자료형 ===");

            /*
             * C#의 주요 기본 자료형들:
             * - string: 문자열 (텍스트 데이터)
             * - int: 정수 (-2,147,483,648 ~ 2,147,483,647)
             * - double: 실수 (소수점 포함)
             * - bool: 불리언 (true 또는 false)
             */
            string name = "ethan";        // 문자열: 따옴표로 감쌈
            int age = 20;                 // 정수: 숫자 그대로
            double height = 170.5;        // 실수: 소수점 포함 가능
            bool isStudent = true;        // 불리언: true 또는 false만 가능

            /*
             * 문자열 연결 방법들:
             * 1. + 연산자 사용 (전통적 방법)
             * 2. $ 문자열 보간 사용 (현대적 방법, 권장)
             */
            Console.WriteLine("이름: " + name);                    // + 연산자 방식
            Console.WriteLine($"나이: {age}세");                   // 문자열 보간 방식 (권장)
            Console.WriteLine($"키: {height}cm");
            Console.WriteLine($"학생인가요? {isStudent}");
            Console.WriteLine();

            // ==========================================
            // 📌 변수 값 변경
            // ==========================================

            Console.WriteLine("=== 3. 변수 값 변경 ===");

            /*
             * 변수의 값은 언제든지 변경 가능 (var 키워드 제외)
             * 같은 타입의 값으로만 변경 가능
             */
            int age1 = 20;
            Console.WriteLine($"age1 초기값: {age1}");

            age1 = 30;                    // 직접 새로운 값 할당
            Console.WriteLine($"age1 변경 후: {age1}");

            age1 = age;                   // 다른 변수의 값을 복사
            Console.WriteLine($"age1을 age 값으로 변경: {age1}");

            /*
             * 문자열 보간 (String Interpolation):
             * - $ 기호를 문자열 앞에 붙이고 {}로 변수를 감쌈
             * - 가독성이 좋고 현대적인 방법
             */
            Console.WriteLine($"최종 정보 → 이름: {name}, 나이: {age1}");
            Console.WriteLine();

            // ==========================================
            // 📌 var 키워드 (자동 자료형 추론)
            // ==========================================

            Console.WriteLine("=== 4. var 키워드 (자동 타입 추론) ===");

            /*
             * var 키워드:
             * - 컴파일러가 초기값을 보고 자동으로 타입을 결정
             * - 반드시 선언과 동시에 초기화해야 함
             * - 한 번 결정된 타입은 변경 불가능
             */
            var name1 = 10;          // 컴파일러가 int로 추론
            var name2 = "ethan";     // 컴파일러가 string으로 추론
            var name3 = 3.14;        // 컴파일러가 double로 추론

            Console.WriteLine($"name1: {name1} (타입: {name1.GetType()})");
            Console.WriteLine($"name2: {name2} (타입: {name2.GetType()})");
            Console.WriteLine($"name3: {name3} (타입: {name3.GetType()})");

            // name1 = "문자열";     // ❌ 에러! int로 결정된 후에는 문자열 할당 불가
            Console.WriteLine();

            // ==========================================
            // 📌 형변환 (캐스팅)
            // ==========================================

            Console.WriteLine("=== 5. 형변환 (캐스팅) ===");

            /*
             * 형변환이 필요한 경우:
             * - 다른 타입의 데이터를 특정 타입으로 변환해야 할 때
             * - 사용자 입력(문자열)을 숫자로 변환할 때
             * - 계산 결과를 문자열로 표시할 때
             */

            // 문자열 → 정수 변환
            int num1 = 10;
            string num2 = "300";                // 문자열 "300"
            num1 = int.Parse(num2);             // 문자열을 정수로 변환
            Console.WriteLine($"문자열 '300'을 정수로 변환: {num1}");

            // 정수 → 문자열 변환
            int str1 = 10;
            string str2 = str1.ToString();      // 정수를 문자열로 변환
            Console.WriteLine($"정수 10을 문자열로 변환: '{str2}'");

            /*
             * 다른 형변환 방법들:
             * - int.Parse(): 문자열 → 정수 (실패 시 예외 발생)
             * - int.TryParse(): 문자열 → 정수 (실패 시 false 반환)
             * - Convert.ToInt32(): 다양한 타입 → 정수
             * - (int): 명시적 캐스팅 (데이터 손실 가능)
             */
            Console.WriteLine();

            // ==========================================
            // 📌 GetType() : 변수의 자료형 확인
            // ==========================================

            Console.WriteLine("=== 6. GetType() - 변수의 자료형 확인 ===");

            /*
             * GetType() 메서드:
             * - 변수의 실제 데이터 타입을 반환
             * - 디버깅이나 타입 확인 시 유용
             * - var 키워드 사용 시 실제 추론된 타입 확인 가능
             */
            var userName = "ethan";     // string으로 추론
            var userNum = 2000;         // int로 추론
            var userChar = 'A';         // char로 추론
            var userDecimal = 10.5m;    // decimal로 추론 (m 접미사 때문)

            Console.WriteLine($"userName의 타입: {userName.GetType()}");    // System.String
            Console.WriteLine($"userNum의 타입: {userNum.GetType()}");      // System.Int32
            Console.WriteLine($"userChar의 타입: {userChar.GetType()}");    // System.Char
            Console.WriteLine($"userDecimal의 타입: {userDecimal.GetType()}"); // System.Decimal
            Console.WriteLine();

            // ==========================================
            // 📌 다양한 숫자형 자료형
            // ==========================================

            Console.WriteLine("=== 7. 다양한 숫자형 자료형 ===");

            /*
             * C#의 숫자형 자료형들과 범위:
             * - byte: 0 ~ 255 (1바이트)
             * - short: -32,768 ~ 32,767 (2바이트)
             * - int: -2,147,483,648 ~ 2,147,483,647 (4바이트)
             * - float: 단정밀도 실수 (4바이트, f 접미사 필요)
             * - double: 배정밀도 실수 (8바이트, 기본 실수형)
             * - decimal: 고정밀도 실수 (16바이트, m 접미사 필요, 금융 계산용)
             */
            byte myByte = 255;              // 최대값 255
            short myShort = 30000;          // -32,768 ~ 32,767
            int myInt = 50000;              // 가장 일반적인 정수형
            float myFloat = 10.1f;          // f 접미사 필수 (없으면 double로 인식)
            double myDouble = 10.2;         // 기본 실수형 (접미사 불필요)
            decimal myDecimal = 10.2m;      // m 접미사 필수, 금융 계산에 적합

            Console.WriteLine("숫자형 자료형 정보:");
            Console.WriteLine($"1. {myByte.GetType(),-10} myByte: {myByte}");
            Console.WriteLine($"2. {myShort.GetType(),-10} myShort: {myShort}");
            Console.WriteLine($"3. {myInt.GetType(),-10} myInt: {myInt}");
            Console.WriteLine($"4. {myFloat.GetType(),-10} myFloat: {myFloat}");
            Console.WriteLine($"5. {myDouble.GetType(),-10} myDouble: {myDouble}");
            Console.WriteLine($"6. {myDecimal.GetType(),-10} myDecimal: {myDecimal}");
            Console.WriteLine();

            // ==========================================
            // 📌 비교 연산자
            // ==========================================

            Console.WriteLine("=== 8. 비교 연산자 ===");

            /*
             * 비교 연산자들:
             * - > : 크다
             * - < : 작다
             * - >= : 크거나 같다
             * - <= : 작거나 같다
             * - == : 같다
             * - != : 같지 않다
             * 
             * 결과는 항상 bool (true 또는 false)
             */
            int a1 = 10, b1 = 20, c1 = 30;

            Console.WriteLine("초기값: a1=10, b1=20, c1=30");
            Console.WriteLine($"1. a1 > b1: {a1 > b1}");        // 10 > 20 = false
            Console.WriteLine($"2. c1 > b1: {c1 > b1}");        // 30 > 20 = true

            b1 = 10;  // b1을 10으로 변경
            Console.WriteLine("\nb1을 10으로 변경 후:");
            Console.WriteLine($"3. a1 >= b1: {a1 >= b1}");      // 10 >= 10 = true
            Console.WriteLine($"4. c1 >= b1: {c1 >= b1}");      // 30 >= 10 = true

            b1 = 30;  // b1을 30으로 변경
            Console.WriteLine("\nb1을 30으로 변경 후:");
            Console.WriteLine($"5. a1 <= b1: {a1 <= b1}");      // 10 <= 30 = true
            Console.WriteLine($"6. c1 <= b1: {c1 <= b1}");      // 30 <= 30 = true
            Console.WriteLine($"7. a1 == b1: {a1 == b1}");      // 10 == 30 = false
            Console.WriteLine($"8. c1 != b1: {c1 != b1}");      // 30 != 30 = false
            Console.WriteLine();

            // ==========================================
            // 📌 산술 연산자 + Math.Pow()
            // ==========================================

            Console.WriteLine("=== 9. 산술 연산자 ===");

            /*
             * 산술 연산자들:
             * - + : 덧셈
             * - - : 뺄셈  
             * - * : 곱셈
             * - / : 나눗셈 (정수 나눗셈 시 소수점 버림)
             * - % : 나머지 (모듈로 연산)
             * - Math.Pow() : 거듭제곱
             */
            int number1 = 10, number2 = 20;
            int num3 = 3, num4 = 5;

            Console.WriteLine("산술 연산자 결과:");
            Console.WriteLine($"1. {number1} + {number2} = {number1 + number2}");
            Console.WriteLine($"2. {number2} - {number1} = {number2 - number1}");
            Console.WriteLine($"3. {number1} * {number2} = {number1 * number2}");
            Console.WriteLine($"4. {number2} / {number1} = {number2 / number1}");           // 정수 나눗셈
            Console.WriteLine($"5. {number1}의 {num3}제곱 = {Math.Pow(number1, num3)}");    // 거듭제곱
            Console.WriteLine($"6. {number1} % {num3} = {number1 % num3}");                 // 나머지

            /*
             * 실수 나눗셈 예제:
             * 정수끼리 나눗셈은 소수점이 버려지므로 주의!
             */
            Console.WriteLine($"\n실수 나눗셈 예제:");
            Console.WriteLine($"정수 나눗셈: 7 / 3 = {7 / 3}");                    // 2 (소수점 버림)
            Console.WriteLine($"실수 나눗셈: 7.0 / 3 = {7.0 / 3}");                // 2.333...
            Console.WriteLine();

            // ==========================================
            // 📌 복합 대입 연산자 & 증감 연산자
            // ==========================================

            Console.WriteLine("=== 10. 복합 대입 연산자 & 증감 연산자 ===");

            /*
             * 복합 대입 연산자:
             * - += : 더하고 할당 (number1 += 10 → number1 = number1 + 10)
             * - -= : 빼고 할당
             * - *= : 곱하고 할당
             * - /= : 나누고 할당
             * 
             * 증감 연산자:
             * - ++ : 1 증가 (전위: ++num, 후위: num++)
             * - -- : 1 감소 (전위: --num, 후위: num--)
             */

            // 현재 값 출력
            Console.WriteLine($"연산 전 값들: number1={number1}, number2={number2}, num3={num3}, num4={num4}");

            // 복합 대입 연산자 적용
            number1 += 10;  // number1 = number1 + 10 = 10 + 10 = 20
            number2 -= 5;   // number2 = number2 - 5 = 20 - 5 = 15
            num3 *= 3;      // num3 = num3 * 3 = 3 * 3 = 9
            num4 /= 5;      // num4 = num4 / 5 = 5 / 5 = 1

            Console.WriteLine("복합 대입 연산자 결과:");
            Console.WriteLine($"1. number1 += 10: {number1}");
            Console.WriteLine($"2. number2 -= 5: {number2}");
            Console.WriteLine($"3. num3 *= 3: {num3}");
            Console.WriteLine($"4. num4 /= 5: {num4}");

            // 증감 연산자
            Console.WriteLine($"\n증감 연산자 (num4 현재값: {num4}):");
            num4++;  // 후위 증가: 현재 값 사용 후 1 증가
            Console.WriteLine($"5. num4++ 후: {num4}");
            num4--;  // 후위 감소: 현재 값 사용 후 1 감소
            Console.WriteLine($"6. num4-- 후: {num4}");

            /*
             * 전위 vs 후위 증감 연산자:
             * - 전위 (++num): 먼저 1 증가/감소 후 값 사용
             * - 후위 (num++): 현재 값 사용 후 1 증가/감소
             */
            int testNum = 5;
            Console.WriteLine($"\n전위 vs 후위 비교 (testNum = {testNum}):");
            Console.WriteLine($"후위 증가 testNum++: {testNum++}"); // 5 출력 후 6이 됨
            Console.WriteLine($"현재 testNum: {testNum}");          // 6
            Console.WriteLine($"전위 증가 ++testNum: {++testNum}"); // 먼저 7로 증가 후 7 출력
            Console.WriteLine();

            // ==========================================
            // 📌 논리 연산자
            // ==========================================

            Console.WriteLine("=== 11. 논리 연산자 ===");

            /*
             * 논리 연산자:
             * - || : OR (논리합) - 하나라도 true면 true
             * - && : AND (논리곱) - 모두 true여야 true
             * - ! : NOT (논리부정) - true ↔ false 반전
             * 
             * 단축 평가 (Short-circuit evaluation):
             * - OR: 첫 번째가 true면 두 번째 평가 안 함
             * - AND: 첫 번째가 false면 두 번째 평가 안 함
             */
            bool isA = false, isB = true;

            Console.WriteLine($"초기값: isA = {isA}, isB = {isB}");
            Console.WriteLine("논리 연산자 결과:");
            Console.WriteLine($"1. isA || isB (OR): {isA || isB}");   // false || true = true
            Console.WriteLine($"2. isA && isB (AND): {isA && isB}");  // false && true = false
            Console.WriteLine($"3. !isA (NOT): {!isA}");              // !false = true
            Console.WriteLine($"4. !isB (NOT): {!isB}");              // !true = false

            // 다양한 조합 예제
            Console.WriteLine("\n다양한 논리 연산 조합:");
            Console.WriteLine($"true || false: {true || false}");     // true
            Console.WriteLine($"true && false: {true && false}");     // false
            Console.WriteLine($"!true && !false: {!true && !false}"); // false && true = false
            Console.WriteLine($"!(true && false): {!(true && false)}"); // !false = true
            Console.WriteLine();

            // ==========================================
            // 📌 삼항 연산자
            // ==========================================

            Console.WriteLine("=== 12. 삼항 연산자 (조건 연산자) ===");

            /*
             * 삼항 연산자 (Ternary Operator):
             * 문법: 조건 ? 참일때값 : 거짓일때값
             * 
             * 장점:
             * - 간단한 조건문을 한 줄로 표현 가능
             * - if-else문의 축약형
             * 
             * 주의사항:
             * - 복잡한 로직에는 가독성이 떨어질 수 있음
             * - 간단한 조건에만 사용 권장
             */
            int score = 85;

            Console.WriteLine("삼항 연산자 예제:");
            Console.WriteLine($"점수: {score}");

            // 기본 삼항 연산자
            string result1 = (score >= 60) ? "합격" : "불합격";
            Console.WriteLine($"1. 합격 여부: {result1}");

            // 복잡한 논리식과 삼항 연산자 조합
            string result2 = (true || (false && true)) ? "참" : "거짓";
            Console.WriteLine($"2. true || (false && true): {result2}");

            string result3 = ((false || true) || (false && true)) ? "참" : "거짓";
            Console.WriteLine($"3. ((false || true) || (false && true)): {result3}");

            string result4 = ((false || false) || (false && true)) ? "참" : "거짓";
            Console.WriteLine($"4. ((false || false) || (false && true)): {result4}");

            // 중첩 삼항 연산자 (권장하지 않음 - 가독성 떨어짐)
            string grade = score >= 90 ? "A" : score >= 80 ? "B" : score >= 70 ? "C" : "F";
            Console.WriteLine($"5. 학점 (중첩 삼항): {grade}");
            Console.WriteLine();

            // ==========================================
            // 📌 조건문 if-else if-else
            // ==========================================

            Console.WriteLine("=== 13. 조건문 (if-else if-else) ===");

            /*
             * 조건문의 구조:
             * if (조건1)
             *     실행문1;
             * else if (조건2)
             *     실행문2;
             * else
             *     실행문3;
             * 
             * 특징:
             * - 위에서부터 순서대로 조건 검사
             * - 첫 번째 참인 조건의 블록만 실행
             * - else는 모든 조건이 거짓일 때 실행
             */
            score = 85;
            Console.WriteLine($"현재 점수: {score}");

            if (score >= 90)
            {
                Console.WriteLine("결과: 합격입니다. (우수한 성적!)");
            }
            else if (score >= 85)
            {
                Console.WriteLine("결과: 재시험입니다. (아쉬운 점수)");
            }
            else if (score >= 60)
            {
                Console.WriteLine("결과: 조건부 합격입니다.");
            }
            else
            {
                Console.WriteLine("결과: 불합격입니다.");
            }
            Console.WriteLine();

            // ==========================================
            // 📌 중첩 조건문: 세밀한 학점 판정
            // ==========================================

            Console.WriteLine("=== 14. 중첩 조건문 - 세밀한 학점 판정 ===");

            /*
             * 중첩 조건문:
             * - 조건문 안에 또 다른 조건문을 포함
             * - 더 세밀한 분류가 가능
             * - 들여쓰기로 구조를 명확히 표현
             */
            score = 66;
            Console.WriteLine($"점수: {score}점");

            if (score >= 90)
            {
                if (score >= 95)
                    Console.WriteLine("학점: A+ (탁월함)");
                else
                    Console.WriteLine("학점: A (우수함)");
            }
            else if (score >= 80)
            {
                if (score >= 85)
                    Console.WriteLine("학점: B+ (양호함)");
                else
                    Console.WriteLine("학점: B (보통 이상)");
            }
            else if (score >= 70)
            {
                if (score >= 75)
                    Console.WriteLine("학점: C+ (평균 이상)");
                else
                    Console.WriteLine("학점: C (평균)");
            }
            else if (score >= 60)
            {
                if (score >= 65)
                    Console.WriteLine("학점: D+ (미흡하지만 통과)");
                else
                    Console.WriteLine("학점: D (최소 통과)");
            }
            else
            {
                Console.WriteLine("학점: F (재수강 필요)");
            }
            Console.WriteLine();

            // ==========================================
            // 📌 랜덤 + 조건문 예제: 게임 승패 판정
            // ==========================================

            Console.WriteLine("=== 15. 랜덤 + 조건문 - 게임 승패 판정 ===");

            /*
             * Random 클래스:
             * - 무작위 숫자 생성을 위한 클래스
             * - Next(min, max): min 이상 max 미만의 정수 반환
             * - NextDouble(): 0.0 이상 1.0 미만의 실수 반환
             * 
             * 활용 예시:
             * - 게임의 랜덤 요소 (주사위, 카드 등)
             * - 시뮬레이션 및 테스트 데이터 생성
             */
            Random random = new Random();

            Console.WriteLine("🎲 랜덤 게임: 홀수면 승리, 짝수면 패배!");

            for (int i = 1; i <= 5; i++)  // 5번 게임 실행
            {
                int randomValue = random.Next(1, 10);  // 1~9 사이의 랜덤 숫자

                Console.Write($"{i}번째 게임 - 랜덤 숫자: {randomValue} → ");

                if (randomValue % 2 == 1)  // 홀수 체크 (나머지가 1)
                {
                    Console.WriteLine("승리! 🎉");
                }
                else  // 짝수 (나머지가 0)
                {
                    Console.WriteLine("패배! 😢");
                }
            }

            // 보너스: 더 복잡한 랜덤 게임
            Console.WriteLine("\n🎯 보너스 게임: 숫자 범위별 등급 판정");
            int bonusNumber = random.Next(1, 101);  // 1~100
            Console.Write($"랜덤 숫자: {bonusNumber} → ");

            if (bonusNumber >= 90)
                Console.WriteLine("전설 등급! ⭐⭐⭐");
            else if (bonusNumber >= 70)
                Console.WriteLine("희귀 등급! ⭐⭐");
            else if (bonusNumber >= 50)
                Console.WriteLine("일반 등급! ⭐");
            else
                Console.WriteLine("쓰레기 등급! 💩");

            Console.WriteLine();

            // ==========================================
            // 📌 추가 학습: switch문
            // ==========================================

            Console.WriteLine("=== 16. switch문 (조건문의 다른 형태) ===");

            /*
             * switch문:
             * - 하나의 변수를 여러 값과 비교할 때 사용
             * - if-else if 연쇄보다 가독성이 좋을 수 있음
             * - break 키워드로 각 case 종료 (없으면 다음 case로 계속)
             * 
             * 사용 적합한 경우:
             * - 하나의 변수를 여러 고정값과 비교
             * - 메뉴 선택, 요일 판정, 등급 분류 등
             */
            int dayNumber = random.Next(1, 8);  // 1~7 (요일)
            Console.WriteLine($"요일 번호: {dayNumber}");

            switch (dayNumber)
            {
                case 1:
                    Console.WriteLine("월요일 - 한 주의 시작! 💪");
                    break;
                case 2:
                    Console.WriteLine("화요일 - 아직 화요일... 😅");
                    break;
                case 3:
                    Console.WriteLine("수요일 - 한 주의 중간! 🕐");
                    break;
                case 4:
                    Console.WriteLine("목요일 - 거의 다 왔어! 😊");
                    break;
                case 5:
                    Console.WriteLine("금요일 - 불금이다! 🎉");
                    break;
                case 6:
                    Console.WriteLine("토요일 - 주말 시작! 🏖️");
                    break;
                case 7:
                    Console.WriteLine("일요일 - 휴식의 날! 😴");
                    break;
                default:
                    Console.WriteLine("잘못된 요일 번호입니다.");
                    break;
            }
            Console.WriteLine();

            // ==========================================
            // 📌 실무 팁: 코딩 베스트 프랙티스
            // ==========================================

            Console.WriteLine("=== 17. 실무 팁: 코딩 베스트 프랙티스 ===");

            /*
             * 실무에서 중요한 코딩 습관들:
             * 1. 명확한 변수명 사용
             * 2. 적절한 주석 작성
             * 3. 들여쓰기와 공백 일관성
             * 4. 매직 넘버 피하기 (상수 사용)
             * 5. 함수/메서드로 기능 분리
             */

            // ❌ 나쁜 예: 의미 불분명한 변수명과 매직 넘버
            // int x = 85;
            // if (x >= 60) Console.WriteLine("OK");

            // ✅ 좋은 예: 명확한 변수명과 상수 사용
            const int PASSING_SCORE = 60;  // 상수로 매직 넘버 제거
            const int EXCELLENT_SCORE = 90;

            int studentScore = 85;  // 명확한 변수명

            Console.WriteLine("베스트 프랙티스 예제:");
            Console.WriteLine($"학생 점수: {studentScore}");

            // 명확한 조건문과 출력 메시지
            if (studentScore >= EXCELLENT_SCORE)
            {
                Console.WriteLine($"우수한 성적입니다! ({EXCELLENT_SCORE}점 이상)");
            }
            else if (studentScore >= PASSING_SCORE)
            {
                Console.WriteLine($"합격입니다! ({PASSING_SCORE}점 이상)");
            }
            else
            {
                Console.WriteLine($"아쉽게도 불합격입니다. ({PASSING_SCORE}점 미만)");
            }
            Console.WriteLine();

            // ==========================================
            // 📌 종합 실습: 간단한 계산기
            // ==========================================

            Console.WriteLine("=== 18. 종합 실습: 간단한 계산기 ===");

            /*
             * 지금까지 배운 내용들을 종합한 실습:
             * - 변수 선언 및 초기화
             * - 산술 연산자
             * - 조건문 (switch문)
             * - 형변환
             * - 예외 처리 개념
             */

            double num1_calc = 15.5;
            double num2_calc = 4.2;
            char operation = '+';  // +, -, *, / 중 하나

            Console.WriteLine("🧮 간단한 계산기");
            Console.WriteLine($"숫자1: {num1_calc}");
            Console.WriteLine($"숫자2: {num2_calc}");
            Console.WriteLine($"연산자: {operation}");
            Console.Write("결과: ");

            switch (operation)
            {
                case '+':
                    Console.WriteLine($"{num1_calc} + {num2_calc} = {num1_calc + num2_calc}");
                    break;
                case '-':
                    Console.WriteLine($"{num1_calc} - {num2_calc} = {num1_calc - num2_calc}");
                    break;
                case '*':
                    Console.WriteLine($"{num1_calc} × {num2_calc} = {num1_calc * num2_calc}");
                    break;
                case '/':
                    if (num2_calc != 0)  // 0으로 나누기 방지
                    {
                        Console.WriteLine($"{num1_calc} ÷ {num2_calc} = {num1_calc / num2_calc:F2}");
                    }
                    else
                    {
                        Console.WriteLine("오류: 0으로 나눌 수 없습니다!");
                    }
                    break;
                default:
                    Console.WriteLine("지원하지 않는 연산자입니다.");
                    break;
            }
            Console.WriteLine();

            // ==========================================
            // 📌 마무리: 학습 내용 정리
            // ==========================================

            Console.WriteLine("========================================");
            Console.WriteLine("🎓 C# 기초 학습 완료!");
            Console.WriteLine("========================================");

            Console.WriteLine("✅ 오늘 학습한 내용:");
            Console.WriteLine("1. 변수 선언과 초기화");
            Console.WriteLine("2. 기본 자료형 (int, string, double, bool 등)");
            Console.WriteLine("3. var 키워드와 타입 추론");
            Console.WriteLine("4. 형변환 (int.Parse, ToString 등)");
            Console.WriteLine("5. GetType()으로 타입 확인");
            Console.WriteLine("6. 다양한 숫자형 자료형");
            Console.WriteLine("7. 비교 연산자 (>, <, ==, != 등)");
            Console.WriteLine("8. 산술 연산자 (+, -, *, /, %, Math.Pow)");
            Console.WriteLine("9. 복합 대입 연산자 (+=, -=, *=, /=)");
            Console.WriteLine("10. 증감 연산자 (++, --)");
            Console.WriteLine("11. 논리 연산자 (||, &&, !)");
            Console.WriteLine("12. 삼항 연산자 (조건 ? 참 : 거짓)");
            Console.WriteLine("13. 조건문 (if, else if, else)");
            Console.WriteLine("14. 중첩 조건문");
            Console.WriteLine("15. switch문");
            Console.WriteLine("16. Random 클래스 활용");
            Console.WriteLine("17. 실무 베스트 프랙티스");
            Console.WriteLine("18. 종합 실습 (계산기)");

            Console.WriteLine("\n🚀 다음 학습 추천:");
            Console.WriteLine("- 반복문 (for, while, foreach)");
            Console.WriteLine("- 배열과 컬렉션");
            Console.WriteLine("- 메서드와 함수");
            Console.WriteLine("- 클래스와 객체지향 프로그래밍");
            Console.WriteLine("- 예외 처리 (try-catch)");

            Console.WriteLine("\n프로그램을 종료하려면 아무 키나 누르세요...");
            Console.ReadKey();

            /*
             ================================================================================================
             C# 기초 완전 정복 완료!
             ================================================================================================
             
             🎯 핵심 학습 포인트 정리:
             
             📝 변수와 자료형:
             - 변수는 데이터를 저장하는 공간
             - 각 자료형마다 저장 가능한 데이터 범위가 다름
             - var 키워드로 타입 추론 가능 (단, 초기화 필수)
             
             🔄 형변환:
             - int.Parse(): 문자열 → 정수
             - ToString(): 다른 타입 → 문자열
             - 적절한 형변환으로 데이터 타입 불일치 해결
             
             🧮 연산자:
             - 산술: +, -, *, /, %, Math.Pow()
             - 비교: >, <, >=, <=, ==, !=
             - 논리: ||, &&, !
             - 대입: =, +=, -=, *=, /=
             - 증감: ++, --
             - 삼항: 조건 ? 참값 : 거짓값
             
             🔀 조건문:
             - if-else if-else: 순차적 조건 검사
             - switch: 하나의 값에 대한 다중 분기
             - 중첩 조건문으로 세밀한 분류 가능
             
             💡 실무 팁:
             - 명확한 변수명 사용
             - 매직 넘버 대신 상수 사용
             - 적절한 주석과 들여쓰기
             - 예외 상황 고려 (0으로 나누기 등)
             
             🎮 실습을 통한 학습:
             - 랜덤 게임으로 조건문 연습
             - 계산기 만들기로 종합 응용
             - 실제 동작하는 프로그램 작성 경험
             
             ================================================================================================
             */
        }
    }
}