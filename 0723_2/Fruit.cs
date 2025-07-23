using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0723_2
{
    // 여기에 Fruit 클래스를 만들어보세요
    public class Fruit
    {
        // TODO: 속성들을 선언하세요
        public string name;
        public string color;
        // TODO: 생성자를 만들어보세요
        public Fruit(string name, string color)
        {
            this.name = name;
            this.color = color;
        }
        // TODO: ShowInfo 메서드를 만들어보세요
        public void ShowInfo()
        {
            Console.WriteLine($"과일 : {name} 색상: {color}");
        }
        // TODO: virtual Taste 메서드를 만들어보세요
        public virtual void Taste() 
        {
            Console.WriteLine($"{name}은(는) 맛있습니다.");
        }

    }

    // 여기에 Apple 클래스를 만들어보세요
    public class Apple : Fruit
    {
        // TODO: sweetness 속성을 추가하세요
        public int sweetness;

        // TODO: 생성자를 만들어보세요
        public Apple(string name, string color, int sweetness) : base(name, color)
        {
            this.sweetness = sweetness;
        }

        // TODO: override Taste 메서드를 만들어보세요
        public override void Taste()
        {
            Console.WriteLine($"{name}은(는) 달콤하고 아삭아삭합니다!");
        }
    }

    // 여기에 Lemon 클래스를 만들어보세요
    public class Lemon : Fruit
    {
        // TODO: sourness 속성을 추가하세요
        public int sourness;

        // TODO: 생성자를 만들어보세요
        public Lemon(string name, string color, int sourness) : base(name, color)
        {
            this.sourness = sourness;
        }

        // TODO: override Taste 메서드를 만들어보세요
        public override void Taste()
        {
            Console.WriteLine($"{name}은(는) 새콤합니다!");
        }
    }
}
