using System;

namespace _0723
{
    /// <summary>
    /// Counter 클래스 - 정적 멤버와 인스턴스 멤버의 차이점을 보여주는 예제
    /// 
    /// 주요 학습 포인트:
    /// 1. static 키워드의 사용법과 의미
    /// 2. 정적 변수 vs 인스턴스 변수의 차이점
    /// 3. 정적 메서드 vs 인스턴스 메서드의 차이점
    /// 4. 모든 객체가 공유하는 데이터 관리 방법
    /// </summary>
    internal class Counter
    {
        // ============================================
        // 정적 멤버 (Static Members)
        // ============================================

        /// <summary>
        /// 정적 변수 (Static Variable)
        /// - 모든 Counter 객체가 공유하는 변수
        /// - 프로그램 실행 중 메모리에 하나만 존재
        /// - 클래스 이름으로 직접 접근 가능: Counter.count
        /// </summary>
        public static int count = 0;

        // ============================================
        // 인스턴스 멤버 (Instance Members)
        // ============================================

        /// <summary>
        /// 인스턴스 변수 (Instance Variable)
        /// - 각 Counter 객체마다 개별적으로 가지는 변수
        /// - 객체가 생성될 때마다 새로운 메모리 공간에 생성
        /// - 객체를 통해서만 접근 가능: counter1.instanceId
        /// </summary>
        private int instanceId;

        // ============================================
        // 생성자 (Constructor)
        // ============================================

        /// <summary>
        /// Counter 객체 생성자
        /// - 객체가 생성될 때마다 자동으로 호출
        /// - 정적 변수 count를 증가시켜 전체 생성된 객체 수를 추적
        /// - 현재 count 값을 instanceId로 설정하여 객체에 고유 번호 부여
        /// </summary>
        public Counter()
        {
            count++;                    // 정적 변수 증가 (모든 객체가 공유)
            instanceId = count;         // 현재 count 값을 이 객체의 ID로 설정

            Console.WriteLine($"Counter 객체 생성됨 - ID: {instanceId}, 총 생성된 객체 수: {count}");
        }

        // ============================================
        // 정적 메서드들 (Static Methods)
        // ============================================

        /// <summary>
        /// 카운트 증가 메서드 (정적)
        /// - 객체 생성 없이 Counter.Increment()로 호출 가능
        /// - 정적 변수 count만 조작 가능 (인스턴스 변수 접근 불가)
        /// </summary>
        public static void Increment()
        {
            count++;
            Console.WriteLine($"Count 증가: {count}");
        }

        /// <summary>
        /// 카운트 감소 메서드 (정적)
        /// - 객체 생성 없이 Counter.Decrement()로 호출 가능
        /// - 정적 변수 count만 조작 가능
        /// </summary>
        public static void Decrement()
        {
            if (count > 0)  // 음수 방지
            {
                count--;
                Console.WriteLine($"Count 감소: {count}");
            }
            else
            {
                Console.WriteLine("Count는 0 이하로 감소할 수 없습니다.");
            }
        }

        /// <summary>
        /// 현재 카운트 출력 메서드 (정적)
        /// - 객체 생성 없이 Counter.ShowInfo()로 호출 가능
        /// - 현재 정적 변수 count의 값만 출력
        /// </summary>
        public static void ShowInfo()
        {
            Console.WriteLine($"현재 카운트: {count}");
        }

        // ============================================
        // 인스턴스 메서드 (Instance Method)
        // ============================================

        /// <summary>
        /// 객체별 정보 출력 메서드 (인스턴스)
        /// - 반드시 객체를 생성한 후 호출해야 함: counter1.Show()
        /// - 인스턴스 변수(instanceId)와 정적 변수(count) 모두 접근 가능
        /// - 각 객체의 고유 ID와 현재 전체 카운트를 함께 출력
        /// </summary>
        public void Show()
        {
            Console.WriteLine($"객체 ID: {instanceId}, 현재 전체 카운트: {count}");
        }

        // ============================================
        // 추가 유틸리티 메서드
        // ============================================

        /// <summary>
        /// 카운트 초기화 메서드 (정적)
        /// - 전체 카운트를 0으로 리셋
        /// </summary>
        public static void Reset()
        {
            count = 0;
            Console.WriteLine("카운트가 0으로 초기화되었습니다.");
        }

        /// <summary>
        /// 현재 객체의 ID 반환 (인스턴스)
        /// </summary>
        public int GetInstanceId()
        {
            return instanceId;
        }
    }
}

/*
 * ============================================
 * 사용 예제 및 결과 예측
 * ============================================
 * 
 * // 정적 메서드 사용 (객체 생성 없이)
 * Counter.Increment();     // Count 증가: 1
 * Counter.Increment();     // Count 증가: 2  
 * Counter.ShowInfo();      // 현재 카운트: 2
 * Counter.Decrement();     // Count 감소: 1
 * 
 * // 객체 생성 및 인스턴스 메서드 사용
 * Counter c1 = new Counter();  // Counter 객체 생성됨 - ID: 2, 총 생성된 객체 수: 2
 * Counter c2 = new Counter();  // Counter 객체 생성됨 - ID: 3, 총 생성된 객체 수: 3
 * Counter c3 = new Counter();  // Counter 객체 생성됨 - ID: 4, 총 생성된 객체 수: 4
 * 
 * c1.Show();  // 객체 ID: 2, 현재 전체 카운트: 4
 * c2.Show();  // 객체 ID: 3, 현재 전체 카운트: 4  
 * c3.Show();  // 객체 ID: 4, 현재 전체 카운트: 4
 * 
 * ============================================
 * 핵심 개념 정리
 * ============================================
 * 
 * 1. 정적 변수 (static int count)
 *    - 모든 객체가 공유하는 하나의 메모리 공간
 *    - 클래스 레벨에서 관리됨
 *    - 프로그램 종료까지 유지됨
 * 
 * 2. 인스턴스 변수 (int instanceId)  
 *    - 각 객체마다 개별적으로 가지는 변수
 *    - 객체가 소멸되면 함께 소멸됨
 * 
 * 3. 정적 메서드 (static void Increment())
 *    - 객체 생성 없이 클래스 이름으로 호출
 *    - 정적 멤버만 접근 가능 (인스턴스 멤버 접근 불가)
 * 
 * 4. 인스턴스 메서드 (void Show())
 *    - 반드시 객체를 통해 호출해야 함
 *    - 정적 멤버와 인스턴스 멤버 모두 접근 가능
 */