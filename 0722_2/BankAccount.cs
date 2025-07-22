using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace _0722_2
{
    public class BankAccount
    {
        private string accountNumber;
        private decimal balance;
        private DateTime createDate;

        public BankAccount(string accountNumber, decimal balance, DateTime createDate)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.createDate = createDate;
        }

        // 읽기 전용 프로퍼티(get만 있음)
        public string AccountNumber
        {
            get { return accountNumber; }
        }
        public DateTime CreateDate
        {
            get { return  createDate; }
        }

        private string password;
        // 쓰기 전용 프로퍼티(set만 있음) - 거의 사용 하지 않습니다.
        public string Password
        {
            set { password = value; }
        }

        public decimal Balance
        { 
            get { return balance; }
            private set { balance = value; } // private set: 클래스 내부에서만 설정 가능
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount; // private set 사용
                Console.WriteLine($"{amount}원 입금 완료");
            }
        }

    }
}
