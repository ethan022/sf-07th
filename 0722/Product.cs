using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0722
{
    /// <summary>
    /// 상품 정보와 재고 관리 기능을 제공하는 클래스
    /// 실제 쇼핑몰이나 재고 관리 시스템에서 사용할 수 있는 기본적인 구조를 제공합니다.
    /// </summary>
    public class Product
    {
        // 📌 private 필드들 - 제품의 핵심 정보를 안전하게 보관
        // 외부에서 직접 접근할 수 없어 데이터 무결성을 보장합니다.
        private string name;   // 제품명
        private int price;     // 제품 가격
        private int stock;     // 현재 재고 수량

        // 📌 생성자 - 제품 생성 시 모든 정보를 초기화
        // 제품을 생성할 때 반드시 이름, 가격, 재고를 설정해야 합니다.
        public Product(string name, int price, int stock)
        {
            this.name = name;     // 제품명 설정
            this.price = price;   // 가격 설정
            this.stock = stock;   // 초기 재고 설정
        }

        // 📌 판매 메서드 - 재고 관리와 유효성 검사를 포함
        /// <summary>
        /// 지정된 수량만큼 제품을 판매합니다.
        /// 재고가 충분한지 확인하고, 판매 후 재고를 차감합니다.
        /// </summary>
        /// <param name="quantity">판매하려는 수량</param>
        /// <returns>판매 성공 시 true, 실패 시 false</returns>
        public bool Sell(int quantity)
        {
            // 📌 유효성 검사
            // 1. 수량이 양수인지 확인
            // 2. 요청 수량이 현재 재고보다 적거나 같은지 확인
            if (quantity > 0 && quantity <= stock)
            {
                stock -= quantity;  // 재고에서 판매 수량만큼 차감
                Console.WriteLine($"{quantity}개 판매 완료. 남은 재고: {stock}개");
                return true;  // 판매 성공
            }
            else
            {
                // 판매 실패 원인에 따른 메시지 출력
                if (quantity <= 0)
                {
                    Console.WriteLine("판매 수량은 1개 이상이어야 합니다.");
                }
                else
                {
                    Console.WriteLine($"재고 부족! 현재 재고: {stock}개, 요청 수량: {quantity}개");
                }
                return false;  // 판매 실패
            }
        }

        // 📌 재고 추가 메서드
        /// <summary>
        /// 제품의 재고를 추가합니다.
        /// </summary>
        /// <param name="quantity">추가할 재고 수량</param>
        public void Restock(int quantity)
        {
            if (quantity > 0)  // 추가 수량이 양수인지 확인
            {
                stock += quantity;  // 현재 재고에 추가
                Console.WriteLine($"{quantity}개 입고 완료. 현재 재고: {this.stock}개");
            }
            else
            {
                Console.WriteLine("추가할 재고 수량은 1개 이상이어야 합니다.");
            }
        }

        // 📌 제품 정보 출력 메서드
        /// <summary>
        /// 제품의 모든 정보(이름, 가격, 재고)를 콘솔에 출력합니다.
        /// </summary>
        public void ShowProductInfo()
        {
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.WriteLine($"제품명: {this.name}");
            Console.WriteLine($"가격: {this.price:N0}원");  // :N0 포맷으로 천 단위 구분자 표시
            Console.WriteLine($"재고: {this.stock}개");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
        }
    }
}