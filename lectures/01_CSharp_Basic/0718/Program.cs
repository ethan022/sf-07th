using System;

namespace CSharpBasics
{
    // ------------------------------
    // 📌 열거형(enum) 정의
    // 열거형은 관련된 상수들을 그룹화하여 코드 가독성을 높이는 데이터 타입입니다.
    // ------------------------------

    // 요일을 나타내는 열거형
    enum Day
    {
        Monday,    // 0
        Tuseday,   // 1 (참고: Tuesday가 정확한 철자)
        Wednesday, // 2
        Thursday,  // 3
        Friday,    // 4
        Saturday,  // 5
        Sunday     // 6
    }

    // 가위바위보를 나타내는 열거형
    enum Rps
    {
        Scissor, // 0 (가위)
        Rock,    // 1 (바위)
        Paper    // 2 (보)
    }

    // 동물을 나타내는 열거형
    enum Animal
    {
        Dog,    // 0 (강아지)
        Cat,    // 1 (고양이)
        Rabbit, // 2 (토끼)
        Bear,   // 3 (곰)
        Lion    // 4 (사자)
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== C# 기초 문법 예제 ===\n");

            // 📌 1. 열거형 + switch문 예제 (Animal)
            // 열거형과 switch문을 사용하여 조건에 따른 처리를 구현합니다.
            Console.WriteLine("📌 1. 열거형 + switch문 예제");

            Animal animal = Animal.Rabbit;  // Animal 열거형 변수에 Rabbit 값 할당

            // switch문을 사용해 animal 값에 따라 다른 동작 수행
            switch (animal)
            {
                case Animal.Dog:        // animal이 Dog인 경우
                    Console.WriteLine("강아지입니다."); break;
                case Animal.Cat:        // animal이 Cat인 경우
                    Console.WriteLine("고양이입니다."); break;
                case Animal.Rabbit:     // animal이 Rabbit인 경우 (현재 선택된 값이므로 이 부분이 실행됨)
                    Console.WriteLine("토끼입니다."); break;
                case Animal.Bear:       // animal이 Bear인 경우
                    Console.WriteLine("곰입니다."); break;
                case Animal.Lion:       // animal이 Lion인 경우
                    Console.WriteLine("사자입니다."); break;
                default:                // 위의 모든 경우에 해당하지 않을 때 실행
                    Console.WriteLine("모르겠습니다..."); break;
            }
            Console.WriteLine();

            // 📌 2. 가위바위보 게임 (랜덤 + enum + 조건문)
            // Random 클래스를 사용해 난수를 생성하고, 열거형과 조건문으로 게임 로직을 구현합니다.
            Console.WriteLine("📌 2. 가위바위보 게임");

            Random random = new Random();  // Random 객체 생성 (난수 생성을 위해 필요)

            // 컴퓨터 선택: 0~2 범위의 랜덤한 정수 생성
            int computer = random.Next(1, 10) % 3;  // 1~9 중 랜덤 숫자를 3으로 나눈 나머지 (0, 1, 2 중 하나)
            Console.WriteLine("컴퓨터: " + (Rps)computer);  // 정수를 Rps 열거형으로 캐스팅하여 출력

            // 유저 선택: 컴퓨터와 동일한 방식으로 랜덤 생성
            int user = random.Next(1, 10) % 3;  // 1~9 중 랜덤 숫자를 3으로 나눈 나머지 (0, 1, 2 중 하나)
            Console.WriteLine("유저: " + (Rps)user);      // 정수를 Rps 열거형으로 캐스팅하여 출력

            // 결과 판별: 가위바위보 승부 규칙 구현
            if (computer == user)
                Console.WriteLine("결과: 비겼습니다.");    // 같은 값이면 무승부
            else if ((user == 0 && computer == 2) ||      // 유저가 가위(0), 컴퓨터가 보(2) → 가위가 보를 이김
                     (user == 1 && computer == 0) ||      // 유저가 바위(1), 컴퓨터가 가위(0) → 바위가 가위를 이김
                     (user == 2 && computer == 1))        // 유저가 보(2), 컴퓨터가 바위(1) → 보가 바위를 이김
                Console.WriteLine("결과: 이겼습니다.");
            else
                Console.WriteLine("결과: 졌습니다.");      // 위 조건에 해당하지 않으면 유저 패배
            Console.WriteLine();

            // 📌 3. 요일 enum + 랜덤 + switch문
            // 랜덤으로 생성된 숫자를 요일 열거형으로 변환하고 switch문으로 처리합니다.
            Console.WriteLine("📌 3. 요일 enum + 랜덤 + switch문");

            int dayValue = new Random().Next(0, 20);  // 0~19 범위의 랜덤 정수 생성
            Day day = (Day)dayValue;                  // 정수를 Day 열거형으로 강제 캐스팅
            Console.WriteLine("랜덤 요일: " + day);    // 열거형 값 출력 (7 이상은 정의되지 않은 값이므로 숫자로 출력됨)

            // switch문으로 요일에 따른 한글 출력
            switch (day)
            {
                case Day.Monday: Console.WriteLine("월요일"); break;
                case Day.Tuseday: Console.WriteLine("화요일"); break;     // 참고: Tuesday가 정확한 철자
                case Day.Wednesday: Console.WriteLine("수요일"); break;
                case Day.Thursday: Console.WriteLine("목요일"); break;
                case Day.Friday: Console.WriteLine("금요일"); break;
                case Day.Saturday: Console.WriteLine("토요일"); break;
                case Day.Sunday: Console.WriteLine("일요일"); break;
                default: Console.WriteLine("잘못된 요일입니다."); break;  // 0~6 범위를 벗어난 값일 때 실행
            }
            Console.WriteLine();

            // 📌 4. for, while, do-while 반복문 기초 예제
            // C#의 세 가지 주요 반복문의 기본 사용법을 보여줍니다.
            Console.WriteLine("📌 4. for, while, do-while 반복문");

            Console.WriteLine("for문 결과:");
            // for문: 초기값, 조건, 증감식을 한 줄에 작성하는 반복문
            // 반복 횟수가 명확할 때 주로 사용합니다.
            for (int i = 1; i <= 5; i++)  // i를 1로 초기화, i가 5 이하일 때까지, i를 1씩 증가
            {
                Console.WriteLine(i + "번째");  // "1번째", "2번째", "3번째", "4번째", "5번째" 출력
            }

            Console.WriteLine("while문 결과:");
            // while문: 조건이 참인 동안 반복 실행
            // 반복 횟수를 미리 알 수 없을 때 주로 사용합니다.
            int k = 1;                    // 반복 제어 변수 초기화
            while (k <= 5)                // k가 5 이하인 동안 반복
            {
                Console.WriteLine(k + "번째");  // "1번째", "2번째", "3번째", "4번째", "5번째" 출력
                k++;                      // k 값을 1씩 증가 (증가시키지 않으면 무한루프 발생)
            }

            Console.WriteLine("do-while문 결과:");
            // do-while문: 조건 검사 전에 최소 1번은 실행되는 반복문
            // 조건이 거짓이어도 반드시 한 번은 실행해야 할 때 사용합니다.
            int num = 1;
            do
            {
                Console.WriteLine(num);   // num 값 출력 (1이 출력됨)
                num++;                    // num을 2로 증가
            } while (num < 1);            // num이 1보다 작은 동안 반복 (조건이 거짓이므로 1번만 실행됨)
            Console.WriteLine();

            // 📌 5. 반복문: 짝수만 출력 / 합계 계산
            // 반복문 내에서 조건문을 사용하여 특정 조건의 값만 처리하는 예제입니다.
            Console.WriteLine("📌 5. 반복문: 짝수만 출력 / 합계 계산");

            Console.WriteLine("1~10 중 짝수:");
            // 1~10 중 짝수만 출력
            for (int i = 1; i <= 10; i++)     // i를 1부터 10까지 1씩 증가하며 반복
            {
                if (i % 2 == 0)               // i를 2로 나눈 나머지가 0이면 (짝수이면)
                    Console.WriteLine("짝수: " + i);  // 짝수 값만 출력: "짝수: 2", "짝수: 4", "짝수: 6", "짝수: 8", "짝수: 10"
            }

            // while문으로 1~100까지의 합 구하기
            int k1 = 1;      // 시작값 (1부터 시작)
            int result = 0;  // 합계를 저장할 변수 (초기값 0)
            while (k1 <= 100)    // k1이 100 이하인 동안 반복
            {
                result += k1;     // result에 k1 값을 누적 합산 (result = result + k1과 동일)
                k1++;             // k1을 1씩 증가
            }
            Console.WriteLine("1~100 합: " + result);  // 최종 합계 출력 (5050)
            Console.WriteLine();

            // 📌 6. 중첩 for문: 구구단 출력
            // for문 안에 또 다른 for문을 사용하여 2차원 반복 구조를 만듭니다.
            Console.WriteLine("📌 6. 중첩 for문: 구구단 출력");

            Console.WriteLine("2단만 출력:");
            // 2단만 출력
            for (int i = 2; i <= 2; i++)  // i가 2일 때만 실행 (2단만 출력하기 위해)
            {
                Console.WriteLine($"{i}단");  // "2단" 출력
                for (int j = 1; j <= 9; j++)  // j를 1부터 9까지 반복 (곱하는 수)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}");  // "2 * 1 = 2", "2 * 2 = 4", ... "2 * 9 = 18" 출력
                }
            }

            Console.WriteLine("\n1~9단 전체 출력:");
            // 1~9단 전체 출력
            for (int i = 1; i <= 9; i++)  // 외부 반복문: 1단부터 9단까지
            {
                Console.WriteLine($"{i}단");  // 각 단의 제목 출력
                for (int j = 1; j <= 9; j++)  // 내부 반복문: 1부터 9까지 곱하기
                {
                    Console.WriteLine($"{i} * {j} = {i * j}");  // 곱셈 결과 출력
                }
                Console.WriteLine();  // 각 단 사이에 빈 줄 추가
            }

            // 📌 7. 배열 선언과 출력 (기초)
            // 배열은 같은 타입의 여러 데이터를 연속적으로 저장하는 자료구조입니다.
            Console.WriteLine("📌 7. 배열 선언과 출력");

            // 배열 선언과 초기화를 동시에 수행
            int[] scores1 = { 90, 80, 70 };  // 3개의 정수를 가진 배열 생성

            // 인덱스로 배열 요소에 접근 (인덱스는 0부터 시작)
            Console.WriteLine("첫 번째 요소: " + scores1[0]);  // 첫 번째 요소 출력: 90
            Console.WriteLine("두 번째 요소: " + scores1[1]);  // 두 번째 요소 출력: 80

            // 전체 출력 (for문 사용)
            Console.WriteLine("전체 배열 요소:");
            for (int i = 0; i < scores1.Length; i++)  // i를 0부터 배열 길이-1까지 반복
            {
                Console.WriteLine(scores1[i]);  // 각 배열 요소 출력: 90, 80, 70
            }

            // 배열의 길이 확인
            Console.WriteLine("배열 길이: " + scores1.Length);  // "배열 길이: 3" 출력
            Console.WriteLine();

            // 📌 8. 배열 선언 (new 사용) + 순회
            // new 키워드를 사용하여 배열을 생성하고 각 요소에 값을 할당합니다.
            Console.WriteLine("📌 8. 배열 선언 (new 사용) + 순회");

            int[] scores2 = new int[3];  // 크기가 3인 정수 배열 생성 (모든 요소는 기본값 0으로 초기화)
            scores2[0] = 10;             // 첫 번째 요소에 10 할당
            scores2[1] = 20;             // 두 번째 요소에 20 할당
            scores2[2] = 30;             // 세 번째 요소에 30 할당

            // for문을 사용하여 모든 배열 요소 출력
            Console.WriteLine("scores2 배열 요소:");
            for (int i = 0; i < scores2.Length; i++)  // i를 0부터 배열길이-1까지 반복
            {
                Console.WriteLine(scores2[i]);  // 각 배열 요소 출력: 10, 20, 30
            }
            Console.WriteLine();

            // 📌 9. 문자열(String) 예제
            // 문자열은 문자들의 연속으로, C#에서는 string 타입으로 표현됩니다.
            Console.WriteLine("📌 9. 문자열(String) 예제");

            string str1 = "문자열입니다.";    // 문자열 변수 선언과 초기화
            Console.WriteLine(str1);         // 문자열 출력: "문자열입니다."
            Console.WriteLine("길이: " + str1.Length);  // 문자열의 길이 출력: "길이: 7"

            // 문자열 연결 방법 1: + 연산자 사용
            string greeting1 = "안녕하세요 " + str1;
            // 문자열 연결 방법 2: 문자열 보간(String Interpolation) 사용
            string greeting2 = $"안녕하세요 {str1}";
            Console.WriteLine(greeting1);  // "안녕하세요 문자열입니다." 출력
            Console.WriteLine(greeting2);  // "안녕하세요 문자열입니다." 출력

            // 문자열 메서드 사용 예제
            string str2 = "hello";
            Console.WriteLine(str2.ToUpper());  // 대문자로 변환: "HELLO" 출력

            string str3 = "HELLO";
            Console.WriteLine(str3.ToLower());  // 소문자로 변환: "hello" 출력

            Console.WriteLine(str3.Contains("L")); // 특정 문자 포함 여부 확인: True 출력
            Console.WriteLine(str3[3]); // 인덱스를 사용한 문자 접근: 'L' 출력 (4번째 문자)
            Console.WriteLine();

            // 📌 10. 이름 배열 + 인사 메시지
            // 문자열 배열을 사용하여 여러 이름을 저장하고 반복문으로 처리합니다.
            Console.WriteLine("📌 10. 이름 배열 + 인사 메시지");

            string[] names = { "철수", "영희", "짱구" };  // 문자열 배열 선언과 초기화

            Console.WriteLine("for문 사용:");
            // for문을 사용한 배열 순회
            for (int i = 0; i < names.Length; i++)  // i를 0부터 배열길이-1까지 반복
            {
                Console.WriteLine($"안녕하세요. {names[i]} 님");  // 각 이름에 대해 인사 메시지 출력
            }

            Console.WriteLine("foreach문 사용:");
            // foreach문을 사용한 배열 순회 (더 간단한 방법)
            foreach (string name in names)  // names 배열의 각 요소를 name 변수로 받아서 반복
            {
                Console.WriteLine($"안녕하세요. {name} 님");  // 각 이름에 대해 인사 메시지 출력
            }
            Console.WriteLine();

            // 📌 11. 배열 평균 구하기
            // 배열의 모든 요소를 합한 후 개수로 나누어 평균을 계산합니다.
            Console.WriteLine("📌 11. 배열 평균 구하기");

            int[] scores3 = { 78, 24, 54 };  // 점수를 담은 정수 배열
            int sum = 0;  // 합계를 저장할 변수 (초기값 0)

            // for문을 사용하여 모든 배열 요소의 합 계산
            for (int i = 0; i < scores3.Length; i++)  // 배열의 모든 요소에 대해 반복
            {
                sum += scores3[i];  // sum에 각 점수를 누적 합산
            }

            // 평균 계산 (정수를 double로 캐스팅하여 소수점 결과 얻기)
            double avg = (double)sum / scores3.Length;  // 합계를 개수로 나누어 평균 계산
            Console.WriteLine("평균: " + avg);  // 평균 출력

            Console.WriteLine("\n프로그램이 종료되었습니다. 아무 키나 누르세요...");
            Console.ReadKey();
        }
    }
}