// See https://aka.ms/new-console-template for more information
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

