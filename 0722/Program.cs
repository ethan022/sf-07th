namespace _0722
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // 객체 생성
            Person person1 = new Person();
            Person person2 = new Person("에단");
            Person person3 = new Person(30);
            Person person4 = new Person("에단", 30);

            person1.PrintInfo(); // 
            person2.PrintInfo(); // 
            person3.PrintInfo(); // 
            person4.PrintInfo(); //  

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Rectangle rc = new Rectangle(20,10);
            rc.showInfo();

            Console.WriteLine("Main종료");
        }
    }
}


