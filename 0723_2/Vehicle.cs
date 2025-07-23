using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0723_2
{
    public class Vehicle
    {
        public string brand;
        public string color;

        public Vehicle(string brand, string color) {
            this.brand = brand;
            this.color = color;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"브랜드 : {brand}, 색상: {color}");
        }

        public void Start()
        {
            Console.WriteLine($"{brand} 차량이 시작됩니다.");
        }
    }
}
