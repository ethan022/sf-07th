using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0722
{

    public class Product
    {
        private string name;
        private int price;
        private int stock;

        // 생성자
        public Product(string name, int price, int stock) 
        {
            this.name = name;
            this.price = price;
            this.stock = stock;
        }

        // 제품 판매 (재고 확인 필요)
        public bool Sell(int quantity)
        {
            if (quantity > 0 && quantity <= stock) 
            { 
                stock -= quantity;
                Console.WriteLine($"{quantity}개 판매 완료. 남은 재고: {stock}개");
                return true;
            }
            return false;
        }
        // 재고 추가
        public void Restock(int quantity)
        {
            if (quantity > 0)
            {
                stock += quantity;
                Console.WriteLine($"{quantity}입고 완료. 현재 재고: {this.stock}개");
            }
        }

        //제품 정보 출력
        public void ShowProductInfo() 
        {
            Console.WriteLine($"제품명: {this.name}");
            Console.WriteLine($"가격: {this.price}원");
            Console.WriteLine($"재고: {this.stock}개");
        }
    }
}
