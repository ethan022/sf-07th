//
// 📌 1. 열거형 + switch문 예제 (Animal)
// enum은 맨 밑에 위치
//

Animal animal = Animal.Rabbit;

switch (animal)
{
    case Animal.Dog:
        Console.WriteLine("강아지입니다."); break;
    case Animal.Cat:
        Console.WriteLine("고양이입니다."); break;
    case Animal.Rabbit:
        Console.WriteLine("토끼입니다."); break;
    case Animal.Bear:
        Console.WriteLine("곰입니다."); break;
    case Animal.Lion:
        Console.WriteLine("사자입니다."); break;
    default:
        Console.WriteLine("모르겠습니다..."); break;
}



//
// 📌 2. 가위바위보 게임 (랜덤 + enum + 조건문)
//

Random random = new Random();

// 컴퓨터 선택
int computer = random.Next(1, 10) % 3;
Console.WriteLine("컴퓨터: " + (Rps)computer);

// 유저 선택
int user = random.Next(1, 10) % 3;
Console.WriteLine("유저: " + (Rps)user);

// 결과 판별
if (computer == user)
    Console.WriteLine("결과: 비겼습니다.");
else if ((user == 0 && computer == 2) ||
         (user == 1 && computer == 0) ||
         (user == 2 && computer == 1))
    Console.WriteLine("결과: 이겼습니다.");
else
    Console.WriteLine("결과: 졌습니다.");


//
// 📌 3. 요일 enum + 랜덤 + switch문
//

int dayValue = new Random().Next(0, 20); // 0~19
Day day = (Day)dayValue;
Console.WriteLine("랜덤 요일: " + day);

switch (day)
{
    case Day.Monday: Console.WriteLine("월요일"); break;
    case Day.Tuseday: Console.WriteLine("화요일"); break;
    case Day.Wednesday: Console.WriteLine("수요일"); break;
    case Day.Thursday: Console.WriteLine("목요일"); break;
    case Day.Friday: Console.WriteLine("금요일"); break;
    case Day.Saturday: Console.WriteLine("토요일"); break;
    case Day.Sunday: Console.WriteLine("일요일"); break;
    default: Console.WriteLine("잘못된 요일입니다."); break;
}


//
// 📌 4. for, while, do-while 반복문 기초 예제
//

// for문: 1~5 출력
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine(i + "번째");
}

// while문: 1~5 출력
int k = 1;
while (k <= 5)
{
    Console.WriteLine(k + "번째");
    k++;
}

// do-while문: 조건이 false여도 1번은 실행됨
int num = 1;
do
{
    Console.WriteLine(num);
    num++;
} while (num < 1);


//
// 📌 5. 반복문: 짝수만 출력 / 합계 계산
//

// 1~10 중 짝수만 출력
for (int i = 1; i <= 10; i++)
{
    if (i % 2 == 0)
        Console.WriteLine("짝수: " + i);
}

// while문으로 1~100까지 합 구하기
int k1 = 1;
int result = 0;
while (k1 <= 100)
{
    result += k1;
    k1++;
}
Console.WriteLine("1~100 합: " + result);


//
// 📌 6. 중첩 for문: 구구단 출력
//

// 2단 출력
for (int i = 2; i <= 2; i++)
{
    Console.WriteLine($"{i}단");
    for (int j = 1; j <= 9; j++)
    {
        Console.WriteLine($"{i} * {j} = {i * j}");
    }
}

// 1~9단 전체 출력
for (int i = 1; i <= 9; i++)
{
    Console.WriteLine($"{i}단");
    for (int j = 1; j <= 9; j++)
    {
        Console.WriteLine($"{i} * {j} = {i * j}");
    }
    Console.WriteLine();
}


//
// 📌 7. 배열 선언과 출력 (기초)
//

// 배열 선언과 초기화
int[] scores1 = { 90, 80, 70 };

// 인덱스로 접근
Console.WriteLine(scores1[0]);
Console.WriteLine(scores1[1]);

// 전체 출력 (for문)
for (int i = 0; i < scores1.Length; i++)
{
    Console.WriteLine(scores1[i]);
}

// 길이 확인
Console.WriteLine("배열 길이: " + scores1.Length);


//
// 📌 8. 배열 선언 (new 사용) + 순회
//

int[] scores2 = new int[3];
scores2[0] = 10;
scores2[1] = 20;
scores2[2] = 30;

for (int i = 0; i < scores2.Length; i++)
{
    Console.WriteLine(scores2[i]);
}


//
// 📌 9. 문자열(String) 예제
//

string str1 = "문자열입니다.";
Console.WriteLine(str1);
Console.WriteLine("길이: " + str1.Length);

// 문자열 연결
string greeting1 = "안녕하세요 " + str1;
string greeting2 = $"안녕하세요 {str1}";
Console.WriteLine(greeting1);
Console.WriteLine(greeting2);

// 문자열 메서드
string str2 = "hello";
Console.WriteLine(str2.ToUpper());  // HELLO

string str3 = "HELLO";
Console.WriteLine(str3.ToLower());  // hello

Console.WriteLine(str3.Contains("L")); // true
Console.WriteLine(str3[3]); // 인덱스 접근: L


//
// 📌 10. 이름 배열 + 인사 메시지
//
string[] names = { "철수", "영희", "짱구" };

// for문
for (int i = 0; i < names.Length; i++)
{
    Console.WriteLine($"안녕하세요. {names[i]} 님");
}

// foreach문
foreach (string name in names)
{
    Console.WriteLine($"안녕하세요. {name} 님");
}

//
// 📌 11. 배열 평균 구하기
//
int[] scores3 = { 78, 24, 54 };
int sum = 0;

for (int i = 0; i < scores3.Length; i++)
{
    sum += scores3[i];
}

double avg = (double)sum / scores3.Length;
Console.WriteLine("평균: " + avg);



// ------------------------------
// 📌 열거형(enum) 정의
// ------------------------------
enum Day
{
    Monday, Tuseday, Wednesday, Thursday, Friday, Saturday, Sunday
}

enum Rps
{
    Scissor, Rock, Paper
}

enum Animal
{
    Dog, Cat, Rabbit, Bear, Lion
}
