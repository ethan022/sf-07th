using System;

namespace _07222
{
    /// <summary>
    /// BankAccount 클래스 - 특수 프로퍼티 접근 제한자 학습
    /// 
    /// 학습 포인트:
    /// 1. 읽기 전용 프로퍼티 (get만 있는 프로퍼티)
    /// 2. 쓰기 전용 프로퍼티 (set만 있는 프로퍼티) - 거의 사용하지 않음
    /// 3. private set 프로퍼티 (클래스 내부에서만 설정 가능)
    /// 4. 은행 계좌의 보안을 고려한 프로퍼티 설계
    /// </summary>
    public class BankAccount
    {
        // ============================================
        // private 필드들 (실제 데이터 저장소)
        // ============================================

        private string accountNumber;  // 계좌번호
        private decimal balance;       // 잔액 (decimal: 정확한 소수점 계산용)
        private DateTime createDate;   // 계좌 개설일
        private string password;       // 비밀번호

        // ============================================
        // 생성자 (Constructor)
        // ============================================

        /// <summary>
        /// BankAccount 생성자 - 계좌 개설 시 필수 정보 설정
        /// </summary>
        /// <param name="accountNumber">계좌번호</param>
        /// <param name="balance">초기 잔액</param>
        /// <param name="createDate">계좌 개설일</param>
        public BankAccount(string accountNumber, decimal balance, DateTime createDate)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.createDate = createDate;
        }

        // ============================================
        // 읽기 전용 프로퍼티들 (get만 있음)
        // ============================================

        /// <summary>
        /// 계좌번호 - 읽기 전용 프로퍼티
        /// 
        /// 특징:
        /// - get만 있어서 외부에서 값 변경 불가
        /// - 계좌번호는 한 번 설정되면 변경되지 않아야 하는 중요한 정보
        /// - 생성자에서만 private 필드에 값 설정
        /// </summary>
        public string AccountNumber
        {
            get { return accountNumber; }
        }

        /// <summary>
        /// 계좌 개설일 - 읽기 전용 프로퍼티
        /// 
        /// 특징:
        /// - get만 있어서 외부에서 값 변경 불가
        /// - 개설일은 변경되지 않아야 하는 고정 정보
        /// </summary>
        public DateTime CreateDate
        {
            get { return createDate; }
        }

        // ============================================
        // 쓰기 전용 프로퍼티 (set만 있음) - 거의 사용하지 않음
        // ============================================

        /// <summary>
        /// 비밀번호 - 쓰기 전용 프로퍼티
        /// 
        /// 특징:
        /// - set만 있어서 값을 설정만 할 수 있고 읽을 수는 없음
        /// - 보안상 비밀번호를 외부에서 읽을 수 없게 함
        /// - 실제로는 거의 사용하지 않는 패턴 (보안 문제)
        /// </summary>
        public string Password
        {
            set { password = value; }
        }

        // ============================================
        // private set 프로퍼티 (클래스 내부에서만 설정 가능)
        // ============================================

        /// <summary>
        /// 잔액 - private set이 있는 프로퍼티
        /// 
        /// 특징:
        /// - get: 외부에서 잔액 조회 가능
        /// - private set: 클래스 내부에서만 값 변경 가능
        /// - 외부에서 직접 잔액을 변경할 수 없음 (보안)
        /// - Deposit, Withdraw 같은 메서드를 통해서만 변경 가능
        /// </summary>
        public decimal Balance
        {
            get { return balance; }
            private set { balance = value; }  // private set: 클래스 내부에서만 설정 가능
        }

        // ============================================
        // 메서드들 (Methods)
        // ============================================

        /// <summary>
        /// 입금 메서드 - Balance의 private set을 사용하여 잔액 증가
        /// </summary>
        /// <param name="amount">입금할 금액</param>
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;  // private set 사용하여 잔액 증가
                Console.WriteLine($"{amount}원 입금 완료");
            }
            else
            {
                Console.WriteLine("입금액은 0보다 커야 합니다.");
            }
        }

        /// <summary>
        /// 출금 메서드 - Balance의 private set을 사용하여 잔액 감소
        /// </summary>
        /// <param name="amount">출금할 금액</param>
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;  // private set 사용하여 잔액 감소
                Console.WriteLine($"{amount}원 출금 완료");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("잔액이 부족합니다.");
            }
            else
            {
                Console.WriteLine("출금액은 0보다 커야 합니다.");
            }
        }

        /// <summary>
        /// 계좌 정보를 출력하는 메서드
        /// </summary>
        public void ShowAccountInfo()
        {
            Console.WriteLine("=== 계좌 정보 ===");
            Console.WriteLine($"계좌번호: {AccountNumber}");
            Console.WriteLine($"잔액: {Balance:C}");  // :C는 통화 형식으로 출력
            Console.WriteLine($"개설일: {CreateDate:yyyy-MM-dd}");
        }
    }
}

/*
 * ============================================
 * 사용 예제
 * ============================================
 * 
 * // 계좌 생성
 * BankAccount account = new BankAccount("123-456-789", 10000, DateTime.Now);
 * 
 * // 계좌 정보 조회 (읽기 전용 프로퍼티)
 * Console.WriteLine($"계좌번호: {account.AccountNumber}");  // 가능: get만 있음
 * Console.WriteLine($"잔액: {account.Balance}");           // 가능: public get
 * 
 * // 잘못된 사용 예제들
 * // account.AccountNumber = "999-999-999";  // 컴파일 오류: set이 없음
 * // account.Balance = 50000;                // 컴파일 오류: private set
 * 
 * // 올바른 사용 예제들
 * account.Password = "1234";     // 가능: set만 있음 (하지만 읽을 수는 없음)
 * account.Deposit(5000);         // 가능: 메서드를 통한 잔액 변경
 * account.Withdraw(2000);        // 가능: 메서드를 통한 잔액 변경
 * 
 * account.ShowAccountInfo();
 * 
 * ============================================
 * 프로퍼티 접근 제한자 패턴 정리
 * ============================================
 * 
 * 1. 읽기 전용 프로퍼티 (get만):
 *    public string AccountNumber { get { return accountNumber; } }
 *    - 외부에서 읽기만 가능, 변경 불가
 *    - 고유 식별자, 생성 시간 등에 사용
 * 
 * 2. 쓰기 전용 프로퍼티 (set만) - 거의 사용 안 함:
 *    public string Password { set { password = value; } }
 *    - 외부에서 설정만 가능, 읽기 불가
 *    - 보안상 문제가 있어 실무에서는 거의 사용하지 않음
 * 
 * 3. private set 프로퍼티:
 *    public decimal Balance { get; private set; }
 *    - 외부에서 읽기는 가능, 클래스 내부에서만 변경 가능
 *    - 제어된 방식으로만 값 변경을 허용할 때 사용
 * 
 * 4. 완전 공개 프로퍼티:
 *    public string Name { get; set; }
 *    - 외부에서 읽기/쓰기 모두 가능
 *    - 제한이 필요 없는 일반적인 데이터
 * 
 * ============================================
 * 은행 계좌 보안 설계 원칙
 * ============================================
 * 
 * 1. 계좌번호, 개설일 → 읽기 전용
 *    - 한 번 설정되면 변경되지 않아야 하는 중요 정보
 * 
 * 2. 잔액 → private set
 *    - 조회는 가능하지만 직접 변경은 불가
 *    - 입금/출금 메서드를 통해서만 변경
 * 
 * 3. 비밀번호 → 쓰기 전용 (이론상)
 *    - 설정은 가능하지만 읽기는 불가
 *    - 실제로는 더 복잡한 보안 처리 필요
 * 
 * 이런 설계를 통해 데이터의 무결성과 보안을 보장할 수 있습니다.
 */