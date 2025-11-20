using System;

namespace _0722
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== C# 생성자 오버로딩과 클래스 활용 예제 ===\n");

            // 📌 생성자 오버로딩 테스트
            // Person 클래스는 4가지 다른 생성자를 가지고 있습니다.
            // 컴파일러가 전달된 인수에 따라 적절한 생성자를 자동으로 선택합니다.
            Console.WriteLine("📌 Person 객체 생성 (생성자 오버로딩 테스트):");

            // 1. 기본 생성자 호출 (매개변수 없음)
            Person person1 = new Person();          // name="홍길동", age=20으로 초기화

            // 2. 이름만 받는 생성자 호출
            Person person2 = new Person("에단");     // name="에단", age=34로 초기화

            // 3. 나이만 받는 생성자 호출
            Person person3 = new Person(30);        // name="마크", age=30으로 초기화

            // 4. 이름과 나이를 모두 받는 생성자 호출
            Person person4 = new Person("에단", 30);  // name="에단", age=30으로 초기화

            Console.WriteLine("\n생성된 객체들의 정보:");
            person1.PrintInfo(); // 출력: 이름: 홍길동 나이: 20
            person2.PrintInfo(); // 출력: 이름: 에단 나이: 34
            person3.PrintInfo(); // 출력: 이름: 마크 나이: 30
            person4.PrintInfo(); // 출력: 이름: 에단 나이: 30

            Console.WriteLine();

            // 📌 가비지 컬렉션 강제 실행
            // .NET의 메모리 관리 시스템을 테스트하기 위해 사용
            // 실제 프로그램에서는 일반적으로 수동으로 호출하지 않습니다.
            Console.WriteLine("📌 가비지 컬렉션 강제 실행:");
            GC.Collect();                    // 가비지 컬렉션 강제 실행
            GC.WaitForPendingFinalizers();   // 소멸자(finalizer) 실행 완료까지 대기
            Console.WriteLine("가비지 컬렉션 완료\n");

            // 📌 Rectangle 클래스 사용 예제
            Console.WriteLine("📌 Rectangle 클래스 사용 예제:");
            Rectangle rc = new Rectangle(20, 10);  // 너비 20, 높이 10인 사각형 생성
            rc.showInfo();  // 사각형의 정보 (너비, 높이, 넓이, 둘레) 출력
            Console.WriteLine();

            // 📌 Product 클래스 사용 예제
            Console.WriteLine("📌 Product 클래스 사용 예제:");
            Product product = new Product("노트북", 1500000, 10);
            product.ShowProductInfo();  // 제품 정보 출력

            Console.WriteLine("\n판매 테스트:");
            product.Sell(3);           // 3개 판매 시도
            product.Sell(15);          // 재고 부족으로 판매 실패

            Console.WriteLine("\n재고 추가:");
            product.Restock(5);        // 5개 재고 추가
            product.ShowProductInfo(); // 업데이트된 제품 정보 출력

            Console.WriteLine("\nMain 함수 종료");
        }
    }
}