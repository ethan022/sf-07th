using System;

namespace _0723
{
    /// <summary>
    /// Program 클래스 - 애플리케이션의 진입점
    /// 
    /// 주요 학습 포인트:
    /// 1. Main 메서드의 역할과 구조
    /// 2. 정적 멤버와 인스턴스 멤버의 실제 사용 차이점
    /// 3. 객체 생성과 메서드 호출 패턴
    /// 4. 정적 생성자의 실행 시점 확인
    /// 5. 클래스별 특성과 활용 방법
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 애플리케이션의 진입점 (Entry Point)
        /// - 프로그램이 시작될 때 가장 먼저 실행되는 메서드
        /// - 반드시 static이어야 하며, Main이라는 이름을 가져야 함
        /// - string[] args는 명령줄 인수를 받는 매개변수
        /// </summary>
        /// <param name="args">명령줄 인수 배열</param>
        static void Main(string[] args)
        {
            // 프로그램 시작 메시지
            Console.WriteLine("🚀 C# 정적 멤버 학습 프로그램 시작!");
            Console.WriteLine("=" + new string('=', 60));
            Console.WriteLine();

            // ============================================
            // 1. Person 클래스 테스트 - 인스턴스 멤버 예제
            // ============================================

            Console.WriteLine("👥 1. Person 클래스 테스트 (인스턴스 멤버)");
            Console.WriteLine("-" + new string('-', 40));

            // Person 객체 생성 - 각각 독립적인 메모리 공간을 가짐
            Person person1 = new Person();
            person1.age = 25;
            person1.name = "김철수";

            Person person2 = new Person();
            person2.age = 22;
            person2.name = "이영희";

            // 각 객체는 서로 다른 값을 가짐 (인스턴스 멤버의 특징)
            Console.WriteLine("📋 각 Person 객체의 정보:");
            person1.PrintInfo();  // 출력: 김철수, 25
            person2.PrintInfo();  // 출력: 이영희, 22

            Console.WriteLine("✅ 인스턴스 멤버는 객체마다 독립적인 값을 가집니다.");
            Console.WriteLine();

            // ============================================
            // 2. Math 클래스 테스트 - 정적 멤버 예제
            // ============================================

            Console.WriteLine("🧮 2. Math 클래스 테스트 (정적 멤버)");
            Console.WriteLine("-" + new string('-', 40));

            // 정적 멤버는 객체 생성 없이 클래스 이름으로 직접 접근
            Console.WriteLine($"📐 Math.PI 값: {Math.PI}");

            // 정적 메서드 호출 - 객체 생성 불필요
            double radius = 5.0;
            double area = Math.GetCircleArea(radius);
            Console.WriteLine($"🔵 반지름 {radius}인 원의 넓이: {area:F2}");

            Console.WriteLine("✅ 정적 멤버는 객체 생성 없이 클래스 이름으로 접근합니다.");
            Console.WriteLine();

            // ============================================
            // 3. Counter 클래스 테스트 - 정적 메서드 사용
            // ============================================

            Console.WriteLine("🔢 3. Counter 클래스 테스트 (정적 메서드 먼저)");
            Console.WriteLine("-" + new string('-', 50));

            // 정적 메서드를 먼저 사용 (객체 생성 전)
            Console.WriteLine("📈 정적 메서드로 카운트 조작:");
            Counter.Increment();  // count: 0 → 1
            Counter.Increment();  // count: 1 → 2  
            Counter.Increment();  // count: 2 → 3
            Counter.ShowInfo();   // 현재 카운트: 3

            Counter.Decrement();  // count: 3 → 2
            Counter.ShowInfo();   // 현재 카운트: 2

            Console.WriteLine();

            // ============================================
            // 4. Logger 클래스 테스트 - 정적 생성자 실행 확인
            // ============================================

            Console.WriteLine("📝 4. Logger 클래스 테스트 (정적 생성자)");
            Console.WriteLine("-" + new string('-', 50));

            Console.WriteLine("🔍 첫 번째 Logger 사용 시 정적 생성자가 실행됩니다:");

            // 첫 번째 Logger 사용 - 이때 정적 생성자가 자동 실행됨
            Logger.WriteLog("첫 번째 로그 메시지");

            // 이후 Logger 사용 시에는 정적 생성자가 실행되지 않음
            Console.WriteLine("\n🔍 이후 Logger 사용 시에는 초기화 메시지가 없습니다:");

            Console.WriteLine();

            // ============================================
            // 5. Counter 객체 생성 및 인스턴스 메서드 테스트
            // ============================================

            Console.WriteLine("🏭 5. Counter 객체 생성 및 인스턴스 메서드");
            Console.WriteLine("-" + new string('-', 50));

            Console.WriteLine("📦 Counter 객체들을 생성합니다:");

            // Counter 객체 생성 - 생성자에서 count가 증가됨
            // 이전 정적 메서드로 count가 2였으므로, 3, 4, 5로 증가
            Counter c1 = new Counter();  // count: 2 → 3, instanceId: 3
            Counter c2 = new Counter();  // count: 3 → 4, instanceId: 4  
            Counter c3 = new Counter();  // count: 4 → 5, instanceId: 5

            Console.WriteLine("\n📊 각 객체의 정보 출력:");
            Console.WriteLine("(instanceId는 개별, count는 공유됨을 확인)");

            // 인스턴스 메서드 호출
            c1.Show();  // 객체 ID: 3, 현재 전체 카운트: 5
            c2.Show();  // 객체 ID: 4, 현재 전체 카운트: 5
            c3.Show();  // 객체 ID: 5, 현재 전체 카운트: 5

            Console.WriteLine("✅ 인스턴스 변수(instanceId)는 각각 다르지만,");
            Console.WriteLine("   정적 변수(count)는 모든 객체가 동일한 값을 공유합니다.");
            Console.WriteLine();

            // ============================================
            // 6. Library 클래스 테스트 - 실용적인 정적 클래스
            // ============================================

            Console.WriteLine("📚 6. Library 클래스 테스트 (도서관 관리 시스템)");
            Console.WriteLine("-" + new string('-', 60));

            // 초기 도서관 상태 확인
            Console.WriteLine("📋 초기 도서관 상태:");
            Library.ShowLibraryInfo();

            // 도서 추가 시나리오
            Console.WriteLine("📥 도서 추가 시나리오:");
            Library.AddBook(100);
            Library.ShowBriefInfo();
            Console.WriteLine();

            // 도서 대출 시나리오
            Console.WriteLine("📤 도서 대출 시나리오:");
            Library.BorrowBook(150);
            Library.ShowBriefInfo();
            Console.WriteLine();

            // 현재 상태 확인
            Console.WriteLine("📊 대출 후 상태:");
            Library.ShowLibraryInfo();

            // 잘못된 반납 시도 (대출된 책보다 많이 반납)
            Console.WriteLine("❌ 잘못된 반납 시도:");
            bool returnResult = Library.ReturnBook(250);
            Console.WriteLine($"반납 결과: {(returnResult ? "성공" : "실패")}");
            Console.WriteLine();

            // 올바른 반납
            Console.WriteLine("✅ 올바른 반납:");
            Library.ReturnBook(50);
            Library.ShowLibraryInfo();

            // ============================================
            // 7. Logger 고급 기능 테스트
            // ============================================

            Console.WriteLine("🔧 7. Logger 고급 기능 테스트");
            Console.WriteLine("-" + new string('-', 40));

            // 다양한 레벨의 로그 추가
            Logger.WriteLog("일반 로그 메시지");

            // ============================================
            // 8. 프로그램 종료
            // ============================================

            Console.WriteLine("🏁 프로그램 종료");
            Console.WriteLine("=" + new string('=', 60));
            Console.WriteLine("📚 학습 내용 요약:");
            Console.WriteLine("   ✓ 정적 멤버 vs 인스턴스 멤버의 차이점");
            Console.WriteLine("   ✓ 정적 생성자의 실행 시점과 특징");
            Console.WriteLine("   ✓ 실용적인 정적 클래스 설계 방법");
            Console.WriteLine("   ✓ 객체 지향 프로그래밍의 기본 개념");
            Console.WriteLine();
            Console.WriteLine("🎉 학습 완료! 수고하셨습니다!");

            // 사용자 입력 대기 (콘솔이 바로 닫히지 않도록)
            Console.WriteLine("\n⌨️  아무 키나 누르면 프로그램이 종료됩니다...");
            Console.ReadKey();
        }

        // ============================================
        // 추가 도우미 메서드들 (Helper Methods)
        // ============================================

        /// <summary>
        /// 구분선을 출력하는 헬퍼 메서드
        /// </summary>
        /// <param name="title">구분선 제목</param>
        /// <param name="length">구분선 길이</param>
        private static void PrintSeparator(string title, int length = 40)
        {
            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine(new string('-', length));
        }

        /// <summary>
        /// 단계별 실행을 위한 일시정지 메서드
        /// </summary>
        /// <param name="message">일시정지 메시지</param>
        private static void PauseWithMessage(string message = "계속하려면 아무 키나 누르세요...")
        {
            Console.WriteLine($"\n⏸️  {message}");
            Console.ReadKey();
            Console.WriteLine();
        }

        /// <summary>
        /// 성공/실패 결과를 시각적으로 표시하는 메서드
        /// </summary>
        /// <param name="success">성공 여부</param>
        /// <param name="successMessage">성공 메시지</param>
        /// <param name="failureMessage">실패 메시지</param>
        private static void ShowResult(bool success, string successMessage, string failureMessage)
        {
            if (success)
            {
                Console.WriteLine($"✅ {successMessage}");
            }
            else
            {
                Console.WriteLine($"❌ {failureMessage}");
            }
        }
    }
}

/*
 * ============================================
 * 예상 실행 결과 및 학습 포인트
 * ============================================
 * 
 * 🔍 실행 순서와 결과 예측:
 * 
 * 1. Person 클래스 테스트
 *    김철수, 25
 *    이영희, 22
 *    → 각 객체가 독립적인 데이터를 가짐
 * 
 * 2. Math 클래스 테스트  
 *    📐 Math.PI 값: 3.1415
 *    🔵 반지름 5인 원의 넓이: 78.54
 *    → 정적 멤버는 객체 생성 없이 사용
 * 
 * 3. Counter 정적 메서드 테스트
 *    Count 증가: 1
 *    Count 증가: 2  
 *    Count 증가: 3
 *    현재 카운트: 3
 *    Count 감소: 2
 *    현재 카운트: 2
 * 
 * 4. Logger 첫 사용 (정적 생성자 실행)
 *    🚀 Logger 시스템이 초기화되었습니다.
 *    📁 로그 파일: log_20240723.txt
 *    ⏰ 초기화 시간: 2024-07-23 14:30:25
 *    ==================================================
 *    📝 [LOG] 첫 번째 로그 메시지
 *    ℹ️ [INFO] 두 번째 로그 메시지
 *    ⚠️ [WARN] 세 번째 로그 메시지
 *    
 *    (이후 Logger 사용 시에는 초기화 메시지 없음)
 *    ❌ [ERROR] 네 번째 로그 메시지
 *    🔧 [DEBUG] 다섯 번째 로그 메시지
 * 
 * 5. Counter 객체 생성
 *    Counter 객체 생성됨 - ID: 3, 총 생성된 객체 수: 3
 *    Counter 객체 생성됨 - ID: 4, 총 생성된 객체 수: 4
 *    Counter 객체 생성됨 - ID: 5, 총 생성된 객체 수: 5
 *    
 *    객체 ID: 3, 현재 전체 카운트: 5
 *    객체 ID: 4, 현재 전체 카운트: 5  
 *    객체 ID: 5, 현재 전체 카운트: 5
 *    → 인스턴스 ID는 각각 다르지만, count는 공유됨
 * 
 * 6. Library 클래스 테스트
 *    📚 중앙 도서관 현황 정보
 *    📖 총 도서 수      : 500권
 *    📤 대출된 도서 수   : 50권  
 *    📥 대출 가능 도서 수: 450권
 *    📊 대출률          : 10.0%
 *    
 *    📚 100권의 도서가 추가되었습니다.
 *    📖 150권의 도서가 대출되었습니다.
 *    
 *    ❌ 오류: 반납할 수 있는 도서보다 많은 수량입니다.
 *    반납 요청: 250권, 반납 가능: 200권
 *    
 *    📚 50권의 도서가 반납되었습니다.
 * 
 * ============================================
 * 핵심 학습 내용 정리
 * ============================================
 * 
 * 🎯 1. 정적 멤버 vs 인스턴스 멤버
 * 
 * 정적 멤버 (Static Members):
 * ✅ 클래스 이름으로 직접 접근: Counter.Increment()
 * ✅ 객체 생성 없이 사용 가능
 * ✅ 모든 인스턴스가 공유하는 하나의 메모리 공간
 * ✅ 프로그램 시작부터 종료까지 메모리에 유지
 * ✅ 용도: 공통 상수, 유틸리티 함수, 전역 상태 관리
 * 
 * 인스턴스 멤버 (Instance Members):
 * ✅ 객체를 통해서만 접근: person1.PrintInfo()
 * ✅ 객체 생성 후 사용 가능
 * ✅ 각 객체마다 독립적인 메모리 공간
 * ✅ 객체가 소멸되면 함께 소멸
 * ✅ 용도: 객체별 고유 데이터, 개별 상태 관리
 * 
 * 🎯 2. 정적 생성자 (Static Constructor)
 * 
 * 특징:
 * ✅ 클래스가 처음 사용될 때 단 한 번만 자동 실행
 * ✅ 매개변수를 가질 수 없음
 * ✅ 접근 제한자 사용 불가 (항상 private)
 * ✅ 직접 호출할 수 없음 (자동 호출)
 * 
 * 실행 시점:
 * ✅ 정적 멤버에 첫 접근 시
 * ✅ 인스턴스를 첫 생성 시
 * ✅ 정적 메서드를 첫 호출 시
 * 
 * 용도:
 * ✅ 정적 필드 초기화
 * ✅ 설정 파일 로드
 * ✅ 시스템 리소스 준비
 * ✅ 로깅 시스템 초기화
 * 
 * 🎯 3. 실제 활용 패턴
 * 
 * Counter 패턴:
 * - 전역 카운터와 개별 ID 관리
 * - 정적 변수로 공유 상태, 인스턴스 변수로 개별 상태
 * 
 * Library 패턴:
 * - 비즈니스 로직을 포함한 정적 클래스
 * - 상태 관리와 유효성 검사
 * - 실용적인 서비스 클래스 설계
 * 
 * Logger 패턴:
 * - 정적 생성자를 활용한 초기화
 * - 전역 로깅 시스템 구현
 * - 시스템 수준 서비스 제공
 * 
 * 🎯 4. 메모리와 성능 관점
 * 
 * 정적 멤버:
 * ✅ 메모리 효율적 (하나의 공간만 사용)
 * ✅ 빠른 접근 속도
 * ⚠️ 프로그램 종료까지 메모리 점유
 * ⚠️ 멀티스레드 환경에서 동기화 필요
 * 
 * 인스턴스 멤버:
 * ✅ 필요할 때만 메모리 할당
 * ✅ 객체별 독립성 보장
 * ⚠️ 객체 생성/소멸 오버헤드
 * ⚠️ 많은 객체 생성 시 메모리 사용량 증가
 * 
 * 🎯 5. 설계 원칙과 가이드라인
 * 
 * 정적 멤버를 사용하는 경우:
 * ✅ 상태가 없는 유틸리티 함수
 * ✅ 전역적으로 공유되어야 하는 데이터
 * ✅ 설정값이나 상수
 * ✅ 싱글톤 패턴 대신 사용할 수 있는 서비스
 * 
 * 인스턴스 멤버를 사용하는 경우:
 * ✅ 객체별로 다른 상태를 가져야 하는 경우
 * ✅ 객체 지향 설계 원칙을 따르는 경우
 * ✅ 테스트하기 쉬운 코드를 원하는 경우
 * ✅ 의존성 주입을 사용하는 경우
 * 
 * ============================================
 * 추가 학습 방향
 * ============================================
 * 
 * 🔗 연관 개념들:
 * - 싱글톤 디자인 패턴
 * - 의존성 주입 (Dependency Injection)
 * - 스레드 안전성 (Thread Safety)
 * - 가비지 컬렉션 (Garbage Collection)
 * - 메모리 관리 최적화
 * 
 * 🔗 실무 활용:
 * - 로깅 프레임워크 설계
 * - 설정 관리 시스템
 * - 캐싱 시스템 구현
 * - 유틸리티 라이브러리 개발
 * - API 서비스 클래스 설계
 */