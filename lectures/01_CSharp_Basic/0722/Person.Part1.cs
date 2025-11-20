using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0722
{
    /// <summary>
    /// 사람을 나타내는 클래스 (Partial 클래스의 첫 번째 부분)
    /// 생성자 오버로딩과 소멸자를 포함합니다.
    /// partial 키워드를 사용하여 클래스를 여러 파일로 분할할 수 있습니다.
    /// </summary>
    public partial class Person
    {
        // 📌 public 필드 - 외부에서 직접 접근 가능
        // 일반적으로는 private으로 하고 프로퍼티를 사용하는 것이 권장되지만,
        // 예제의 단순화를 위해 public으로 선언되었습니다.
        public string name;  // 이름
        public int age;      // 나이

        // 📌 생성자 오버로딩 (Constructor Overloading)
        // 같은 클래스에서 매개변수가 다른 여러 개의 생성자를 정의할 수 있습니다.
        // 객체 생성 시 전달하는 인수에 따라 적절한 생성자가 자동으로 선택됩니다.

        /// <summary>
        /// 기본 생성자 - 매개변수가 없는 생성자
        /// 기본값으로 "홍길동", 20세로 초기화합니다.
        /// </summary>
        public Person()
        {
            this.name = "홍길동";  // 기본 이름 설정
            this.age = 20;        // 기본 나이 설정
            Console.WriteLine("첫번째 생성자 - 기본값으로 초기화");
        }

        /// <summary>
        /// 이름만 받는 생성자
        /// 이름은 매개변수로 받고, 나이는 기본값 34로 설정합니다.
        /// </summary>
        /// <param name="name">설정할 이름</param>
        public Person(string name)
        {
            this.name = name;     // 전달받은 이름으로 설정
            this.age = 34;        // 기본 나이 34로 설정
            Console.WriteLine("두번째 이름 생성자 - 이름만 초기화");
        }

        /// <summary>
        /// 나이만 받는 생성자
        /// 나이는 매개변수로 받고, 이름은 기본값 "마크"로 설정합니다.
        /// </summary>
        /// <param name="age">설정할 나이</param>
        public Person(int age)
        {
            this.name = "마크";   // 기본 이름 "마크"로 설정
            this.age = age;      // 전달받은 나이로 설정
            Console.WriteLine("세번째 나이 생성자 - 나이만 초기화");
        }

        /// <summary>
        /// 이름과 나이를 모두 받는 생성자
        /// 가장 완전한 형태의 생성자로, 모든 필드를 매개변수로 초기화합니다.
        /// </summary>
        /// <param name="name">설정할 이름</param>
        /// <param name="age">설정할 나이</param>
        public Person(string name, int age)
        {
            this.name = name;    // 전달받은 이름으로 설정
            this.age = age;      // 전달받은 나이로 설정
            Console.WriteLine("네번째 이름 나이 생성자 - 모든 값 초기화");
        }

        // 📌 소멸자(Destructor/Finalizer)
        // ~클래스명() 형태로 정의하며, 객체가 메모리에서 해제될 때 호출됩니다.
        // .NET의 가비지 컬렉터에 의해 자동으로 호출되므로 직접 호출할 수 없습니다.
        // 일반적으로 관리되지 않는 리소스(파일, 네트워크 연결 등)를 정리할 때 사용합니다.
        ~Person()
        {
            Console.WriteLine($"소멸자 호출 - {name} 객체가 메모리에서 해제됨");
        }

        // 📌 정보 출력 메서드
        /// <summary>
        /// 현재 Person 객체의 이름과 나이 정보를 콘솔에 출력합니다.
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"이름: {name}, 나이: {age}");
        }
    }
}