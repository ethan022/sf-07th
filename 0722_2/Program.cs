using System;

namespace _07222
{
    /// <summary>
    /// Program 클래스 - 프로퍼티 학습을 위한 메인 실행 코드
    /// 
    /// 실행 내용:
    /// 1. Person 클래스의 기본 프로퍼티 사용
    /// 2. Rectangle 클래스의 자동 프로퍼티와 계산된 프로퍼티 사용
    /// 3. Book 클래스의 복합 프로퍼티와 유효성 검사 확인
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 프로그램의 시작점
        /// </summary>
        /// <param name="args">명령줄 인수</param>
        static void Main(string[] args)
        {
            Console.WriteLine("🎓 C# 프로퍼티(Property) 학습 프로그램");
            Console.WriteLine("=" + new string('=', 50));
            Console.WriteLine();

            // ============================================
            // 1. Person 클래스 테스트 - 기본 프로퍼티
            // ============================================

            Console.WriteLine("👤 1. Person 클래스 - 기본 프로퍼티 테스트");
            Console.WriteLine("-" + new string('-', 40));

            // Person 객체 생성
            Person person = new Person();

            // 프로퍼티를 통한 값 설정 (setter 호출)
            person.Name = "김철수";  // Name 프로퍼티의 set 호출
            person.Age = 30;        // Age 프로퍼티의 set 호출 (유효성 검사 통과)

            // 프로퍼티를 통한 값 조회 (getter 호출)
            Console.WriteLine($"이름: {person.Name}");  // Name 프로퍼티의 get 호출
            Console.WriteLine($"나이: {person.Age}");   // Age 프로퍼티의 get 호출

            // 유효성 검사 테스트 - 잘못된 나이 설정 시도
            Console.WriteLine("\n🚫 유효성 검사 테스트:");
            person.Age = -10;  // Age 프로퍼티의 set 호출 (유효성 검사 실패)

            Console.WriteLine();

            // ============================================
            // 2. Rectangle 클래스 테스트 - 자동 프로퍼티와 계산된 프로퍼티
            // ============================================

            Console.WriteLine("📐 2. Rectangle 클래스 - 자동/계산된 프로퍼티 테스트");
            Console.WriteLine("-" + new string('-', 50));

            // Rectangle 객체 생성 (초기값 사용)
            Rectangle rc = new Rectangle();
            Console.WriteLine("📋 초기값으로 생성된 사각형 정보:");
            rc.ShowInfo();  // Width=22, Height=10 (초기값)

            Console.WriteLine("\n📝 크기 변경 후:");
            // 자동 프로퍼티 값 변경
            rc.Width = 5;   // 자동 프로퍼티의 set 호출
            rc.Height = 3;  // 자동 프로퍼티의 set 호출
            rc.ShowInfo();  // 계산된 프로퍼티들이 자동으로 새 값으로 계산됨

            Console.WriteLine();

            // ============================================
            // 3. Book 클래스 테스트 - 복합 프로퍼티와 유효성 검사
            // ============================================

            Console.WriteLine("📚 3. Book 클래스 - 복합 프로퍼티 테스트");
            Console.WriteLine("-" + new string('-', 40));

            // Book 객체 생성 (생성자에서 프로퍼티 사용)
            Console.WriteLine("📖 새 책 생성:");
            Book book = new Book("해리 포터", "JK", 15000, "123-78-9123", 200);

            Console.WriteLine("\n📋 책 정보 출력:");
            book.ShowInfo();  // 모든 프로퍼티 값 출력 (계산된 분류 포함)

            // 유효성 검사 테스트들
            Console.WriteLine("\n🚫 유효성 검사 테스트들:");

            // 빈 제목 설정 시도
            Console.WriteLine("• 빈 제목 설정 시도:");
            book.Title = "";  // 유효성 검사 실패

            // 빈 저자명 설정 시도  
            Console.WriteLine("• 빈 저자명 설정 시도:");
            book.Author = "   ";  // 공백만 있는 문자열 (유효성 검사 실패)

            // 잘못된 가격 설정 시도
            Console.WriteLine("• 음수 가격 설정 시도:");
            book.Price = -5000;  // 유효성 검사 실패

            // 올바른 가격 변경
            Console.WriteLine("• 올바른 가격 변경:");
            book.Price = 18000;  // 유효성 검사 통과

            Console.WriteLine("\n📋 최종 책 정보:");
            book.ShowInfo();

            // ============================================
            // 4. 다양한 페이지 수에 따른 분류 테스트
            // ============================================

            Console.WriteLine("\n📊 4. 책 분류 시스템 테스트 (계산된 프로퍼티)");
            Console.WriteLine("-" + new string('-', 50));

            // 소책자 테스트
            Book smallBook = new Book("소설집", "작가A", 8000, "111-11-1111", 80);
            Console.WriteLine($"📘 {smallBook.Title} ({smallBook.PageCount}페이지) → 분류: {smallBook.Category}");

            // 일반서 테스트  
            Book normalBook = new Book("에세이", "작가B", 12000, "222-22-2222", 150);
            Console.WriteLine($"📗 {normalBook.Title} ({normalBook.PageCount}페이지) → 분류: {normalBook.Category}");

            // 대형책자 테스트
            Book largeBook = new Book("백과사전", "작가C", 30000, "333-33-3333", 500);
            Console.WriteLine($"📕 {largeBook.Title} ({largeBook.PageCount}페이지) → 분류: {largeBook.Category}");

            // ============================================
            // 5. 프로그램 종료
            // ============================================

            Console.WriteLine("\n" + "=" + new string('=', 50));
            Console.WriteLine("🎉 프로퍼티 학습 완료!");
            Console.WriteLine("📚 학습한 내용:");
            Console.WriteLine("   ✓ 기본 프로퍼티 (get/set)");
            Console.WriteLine("   ✓ 자동 구현 프로퍼티");
            Console.WriteLine("   ✓ 계산된 프로퍼티 (읽기 전용)");
            Console.WriteLine("   ✓ 유효성 검사가 포함된 프로퍼티");
            Console.WriteLine("   ✓ 읽기 전용 프로퍼티");

            Console.WriteLine("\n⌨️  아무 키나 누르면 프로그램이 종료됩니다...");
            Console.ReadKey();
        }
    }
}

/*
 * ============================================
 * 예상 실행 결과
 * ============================================
 * 
 * 🎓 C# 프로퍼티(Property) 학습 프로그램
 * ==================================================
 * 
 * 👤 1. Person 클래스 - 기본 프로퍼티 테스트
 * ----------------------------------------
 * 이름: 김철수
 * 나이: 30
 * 
 * 🚫 유효성 검사 테스트:
 * 나이는 1 ~ 120 사이의 값이어야 합니다.
 * 
 * 📐 2. Rectangle 클래스 - 자동/계산된 프로퍼티 테스트
 * --------------------------------------------------
 * 📋 초기값으로 생성된 사각형 정보:
 * 가로: 22, 세로: 10
 * 넓이: 220
 * 둘레: 64
 * 
 * 📝 크기 변경 후:
 * 가로: 5, 세로: 3
 * 넓이: 15
 * 둘레: 16
 * 
 * 📚 3. Book 클래스 - 복합 프로퍼티 테스트
 * ----------------------------------------
 * 📖 새 책 생성:
 * 해리 포터의 가격이 15000원으로 설정 되었습니다.
 * 새 도서 등록 완료: 해리 포터
 * 
 * 📋 책 정보 출력:
 * === 도서 정보 ===
 * 제목: 해리 포터
 * 저자 : JK
 * 가격: 15000
 * 페이지 수: 200
 * ISBN: 123-78-9123
 * 분류: 일반서
 * 
 * 🚫 유효성 검사 테스트들:
 * • 빈 제목 설정 시도:
 * 제목은 비어 있을 수 없습니다.!
 * • 빈 저자명 설정 시도:
 * 저자명은 비어 있을 수 없습니다.!
 * • 음수 가격 설정 시도:
 * 가격은 0보다 커야 합니다.
 * • 올바른 가격 변경:
 * 해리 포터의 가격이 18000원으로 설정 되었습니다.
 * 
 * 📊 4. 책 분류 시스템 테스트 (계산된 프로퍼티)
 * --------------------------------------------------
 * 소설집의 가격이 8000원으로 설정 되었습니다.
 * 새 도서 등록 완료: 소설집
 * 📘 소설집 (80페이지) → 분류: 소책자
 * 에세이의 가격이 12000원으로 설정 되었습니다.
 * 새 도서 등록 완료: 에세이
 * 📗 에세이 (150페이지) → 분류: 일반서
 * 백과사전의 가격이 30000원으로 설정 되었습니다.
 * 새 도서 등록 완료: 백과사전
 * 📕 백과사전 (500페이지) → 분류: 대형책자
 * 
 * ==================================================
 * 🎉 프로퍼티 학습 완료!
 */