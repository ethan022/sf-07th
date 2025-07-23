using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0723
{
    // 정적 생성자
    // 클래스가 처음! 사용될 때 자동으로 한번만 실행 되는 특별한 메서드
    // internal = public 현재 프로젝트 에서만 
    internal class Logger
    {
        private static string log;

        // 정적 생성자 
        static Logger()
        {
            log = $"log_{ DateTime.Now:yyyyMMdd}.txt";
            Console.WriteLine("Logger 시스템이 초기화 되었습니다.");
        }

        public static void WriteLog(string message)
        {
            Console.WriteLine($"[LOG] {message}");
        }
    }
}
