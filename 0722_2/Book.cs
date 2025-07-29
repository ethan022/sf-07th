using System;

namespace _07222
{
    /// <summary>
    /// Book 클래스 - 복합 프로퍼티와 유효성 검사 학습
    /// 
    /// 학습 포인트:
    /// 1. 유효성 검사가 포함된 프로퍼티
    /// 2. 읽기 전용 프로퍼티 (get만 있는 프로퍼티)
    /// 3. 자동 구현 프로퍼티와 일반 프로퍼티 혼합 사용
    /// 4. 계산된 프로퍼티 (페이지 수에 따른 분류)
    /// 5. 생성자에서 프로퍼티 활용
    /// </summary>
    public class Book
    {
        // ============================================
        // private 필드들 (실제 데이터 저장소)
        // ============================================

        private string title;    // 제목 저장
        private string author;   // 저자 저장
        private double price;    // 가격 저장
        private string isbn;     // ISBN 저장

        // ============================================
        // 유효성 검사가 포함된 프로퍼티들
        // ============================================

        /// <summary>
        /// 제목 프로퍼티 - 빈 값 검사 포함
        /// </summary>
        public string Title
        {
            get { return title; }
            set
            {
                // string.IsNullOrWhiteSpace(): null, 빈 문자열, 공백만 있는 문자열 검사
                if (!string.IsNullOrWhiteSpace(value))
                {
                    title = value;
                }
                else
                {
                    Console.WriteLine("제목은 비어 있을 수 없습니다.!");
                }
            }
        }

        /// <summary>
        /// 저자 프로퍼티 - 빈 값 검사 포함
        /// </summary>
        public string Author
        {
            get { return author; }
            set
            {
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

        /// <summary>
        /// 가격 프로퍼티 - 양수 검사 및 설정 알림 포함
        /// </summary>
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

        /// <summary>
        /// ISBN 프로퍼티 - 읽기 전용 (get만 있음)
        /// 
        /// 특징:
        /// - set이 없어서 외부에서 값 변경 불가
        /// - 생성자에서만 private 필드에 직접 할당
        /// - 한 번 설정되면 변경할 수 없는 고유 식별자
        /// </summary>
        public string ISBN
        {
            get { return isbn; }
        }

        // ============================================
        // 자동 구현 프로퍼티
        // ============================================

        /// <summary>
        /// 페이지 수 - 자동 구현 프로퍼티
        /// 
        /// 특징:
        /// - 간단한 get/set이므로 자동 구현 사용
        /// - 별도 유효성 검사 없음
        /// </summary>
        public int PageCount { get; set; }

        // ============================================
        // 계산된 프로퍼티 (읽기 전용)
        // ============================================

        /// <summary>
        /// 책 분류 - 페이지 수에 따라 자동 계산되는 프로퍼티
        /// 
        /// 분류 기준:
        /// - 100페이지 미만: "소책자"
        /// - 100~200페이지: "일반서"  
        /// - 200페이지 초과: "대형책자"
        /// </summary>
        public string Category
        {
            get
            {
                if (PageCount < 100)
                {
                    return "소책자";
                }
                else if (PageCount <= 200)
                {
                    return "일반서";
                }
                else
                {
                    return "대형책자";
                }
            }
        }

        // ============================================
        // 생성자 (Constructor)
        // ============================================

        /// <summary>
        /// Book 생성자 - 모든 필수 정보를 받아서 객체 초기화
        /// 
        /// 주의사항:
        /// - Title, Author, Price는 프로퍼티를 통해 설정 (유효성 검사 적용)
        /// - isbn은 private 필드에 직접 할당 (읽기 전용이므로)
        /// - PageCount는 자동 프로퍼티에 직접 할당
        /// </summary>
        /// <param name="title">책 제목</param>
        /// <param name="author">저자명</param>
        /// <param name="price">가격</param>
        /// <param name="isbn">ISBN 번호</param>
        /// <param name="pageCount">페이지 수</param>
        public Book(string title, string author, double price, string isbn, int pageCount)
        {
            Title = title;           // Title 프로퍼티의 set 호출 (유효성 검사 적용)
            Author = author;         // Author 프로퍼티의 set 호출 (유효성 검사 적용)
            Price = price;           // Price 프로퍼티의 set 호출 (유효성 검사 적용)
            this.isbn = isbn;        // private 필드에 직접 할당 (읽기 전용)
            PageCount = pageCount;   // 자동 프로퍼티에 직접 할당

            Console.WriteLine($"새 도서 등록 완료: {title}");
        }

        // ============================================
        // 메서드 (Methods)
        // ============================================

        /// <summary>
        /// 책의 모든 정보를 출력하는 메서드
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine($"=== 도서 정보 ===");
            Console.WriteLine($"제목: {Title}");        // Title 프로퍼티의 get 호출
            Console.WriteLine($"저자 : {Author}");      // Author 프로퍼티의 get 호출
            Console.WriteLine($"가격: {Price}");        // Price 프로퍼티의 get 호출
            Console.WriteLine($"페이지 수: {PageCount}"); // PageCount 프로퍼티의 get 호출
            Console.WriteLine($"ISBN: {ISBN}");         // ISBN 프로퍼티의 get 호출
            Console.WriteLine($"분류: {Category}");     // Category 프로퍼티의 get 호출 (자동 계산)
        }
    }
}

/*
 * ============================================
 * 사용 예제
 * ============================================
 * 
 * Book book = new Book("해리 포터", "JK", 15000, "123-78-9123", 200);
 * // 출력: 해리 포터의 가격이 15000원으로 설정 되었습니다.
 * //      새 도서 등록 완료: 해리 포터
 * 
 * book.ShowInfo();
 * // 출력: === 도서 정보 ===
 * //      제목: 해리 포터
 * //      저자 : JK
 * //      가격: 15000
 * //      페이지 수: 200
 * //      ISBN: 123-78-9123
 * //      분류: 일반서
 * 
 * // 잘못된 값 설정 시도
 * book.Title = "";     // 출력: 제목은 비어 있을 수 없습니다.!
 * book.Price = -5000;  // 출력: 가격은 0보다 커야 합니다.
 * 
 * ============================================
 * 프로퍼티 설계 패턴 정리
 * ============================================
 * 
 * 1. 유효성 검사가 필요한 데이터:
 *    - private 필드 + get/set 프로퍼티
 *    - set에서 조건 검사 후 할당
 *    - 예: Title, Author, Price
 * 
 * 2. 변경되지 않아야 하는 데이터:
 *    - private 필드 + get만 있는 프로퍼티
 *    - 생성자에서만 private 필드에 직접 할당
 *    - 예: ISBN
 * 
 * 3. 간단한 데이터:
 *    - 자동 구현 프로퍼티 { get; set; }
 *    - 별도 검사가 필요 없는 경우
 *    - 예: PageCount
 * 
 * 4. 계산되는 데이터:
 *    - get만 있는 프로퍼티
 *    - 다른 프로퍼티를 기반으로 계산
 *    - 예: Category
 */