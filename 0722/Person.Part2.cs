using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0722
{
    /// <summary>
    /// Person 클래스의 두 번째 부분 (Partial 클래스)
    /// partial 키워드를 사용하여 하나의 클래스를 여러 파일로 나누어 작성할 수 있습니다.
    /// 
    /// Partial 클래스의 특징:
    /// 1. 같은 네임스페이스와 같은 클래스명을 가져야 합니다.
    /// 2. 모든 부분이 같은 어셈블리에 있어야 합니다.
    /// 3. 컴파일 시점에 하나의 클래스로 합쳐집니다.
    /// 4. 코드 구조화, 팀 작업 분할, 코드 생성기와의 협업에 유용합니다.
    /// </summary>
    public partial class Person
    {
        // 📌 추가 메서드 - 객체 생성 후 정보를 변경하는 기능
        /// <summary>
        /// 기존 Person 객체의 이름과 나이를 새로운 값으로 설정합니다.
        /// 객체 생성 후에도 정보를 업데이트할 수 있는 기능을 제공합니다.
        /// </summary>
        /// <param name="name">새로 설정할 이름</param>
        /// <param name="age">새로 설정할 나이</param>
        public void SetInfo(string name, int age)
        {
            // 📌 유효성 검사 (개선된 버전)
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("경고: 이름이 비어있거나 공백입니다. 기본값을 사용합니다.");
                this.name = "Unknown";
            }
            else
            {
                this.name = name;
            }

            if (age < 0 || age > 150)
            {
                Console.WriteLine("경고: 유효하지 않은 나이입니다. 기본값 0을 사용합니다.");
                this.age = 0;
            }
            else
            {
                this.age = age;
            }

            Console.WriteLine($"정보 업데이트 완료: {this.name}, {this.age}세");
        }

        // 📌 추가 유틸리티 메서드들
        /// <summary>
        /// 현재 Person이 성인인지 확인합니다.
        /// </summary>
        /// <returns>만 18세 이상이면 true, 미만이면 false</returns>
        public bool IsAdult()
        {
            return age >= 18;
        }

        /// <summary>
        /// 나이 그룹을 반환합니다.
        /// </summary>
        /// <returns>나이 그룹을 나타내는 문자열</returns>
        public string GetAgeGroup()
        {
            if (age < 13) return "어린이";
            else if (age < 20) return "청소년";
            else if (age < 65) return "성인";
            else return "시니어";
        }

        /// <summary>
        /// Person 객체의 상세 정보를 출력합니다.
        /// 기본 PrintInfo()보다 더 많은 정보를 제공합니다.
        /// </summary>
        public void PrintDetailedInfo()
        {
            Console.WriteLine("═══════════════════════════════");
            Console.WriteLine("        Person 상세 정보        ");
            Console.WriteLine("═══════════════════════════════");
            Console.WriteLine($"이름: {name}");
            Console.WriteLine($"나이: {age}세");
            Console.WriteLine($"성인 여부: {(IsAdult() ? "성인" : "미성년자")}");
            Console.WriteLine($"연령대: {GetAgeGroup()}");
            Console.WriteLine("═══════════════════════════════");
        }
    }
}