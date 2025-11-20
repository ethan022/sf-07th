using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0723_2
{
    public class Car : Vehicle
    {
        public int doors;

        public Car(string brand, string color, int doors) : base(brand, color)
        {
            this.doors = doors;
        }
    }
}
