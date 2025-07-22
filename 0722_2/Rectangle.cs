using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0722_2
{
    public class Rectangle
    {
        // 자동 구현 프로퍼티 - 컴파일러가 자동으로 Privete 필드 생성
        // 초기값이 있는 자동 프로퍼티
        public double Width { get; set; } = 22;
        public double Height { get; set; } = 10;

        // 계산된 프로퍼티 - 저장되지 않고 매번 계산됨
        public double Area
        {
            get { return Width * Height; }
        }

        public double Perimeter
        {
            get { return 2 * (Width + Height); }
        }

        // 생성자
        //public Rectangle(double width, double height)
        //{
        //    // set
        //    Width = width;
        //    Height = height;
        //} 

        public void ShowInfo()
        {
            Console.WriteLine($"가로: {Width}, 세로: {Height}");
            Console.WriteLine($"넓이: {Area}");
            Console.WriteLine($"둘레: {Perimeter}");
        }
    }
}
