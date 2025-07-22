using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0722_2
{
    // 프로퍼티(Property)
    // 프로퍼티는 필드에 대한 접근을 제어하는 특별한 메서드
    // 외부에서는 필드처럼 보이지만, 내부에서는 메서드로 동작합니다.

    // 왜 사용하는가?
    // 데이터 보호 : 잘못된 값이 들어오는것을 방지
    // 유효성 검사 : 값을 설정할때 조건 검사
    // 계산된 값 : 다른 필드들을 기반으로 값을 계산
    // 캡슐화 : 내부 구현을 숨기면서 안전한 접근 제공

    public class Person
    {
        private string name;
        private int age;

        // Name 프로퍼티
        public string Name
        {
            // 값을 읽을 때 호출
            get
            {
                return name;
            }
            // 값을 설정할 때 호출
            set
            {
                name = value;
            }
        }
        // Age 프로퍼티
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 0 && value < 120)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine($"나이는 1 ~ 120 사이의 값이어야 합니다.");
                }
            }
        }
    }
}
