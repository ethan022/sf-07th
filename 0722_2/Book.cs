using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0722_2
{
    // 책의 분류를 나타내는 계산된 프로퍼티 (페이지수에 따라)
    public class Book
    {
        private string title;
        private string author;
        private double price;
        private string isbn;

        public string Title { 
            get { return title; }
            set
            { 
                if (!string.IsNullOrWhiteSpace(value))
                {
                    title = value;
                } else
                {
                    Console.WriteLine("제목은 비어 있을 수 없습니다.!");
                }
            }
        }

        public string Author
        {
            get { return author; }
            set {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    author = value;
                }
                else
                {
                    Console.WriteLine("저자명은 비어 있을 수 없습니다.!");
                }
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                {
                    price = value;
                    Console.WriteLine($"{title}의 가격이 {price}원으로 설정 되었습니다.");
                }
                else
                {
                    Console.WriteLine($"가격은 0보다 커야 합니다.");
                }
            }
        }

        public string ISBN
        {
            get { return isbn; } 
        }

        // 페이지 수
        public int PageCount { get; set; }

        public string Category
        {
            get
            {
                if (PageCount < 100)
                {
                    return "소책자";
                } else if (PageCount <= 200)
                {
                    return "일반서";
                }
                else
                {
                    return "대형책자";
                }
            }
        }

        public Book(string title, string author, double price, string isbn, int pageCount)
        {
            Title = title;
            Author = author;
            Price = price;
            this.isbn = isbn;
            PageCount = pageCount;

            Console.WriteLine($"새 도서 등록 완료: {title}");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"=== 도서 정보 ===");
            Console.WriteLine($"제목: {Title}");
            Console.WriteLine($"저자 : {Author}");
            Console.WriteLine($"가격: {Price}");
            Console.WriteLine($"페이지 수: {PageCount}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"분류: {Category}");
        }
    }
}
