using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0722
{
    /// <summary>
    /// 사각형을 나타내는 클래스
    /// 너비와 높이를 가지며, 넓이와 둘레를 계산할 수 있습니다.
    /// </summary>
    public class Rectangle
    {
        // 📌 private 필드 - 외부에서 직접 접근할 수 없는 내부 데이터
        // 캡슐화(Encapsulation)의 원칙에 따라 데이터를 보호합니다.
        private int width;   // 사각형의 너비
        private int height;  // 사각형의 높이

        // 📌 생성자(Constructor)
        // 객체가 생성될 때 호출되어 초기값을 설정하는 특별한 메서드입니다.
        // 클래스 이름과 동일하며 반환 타입이 없습니다.
        public Rectangle(int width, int height)
        {
            // this 키워드: 현재 인스턴스(객체)를 가리킵니다.
            // 매개변수 이름과 필드 이름이 같을 때 구분하기 위해 사용합니다.
            this.width = width;   // 매개변수 width 값을 필드 width에 저장
            this.height = height; // 매개변수 height 값을 필드 height에 저장
        }

        // 📌 메서드(Methods) - 클래스의 기능을 구현하는 함수들

        /// <summary>
        /// 사각형의 넓이를 계산하여 반환합니다.
        /// </summary>
        /// <returns>너비 × 높이 결과값</returns>
        public int GetArea()
        {
            return width * height;  // 넓이 = 가로 × 세로
        }

        /// <summary>
        /// 사각형의 둘레를 계산하여 반환합니다.
        /// </summary>
        /// <returns>둘레 계산 결과값</returns>
        public int GetPerimeter()
        {
            return (width + height) * 2;  // 둘레 = (가로 + 세로) × 2
        }

        /// <summary>
        /// 사각형의 모든 정보를 콘솔에 출력합니다.
        /// 너비, 높이, 넓이, 둘레 정보를 포함합니다.
        /// </summary>
        public void showInfo()
        {
            Console.WriteLine($"너비: {this.width}, 높이: {height}");
            // 참고: this.width와 height 모두 같은 클래스의 필드이므로
            // this는 생략 가능하지만 명시적으로 표현할 수 있습니다.

            Console.WriteLine($"넓이: {GetArea()}");        // GetArea() 메서드 호출
            Console.WriteLine($"둘레: {GetPerimeter()}");   // GetPerimeter() 메서드 호출
            Console.WriteLine($"사각형 입니다.");
        }
    }
}