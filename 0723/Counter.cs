using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0723
{
    internal class Counter
    {
        public static int count = 0;
        private int instanceId;

        public Counter()
        {
            count++;
            instanceId = count;
        }

        public static void Increment()
        {
            count++;
        }
        public static void Decrement() 
        {        
            count--;
        }
        public static void ShowInfo()
        {
            Console.WriteLine($"{count} ");
        }

        // 일반 메서드
        public void Show()
        {
            Console.WriteLine($"instanceId : {instanceId}, count: {count}");
        }
    }
}
