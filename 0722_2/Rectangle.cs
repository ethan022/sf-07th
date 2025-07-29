using System;

namespace _07222
{
    /// <summary>
    /// Rectangle 클래스 - 자동 프로퍼티와 계산된 프로퍼티 학습
    /// 
    /// 학습 포인트:
    /// 1. 자동 구현 프로퍼티 (Auto-Implemented Property)
    /// 2. 초기값이 있는 자동 프로퍼티
    /// 3. 계산된 프로퍼티 (Computed Property)
    /// 4. 읽기 전용 프로퍼티
    /// </summary>
    public class Rectangle
    {
        // ============================================
        // 자동 구현 프로퍼티 (Auto-Implemented Properties)
        // ============================================

        /// <summary>
        /// 가로 길이 - 자동 구현 프로퍼티 (초기값 포함)
        /// 
        /// 특징:
        /// - 컴파일러가 자동으로 private 필드를 생성
        /// - get과 set을 직접 구현할 필요 없음
        /// - = 22로 초기값 설정
        /// </summary>
        public double Width { get; set; } = 22;

        /// <summary>
        /// 세로 길이 - 자동 구현 프로퍼티 (초기값 포함)
        /// 
        /// 특징:
        /// - 컴파일러가 자동으로 private 필드를 생성
        /// - get과 set을 직접 구현할 필요 없음
        /// - = 10으로 초기값 설정
        /// </summary>
        public double Height { get; set; } = 10;

        // ============================================
        // 계산된 프로퍼티 (Computed Properties)
        // ============================================

        /// <summary>
        /// 넓이 - 계산된 프로퍼티 (읽기 전용)
        /// 
        /// 특징:
        /// - 저장되지 않고 매번 계산됨
        /// - get만 있음 (읽기 전용)
        /// - Width와 Height를 사용해서 계산
        /// </summary>
        public double Area
        {
            get { return Width * Height; }
        }

        /// <summary>
        /// 둘레 - 계산된 프로퍼티 (읽기 전용)
        /// 
        /// 특징:
        /// - 저장되지 않고 매번 계산됨
        /// - get만 있음 (읽기 전용)  
        /// - Width와 Height를 사용해서 계산
        /// </summary>
        public double Perimeter
        {
            get { return 2 * (Width + Height); }
        }

        // ============================================
        // 생성자 (Constructor) - 주석 처리된 예제
        // ============================================

        // 만약 생성자를 사용한다면 이렇게 작성할 수 있음
        // public Rectangle(double width, double height)
        // {
        //     Width = width;   // 프로퍼티의 set 호출
        //     Height = height; // 프로퍼티의 set 호출
        // }

        // ============================================
        // 메서드 (Methods)
        // ============================================

        /// <summary>
        /// 사각형의 모든 정보를 출력하는 메서드
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine($"가로: {Width}, 세로: {Height}");
            Console.WriteLine($"넓이: {Area}");       // Area 프로퍼티의 get 호출
            Console.WriteLine($"둘레: {Perimeter}");  // Perimeter 프로퍼티의 get 호출
        }
    }
}

/*
 * ============================================
 * 사용 예제
 * ============================================
 * 
 * Rectangle rc = new Rectangle();
 * // 초기값: Width = 22, Height = 10
 * 
 * rc.ShowInfo();
 * // 출력: 가로: 22, 세로: 10
 * //      넓이: 220
 * //      둘레: 64
 * 
 * // 값 변경
 * rc.Width = 5;
 * rc.Height = 3;
 * 
 * rc.ShowInfo();
 * // 출력: 가로: 5, 세로: 3
 * //      넓이: 15    (자동으로 다시 계산됨)
 * //      둘레: 16    (자동으로 다시 계산됨)
 * 
 * ============================================
 * 프로퍼티 종류별 특징
 * ============================================
 * 
 * 1. 자동 구현 프로퍼티:
 *    public double Width { get; set; } = 22;
 *    - 컴파일러가 private 필드 자동 생성
 *    - 간단한 get/set 로직일 때 사용
 *    - 초기값 설정 가능
 * 
 * 2. 계산된 프로퍼티:
 *    public double Area { get { return Width * Height; } }
 *    - 다른 프로퍼티 값을 기반으로 계산
 *    - 별도 저장 공간 없음
 *    - 매번 호출될 때마다 계산
 * 
 * 3. 읽기 전용 프로퍼티:
 *    - get만 있고 set이 없음
 *    - 외부에서 값 변경 불가
 *    - 계산된 프로퍼티는 보통 읽기 전용
 * 
 * ============================================
 * 메모리와 성능 관점
 * ============================================
 * 
 * 자동 프로퍼티 (Width, Height):
 * - 실제 메모리에 값 저장
 * - 빠른 접근 속도
 * 
 * 계산된 프로퍼티 (Area, Perimeter):
 * - 메모리에 값 저장 안 함
 * - 호출할 때마다 계산 (약간의 연산 비용)
 * - 항상 최신 값 보장
 */