using System;

namespace _0724_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             ==========================================
             Part 1: 인터페이스와 다형성 예제
             ==========================================
             
             목적: 
             - 인터페이스를 통한 다중 기능 구현 확인
             - 다형성을 통한 일관된 처리 방식 학습
             - 런타임 타입 검사와 다운캐스팅 활용
             */

            // ========================================
            // 동물 객체 배열 생성 및 업캐스팅
            // ========================================

            /*
             * var 키워드 사용:
             * - 컴파일러가 우측 값을 보고 타입을 자동 추론
             * - 여기서는 Animal[] 타입으로 추론됨
             * - new Animal[] 대신 간결하게 작성 가능
             */
            var animals = new Animal[]
            {
                /*
                 * Bird 객체 생성과 업캐스팅:
                 * - new Bird {...} → Bird 타입 객체 생성
                 * - Animal[] 배열에 할당 → Bird를 Animal로 업캐스팅 (자동)
                 * - 객체 초기화자로 Name과 MaxAltitude 속성 설정
                 * - Bird는 IFlyable 인터페이스 구현
                 */
                new Bird { Name = "참새", MaxAltitude = 3000 },

                /*
                 * Fish 객체 생성과 업캐스팅:
                 * - Fish를 Animal로 업캐스팅
                 * - Fish는 ISwimmable 인터페이스 구현
                 * - MaxDepth 속성으로 최대 수영 깊이 설정
                 */
                new Fish { Name = "상어", MaxDepth = 200 },

                /*
                 * Duck 객체 생성과 업캐스팅:
                 * - Duck을 Animal로 업캐스팅
                 * - Duck은 IFlyable과 ISwimmable 모두 구현 (다중 인터페이스)
                 * - 날기와 수영 모두 가능한 특별한 동물
                 */
                new Duck { Name = "오리", MaxAltitude = 300, MaxDepth = 10 }
            };

            // ========================================
            // 다형성을 통한 공통 동작 수행
            // ========================================

            Console.WriteLine("=== 모든 동물의 이동 ===");

            /*
             * foreach 루프를 통한 배열 순회:
             * - animals 배열의 각 요소를 Animal 타입 변수 animal로 참조
             * - 실제 객체는 Bird, Fish, Duck이지만 Animal 타입으로 접근
             */
            foreach (Animal animal in animals)
            {
                /*
                 * animal.Move() 메서드 호출 시 다형성 동작:
                 * 
                 * 컴파일타임:
                 * 1. animal 변수의 타입 확인 → Animal
                 * 2. Animal 클래스에 Move() 메서드 존재 확인
                 * 3. 문법적으로 올바르므로 컴파일 성공
                 * 
                 * 런타임:
                 * 1. animal이 실제로 가리키는 객체의 타입 확인
                 * 2. Bird 객체라면 → Bird.Move() 실행
                 * 3. Fish 객체라면 → Fish.Move() 실행
                 * 4. Duck 객체라면 → Duck.Move() 실행
                 * 
                 * 결과: 같은 코드(animal.Move())이지만 각 동물의 고유한 이동 방식 실행
                 */
                animal.Move(); // 각 동물들의 고유한 이동 방식 실행
            }
            Console.WriteLine();

            // ========================================
            // 인터페이스 기반 선별적 기능 사용 - 날기
            // ========================================

            Console.WriteLine("=== 날 수 있는 동물들 ===");

            /*
             * 인터페이스를 통한 기능별 분류 처리:
             * - 모든 동물을 순회하면서 날 수 있는 동물만 선별
             * - 인터페이스 구현 여부에 따른 조건부 실행
             */
            foreach (Animal animal in animals)
            {
                /*
                 * 패턴 매칭을 사용한 인터페이스 다운캐스팅:
                 * 
                 * if (animal is IFlyable flyer) 분석:
                 * 1. animal 객체가 IFlyable 인터페이스를 구현했는지 런타임 검사
                 * 2. 구현했다면 해당 객체를 IFlyable 타입의 flyer 변수에 할당
                 * 3. if 블록 내에서 flyer 변수 사용 가능
                 * 
                 * 각 동물별 동작:
                 * - Bird(참새): IFlyable 구현 → 조건 true → flyer.Fly() 실행
                 * - Fish(상어): IFlyable 미구현 → 조건 false → 건너뜀
                 * - Duck(오리): IFlyable 구현 → 조건 true → flyer.Fly() 실행
                 * 
                 * 핵심: Animal 타입으로는 Fly() 메서드 접근 불가능하지만,
                 *       IFlyable로 다운캐스팅하면 Fly() 메서드 사용 가능
                 */
                if (animal is IFlyable flyer)
                {
                    flyer.Fly(); // IFlyable 인터페이스의 Fly() 메서드 호출
                }
            }
            Console.WriteLine();

            // ========================================
            // 인터페이스 기반 선별적 기능 사용 - 수영
            // ========================================

            Console.WriteLine("=== 헤엄 칠 수 있는 동물들 ===");

            /*
             * 수영 가능한 동물들 선별 및 처리:
             * - 위의 날기와 동일한 패턴
             * - ISwimmable 인터페이스 구현 여부 확인
             */
            foreach (Animal animal in animals)
            {
                /*
                 * ISwimmable 인터페이스 패턴 매칭:
                 * 
                 * 각 동물별 동작:
                 * - Bird(참새): ISwimmable 미구현 → 조건 false → 건너뜀
                 * - Fish(상어): ISwimmable 구현 → 조건 true → swimmer.Swim() 실행
                 * - Duck(오리): ISwimmable 구현 → 조건 true → swimmer.Swim() 실행
                 * 
                 * 주목할 점: Duck은 IFlyable과 ISwimmable 모두 구현하므로
                 * 위의 날기 섹션과 여기 수영 섹션 모두에서 동작함
                 */
                if (animal is ISwimmable swimmer)
                {
                    swimmer.Swim(); // ISwimmable 인터페이스의 Swim() 메서드 호출
                }
            }
            Console.WriteLine();

            /*
             ==========================================
             Part 2: 추상 클래스와 다형성 예제
             ==========================================
             
             목적:
             - 추상 클래스의 인스턴스 생성 제한 확인
             - 추상 클래스를 통한 다형성 구현
             - 추상 메서드와 가상 메서드의 동작 차이 학습
             */

            // ========================================
            // 추상 클래스 직접 생성 시도 (컴파일 에러)
            // ========================================

            /*
             * 추상 클래스 직접 인스턴스 생성 불가:
             * 
             * Shape shape = new Shape(); ← 이 코드는 컴파일 에러 발생!
             * 
             * 에러 이유:
             * 1. Shape는 abstract 키워드로 선언된 추상 클래스
             * 2. 추상 클래스는 완전하지 않은 클래스 (추상 메서드 포함)
             * 3. 따라서 직접 인스턴스 생성이 불가능
             * 4. 반드시 자식 클래스를 통해서만 사용 가능
             * 
             * 컴파일 에러 메시지:
             * "Cannot create an instance of the abstract class or interface 'Shape'"
             */
            // Shape shape = new Shape(); // ❌ 컴파일 에러! 추상 클래스는 직접 생성 불가

            // ========================================
            // 추상 클래스를 통한 다형성 구현
            // ========================================

            /*
             * 추상 클래스 기반 다형성 배열 생성:
             * - Shape는 추상 클래스이지만 '타입'으로는 사용 가능
             * - Circle과 Rectangle 객체들을 Shape 타입으로 업캐스팅하여 저장
             * - 배열 초기화자와 객체 초기화자를 조합하여 간결한 코드 작성
             */
            Shape[] shapes =
            {
                /*
                 * Circle 객체 생성 및 Shape로 업캐스팅:
                 * - new Circle {...} → Circle 타입 객체 생성
                 * - Shape[] 배열에 할당 → Circle을 Shape로 업캐스팅
                 * - Color는 Shape에서 상속받은 속성
                 * - Radius는 Circle 고유 속성
                 */
                new Circle { Color = "빨강", Radius = 5 },

                /*
                 * Rectangle 객체 생성 및 Shape로 업캐스팅:
                 * - Rectangle을 Shape로 업캐스팅
                 * - Width와 Height는 Rectangle 고유 속성
                 */
                new Rectangle { Color = "파랑", Width = 10, Height = 15 },

                /*
                 * 동일한 타입(Circle)의 다른 인스턴스:
                 * - 같은 Circle 클래스이지만 다른 속성값을 가진 객체
                 * - 배열에 동일한 타입의 여러 객체 저장 가능
                 */
                new Circle { Color = "노랑", Radius = 20 },
            };

            // ========================================
            // 추상 클래스 기반 다형성 동작 확인
            // ========================================

            Console.WriteLine("=== 도형 정보 출력 ===");

            /*
             * 추상 클래스를 통한 다형성 순회:
             * - shapes 배열의 각 요소는 Shape 타입으로 참조
             * - 실제 객체는 Circle 또는 Rectangle
             */
            foreach (Shape shape in shapes)
            {
                /*
                 * shape.Draw() 메서드 호출 시 다형성 동작:
                 * 
                 * Draw() 메서드 분석:
                 * - Shape 클래스에서 virtual로 선언됨
                 * - 기본 구현을 제공하면서도 자식에서 재정의 가능
                 * 
                 * 런타임 동작:
                 * 1. shape가 Circle 객체라면 → Circle.Draw() 실행
                 * 2. shape가 Rectangle 객체라면 → Rectangle.Draw() 실행
                 * 
                 * 각 도형별 출력:
                 * - Circle: "반지름 X인 원을 그립니다."
                 * - Rectangle: "가로 x 세로 직사각형을 그립니다."
                 */
                shape.Draw(); // 각 도형에 맞는 고유한 그리기 방식 실행

                /*
                 * shape.DisplayInfo() 메서드 호출:
                 * 
                 * DisplayInfo() 메서드 분석:
                 * - Shape 클래스에서 구현된 일반 메서드
                 * - 모든 자식 클래스가 동일하게 사용
                 * - 내부에서 추상 메서드들을 호출하여 실제 계산 수행
                 * 
                 * 내부 동작 과정:
                 * 1. Color 속성 출력 (이미 구현됨)
                 * 2. GetArea() 호출 → 자식 클래스의 구현된 메서드 실행
                 *    - Circle이면 → π × 반지름² 계산
                 *    - Rectangle이면 → 가로 × 세로 계산
                 * 3. GetPerimeter() 호출 → 자식 클래스의 구현된 메서드 실행
                 *    - Circle이면 → 2 × π × 반지름 계산
                 *    - Rectangle이면 → 2 × (가로 + 세로) 계산
                 * 
                 * 템플릿 메서드 패턴:
                 * - DisplayInfo()는 공통 구조를 제공
                 * - 내부에서 추상 메서드를 호출하여 구체적인 계산은 자식에게 위임
                 */
                shape.DisplayInfo(); // 공통 정보 출력 (색상, 넓이, 둘레)

                /*
                 * 빈 줄 출력:
                 * - 각 도형 정보를 구분하기 위한 가독성 향상
                 * - 출력 결과를 보기 좋게 정리
                 */
                Console.WriteLine();
            }

            /*
             ==========================================
             전체 코드에서 보여주는 핵심 개념들
             ==========================================
             
             1. 📊 다형성 (Polymorphism):
                - 같은 메서드 호출이 객체 타입에 따라 다르게 동작
                - animal.Move(), shape.Draw() 등에서 확인
             
             2. 🔌 인터페이스 (Interface):
                - 기능별 계약 정의 (IFlyable, ISwimmable)
                - 다중 구현 가능 (Duck이 두 인터페이스 모두 구현)
                - 선택적 기능 사용을 위한 패턴 매칭
             
             3. 🏗️ 추상 클래스 (Abstract Class):
                - 공통 기능 제공 + 강제 구현 (Shape)
                - 직접 인스턴스 생성 불가
                - 템플릿 메서드 패턴 구현
             
             4. ⬆️ 업캐스팅 (Upcasting):
                - 자식 → 부모 타입 변환 (자동, 안전)
                - 배열에 다양한 타입 저장 가능
             
             5. ⬇️ 다운캐스팅 (Downcasting):
                - 부모 → 자식/인터페이스 타입 변환
                - 패턴 매칭으로 안전하게 처리 (is 연산자)
             
             6. ⏰ 런타임 바인딩:
                - 컴파일타임에는 부모 타입으로 인식
                - 런타임에 실제 객체 타입 확인하여 적절한 메서드 호출
                - virtual/override, abstract/override에 의한 동적 메서드 디스패치
             
             7. 🎨 객체 초기화자:
                - new ClassName { Property = Value } 문법
                - 생성과 동시에 속성 설정
                - 코드 간결성과 가독성 향상
             */
        }
    }
}