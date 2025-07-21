// See https://aka.ms/new-console-template for more information

// 열거형

//using System.Diagnostics.Metrics;

//Console.WriteLine("Hello, World!");


//Animal animal = Animal.Rabbit;

//switch (animal)
//{
//    case Animal.Dog:
//        Console.WriteLine("강아지 입니다.");
//        break;
//    case Animal.Cat:
//        Console.WriteLine("고양이 입니다.");
//        break;
//    case Animal.Rabbit:
//        Console.WriteLine("토끼 입니다.");
//        break;
//    case Animal.Bear:
//        Console.WriteLine("곰 입니다.");
//        break;
//    case Animal.Lion:
//        Console.WriteLine("사자 입니다.");
//        break;
//    default:
//        Console.WriteLine("모르겠습니다...");
//        break;
//}


//// random
//// 컴퓨터는 랜덤값의 %3을 했을때  0 이 가위, 1 이 바위, 2 보 
//// 유저가 입력 이겼는지? 비겼는지? 졌는지? 출력해주세요.

//// if문 , switch문 둘중 아무거나 사용

//Random random = new Random();
//// 1 ~ 9까지 숫자 랜덤으로 생성
//int randomValue = random.Next(1, 10);
//// 0 ~ 2 까지 값이 나옵니다.
//int computer = randomValue % 3;
//Console.WriteLine("컴퓨터 : " + (Rps)computer);

//// 1 ~ 9까지 숫자 랜덤으로 생성
//int randomValue2 = random.Next(1, 10);
//// 0 ~ 2 까지 값이 나옵니다.
//int user = randomValue2 % 3;
//Console.WriteLine("유저 : " + (Rps)user);


//if (computer == user)
//{
//    Console.WriteLine("결과 : 비겼습니다.");
//} else if ((user == 0 && computer == 2) ||
//            (user == 1 && computer == 0) ||
//            (user == 2 && computer == 1))
//{
//    Console.WriteLine("결과 : 이겼습니다.");
//} else
//{
//    Console.WriteLine("결과 : 졌습니다..");
//}


//int selection = 0;

//pos:
//if (selection == 0)
//{
//    selection = 1;
//    goto pos;
//}

//int days = random.Next(0, 20);
//// enum, switch문을 사용해서 요일별 메시지를 출력
//// 0 월 1 화, 2 수, ~~ 6 일요일 

//// int를 Enum으로 변환
//Day day = (Day) days;
//Console.WriteLine(day);

//switch (day) {
//    case Day.Monday:
//        Console.WriteLine("월요일");
//        break;
//    case Day.Tuseday:
//        Console.WriteLine("화요일");
//        break;
//    case Day.Wednesday:
//        Console.WriteLine("수요일");
//        break;
//    case Day.Thursday:
//        Console.WriteLine("목요일");
//        break;
//    case Day.Friday:
//        Console.WriteLine("금요일");
//        break;
//    case Day.Saturday:
//        Console.WriteLine("토요일");
//        break;
//    case Day.Sunday:
//        Console.WriteLine("일요일");
//        break;
//    default:
//        Console.WriteLine("잘못되었습니다.");
//        break;
//}

// 반복문
// i = i + 1
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine(i + "번째");
//}

// 1부터 5까지 출력
// for문
//for (int i = 1;i < 6; i++)
//{
//    Console.WriteLine(i + "번째");
//}

// 10부터 1까지 거꾸로 출력
// for문
//for (int i = 10; i > 0; i--)
//{
//    Console.WriteLine(i + "번째");
//}

//int i = 0;
//while (i <= 5)
//{
//    Console.WriteLine(i + "번째 hello");
//    i++;
//}

//// 1부터 5까지 출력
//// while 문
//int j = 1;
//while (j <= 5)
//{
//    Console.WriteLine(j + "번째");
//    j++;
//}

//int count = 0;
//// 무한루프
//while (true)
//{
//    count++;
//    if (count % 2 == 1)
//    {
//        continue;
//    }
//    Console.WriteLine("count: " + count);

//    if (count == 5)
//    {
//        break;
//    }
//}

//// 1. 1부터 10까지 짝수만 출력
//for (int idx = 1; idx <= 10; idx++)
//{
//    if (idx % 2 == 0)
//    {
//        Console.WriteLine(idx);
//    }
//}

//int jdx = 1;
//while (jdx <= 10)
//{
//    if (jdx % 2 == 0)
//    {
//        Console.WriteLine(jdx);
//    }
//    jdx++;
//}

//// 2. while문을 사용해서 1부터 100까지 합 구하기
//int k = 1;
//int result = 0;
//while (k <= 100)
//{
//    result += k;
//    k++;
//}

//Console.WriteLine("result: " + result);

//do while
// 최소 1번은 무조건 실행이 된다.

//while (num < 1)
//{
//    Console.WriteLine(num);
//    num++;
//}
//int num = 1;

//do
//{
//    Console.WriteLine(num);
//    num++;
//}
//while (num < 1);


//// 중첩 반복문
//for (int i = 0; i < 5; i++)
//{
//    for (int j = 0; j < 5; j++)
//    {
//        Console.WriteLine("i:" + i );
//        Console.WriteLine("j:" + j);
//        Console.WriteLine("i + j = " + (i + j));
//    }
//}

// 구구단 2단 출력(중첩 for문)

//for (int i = 2; i < 3; i++)
//{
//    Console.WriteLine($"{i} 단");
//    for (int j = 1; j < 10; j++)
//    {
//        Console.WriteLine($"{i} * {j} = {i * j}");
//    }
//    Console.WriteLine();
//}

// 구구단 1 ~ 9단 출력(중첩 for문)
//for (int i = 1; i < 10; i++)
//{
//    Console.WriteLine($"{i} 단");
//    for (int j = 1; j < 10; j++)
//    {
//        Console.WriteLine($"{i} * {j} = {i * j}");
//    }
//    Console.WriteLine();
//}



// 배열 선언과 초기화
// 1.
//using System.Globalization;

//int[] scores1 = { 90, 80, 70, 55, 64, 89, 100, 20, 56 };

//// 0번째 인덱스 (맨 처음)
//Console.WriteLine(scores1[0]);
//Console.WriteLine(scores1[1]);
//Console.WriteLine(scores1[2]);

//// 배열의 모든 원소를 출력
//for (int i = 0; i < scores1.Length; i++)
//{
//    Console.WriteLine(scores1[i]);
//}

//// 배열의 길이 출력
//Console.WriteLine(scores1.Length);

//// 2.
//int[] scores2 = new int[3];
//scores2[0] = 10;
//scores2[1] = 20;
//scores2[2] = 30;

//for (int i = 0; i < scores2.Length; i++)
//{
//    Console.WriteLine(scores2[i]);
//}


//string str1 = "문자열 입니다.";

//Console.WriteLine(str1);
//// 문자열의 길이 출력
//Console.WriteLine(str1.Length);

//string greeting = "안녕하세요" + str1;
//string greeting2 = $"안녕하세요 {str1}";

//Console.WriteLine(greeting);
//Console.WriteLine(greeting2);

//string str2 = "hello";
//Console.WriteLine(str2.ToUpper());

//String str3 = "HELLO";
//Console.WriteLine(str3.ToLower());

//// 특정 단어의 포함 여부 확인
//Console.WriteLine(str3.Contains("L"));


//Console.WriteLine(str3[3]); // L


// 이름 3개를 배열로 선언 하고 출력하세요.
// "안녕하세요. {이름} 님" 
string[] names = { "철수", "영희", "짱구" };

for (int i = 0; i < names.Length; i++)
{
    Console.WriteLine($"안녕하세요. {names[i]} 님");
}

//for each
// 순회 한다.
foreach (string str1 in names)
{
    Console.WriteLine($"안녕하세요. {str1} 님");
}


// 점수 평균 구하기
// 배열의 길이 사용!
int[] scores3 = { 78, 24, 54 };
int sum = 0;

// 모든 점수를 더한 값
for (int i = 0;i < scores3.Length;i++)
{
    sum += scores3[i];
}

double avg = (double)sum / scores3.Length;
Console.WriteLine("평균 : " + avg);


enum Day
{
    Monday,
    Tuseday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}


enum Rps {
    Scissor,
    Rock,
    Paper
}


enum Animal
{
    Dog,        // 0
    Cat,        // 1
    Rabbit,     // 2
    Bear,       // 3
    Lion        // 4
}

