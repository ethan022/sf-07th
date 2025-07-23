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

            Console.WriteLine(Math.PI);
            Console.WriteLine(Math.GetCircleArea(10));

            Counter.Increment(); // 1
            Counter.Increment(); // 2
            Counter.Increment(); // 3
            Counter.ShowInfo(); // Console

            Counter.Decrement(); // 2
            Counter.ShowInfo(); // Console

            Logger.WriteLog("첫 번째 로그");
            Logger.WriteLog("두 번째 로그");
            Logger.WriteLog("세 번째 로그");


            Counter c1 = new Counter();
            c1.Show(); //
            Counter c2 = new Counter();
            c2.Show(); // 
            Counter c3 = new Counter();
            c3.Show(); //

        }
    }
}
