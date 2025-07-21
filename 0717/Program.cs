// ✅ C# 입문: 변수, 자료형, 연산자, 조건문 정리 예제

Console.WriteLine("Hello, World!");

// ------------------------------
// 📌 변수 선언 및 출력
// ------------------------------
int a = 10, b = 20, c = 30;
Console.WriteLine(a);
Console.WriteLine(b);
Console.WriteLine(c);

// ------------------------------
// 📌 다양한 기본 자료형
// ------------------------------
string name = "ethan";
int age = 20;
double height = 170;
bool isStudent = true;

Console.WriteLine("이름: " + name);
Console.WriteLine("나이: " + age);
Console.WriteLine("키: " + height);
Console.WriteLine("학생인가요? " + isStudent);

// ------------------------------
// 📌 변수 값 변경
// ------------------------------
int age1 = 20;
Console.WriteLine("age1: " + age1);
age1 = 30;
Console.WriteLine("age1: " + age1);
age1 = age;  // age의 값(20)으로 변경
Console.WriteLine("age1: " + age1);

// f-string 방식 출력
Console.WriteLine($"이름: {name}, 나이: {age1}");

// ------------------------------
// 📌 var 키워드 (자동 자료형 추론)
// ------------------------------
var name1 = 10;          // int로 추론
var name2 = "ethan";     // string으로 추론
Console.WriteLine(name1);

// ------------------------------
// 📌 형변환 (캐스팅)
// ------------------------------
int num1 = 10;
string num2 = "300";
num1 = int.Parse(num2);  // 문자열 -> 정수로 변환
Console.WriteLine(num1);

int str1 = 10;
string str2 = str1.ToString(); // 정수 -> 문자열 변환
Console.WriteLine(str2);

// ------------------------------
// 📌 GetType() : 변수의 자료형 확인
// ------------------------------
var userName = "ethan";
var userNum = 2000;
var userChar = 'A';

Console.WriteLine(userName.GetType()); // String
Console.WriteLine(userNum.GetType());  // Int32
Console.WriteLine(userChar.GetType()); // Char

// ------------------------------
// 📌 다양한 숫자형 출력
// ------------------------------
byte myByte = 10;
short myShort = 300;
int myInt = 50000;
float myFloat = 10.1f;
double myDouble = 10.2;
decimal myDecimal = 10.2m;

Console.WriteLine("=================");
Console.WriteLine($"1. {myByte.GetType()} myByte: {myByte}");
Console.WriteLine($"2. {myShort.GetType()} myShort: {myShort}");
Console.WriteLine($"3. {myInt.GetType()} myInt: {myInt}");
Console.WriteLine($"4. {myFloat.GetType()} myFloat: {myFloat}");
Console.WriteLine($"5. {myDouble.GetType()} myDouble: {myDouble}");
Console.WriteLine($"6. {myDecimal.GetType()} myDecimal: {myDecimal}");

// ------------------------------
// 📌 비교 연산자
// ------------------------------
int a1 = 10, b1 = 20, c1 = 30;
Console.WriteLine("1. a1 > b1: " + (a1 > b1));
Console.WriteLine("2. c1 > b1: " + (c1 > b1));

b1 = 10;
Console.WriteLine("3. a1 >= b1: " + (a1 >= b1));
Console.WriteLine("4. c1 >= b1: " + (c1 >= b1));

b1 = 30;
Console.WriteLine("5. a1 <= b1: " + (a1 <= b1));
Console.WriteLine("6. c1 <= b1: " + (c1 <= b1));
Console.WriteLine("7. a1 == b1: " + (a1 == b1));
Console.WriteLine("8. c1 != b1: " + (c1 != b1));

// ------------------------------
// 📌 산술 연산자 + Math.Pow()
// ------------------------------
int number1 = 10, number2 = 20;
int num3 = 3, num4 = 5;
Console.WriteLine("산술 연산자");
Console.WriteLine("1. + : " + (number1 + number2));
Console.WriteLine("2. - : " + (number2 - number1));
Console.WriteLine("3. * : " + (number1 * number2));
Console.WriteLine("4. / : " + (number2 / number1));
Console.WriteLine("5. 제곱: " + Math.Pow(number1, num3));
Console.WriteLine("6. 나머지: " + (number1 % num3));

// ------------------------------
// 📌 복합 대입 연산자 & 증감 연산자
// ------------------------------
number1 += 10;
number2 -= 20;
num3 *= 3;
num4 /= 5;

Console.WriteLine("대입 연산자");
Console.WriteLine("1. += : " + num1);
Console.WriteLine("2. -= : " + num2);
Console.WriteLine("3. *= : " + num3);
Console.WriteLine("4. /= : " + num4);

num4++;
Console.WriteLine("5. num4++ : " + num4);
num4--;
Console.WriteLine("6. num4-- : " + num4);

// ------------------------------
// 📌 논리 연산자
// ------------------------------
bool isA = false, isB = true;
Console.WriteLine("논리 연산자 결과:");
Console.WriteLine("1. OR(||): " + (isA || isB));
Console.WriteLine("2. AND(&&): " + (isA && isB));
Console.WriteLine("3. NOT(!): " + (!isA));

// 다양한 조합 예제
Console.WriteLine("true || false: " + (true || false));
Console.WriteLine("true && false: " + (true && false));

// ------------------------------
// 📌 삼항 연산자
// ------------------------------
int score = 85;
Console.WriteLine((score >= 60) ? "합격" : "불합격");
Console.WriteLine((true || (false && true)) ? "참" : "거짓");
Console.WriteLine(((false || true) || (false && true)) ? "참" : "거짓");
Console.WriteLine(((false || false) || (false && true)) ? "참" : "거짓");

// ------------------------------
// 📌 조건문 if-else if-else
// ------------------------------
score = 85;
if (score >= 90)
    Console.WriteLine("합격입니다.");
else if (score >= 85)
    Console.WriteLine("재시험입니다.");
else
    Console.WriteLine("불합격입니다.");

// ------------------------------
// 📌 중첩 조건문: 학점 판정
// ------------------------------
score = 66;
if (score >= 90)
{
    if (score >= 95) Console.WriteLine("A+ 학점");
    else Console.WriteLine("A 학점");
}
else if (score >= 80)
{
    if (score >= 85) Console.WriteLine("B+ 학점");
    else Console.WriteLine("B 학점");
}
else if (score >= 70)
{
    if (score >= 75) Console.WriteLine("C+ 학점");
    else Console.WriteLine("C 학점");
}
else if (score >= 60)
{
    if (score >= 65) Console.WriteLine("D+ 학점");
    else Console.WriteLine("D 학점");
}
else
{
    Console.WriteLine("F 학점");
}

// ------------------------------
// 📌 랜덤 + 조건문 예제: 승패 판정
// ------------------------------
Random random = new Random();
int randomValue = random.Next(1, 10);  // 1~9

if (randomValue % 2 == 1)
    Console.WriteLine("승리! randomValue: " + randomValue);
else
    Console.WriteLine("패배! randomValue: " + randomValue);
