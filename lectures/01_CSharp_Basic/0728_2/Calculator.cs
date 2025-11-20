// 제네릭 계산기 - 완전 개선 버전
// 
// 🎯 제네릭 제약 조건 (Generic Constraints)
// - where T : struct   → T는 값 타입만 가능 (int, double, float 등)
// - where T : class    → T는 참조 타입만 가능 (string, object 등)
// - where T : new()    → T는 기본 생성자가 있는 타입만 가능
// - where T : BaseClass → T는 특정 클래스를 상속받은 타입만 가능
// - where T : IInterface → T는 특정 인터페이스를 구현한 타입만 가능

using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCalculatorGuide
{
    #region 1. 기본 제네릭 계산기 (원본 코드 개선)

    /// <summary>
    /// 기본 제네릭 계산기 클래스
    /// where T : struct → T는 값 타입만 허용 (int, double, float, decimal 등)
    /// </summary>
    /// <typeparam name="T">계산할 값의 타입 (값 타입만 허용)</typeparam>
    internal class BasicCalculator<T> where T : struct
    {
        #region 프로퍼티 설명

        /// <summary>
        /// 첫 번째 값
        /// 프로퍼티: 내부적으로 private T _firstValue 필드가 자동 생성됨
        /// get: 값을 반환하는 접근자
        /// set: 값을 설정하는 접근자
        /// </summary>
        public T FirstValue { get; set; }

        /// <summary>
        /// 두 번째 값
        /// </summary>
        public T SecondValue { get; set; }

        #endregion

        #region 생성자

        /// <summary>
        /// 기본 생성자
        /// </summary>
        public BasicCalculator()
        {
            FirstValue = default(T);  // T 타입의 기본값 (int면 0, double이면 0.0)
            SecondValue = default(T);
        }

        /// <summary>
        /// 값을 초기화하는 생성자
        /// </summary>
        /// <param name="first">첫 번째 값</param>
        /// <param name="second">두 번째 값</param>
        public BasicCalculator(T first, T second)
        {
            FirstValue = first;
            SecondValue = second;
        }

        #endregion

        #region 연산 메서드들 (Dynamic 사용)

        /// <summary>
        /// 덧셈 연산
        /// dynamic 사용: 런타임에 + 연산자 지원 여부 확인
        /// </summary>
        /// <returns>두 값의 합</returns>
        public T Add()
        {
            try
            {
                // dynamic으로 변환: 런타임에 타입 결정
                dynamic first = FirstValue;
                dynamic second = SecondValue;

                Console.WriteLine($"[Add] {first} + {second} 계산 중...");

                // 런타임에 + 연산자가 지원되는지 확인하고 실행
                dynamic result = first + second;

                return (T)result;  // 결과를 T 타입으로 변환
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Add] 오류 발생: {ex.Message}");
                throw; // 예외를 다시 던짐
            }
        }

        /// <summary>
        /// 곱셈 연산
        /// </summary>
        /// <returns>두 값의 곱</returns>
        public T Multiply()
        {
            try
            {
                dynamic first = FirstValue;
                dynamic second = SecondValue;

                Console.WriteLine($"[Multiply] {first} × {second} 계산 중...");

                dynamic result = first * second;
                return (T)result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Multiply] 오류 발생: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// 나눗셈 연산
        /// </summary>
        /// <returns>두 값의 나눗셈 결과</returns>
        public T Divide()
        {
            try
            {
                dynamic first = FirstValue;
                dynamic second = SecondValue;

                Console.WriteLine($"[Divide] {first} ÷ {second} 계산 중...");

                // 0으로 나누기 체크
                if (second.Equals(default(T)))
                {
                    throw new DivideByZeroException("0으로 나눌 수 없습니다.");
                }

                dynamic result = first / second;
                return (T)result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Divide] 오류 발생: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// 최대값 구하기
        /// </summary>
        /// <returns>두 값 중 큰 값</returns>
        public T GetMax()
        {
            try
            {
                dynamic first = FirstValue;
                dynamic second = SecondValue;

                Console.WriteLine($"[GetMax] {first}와 {second} 중 최대값 찾는 중...");

                // 비교 연산자를 사용하여 큰 값 반환
                if (first > second)
                {
                    Console.WriteLine($"[GetMax] {first}가 더 큽니다.");
                    return (T)first;
                }
                else
                {
                    Console.WriteLine($"[GetMax] {second}가 더 크거나 같습니다.");
                    return (T)second;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetMax] 오류 발생: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// 최소값 구하기
        /// </summary>
        /// <returns>두 값 중 작은 값</returns>
        public T GetMin()
        {
            try
            {
                dynamic first = FirstValue;
                dynamic second = SecondValue;

                Console.WriteLine($"[GetMin] {first}와 {second} 중 최소값 찾는 중...");

                if (first < second)
                {
                    Console.WriteLine($"[GetMin] {first}가 더 작습니다.");
                    return (T)first;
                }
                else
                {
                    Console.WriteLine($"[GetMin] {second}가 더 작거나 같습니다.");
                    return (T)second;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetMin] 오류 발생: {ex.Message}");
                throw;
            }
        }

        #endregion

        #region 유틸리티 메서드

        /// <summary>
        /// 두 값을 모두 설정
        /// </summary>
        public void SetValues(T first, T second)
        {
            FirstValue = first;
            SecondValue = second;
            Console.WriteLine($"[SetValues] 값 설정: {first}, {second}");
        }

        /// <summary>
        /// 현재 값들을 출력
        /// </summary>
        public void DisplayValues()
        {
            Console.WriteLine($"[DisplayValues] 첫 번째 값: {FirstValue} (타입: {typeof(T).Name})");
            Console.WriteLine($"[DisplayValues] 두 번째 값: {SecondValue} (타입: {typeof(T).Name})");
        }

        /// <summary>
        /// 모든 기본 연산 결과를 출력
        /// </summary>
        public void ShowAllOperations()
        {
            Console.WriteLine($"\n=== {typeof(T).Name} 타입 계산기 결과 ===");
            DisplayValues();

            try
            {
                Console.WriteLine($"덧셈: {Add()}");
                Console.WriteLine($"곱셈: {Multiply()}");
                Console.WriteLine($"나눗셈: {Divide()}");
                Console.WriteLine($"최대값: {GetMax()}");
                Console.WriteLine($"최소값: {GetMin()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"연산 중 오류: {ex.Message}");
            }
        }

        #endregion
    }

    #endregion

    #region 2. 고급 제네릭 계산기 (IComparable 제약 사용)

    /// <summary>
    /// 고급 제네릭 계산기 - IComparable 제약 사용
    /// where T : struct, IComparable<T>
    /// → T는 값 타입이면서 비교 가능한 타입만 허용
    /// </summary>
    /// <typeparam name="T">비교 가능한 값 타입</typeparam>
    internal class AdvancedCalculator<T> where T : struct, IComparable<T>
    {
        public T FirstValue { get; set; }
        public T SecondValue { get; set; }

        public AdvancedCalculator(T first, T second)
        {
            FirstValue = first;
            SecondValue = second;
        }

        /// <summary>
        /// 안전한 최대값 구하기 (IComparable 사용)
        /// dynamic 없이 타입 안전하게 비교
        /// </summary>
        public T GetMaxSafe()
        {
            Console.WriteLine($"[안전한 비교] {FirstValue}와 {SecondValue} 비교 중...");

            // IComparable<T>.CompareTo 메서드 사용
            // 반환값: 0보다 크면 첫 번째가 큼, 0이면 같음, 0보다 작으면 두 번째가 큼
            int comparison = FirstValue.CompareTo(SecondValue);

            if (comparison > 0)
            {
                Console.WriteLine($"[안전한 비교] {FirstValue}가 더 큽니다.");
                return FirstValue;
            }
            else
            {
                Console.WriteLine($"[안전한 비교] {SecondValue}가 더 크거나 같습니다.");
                return SecondValue;
            }
        }

        /// <summary>
        /// 안전한 최소값 구하기
        /// </summary>
        public T GetMinSafe()
        {
            Console.WriteLine($"[안전한 비교] {FirstValue}와 {SecondValue} 비교 중...");

            int comparison = FirstValue.CompareTo(SecondValue);

            if (comparison < 0)
            {
                Console.WriteLine($"[안전한 비교] {FirstValue}가 더 작습니다.");
                return FirstValue;
            }
            else
            {
                Console.WriteLine($"[안전한 비교] {SecondValue}가 더 작거나 같습니다.");
                return SecondValue;
            }
        }

        /// <summary>
        /// 두 값이 같은지 확인
        /// </summary>
        public bool AreEqual()
        {
            bool result = FirstValue.CompareTo(SecondValue) == 0;
            Console.WriteLine($"[같은지 확인] {FirstValue} == {SecondValue}: {result}");
            return result;
        }
    }

    #endregion

    #region 3. 특수 제약 조건 예제들

    /// <summary>
    /// 참조 타입만 허용하는 컨테이너
    /// where T : class → 참조 타입만 (string, object, 사용자 정의 클래스 등)
    /// </summary>
    internal class ReferenceTypeContainer<T> where T : class
    {
        public T Value { get; set; }

        public bool IsNull()
        {
            bool result = Value == null;
            Console.WriteLine($"[Null 체크] 값이 null인가? {result}");
            return result;
        }

        public void SetToNull()
        {
            Value = null;
            Console.WriteLine("[SetToNull] 값을 null로 설정했습니다.");
        }
    }

    /// <summary>
    /// 기본 생성자가 있는 타입만 허용
    /// where T : new() → 매개변수 없는 생성자가 있는 타입만
    /// </summary>
    internal class Factory<T> where T : new()
    {
        /// <summary>
        /// 새 인스턴스 생성
        /// </summary>
        public T CreateInstance()
        {
            T instance = new T();  // new() 제약 덕분에 가능
            Console.WriteLine($"[Factory] {typeof(T).Name} 타입의 새 인스턴스 생성");
            return instance;
        }

        /// <summary>
        /// 여러 개 인스턴스 생성
        /// </summary>
        public T[] CreateInstances(int count)
        {
            T[] instances = new T[count];
            for (int i = 0; i < count; i++)
            {
                instances[i] = new T();
            }
            Console.WriteLine($"[Factory] {typeof(T).Name} 타입의 인스턴스 {count}개 생성");
            return instances;
        }
    }

    #endregion

    #region 4. 테스트용 클래스들

    /// <summary>
    /// 테스트용 간단한 클래스 (기본 생성자 있음)
    /// </summary>
    public class TestClass
    {
        public string Name { get; set; } = "기본 이름";
        public int Value { get; set; } = 0;

        public override string ToString()
        {
            return $"TestClass(Name: {Name}, Value: {Value})";
        }
    }

    #endregion

    #region 5. 메인 프로그램

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🎯 제네릭 계산기 완전 가이드 🎯\n");

            // 1. 기본 제네릭 계산기 테스트
            TestBasicCalculator();

            // 2. 고급 제네릭 계산기 테스트
            TestAdvancedCalculator();

            // 3. 제약 조건별 테스트
            TestConstraints();

            // 4. 다양한 타입으로 테스트
            TestDifferentTypes();

            Console.WriteLine("\n🎉 모든 테스트 완료!");
        }

        /// <summary>
        /// 기본 제네릭 계산기 테스트
        /// </summary>
        static void TestBasicCalculator()
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("1. 기본 제네릭 계산기 테스트");
            Console.WriteLine(new string('=', 50));

            // int 타입 계산기
            Console.WriteLine("\n🔸 int 타입 계산기:");
            var intCalc = new BasicCalculator<int>(10, 3);
            intCalc.ShowAllOperations();

            // double 타입 계산기
            Console.WriteLine("\n🔸 double 타입 계산기:");
            var doubleCalc = new BasicCalculator<double>(15.5, 4.2);
            doubleCalc.ShowAllOperations();

            // 값 변경해서 다시 테스트
            Console.WriteLine("\n🔸 값 변경 후 테스트:");
            intCalc.SetValues(100, 25);
            intCalc.ShowAllOperations();
        }

        /// <summary>
        /// 고급 제네릭 계산기 테스트
        /// </summary>
        static void TestAdvancedCalculator()
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("2. 고급 제네릭 계산기 테스트 (IComparable 제약)");
            Console.WriteLine(new string('=', 50));

            // 안전한 비교 연산
            Console.WriteLine("\n🔸 안전한 비교 연산:");
            var advancedCalc = new AdvancedCalculator<int>(45, 32);
            //advancedCalc.DisplayValues();

            Console.WriteLine($"최대값: {advancedCalc.GetMaxSafe()}");
            Console.WriteLine($"최소값: {advancedCalc.GetMinSafe()}");
            Console.WriteLine($"같은 값인가? {advancedCalc.AreEqual()}");

            // DateTime으로 테스트
            Console.WriteLine("\n🔸 DateTime 비교:");
            var dateCalc = new AdvancedCalculator<DateTime>(
                new DateTime(2024, 1, 1),
                new DateTime(2024, 12, 31)
            );

            Console.WriteLine($"첫 번째 날짜: {dateCalc.FirstValue:yyyy-MM-dd}");
            Console.WriteLine($"두 번째 날짜: {dateCalc.SecondValue:yyyy-MM-dd}");
            Console.WriteLine($"더 늦은 날짜: {dateCalc.GetMaxSafe():yyyy-MM-dd}");
        }

        /// <summary>
        /// 제약 조건별 테스트
        /// </summary>
        static void TestConstraints()
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("3. 제약 조건별 테스트");
            Console.WriteLine(new string('=', 50));

            // 참조 타입 컨테이너 테스트
            Console.WriteLine("\n🔸 참조 타입 컨테이너 (where T : class):");
            var stringContainer = new ReferenceTypeContainer<string>();
            stringContainer.Value = "안녕하세요";
            Console.WriteLine($"문자열 값: {stringContainer.Value}");
            Console.WriteLine($"null인가? {stringContainer.IsNull()}");

            stringContainer.SetToNull();
            Console.WriteLine($"null 설정 후: {stringContainer.IsNull()}");

            // Factory 테스트 (where T : new())
            Console.WriteLine("\n🔸 Factory (where T : new()):");
            var factory = new Factory<TestClass>();
            var instance = factory.CreateInstance();
            Console.WriteLine($"생성된 인스턴스: {instance}");

            var instances = factory.CreateInstances(3);
            Console.WriteLine($"생성된 인스턴스들: {instances.Length}개");
        }

        /// <summary>
        /// 다양한 타입으로 테스트
        /// </summary>
        static void TestDifferentTypes()
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("4. 다양한 타입으로 테스트");
            Console.WriteLine(new string('=', 50));

            // decimal 타입 (정밀한 소수점 계산)
            Console.WriteLine("\n🔸 decimal 타입 (금융 계산):");
            var decimalCalc = new BasicCalculator<decimal>(1000.50m, 250.25m);
            decimalCalc.ShowAllOperations();

            // float 타입
            Console.WriteLine("\n🔸 float 타입:");
            var floatCalc = new BasicCalculator<float>(3.14f, 2.71f);
            floatCalc.ShowAllOperations();

            // byte 타입 (작은 정수)
            Console.WriteLine("\n🔸 byte 타입:");
            var byteCalc = new BasicCalculator<byte>(100, 50);
            byteCalc.ShowAllOperations();

            // 오버플로우 테스트
            Console.WriteLine("\n🔸 오버플로우 테스트:");
            try
            {
                var overflowCalc = new BasicCalculator<byte>(200, 200);
                overflowCalc.ShowAllOperations();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오버플로우 오류: {ex.Message}");
            }
        }
    }

    #endregion
}

// 📚 학습 포인트 정리:
//
// 1. 제네릭 제약 조건 (Generic Constraints):
//    - where T : struct     → 값 타입만
//    - where T : class      → 참조 타입만  
//    - where T : new()      → 기본 생성자 있는 타입만
//    - where T : BaseClass  → 특정 클래스 상속받은 타입만
//    - where T : IInterface → 특정 인터페이스 구현한 타입만
//
// 2. Dynamic의 장단점:
//    ✅ 장점: 컴파일 타임에 지원하지 않는 연산도 런타임에 실행 가능
//    ❌ 단점: 런타임 에러 위험성, 성능 저하, IntelliSense 지원 제한
//
// 3. 프로퍼티 (Property):
//    - public T Value { get; set; }
//    - 내부적으로 private 필드 자동 생성
//    - get: 값 반환, set: 값 설정
//
// 4. 타입 안전성:
//    - IComparable<T> 제약으로 안전한 비교 연산
//    - Dynamic 대신 제약 조건 활용 권장