using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 ================================================================================================
 인터페이스 (Interface) 개념 정리
 ================================================================================================
 
 📚 인터페이스란?
 - 메서드의 선언만 포함하는 계약서 (Contract)
 - 구현 클래스는 모든 메서드를 반드시 구현해야 함
 - 다중 상속이 가능 (클래스는 하나만 상속, 인터페이스는 여러 개 구현)
 - 'I'로 시작하는 네이밍 컨벤션 (IFlyable, ISwimmable 등)
 
 🎯 인터페이스 특징:
 ✅ 메서드 선언만 포함 (구현 없음)
 ✅ 속성 선언 가능 (get/set 접근자)
 ✅ 모든 멤버는 public (접근 제한자 생략)
 ✅ 다중 구현 가능
 ✅ 다형성 지원
 
 🔍 언제 인터페이스를 사용하나?
 - 완전히 다른 클래스들이 같은 동작을 수행해야 할 때
 - 다중 상속이 필요할 때  
 - CAN-DO 관계 표현 (Bird는 날 수 있다, Fish는 수영할 수 있다)
 - 느슨한 결합(Loose Coupling) 구현
 
 ================================================================================================
 */

namespace _0724_2
{
    // ==========================================
    // 인터페이스 정의들
    // ==========================================

    /// <summary>
    /// IFlyable 인터페이스 - 날 수 있는 능력을 정의
    /// CAN-DO 관계: "날 수 있다"는 능력을 표현
    /// </summary>
    public interface IFlyable
    {
        /*
         * Fly() 메서드 선언:
         * - 메서드 시그니처만 정의 (구현 없음)
         * - 구현 클래스에서 반드시 구현해야 함
         * - public 접근 제한자 생략 (인터페이스는 모든 멤버가 public)
         */
        void Fly();

        /*
         * MaxAltitude 속성 선언:
         * - get 접근자만 선언 (읽기 전용)
         * - 구현 클래스에서 이 속성을 제공해야 함
         * - 최대 비행 고도를 나타내는 정보
         */
        int MaxAltitude { get; }
    }

    /// <summary>
    /// ISwimmable 인터페이스 - 수영할 수 있는 능력을 정의
    /// CAN-DO 관계: "수영할 수 있다"는 능력을 표현
    /// </summary>
    public interface ISwimmable
    {
        /*
         * Swim() 메서드 선언:
         * - 수영 동작을 정의하는 메서드
         * - 각 클래스에서 고유한 수영 방식을 구현
         */
        void Swim();

        /*
         * MaxDepth 속성 선언:
         * - 최대 수영 깊이를 나타내는 정보
         * - 읽기 전용 속성으로 선언
         */
        int MaxDepth { get; }
    }

    // ==========================================
    // 기본 클래스 - Animal
    // ==========================================

    /// <summary>
    /// Animal 기본 클래스 - 모든 동물의 공통 특성 정의
    /// IS-A 관계의 기반이 되는 클래스
    /// </summary>
    public class Animal
    {
        // 모든 동물이 가지는 공통 속성
        public string Name { get; set; }

        /*
         * Move() 가상 메서드:
         * - 기본 이동 방식을 정의
         * - virtual 키워드로 자식 클래스에서 재정의 가능
         * - 각 동물의 특성에 맞게 오버라이드됨
         */
        public virtual void Move()
        {
            Console.WriteLine($"{Name}이(가) 움직입니다.");
        }
    }

    // ==========================================
    // 구현 클래스 1 - Bird (새)
    // ==========================================

    /// <summary>
    /// Bird 클래스 - 날 수 있는 동물
    /// Animal 상속 + IFlyable 인터페이스 구현
    /// </summary>
    public class Bird : Animal, IFlyable
    {
        /*
         * MaxAltitude 속성 구현:
         * - IFlyable 인터페이스의 MaxAltitude 속성 구현
         * - get과 set 모두 제공 (인터페이스는 get만 요구하지만 확장 가능)
         * - 새의 최대 비행 고도 저장
         */
        public int MaxAltitude { get; set; }

        /*
         * Fly() 메서드 구현:
         * - IFlyable 인터페이스의 Fly() 메서드 구현 (필수)
         * - 새의 고유한 날기 동작 정의
         * - Name과 MaxAltitude 정보를 포함한 출력
         */
        public void Fly()
        {
            Console.WriteLine($"{Name}이(가) 하늘을 날아갑니다! " +
                            $"(최대 고도: {MaxAltitude}m)");
        }

        /*
         * Move() 메서드 재정의:
         * - Animal의 가상 메서드를 오버라이드
         * - 새의 기본 이동 방식은 '날기'로 설정
         * - 내부적으로 Fly() 메서드 호출
         */
        public override void Move()
        {
            Fly(); // 새의 기본 이동 방식은 날기
        }
    }

    // ==========================================
    // 구현 클래스 2 - Fish (물고기)
    // ==========================================

    /// <summary>
    /// Fish 클래스 - 수영할 수 있는 동물
    /// Animal 상속 + ISwimmable 인터페이스 구현
    /// </summary>
    public class Fish : Animal, ISwimmable
    {
        /*
         * MaxDepth 속성 구현:
         * - ISwimmable 인터페이스의 MaxDepth 속성 구현
         * - 물고기의 최대 수영 깊이 저장
         */
        public int MaxDepth { get; set; }

        /*
         * Swim() 메서드 구현:
         * - ISwimmable 인터페이스의 Swim() 메서드 구현 (필수)
         * - 물고기의 고유한 수영 동작 정의
         * - Name과 MaxDepth 정보를 포함한 출력
         */
        public void Swim()
        {
            Console.WriteLine($"{Name}이(가) 물속을 헤엄칩니다! " +
                            $"(최대 깊이: {MaxDepth}m)");
        }

        /*
         * Move() 메서드 재정의:
         * - Animal의 가상 메서드를 오버라이드
         * - 물고기의 기본 이동 방식은 '수영'으로 설정
         * - 내부적으로 Swim() 메서드 호출
         */
        public override void Move()
        {
            Swim(); // 물고기의 기본 이동 방식은 수영
        }
    }

    // ==========================================
    // 구현 클래스 3 - Duck (오리) - 다중 인터페이스 구현
    // ==========================================

    /// <summary>
    /// Duck 클래스 - 날기와 수영 모두 가능한 동물
    /// Animal 상속 + IFlyable, ISwimmable 인터페이스 모두 구현
    /// 다중 인터페이스 구현의 대표적인 예
    /// </summary>
    public class Duck : Animal, IFlyable, ISwimmable
    {
        /*
         * 다중 인터페이스 구현을 위한 속성들:
         * - IFlyable.MaxAltitude와 ISwimmable.MaxDepth 모두 구현
         * - 두 인터페이스의 모든 요구사항을 충족
         */
        public int MaxAltitude { get; set; }  // IFlyable 인터페이스 요구사항
        public int MaxDepth { get; set; }     // ISwimmable 인터페이스 요구사항

        /*
         * Fly() 메서드 구현:
         * - IFlyable 인터페이스의 Fly() 메서드 구현
         * - 오리의 고유한 날기 동작 정의
         * - Bird와 유사하지만 독립적인 구현
         */
        public void Fly()
        {
            Console.WriteLine($"{Name}이(가) 하늘을 날아갑니다! " +
                            $"(최대 고도: {MaxAltitude}m)");
        }

        /*
         * Swim() 메서드 구현:
         * - ISwimmable 인터페이스의 Swim() 메서드 구현
         * - 오리의 고유한 수영 동작 정의
         * - Fish와 유사하지만 독립적인 구현
         */
        public void Swim()
        {
            Console.WriteLine($"{Name}이(가) 물속을 헤엄칩니다! " +
                            $"(최대 깊이: {MaxDepth}m)");
        }

        /*
         * Move() 메서드 재정의:
         * - Animal의 가상 메서드를 오버라이드
         * - 오리의 특별한 점: 날기와 수영을 모두 수행
         * - 다중 능력을 가진 동물의 이동 방식 표현
         */
        public override void Move()
        {
            /*
             * 오리의 복합 이동:
             * 1. 먼저 날기 동작 수행
             * 2. 이어서 수영 동작 수행
             * 3. 두 능력을 모두 활용하는 특별한 이동 방식
             */
            Fly();   // 첫 번째 능력: 날기
            Swim();  // 두 번째 능력: 수영
        }
    }

    /*
     ================================================================================================
     다중 인터페이스 구현의 장점과 활용
     ================================================================================================
     
     🎯 Duck 클래스의 특별한 점:
     1. 다중 능력: 날기와 수영 모두 가능
     2. 유연한 활용: IFlyable 또는 ISwimmable 타입으로 모두 사용 가능
     3. 확장성: 새로운 인터페이스 추가 시 쉽게 확장 가능
     
     💡 실제 사용 예시:
     Duck duck = new Duck();
     IFlyable flyer = duck;    // Duck을 IFlyable로 참조
     ISwimmable swimmer = duck; // 같은 Duck을 ISwimmable로 참조
     Animal animal = duck;      // 같은 Duck을 Animal로 참조
     
     🔄 다형성 활용:
     - 날 수 있는 동물들만 모아서 처리: IFlyable[] flyers
     - 수영할 수 있는 동물들만 모아서 처리: ISwimmable[] swimmers
     - 모든 동물을 공통으로 처리: Animal[] animals
     
     🏗️ 아키텍처 관점:
     - 느슨한 결합(Loose Coupling) 구현
     - 의존성 역전 원칙(DIP) 적용
     - 개방-폐쇄 원칙(OCP) 준수
     
     ================================================================================================
     */
}