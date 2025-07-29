using System;

namespace _0723
{
    /// <summary>
    /// Library 클래스 - 정적 멤버를 활용한 도서관 관리 시스템
    /// 
    /// 주요 학습 포인트:
    /// 1. 정적 클래스의 실제 활용 사례
    /// 2. 상태 관리를 위한 정적 변수 사용
    /// 3. 비즈니스 로직을 포함한 정적 메서드 설계
    /// 4. 입력 유효성 검사 및 예외 처리
    /// 5. XML 문서화 주석 사용법
    /// 
    /// 왜 정적으로 만들었을까?
    /// - 도서관은 일반적으로 하나의 시스템으로 관리됨
    /// - 전체 도서 현황은 공통 데이터로 관리되어야 함
    /// - 객체를 생성할 필요 없이 기능만 제공하면 됨
    /// </summary>
    internal class Library
    {
        // ============================================
        // 정적 필드들 (Static Fields) - 도서관 상태 데이터
        // ============================================

        /// <summary>
        /// 도서관 이름 (정적 필드)
        /// - 모든 도서관 관련 작업에서 공통으로 사용되는 이름
        /// - 변경되지 않는 고정 데이터이므로 정적으로 관리
        /// </summary>
        public static string LibraryName = "중앙 도서관";

        /// <summary>
        /// 전체 도서 수 (정적 필드)
        /// - 도서관이 보유한 모든 도서의 총 개수
        /// - 도서 추가 시 증가됨
        /// </summary>
        public static int totalBooks = 500;

        /// <summary>
        /// 대출된 도서 수 (정적 필드) 
        /// - 현재 대출 중인 도서의 개수
        /// - 대출 시 증가, 반납 시 감소
        /// </summary>
        public static int borrowedBooks = 50;

        // ============================================
        // 계산된 속성 (Computed Properties)
        // ============================================

        /// <summary>
        /// 대출 가능한 도서 수 (계산된 속성)
        /// - 전체 도서 수에서 대출된 도서 수를 뺀 값
        /// - 실시간으로 계산되는 값
        /// </summary>
        public static int AvailableBooks => totalBooks - borrowedBooks;

        // ============================================
        // 도서 관리 메서드들 (Static Methods)
        // ============================================

        /// <summary>
        /// 도서관에 새 도서를 추가하는 메서드
        /// </summary>
        /// <param name="num">추가할 도서의 수량 (양수여야 함)</param>
        /// <returns>추가 성공 여부</returns>
        public static bool AddBook(int num)
        {
            // 입력 유효성 검사
            if (num <= 0)
            {
                Console.WriteLine("❌ 오류: 추가할 도서 수는 0보다 커야 합니다.");
                return false;
            }

            // 도서 추가 로직
            totalBooks += num;

            // 성공 메시지 출력
            Console.WriteLine($"📚 {num}권의 도서가 추가되었습니다.");
            Console.WriteLine($"✅ 도서 추가 완료! (현재 총 도서 수: {totalBooks}권)");

            return true;
        }

        /// <summary>
        /// 도서를 대출하는 메서드
        /// </summary>
        /// <param name="num">대출할 도서의 수량</param>
        /// <returns>대출 성공 여부</returns>
        public static bool BorrowBook(int num)
        {
            // 입력 유효성 검사
            if (num <= 0)
            {
                Console.WriteLine("❌ 오류: 대출할 도서 수는 0보다 커야 합니다.");
                return false;
            }

            // 대출 가능 여부 검사
            if (num > AvailableBooks)
            {
                Console.WriteLine($"❌ 오류: 대출 가능한 도서가 부족합니다.");
                Console.WriteLine($"   대출 요청: {num}권, 대출 가능: {AvailableBooks}권");
                return false;
            }

            // 대출 처리 로직
            borrowedBooks += num;

            // 성공 메시지 출력
            Console.WriteLine($"📖 {num}권의 도서가 대출되었습니다.");
            Console.WriteLine($"✅ 대출 완료! (대출된 도서: {borrowedBooks}권, 남은 도서: {AvailableBooks}권)");

            return true;
        }

        /// <summary>
        /// 도서를 반납하는 메서드
        /// </summary>
        /// <param name="num">반납할 도서의 수량</param>
        /// <returns>반납 성공 여부</returns>
        public static bool ReturnBook(int num)
        {
            // 입력 유효성 검사
            if (num <= 0)
            {
                Console.WriteLine("❌ 오류: 반납할 도서 수는 0보다 커야 합니다.");
                return false;
            }

            // 반납 가능 여부 검사 (대출된 도서보다 많이 반납할 수 없음)
            if (num > borrowedBooks)
            {
                Console.WriteLine($"❌ 오류: 반납할 수 있는 도서보다 많은 수량입니다.");
                Console.WriteLine($"   반납 요청: {num}권, 반납 가능: {borrowedBooks}권");
                return false;
            }

            // 반납 처리 로직
            borrowedBooks -= num;

            // 성공 메시지 출력
            Console.WriteLine($"📚 {num}권의 도서가 반납되었습니다.");
            Console.WriteLine($"✅ 반납 완료! (대출된 도서: {borrowedBooks}권, 남은 도서: {AvailableBooks}권)");

            return true;
        }

        // ============================================
        // 정보 조회 메서드들 (Information Methods)
        // ============================================

        /// <summary>
        /// 도서관의 전체 현황 정보를 출력하는 메서드
        /// </summary>
        public static void ShowLibraryInfo()
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine($"📚 {LibraryName} 현황 정보");
            Console.WriteLine("========================================");
            Console.WriteLine($"📖 총 도서 수      : {totalBooks:N0}권");
            Console.WriteLine($"📤 대출된 도서 수   : {borrowedBooks:N0}권");
            Console.WriteLine($"📥 대출 가능 도서 수: {AvailableBooks:N0}권");
            Console.WriteLine($"📊 대출률          : {GetBorrowRate():F1}%");
            Console.WriteLine("========================================");
            Console.WriteLine();
        }

        /// <summary>
        /// 간단한 도서관 현황을 한 줄로 출력하는 메서드
        /// </summary>
        public static void ShowBriefInfo()
        {
            Console.WriteLine($"[{LibraryName}] 총 {totalBooks}권 | 대출 {borrowedBooks}권 | 이용가능 {AvailableBooks}권");
        }

        // ============================================
        // 유틸리티 메서드들 (Utility Methods)
        // ============================================

        /// <summary>
        /// 현재 도서 대출률을 계산하는 메서드
        /// </summary>
        /// <returns>대출률 (백분율)</returns>
        public static double GetBorrowRate()
        {
            if (totalBooks == 0) return 0.0;
            return (double)borrowedBooks / totalBooks * 100.0;
        }

        /// <summary>
        /// 도서관 데이터를 초기값으로 리셋하는 메서드
        /// </summary>
        public static void ResetLibrary()
        {
            totalBooks = 500;
            borrowedBooks = 50;
            Console.WriteLine("🔄 도서관 데이터가 초기값으로 리셋되었습니다.");
        }

        /// <summary>
        /// 특정 수량의 도서가 대출 가능한지 확인하는 메서드
        /// </summary>
        /// <param name="requestedBooks">확인할 도서 수량</param>
        /// <returns>대출 가능 여부</returns>
        public static bool CanBorrow(int requestedBooks)
        {
            return requestedBooks > 0 && requestedBooks <= AvailableBooks;
        }

        /// <summary>
        /// 특정 수량의 도서가 반납 가능한지 확인하는 메서드
        /// </summary>
        /// <param name="returnBooks">확인할 반납 도서 수량</param>
        /// <returns>반납 가능 여부</returns>
        public static bool CanReturn(int returnBooks)
        {
            return returnBooks > 0 && returnBooks <= borrowedBooks;
        }
    }
}

/*
 * ============================================
 * 사용 예제 및 예상 결과
 * ============================================
 * 
 * // 초기 상태 확인
 * Library.ShowLibraryInfo();
 * // 출력: 총 도서 수: 500권, 대출된 도서 수: 50권, 대출 가능 도서 수: 450권
 * 
 * // 도서 추가
 * Library.AddBook(100);
 * // 출력: 📚 100권의 도서가 추가되었습니다.
 * //      ✅ 도서 추가 완료! (현재 총 도서 수: 600권)
 * 
 * // 도서 대출
 * Library.BorrowBook(150);
 * // 출력: 📖 150권의 도서가 대출되었습니다.
 * //      ✅ 대출 완료! (대출된 도서: 200권, 남은 도서: 400권)
 * 
 * // 잘못된 반납 시도 (대출된 책보다 많이 반납)
 * Library.ReturnBook(250);
 * // 출력: ❌ 오류: 반납할 수 있는 도서보다 많은 수량입니다.
 * //      반납 요청: 250권, 반납 가능: 200권
 * 
 * // 올바른 반납
 * Library.ReturnBook(50);
 * // 출력: 📚 50권의 도서가 반납되었습니다.
 * //      ✅ 반납 완료! (대출된 도서: 150권, 남은 도서: 450권)
 * 
 * ============================================
 * 정적 클래스 설계의 장점
 * ============================================
 * 
 * 1. 전역 상태 관리
 *    - 도서관의 전체 현황을 하나의 공통 데이터로 관리
 *    - 어디서든 Library.totalBooks로 접근 가능
 * 
 * 2. 메모리 효율성
 *    - 객체 생성 없이 기능 제공
 *    - 불필요한 인스턴스 생성 방지
 * 
 * 3. 사용 편의성
 *    - Library.AddBook(100) 형태로 직관적 사용
 *    - 복잡한 객체 생명주기 관리 불필요
 * 
 * 4. 일관성 보장
 *    - 모든 곳에서 동일한 데이터 상태 보장
 *    - 데이터 불일치 문제 방지
 * 
 * ============================================
 * 실제 적용 시나리오
 * ============================================
 * 
 * 이런 정적 클래스 패턴은 다음과 같은 경우에 유용합니다:
 * - 설정 관리 클래스 (ConfigManager)
 * - 로깅 시스템 (Logger)
 * - 유틸리티 함수 모음 (MathUtils, StringUtils)
 * - 전역 상태 관리 (GameManager, UserSession)
 * - 싱글톤 패턴 대신 사용할 수 있는 간단한 서비스
 */