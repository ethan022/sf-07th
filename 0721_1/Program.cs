// See https://aka.ms/new-console-template for more information
static int Add(int x, int y)
{
    return x + y;
}

//static float Add(float x, float y)
//{
//    return x + y;
//}
Console.WriteLine("Hello, World!");




string Add(string x, string y)
{
    return x + y;
}

Add(1.1f, 2.2f);

static int Sub(int x,int y) {
    return x - y; 
}

static void Print()
{
    Console.WriteLine("출력");
}

//Console.WriteLine(Add("aaa","bbb"));

Console.WriteLine(Sub(5, 2));

Print();

Console.WriteLine(Add(3, 2) - Sub(5, 2));
// Add(3, 2) = 5
// Sub(5, 2) = 3

int num1 = Add(10, 3); // 13
int num2 = Sub(16, 3); // 13

Console.WriteLine(num1 + num2); // 26

int num = 200;
num1 = Add(num, 3); //203

int num3 = 50;
num2 = Sub(num, num3); // 150


// 곱하기 함수
int Mul(int x, int y)
{
    return x * y;
}

// 나누기 함수
double Div(int x, int y)
{
    return x / y;
}