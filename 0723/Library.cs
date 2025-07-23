using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0723
{
    internal class Library
    {
        public static string LibraryName = "중앙 도서관";
        public static int totalBooks = 500;
        public static int borrowedBook = 50;

        /// <summary>
        /// 도서관에서 새 도서를 추가합니다.
        /// </summary>
        public static void AddBook(int num)
        {
            if (num > 0)
            {
                totalBooks += num;
                Console.WriteLine($"{num}권 추가 했습니다.");
                Console.WriteLine($"새 도서가 추가 되었습니다. (총 도서 수: {totalBooks}권)");
            } else
            {
                Console.WriteLine($"추가 할 도서 수는 0보다 커야 합니다.");
            }
        }

        /// <summary>
        /// 도서를 대출 합니다.
        /// </summary>
        public static void BorrowBook(int num)
        {
            if (num > 0)
            {
                borrowedBook += num;
                Console.WriteLine($"{num}권 대출 했습니다.");
                Console.WriteLine($"도서가 대출 되었습니다. (대출된 도서: {borrowedBook}권, 남은 도서 : {totalBooks - borrowedBook}");
            } else
            {
                Console.WriteLine($"대출할 도서 수는 0보다 커야 합니다.");
            }
        }

        /// <summary>
        /// 도서를 반납합니다.
        /// </summary>
        public static void ReturnBook(int num) 
        {
            // 0보다 크고 대출 도서보단 작아야 합니다.
            if (num > 0 && borrowedBook >= num) 
            {
                borrowedBook -= num;
                Console.WriteLine($"{num}권 반납했습니다.");
                Console.WriteLine($"도서가 반납 되었습니다. (대출된 도서: {borrowedBook}권, 남은 도서 : {totalBooks - borrowedBook}");
            } else
            {
                Console.WriteLine($"반납할 도서 수는 0보다 크거나 {borrowedBook}권 보다 작아야 합니다.");
            }
        }

        /// <summary>
        /// 도서관 정보 출력
        /// </summary>
        public static void ShowLibraryInfo() {

            Console.WriteLine($"=== {LibraryName} ===");
            Console.WriteLine($"총 도서 수: {totalBooks}");
            Console.WriteLine($"대출된 도서 수: {borrowedBook}");
            Console.WriteLine($"대출 가능 도서 수: {totalBooks - borrowedBook}");
        }
    }
}
