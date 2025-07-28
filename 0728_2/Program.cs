// 제네릭(Generics) 기초 완전 이해
// 
// 🎯 제네릭이란?
// - 타입을 매개변수화하는 기능
// - 같은 코드로 여러 타입을 처리할 수 있음
// - 재사용성과 타입 안전성을 동시에 제공
//
// 🌟 일상 비유:
// - 만능 상자: 어떤 물건이든 담을 수 있는 상자
// - 주형(틀): 같은 모양으로 다양한 재료의 제품을 만들 수 있음
// - 템플릿: 양식은 같지만 내용을 다르게 채울 수 있음

using System;

namespace GenericsBasicGuide
{
    #region 1. 문제 상황 - 제네릭이 없다면?

    // ❌ 문제: 타입별로 똑같은 코드를 계속 만들어야 함!

    /// <summary>
    /// 정수만 저장할 수 있는 컨테이너
    /// </summary>
    public class IntContainer
    {
        private int value;

        public void SetValue(int value)
        {
            this.value = value;
            Console.WriteLine($"[정수 컨테이너] {value} 저장됨");
        }

        public int GetValue()
        {
            Console.WriteLine($"[정수 컨테이너] {value} 반환");
            return this.value;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"[정수 컨테이너] 타입: {value.GetType().Name}, 값: {value}");
        }
    }

    /// <summary>
    /// 문자열만 저장할 수 있는 컨테이너 - 똑같은 코드의 반복!
    /// </summary>
    public class StringContainer
    {
        private string value;

        public void SetValue(string value)
        {
            this.value = value;
            Console.WriteLine($"[문자열 컨테이너] {value} 저장됨");
        }

        public string GetValue()
        {
            Console.WriteLine($"[문자열 컨테이너] {value} 반환");
            return this.value;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"[문자열 컨테이너] 타입: {value?.GetType().Name}, 값: {value}");
        }
    }

    /// <summary>
    /// 불리언만 저장할 수 있는 컨테이너 - 또 똑같은 코드!
    /// </summary>
    public class BoolContainer
    {
        private bool value;

        public void SetValue(bool value)
        {
            this.value = value;
            Console.WriteLine($"[불리언 컨테이너] {value} 저장됨");
        }

        public bool GetValue()
        {
            Console.WriteLine($"[불리언 컨테이너] {value} 반환");
            return this.value;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"[불리언 컨테이너] 타입: {value.GetType().Name}, 값: {value}");
        }
    }

    // 😱 이런 식으로 계속 만들어야 함:
    // - FloatContainer
    // - DoubleContainer
    // - DateTimeContainer
    // - CharContainer
    // - PersonContainer
    // ... 끝이 없음!

    #endregion

    #region 2. 해결책 - 제네릭!

    /// <summary>
    /// ✅ 해결책: 제네릭 컨테이너
    /// T는 "Type Parameter" - 나중에 실제 타입으로 바뀔 자리표시자
    /// </summary>
    /// <typeparam name="T">저장할 데이터의 타입</typeparam>
    public class Container<T>
    {
        private T value;

        /// <summary>
        /// 값을 저장합니다
        /// </summary>
        public void SetValue(T value)
        {
            this.value = value;
            Console.WriteLine($"[제네릭 컨테이너<{typeof(T).Name}>] {value} 저장됨");
        }

        /// <summary>
        /// 저장된 값을 반환합니다
        /// </summary>
        public T GetValue()
        {
            Console.WriteLine($"[제네릭 컨테이너<{typeof(T).Name}>] {value} 반환");
            return this.value;
        }

        /// <summary>
        /// 저장된 값의 정보를 출력합니다
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine($"[제네릭 컨테이너<{typeof(T).Name}>] 타입: {typeof(T).Name}, 값: {value}");
        }

        /// <summary>
        /// 컨테이너가 비어있는지 확인
        /// </summary>
        public bool IsEmpty()
        {
            // default(T)는 타입 T의 기본값 (int면 0, string이면 null, bool이면 false 등)
            return value == null || value.Equals(default(T));
        }

        /// <summary>
        /// 컨테이너를 비웁니다
        /// </summary>
        public void Clear()
        {
            value = default(T);
            Console.WriteLine($"[제네릭 컨테이너<{typeof(T).Name}>] 컨테이너가 비워졌습니다");
        }
    }

    #endregion

    #region 3. 여러 타입 매개변수

    /// <summary>
    /// 두 개의 서로 다른 타입을 저장하는 Pair 클래스
    /// T: 첫 번째 값의 타입
    /// U: 두 번째 값의 타입
    /// </summary>
    public class Pair<T, U>
    {
        public T First { get; set; }
        public U Second { get; set; }

        /// <summary>
        /// Pair 생성자
        /// </summary>
        public Pair(T first, U second)
        {
            First = first;
            Second = second;
        }

        /// <summary>
        /// 저장된 값들을 출력합니다
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"Pair<{typeof(T).Name}, {typeof(U).Name}>");
            Console.WriteLine($"  첫 번째 ({typeof(T).Name}): {First}");
            Console.WriteLine($"  두 번째 ({typeof(U).Name}): {Second}");
        }

        /// <summary>
        /// 첫 번째 값을 업데이트
        /// </summary>
        public void UpdateFirst(T newValue)
        {
            First = newValue;
            Console.WriteLine($"첫 번째 값이 {newValue}로 업데이트되었습니다");
        }

        /// <summary>
        /// 두 번째 값을 업데이트
        /// </summary>
        public void UpdateSecond(U newValue)
        {
            Second = newValue;
            Console.WriteLine($"두 번째 값이 {newValue}로 업데이트되었습니다");
        }
    }

    #endregion

    #region 4. 제네릭 메서드

    /// <summary>
    /// 제네릭 메서드들을 포함하는 도구 클래스
    /// </summary>
    public static class GenericTools
    {
        /// <summary>
        /// 두 값을 교환하는 제네릭 메서드
        /// </summary>
        /// <typeparam name="T">교환할 값들의 타입</typeparam>
        public static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine($"교환 전: a={a}, b={b}");
            T temp = a;
            a = b;
            b = temp;
            Console.WriteLine($"교환 후: a={a}, b={b}");
        }

        /// <summary>
        /// 두 값이 같은지 비교하는 제네릭 메서드
        /// </summary>
        public static bool AreEqual<T>(T value1, T value2)
        {
            bool result = value1.Equals(value2);
            Console.WriteLine($"{value1}과(와) {value2}가 같은가? {result}");
            return result;
        }

        /// <summary>
        /// 값을 복사하는 제네릭 메서드
        /// </summary>
        public static T Copy<T>(T original)
        {
            Console.WriteLine($"{typeof(T).Name} 타입의 값 {original}을(를) 복사합니다");
            return original; // 값 타입은 자동으로 복사됨
        }

        /// <summary>
        /// 기본값을 반환하는 제네릭 메서드
        /// </summary>
        public static T GetDefaultValue<T>()
        {
            T defaultValue = default(T);
            Console.WriteLine($"{typeof(T).Name} 타입의 기본값: {defaultValue}");
            return defaultValue;
        }
    }

    #endregion

    #region 5. Object vs 제네릭 비교

    /// <summary>
    /// Object를 사용한 범용 컨테이너 (구식 방법)
    /// </summary>
    public class ObjectContainer
    {
        private object value;

        public void SetValue(object value)
        {
            this.value = value;
            Console.WriteLine($"[Object 컨테이너] {value} 저장 (실제 타입: {value?.GetType().Name})");
        }

        public object GetValue()
        {
            Console.WriteLine($"[Object 컨테이너] {value} 반환");
            return this.value;
        }
    }

    #endregion

    #region 6. 실전 예제 클래스들

    /// <summary>
    /// 간단한 학생 클래스 (제네릭 테스트용)
    /// </summary>
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"학생: {Name}({Age}세)";
        }
    }

    /// <summary>
    /// 성적을 저장하는 제네릭 클래스
    /// </summary>
    public class Score<T>
    {
        public string Subject { get; set; }  // 과목
        public T Value { get; set; }         // 점수 (int, double, string 등 가능)

        public Score(string subject, T value)
        {
            Subject = subject;
            Value = value;
        }

        public void DisplayScore()
        {
            Console.WriteLine($"{Subject} 점수: {Value} (타입: {typeof(T).Name})");
        }
    }

    #endregion

    #region 7. 메인 프로그램

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🎯 제네릭 기초 완전 마스터 🎯\n");

            // 1. 기본 제네릭 컨테이너 사용
            Console.WriteLine("=== 1. 기본 제네릭 컨테이너 ===");
            DemoBasicContainers();

            // 2. Pair 클래스 활용
            Console.WriteLine("\n=== 2. Pair 클래스 활용 ===");
            DemoPairClass();

            // 3. 제네릭 메서드 활용
            Console.WriteLine("\n=== 3. 제네릭 메서드 활용 ===");
            DemoGenericMethods();

            // 4. Object vs 제네릭 비교
            Console.WriteLine("\n=== 4. Object vs 제네릭 비교 ===");
            DemoObjectVsGenerics();

            // 5. 실전 예제
            Console.WriteLine("\n=== 5. 실전 예제 ===");
            DemoRealWorldExamples();

            // 6. Dynamic 위험성
            Console.WriteLine("\n=== 6. Dynamic의 위험성 ===");
            DemoDynamicIssues();
        }

        /// <summary>
        /// 기본 제네릭 컨테이너 사용 데모
        /// </summary>
        static void DemoBasicContainers()
        {
            // 정수 컨테이너
            Console.WriteLine("🔸 정수 컨테이너:");
            Container<int> intContainer = new Container<int>();
            intContainer.SetValue(42);
            int number = intContainer.GetValue();
            intContainer.ShowInfo();
            Console.WriteLine($"비어있나? {intContainer.IsEmpty()}");

            // 문자열 컨테이너
            Console.WriteLine("\n🔸 문자열 컨테이너:");
            Container<string> stringContainer = new Container<string>();
            stringContainer.SetValue("안녕하세요!");
            string text = stringContainer.GetValue();
            stringContainer.ShowInfo();

            // 불리언 컨테이너
            Console.WriteLine("\n🔸 불리언 컨테이너:");
            Container<bool> boolContainer = new Container<bool>();
            boolContainer.SetValue(true);
            bool flag = boolContainer.GetValue();
            boolContainer.ShowInfo();

            // 실수 컨테이너
            Console.WriteLine("\n🔸 실수 컨테이너:");
            Container<double> doubleContainer = new Container<double>();
            doubleContainer.SetValue(3.14159);
            double pi = doubleContainer.GetValue();
            doubleContainer.ShowInfo();

            // 컨테이너 비우기
            Console.WriteLine("\n🔸 컨테이너 비우기:");
            intContainer.Clear();
            Console.WriteLine($"비우기 후 - 비어있나? {intContainer.IsEmpty()}");
        }

        /// <summary>
        /// Pair 클래스 활용 데모
        /// </summary>
        static void DemoPairClass()
        {
            // 이름과 나이
            Console.WriteLine("🔸 이름과 나이:");
            Pair<string, int> nameAge = new Pair<string, int>("김철수", 25);
            nameAge.Display();

            // 합격 여부와 점수
            Console.WriteLine("\n🔸 합격 여부와 점수:");
            Pair<bool, double> passScore = new Pair<bool, double>(true, 85.5);
            passScore.Display();

            // 좌표 (x, y)
            Console.WriteLine("\n🔸 좌표 (x, y):");
            Pair<int, int> coordinate = new Pair<int, int>(10, 20);
            coordinate.Display();

            // 값 업데이트
            Console.WriteLine("\n🔸 값 업데이트:");
            nameAge.UpdateFirst("이영희");
            nameAge.UpdateSecond(30);
            nameAge.Display();

            // 과목과 성적
            Console.WriteLine("\n🔸 과목과 성적:");
            Pair<string, char> subjectGrade = new Pair<string, char>("수학", 'A');
            subjectGrade.Display();
        }

        /// <summary>
        /// 제네릭 메서드 활용 데모
        /// </summary>
        static void DemoGenericMethods()
        {
            // 값 교환
            Console.WriteLine("🔸 정수 교환:");
            int a = 10, b = 20;
            GenericTools.Swap(ref a, ref b);

            Console.WriteLine("\n🔸 문자열 교환:");
            string x = "첫번째", y = "두번째";
            GenericTools.Swap(ref x, ref y);

            // 값 비교
            Console.WriteLine("\n🔸 값 비교:");
            GenericTools.AreEqual(10, 10);
            GenericTools.AreEqual("안녕", "안녕");
            GenericTools.AreEqual(true, false);

            // 값 복사
            Console.WriteLine("\n🔸 값 복사:");
            int originalInt = 100;
            int copiedInt = GenericTools.Copy(originalInt);

            string originalString = "원본 문자열";
            string copiedString = GenericTools.Copy(originalString);

            // 기본값 확인
            Console.WriteLine("\n🔸 타입별 기본값:");
            GenericTools.GetDefaultValue<int>();
            GenericTools.GetDefaultValue<string>();
            GenericTools.GetDefaultValue<bool>();
            GenericTools.GetDefaultValue<double>();
        }

        /// <summary>
        /// Object vs 제네릭 비교 데모
        /// </summary>
        static void DemoObjectVsGenerics()
        {
            Console.WriteLine("❌ Object 방식의 문제점:");

            // Object 컨테이너 사용
            ObjectContainer objectContainer = new ObjectContainer();
            objectContainer.SetValue(42);

            // 문제 1: 타입 정보 손실
            object retrievedValue = objectContainer.GetValue();
            Console.WriteLine($"반환된 값: {retrievedValue} (타입: {retrievedValue.GetType().Name})");

            // 문제 2: 캐스팅 필요 + 런타임 에러 위험
            try
            {
                // 올바른 캐스팅
                int correctValue = (int)retrievedValue;
                Console.WriteLine($"올바른 캐스팅: {correctValue}");

                // 잘못된 캐스팅 시도
                string wrongValue = (string)retrievedValue; // 💥 런타임 에러!
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"캐스팅 에러: {ex.Message}");
            }

            Console.WriteLine("\n✅ 제네릭 방식의 장점:");

            // 제네릭 컨테이너 사용
            Container<int> genericContainer = new Container<int>();
            genericContainer.SetValue(42);

            // 장점 1: 타입 안전성
            int safeValue = genericContainer.GetValue(); // 자동으로 올바른 타입!
            Console.WriteLine($"안전한 값 반환: {safeValue}");

            // 장점 2: 컴파일 타임 타입 체크
            // genericContainer.SetValue("문자열"); // 컴파일 에러! 미리 방지됨
            Console.WriteLine("컴파일 타임에 타입 체크로 에러 방지!");
        }

        /// <summary>
        /// 실전 예제 데모
        /// </summary>
        static void DemoRealWorldExamples()
        {
            // 학생 정보 관리
            Console.WriteLine("🔸 학생 정보 관리:");
            Student student = new Student("김철수", 20);
            Container<Student> studentContainer = new Container<Student>();
            studentContainer.SetValue(student);
            Student retrievedStudent = studentContainer.GetValue();
            Console.WriteLine($"저장된 학생: {retrievedStudent}");

            // 다양한 타입의 성적 관리
            Console.WriteLine("\n🔸 다양한 타입의 성적:");

            // 숫자 점수
            Score<int> mathScore = new Score<int>("수학", 95);
            mathScore.DisplayScore();

            // 실수 점수
            Score<double> englishScore = new Score<double>("영어", 87.5);
            englishScore.DisplayScore();

            // 등급 점수
            Score<char> scienceScore = new Score<char>("과학", 'A');
            scienceScore.DisplayScore();

            // 합격/불합격
            Score<bool> passFailScore = new Score<bool>("체육", true);
            passFailScore.DisplayScore();

            // 복잡한 데이터 구조
            Console.WriteLine("\n🔸 복잡한 데이터 구조:");
            Pair<Student, Score<int>> studentScore = new Pair<Student, Score<int>>(
                new Student("이영희", 22),
                new Score<int>("프로그래밍", 98)
            );

            Console.WriteLine("학생과 성적 정보:");
            Console.WriteLine($"  학생: {studentScore.First}");
            Console.Write("  ");
            studentScore.Second.DisplayScore();
        }

        /// <summary>
        /// Dynamic의 위험성 데모
        /// </summary>
        static void DemoDynamicIssues()
        {
            Console.WriteLine("⚠️ Dynamic 사용 시 주의사항:");

            // Dynamic의 편리함
            Console.WriteLine("\n✅ Dynamic의 편리한 점:");
            dynamic value1 = 10;
            dynamic value2 = 20;
            dynamic result = value1 + value2; // 편리함!
            Console.WriteLine($"Dynamic 연산: {value1} + {value2} = {result}");

            dynamic str1 = "안녕";
            dynamic str2 = "하세요";
            dynamic strResult = str1 + str2;
            Console.WriteLine($"Dynamic 문자열: {str1} + {str2} = {strResult}");

            // Dynamic의 위험성
            Console.WriteLine("\n❌ Dynamic의 위험한 점:");
            try
            {
                dynamic num = 10;
                dynamic text = "문자열";
                // 이 코드는 컴파일은 되지만 런타임에 에러!
                dynamic dangerousResult = num - text; // 💥 런타임 에러!
                Console.WriteLine($"위험한 연산: {dangerousResult}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Runtime 에러 발생: {ex.GetType().Name}");
                Console.WriteLine($"에러 메시지: {ex.Message}");
            }

            // 비교: 제네릭의 안전성
            Console.WriteLine("\n✅ 제네릭의 안전성:");
            Container<int> safeContainer = new Container<int>();
            safeContainer.SetValue(10);
            // safeContainer.SetValue("문자열"); // 컴파일 에러로 미리 방지!

            int safeResult = safeContainer.GetValue(); // 타입 안전!
            Console.WriteLine($"안전한 값: {safeResult}");
            Console.WriteLine("컴파일 타임에 모든 타입 에러를 미리 잡아냄!");
        }
    }

    #endregion
}