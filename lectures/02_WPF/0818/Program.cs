namespace _0818
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // i는 제곱근, i*i가 n이면 1
            // n = 976
            for (int i = 1; i * i <= 976; i++)
            {
                Console.WriteLine(i);

                if (i * i == 976)
                {
                    break;
                }
            }
        }
    }
}
