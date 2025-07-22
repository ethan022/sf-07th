using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0722
{
    public class Rectangle
    {
        private int width;
        private int height;

        // 생성자
        public Rectangle (int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        // 메서드
        // 넓이 반환
        public int GetArea()
        {
            return width * height;
        }
        // 둘레 반환
        public int GetPerimeter()  
        {
            return (width + height) * 2;
        }

        // 사각형 정보 출력
        public void showInfo()
        {
            Console.WriteLine($"너비: {this.width}, 높이: {height}");
            Console.WriteLine($"넓이: {GetArea()}");
            Console.WriteLine($"둘레: {GetPerimeter()}");
            Console.WriteLine($"사각형 입니다.");
        }
    }
}
