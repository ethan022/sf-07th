namespace _0723
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.age = 1;
            person1.name = "철수";

            Person person2 = new Person();
            person2.age = 2;
            person2.name = "영희";

            // 각각의 값이 다르게 들어간다.
            person1.PrintInfo();
            person2.PrintInfo();


            // Math math = new Math
            // math.pi 
            
            Console.WriteLine(Math.PI); // 3.1415
            // math.GetCircleArea(10)
            Console.WriteLine(Math.GetCircleArea(10));

            Counter.Increment(); // 1
            Counter.Increment(); // 2
            Counter.Increment(); // 3
            Counter.ShowInfo(); // Console 3

            Counter.Decrement(); // 2
            Counter.ShowInfo(); // Console 2

            Logger.WriteLog("첫 번째 로그");
            Logger.WriteLog("두 번째 로그");
            Logger.WriteLog("세 번째 로그");

            // 객체 만듬
            Counter c1 = new Counter(); // instanceId : 3, count: 5
            Counter c2 = new Counter(); // instanceId : 4, count: 5
            Counter c3 = new Counter(); // instanceId : 5, count: 5
            // instanceId 개별 박스
            // count 공통 박스

            c1.Show(); // instanceId : 3, count: 5
            c2.Show(); // instanceId : 4, count: 5
            c3.Show(); // instanceId : 5, count: 5


            Library.ShowLibraryInfo();
            // 100권 추가
            Library.AddBook(100);

            // 150권 대출
            Library.BorrowBook(150);

            Library.ShowLibraryInfo();

            // 200권 반납
            Library.ReturnBook(250);

            Library.ShowLibraryInfo();
        }
    }
}
