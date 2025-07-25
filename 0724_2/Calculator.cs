using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0724_2
{
    public class Calculator
    {
        // TODO: 다음 오버로딩 메서드들을 구현하세요
        // 1. Multiply(int a, int b)
        public int Multiply(int a, int b) { 
            return a * b;
        }
        // 2. Multiply(double a, double b) 
        public double Multiply(double a, double b)
        {
            return a * b;
        }
        // 3. Multiply(int a, int b, int c)
        public int Multiply(int a, int b, int c)
        {
            return a * b * c;
        }
        // 4. Multiply(params int[] numbers) - 배열의 모든 수를 곱함
        
        // 가변 개수의 인수를 메서드에 전달
        // 배열의 형태로 여러 개의 인수를 넘길 수 있게 해주는 키워드
        public int Multiply(params int[] numbers)
        {
            int result = 1;
            foreach (int num in numbers)
            {
                result *= num;
            }
            return result;
        }
    }
}
