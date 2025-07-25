namespace _0725
{
    // 📌 구조체(struct) 정의 - 값 타입(Value Type)
    // 구조체는 값 타입으로, Stack 메모리에 저장되며 복사 시 새로운 값이 생성됩니다.
    struct Point
    {
        public int x;  // x 좌표
        public int y;  // y 좌표
    }

    // 📌 클래스(class) 정의 - 참조 타입(Reference Type)
    // 클래스는 참조 타입으로, Heap 메모리에 저장되며 복사 시 주소가 복사됩니다.
    class Person
    {
        public string Name;  // 이름
        public int Age;      // 나이
    }

    internal class Program
    {
        // 📌 값 타입 전달 (Call by Value)
        // 매개변수로 전달될 때 값이 복사되어 전달됩니다.
        // 원본 변수에는 영향을 주지 않습니다.
        static void ModifyValue(int num)
        {
            num = 0;    // 복사된 값만 변경됨 (원본에 영향 없음)
        }

        // 📌 값 타입을 참조로 전달 (Call by Reference)
        // ref 키워드를 사용하여 변수의 주소를 전달합니다.
        // 원본 변수의 값이 직접 변경됩니다.
        static void ModifyValue(ref int num)
        {
            num = 0;    // 원본 변수의 값이 직접 변경됨
        }

        // 📌 참조 타입 전달
        // 객체의 주소가 복사되어 전달되므로, 같은 객체를 가리킵니다.
        // 객체의 내용을 변경하면 원본 객체에 영향을 줍니다.
        static void ModifyValue(Person p)
        {
            p.Age = 0;  // 전달받은 참조를 통해 원본 객체의 Age를 변경
        }

        // 📌 out 매개변수를 사용한 메서드
        // out 키워드는 메서드에서 여러 값을 반환할 때 사용합니다.
        // out 매개변수는 메서드 내에서 반드시 값을 할당해야 합니다.
        static void GetCircleInfo(double radius, out double area, out double circumference)
        {
            area = Math.PI * radius * radius;  // 원의 넓이 계산 (π × r²)
            circumference = Math.PI * radius * 2;  // 원의 둘레 계산 (2 × π × r)
        }

        static void Main(string[] args)
        {
            // 📌 값 타입 (Value Types)
            // - 실제 값을 변수에 저장
            // - Stack 메모리에 저장
            // - 복사할 때 새로운 값이 생성되어 독립적으로 관리됨

            int number = 10;        // 정수 (값 타입)
            double price = 99.99;   // 실수 (값 타입) - 오타 수정: pice → price
            bool flag = false;      // 불리언 (값 타입)
            char grade = 'A';       // 문자 (값 타입) - 오타 수정: garde → grade

            // 값 타입의 복사 예제
            int copy = number;      // number의 값(10)을 copy에 복사
            copy = 20;              // copy 값만 변경 (number에는 영향 없음)

            Console.WriteLine($"number: {number}");  // 출력: number: 10 (원본 값 유지)
            Console.WriteLine($"copy: {copy}");      // 출력: copy: 20 (복사본만 변경됨)

            // 구조체(값 타입)의 복사 예제
            Point point1 = new Point { x = 10, y = 20 };  // 첫 번째 Point 생성
            Point point2 = point1;  // point1의 값들을 point2에 복사 (독립적인 새 객체 생성)
            point2.x = 100;         // point2의 x값만 변경 (point1에는 영향 없음)

            Console.WriteLine($"point1.x: {point1.x}, point1.y: {point1.y}");  // 출력: point1.x: 10, point1.y: 20
            Console.WriteLine($"point2.x: {point2.x}, point2.y: {point2.y}");  // 출력: point2.x: 100, point2.y: 20

            // 📌 참조 타입 (Reference Types)
            // - 객체의 주소(참조)를 변수에 저장
            // - Heap 메모리에 실제 객체가 저장됨
            // - 복사할 때 주소가 복사되어 같은 객체를 가리킴

            string name = "홍길동";  // 문자열 (참조 타입)
            int[] numbers = { 1, 2, 3, 4, 5, 6, };  // 배열 (참조 타입)
            Person person = new Person();  // Person 객체 생성 (참조 타입)

            // 참조 타입의 동작 예제 (아파트 비유로 설명)
            // 김철수라는 사람을 만들었습니다.
            // 아파트 101동 101호에 사람이 있다. 
            // 그 안에 사는 사람은 김철수이고 나이는 25살이다.
            Person person1 = new Person { Name = "김철수", Age = 25 };

            // 아파트 101동 101호의 주소를 person2에도 할당
            Person person2 = person1;  // 같은 객체를 가리키는 참조를 복사

            // 아파트 101동 101호에 사는 사람의 이름을 영희로 변경하겠다.
            person2.Name = "영희";
            // 아파트 101동 101호에 사는 사람을 20살로 변경하겠다.
            person2.Age = 20;

            // person1과 person2는 같은 객체를 가리키므로 둘 다 변경된 값을 보여줌
            Console.WriteLine($"person1.Name: {person1.Name}, person1.Age: {person1.Age}");
            // 예상과 다른 결과: person1.Name: 영희, person1.Age: 20 (같은 객체이므로 변경됨)
            Console.WriteLine($"person2.Name: {person2.Name}, person2.Age: {person2.Age}");
            // 출력: person2.Name: 영희, person2.Age: 20

            // 배열(참조 타입)의 동작 예제
            int[] numbers1 = { 1, 2, 3, 4, 5, 6, };  // 배열 생성
            int[] numbers2 = numbers1;  // 같은 배열을 가리키는 참조를 복사
            numbers2[2] = 10;           // numbers2를 통해 3번째 요소 변경

            // numbers1과 numbers2는 같은 배열을 가리키므로 둘 다 변경된 값을 보여줌
            Console.WriteLine($"numbers1[2]: {numbers1[2]}");  // 출력: numbers1[2]: 10
            Console.WriteLine($"numbers2[2]: {numbers2[2]}");  // 출력: numbers2[2]: 10

            // 📌 메서드 호출과 매개변수 전달 방식

            // 값 타입을 일반적인 방식으로 전달 (Call by Value)
            int value = 20;
            ModifyValue(value);  // value의 복사본이 전달되므로 원본은 변경되지 않음
            Console.WriteLine("value: " + value);  // 출력: value: 20 (원본 값 유지)

            // 값 타입을 참조로 전달 (Call by Reference)
            ModifyValue(ref value);  // value의 주소가 전달되므로 원본이 직접 변경됨
            Console.WriteLine("value: " + value);  // 출력: value: 0 (원본 값이 변경됨)

            // 참조 타입을 전달
            Person person3 = new Person { Name = "김철수", Age = 25 };
            ModifyValue(person3);  // 객체의 참조가 전달되므로 원본 객체가 변경됨
            Console.WriteLine("person3.Age: " + person3.Age);  // 출력: person3.Age: 0

            // 📌 out 매개변수 사용 예제
            // out 매개변수는 메서드에서 여러 값을 반환받을 때 사용합니다.
            double radius = 5.0;
            double area, circumference;  // 초기화하지 않고 선언 (out 매개변수로 값을 받을 예정)

            // GetCircleInfo 메서드 호출하여 원의 넓이와 둘레를 동시에 계산
            GetCircleInfo(radius, out area, out circumference);

            Console.WriteLine("area: " + area);              // 출력: area: 78.53981633974483 (π × 5²)
            Console.WriteLine("circumference: " + circumference);  // 출력: circumference: 31.41592653589793 (2 × π × 5)
        }
    }
}