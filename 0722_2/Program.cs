namespace _0722_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            person.Name = "김철수";
            person.Age = 30;

            Console.WriteLine($"이름: {person.Name}");
            Console.WriteLine($"나이: {person.Age}");

            person.Age = -10;

            Rectangle rc = new Rectangle();
            rc.ShowInfo();


            Book book = new Book("해리 포터", "Jk", 15000, "123-78-9123",200); 
            book.ShowInfo();
        }
    }
}
