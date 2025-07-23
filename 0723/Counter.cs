using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0723
{
    internal class Counter
    {
        // 정적 멤버
        public static int count = 0;
        private int instanceId;

        // 생성자
        public Counter()
        {
            // 카운트 증가
            count++; // 5
            instanceId = count; // 5
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
