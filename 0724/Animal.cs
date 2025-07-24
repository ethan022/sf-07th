using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0724
{
    public class Animal
    {
        // 자동적으로 멤버 변수?가 만들어짐
        public string Name { get; set; }

        // 재정의 할 수 있다.
        public virtual void MakeSound()
        {
            Console.WriteLine($"동물이 소리를 냅니다.");
        }

        // Animal만의 메서드
        public void Sleep()
        {
            Console.WriteLine($"{Name} 이(가) 잠을 잡니다.");
        }
    }

    public class Dog : Animal
    {
        // 자동적으로 멤버 변수?가 만들어짐
        public string Breed { get; set; }

        // Animal 정의되어 있는 매서를 재정의
        public override void MakeSound()
        {
            Console.WriteLine($"{Name}: 멍멍!");
        }

        // Dog만의 메서드
        public void Fetch()
        {
            Console.WriteLine($"{Name} 이(가) 공을 가져옵니다.");
        }
        public void Guard()
        {
            Console.WriteLine($"{Name} 이(가) 집을 지킵니다.");
        }
    }

    public class Cat : Animal {
        public bool isIndoor { get; set; }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name}: 야옹!");
        }

        public void Climb()
        {
            Console.WriteLine($"{Name} 이(가) 나무에 올라갑니다.");
        }
    }

    public class Bird : Animal {
        public override void MakeSound()
        {
            Console.WriteLine($"{Name}: 짹짹!");
        }

        public void Fly()
        {
            Console.WriteLine($"{Name} 이(가) 하늘을 날아갑니다!");
        }
    }
}
