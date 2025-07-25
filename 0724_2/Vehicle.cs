using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0724_2
{
    // 여기에 코드를 작성하세요
    public class Vehicle
    {
        // TODO: 속성과 메서드 구현
        public string Brand {  get; set; }
        public int Speed { get; set; }

        public virtual void Move()
        {
            Console.WriteLine($"이동 중 입니다.");
        }
    }

    public class Car : Vehicle
    {
        // TODO: Move() 메서드 재정의
        public override void Move()
        {
            Console.WriteLine($"도로를 달립니다.");
        }
    }

    // TODO: Airplane, Ship 클래스 구현
    public class Airplane : Vehicle
    {
        // TODO: Move() 메서드 재정의
        public override void Move()
        {
            Console.WriteLine($"하늘을 날아갑니다.");
        }
    }
    public class Ship : Vehicle
    {
        // TODO: Move() 메서드 재정의
        public override void Move()
        {
            Console.WriteLine($"바다를 항해합니다.");
        }
    }

}
