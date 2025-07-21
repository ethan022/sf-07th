//// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//bool True, False


// 변수 선언
int a = 10, b = 20, c = 30;

Console.WriteLine(a);
Console.WriteLine(b);
Console.WriteLine(c);

// 잘못된 자료형
//int d = 2.1;

string name = "ethan";
int age = 20;
double height = 170;
bool isStudent = true;

Console.WriteLine("이름" + name);
Console.WriteLine("나이" + age);
Console.WriteLine("키" + height);
Console.WriteLine("학생인가요? " + isStudent);


// 값 바꾸기 
int age1 = 20;
Console.WriteLine("age1 : " + age1);
age1 = 30;
Console.WriteLine("age1 : " + age1);

age1 = age;
Console.WriteLine("age1 : " + age1);


// 기존 변수의 값을 바꾼다.


// f-string 
Console.WriteLine($"이름 : {name}, 나이 : {age1}");

// 자동 자료형 추론
// int 인식
var name1 = 10;
// string 인식
var name2 = "ethan";

Console.WriteLine(name1);


// 캐스팅(변환)

int num1 = 10;
string num2 = "300";

// 에러 발생
//num1 = num2;
num1 = int.Parse(num2);
Console.WriteLine(num1);
num1 = int.Parse("100");
Console.WriteLine(num1);

int str1 = 10;
string str2 = "200";

// 에러 발생
//str2 = str1;
str2 = str1.ToString();
Console.WriteLine(str2);

var userName = "ethan";
var userNum = 2000;
var userChar = 'A';

Console.WriteLine(userName.GetType());
Console.WriteLine(userNum.GetType());
Console.WriteLine(userChar.GetType());


byte myByte = 10;
short myShort = 300;
int myInt = 50000;
float myFloat = 10.1f;
double myDouble = 10.2;
decimal myDecimal = 10.2m;

Console.WriteLine("=================");
Console.WriteLine("1. " + myByte.GetType() + " myByte : " + myByte);
Console.WriteLine($"1. {myByte.GetType()} myByte: {myByte}");
Console.WriteLine(myShort.GetType() + " myShort : " + myShort);
Console.WriteLine(myInt.GetType() + " myInt : " + myInt);
Console.WriteLine(myFloat.GetType() + " myFloat : " + myFloat);
Console.WriteLine(myDouble.GetType() + " myDouble : " + myDouble);
Console.WriteLine(myDecimal.GetType() + " myDecimal : " + myDecimal);



//연산자

//대입 연산자
int a1 = 10, b1 = 20, c1 = 30;

// 비교 연산자 (>, >=, <=, <, == , !=)
Console.WriteLine("1. a1 > b1: " + (a1 > b1));
Console.WriteLine("2. c1 > b1: " + (c1 > b1));

b1 = 10;
Console.WriteLine("3. a1 >= b1: " + (a1 >= b1));
Console.WriteLine("4. c1 >= b1: " + (c1 >= b1));

// 대입 연산자
b1 = 30;
// 비교 연산자
Console.WriteLine("5. a1 <= b1: " + (a1 <= b1));
Console.WriteLine("6. c1 <= b1: " + (c1 <= b1));

Console.WriteLine("7. a1 == b1: " + (a1 == b1));
Console.WriteLine("8. c1 != b1: " + (c1 != b1));

// 산술 연산자
int num1 = 10, num2 = 20, num3 = 3, num4 = 5;
Console.WriteLine("산술 연산자");
Console.WriteLine("1. num1 + num2: " + (num1 + num2));
Console.WriteLine("2. num2 - num1: " + (num2 - num1));
Console.WriteLine("3. num1 * num2: " + (num1 * num2));
Console.WriteLine("4. num2 / num1: " + (num2 / num1));
Console.WriteLine("5. Math.Pow(num1, num3): " + Math.Pow(num1, num3));
Console.WriteLine("6. num1 % num3: " + (num1 % num3));


num1 += 10; // num1 = num1 + 10;
num2 -= 20; // num2 = num2 - 20;
num3 *= 3; // num3 = num3 * 3;
num4 /= 5; // num4 = num4 / 5;

Console.WriteLine("대입 연산자");
Console.WriteLine("1. num1 += 10: " + (num1));
Console.WriteLine("2. num2 -= 20: " + (num2));
Console.WriteLine("2. num3 *= 3: " + (num3));
Console.WriteLine("2. num4 /= 5: " + (num4));

num4++; // num4 = num4 + 1;
Console.WriteLine("2. num4++: " + (num4));
num4--; // num4 = num4 - 1;
Console.WriteLine("2. num4--: " + (num4));


bool isA = false, isB = true;

Console.WriteLine("논리 연산자");

Console.WriteLine("1. isA || isB: " + (isA || isB));

Console.WriteLine("2. false || false: " + (false || false));
Console.WriteLine("3. false || true: " + (false || true));
Console.WriteLine("4. true || false: " + (true || false));
Console.WriteLine("5. true || true: " + (true || true));


Console.WriteLine("6. false && false: " + (false && false));
Console.WriteLine("7. false && true: " + (false && true));
Console.WriteLine("8. true &&false: " + (true && false));
Console.WriteLine("9. true && true: " + (true && true));

Console.WriteLine("10. !true : " + (!true));
Console.WriteLine("11. !false : " + (!false));

// 삼항 연산자
// 조건 ?  참 : 거짓

int score = 85;
Console.WriteLine((score >= 60) ? "합격" : "불합격");

// 1번 문제
Console.WriteLine((true || (false && true)) ? "참" : "거짓");

// 2번 문제
Console.WriteLine(((false || true) || (false && true)) ? "참" : "거짓");

// 3번 문제
Console.WriteLine(((false || false) || (false && true)) ? "참" : "거짓");


score = 85;
if (score >= 90)
{
    // 조건이 참일 때 실행
    Console.WriteLine("합격 입니다.");
}
else if (score >= 85)
{
    // 조건이 참일 때 실행
    Console.WriteLine("재시험 입니다.");
}
else
{
    // 조건이 거짓일 때 실행
    Console.WriteLine("불합격 입니다.");
}

// 중첩 조건문
score = 66;
if (score >= 90)
{
    if (score >= 95)
    {
        Console.WriteLine("A+ 학점 입니다.");
    }
    else
    {
        Console.WriteLine("A학점 입니다.");
    }
}
else if (score >= 80)
{
    if (score >= 85)
    {
        Console.WriteLine("B+ 학점 입니다.");
    }
    else
    {
        Console.WriteLine("B학점 입니다.");
    }
}
else if (score >= 70)
{
    if (score >= 75)
    {
        Console.WriteLine("C+ 학점 입니다.");
    }
    else
    {
        Console.WriteLine("C학점 입니다.");
    }
}
else if (score >= 60)
{
    if (score >= 65)
    {
        Console.WriteLine("D+ 학점 입니다.");
    }
    else
    {
        Console.WriteLine("D학점 입니다.");
    }
}
else
{
    Console.WriteLine("F 학점 입니다.");
}


Random random = new Random();
int randomValue = random.Next(1, 10);

// % 연산을 이용해서 0 또는 1만 값이 나오도록 작성
if (randomValue % 2 == 1)
// 1이 나오면 승리를 출력
{
    Console.WriteLine("승리 randomValue: " + randomValue);
}
// 0이 나오면 패배 출력
else
{
    Console.WriteLine("패배 randomValue: " + randomValue);
}


