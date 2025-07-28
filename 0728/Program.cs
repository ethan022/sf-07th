// 델리게이트(Delegate) 완전 초보자 가이드
// 
// 🎯 델리게이트란?
// - 메서드를 가리키는 "포인터" 또는 "리모컨"
// - 메서드를 변수처럼 저장하고 전달할 수 있게 해주는 기능
//
// 🌟 일상생활 비유:
// - 리모컨: 버튼을 누르면 지정된 TV 기능이 실행됨
// - 전화번호부: 이름을 누르면 해당 번호로 전화가 걸림
// - 스위치: 스위치를 누르면 연결된 전등이 켜짐
// - 대리인: "이 일은 김 과장에게 맡겨주세요"

using System;

namespace DelegateBeginnersGuide
{
    internal class Program
    {
        #region 1. 델리게이트 타입 정의

        /// <summary>
        /// 델리게이트 타입 선언: 메서드의 "형태(틀)"를 정의
        /// 이것은 "int를 두 개 받아서 int를 반환하는 메서드"의 틀
        /// </summary>
        /// <param name="a">첫 번째 정수</param>
        /// <param name="b">두 번째 정수</param>
        /// <returns>계산 결과</returns>
        delegate int Calculate(int a, int b);
        //         ↑     ↑         ↑
        //     반환타입  이름     매개변수

        // 🔍 이해하기 쉬운 설명:
        // Calculate는 "계산기 리모컨"의 규격을 정의한 것!
        // "정수 2개를 받아서 정수 1개를 돌려주는 버튼"이라는 규격

        #endregion

        #region 2. 델리게이트가 가리킬 수 있는 메서드들

        /// <summary>
        /// 덧셈 메서드 - Calculate 델리게이트와 형태가 일치함
        /// </summary>
        static int Add(int x, int y)
        {
            int result = x + y;
            Console.WriteLine($"🔸 Add 함수 실행: {x} + {y} = {result}");
            return result;
        }

        /// <summary>
        /// 뺄셈 메서드 - Calculate 델리게이트와 형태가 일치함
        /// </summary>
        static int Subtract(int x, int y)
        {
            int result = x - y;
            Console.WriteLine($"🔸 Subtract 함수 실행: {x} - {y} = {result}");
            return result;
        }

        /// <summary>
        /// 곱셈 메서드 - Calculate 델리게이트와 형태가 일치함
        /// </summary>
        static int Multiply(int x, int y)
        {
            int result = x * y;
            Console.WriteLine($"🔸 Multiply 함수 실행: {x} × {y} = {result}");
            return result;
        }

        /// <summary>
        /// 나눗셈 메서드 - 추가 예제
        /// </summary>
        static int Divide(int x, int y)
        {
            if (y == 0)
            {
                Console.WriteLine("🔸 Divide 함수: 0으로 나눌 수 없습니다!");
                return 0;
            }
            int result = x / y;
            Console.WriteLine($"🔸 Divide 함수 실행: {x} ÷ {y} = {result}");
            return result;
        }

        /// <summary>
        /// 거듭제곱 메서드 - 추가 예제
        /// </summary>
        static int Power(int x, int y)
        {
            int result = 1;
            for (int i = 0; i < y; i++)
            {
                result *= x;
            }
            Console.WriteLine($"🔸 Power 함수 실행: {x}^{y} = {result}");
            return result;
        }

        #endregion

        #region 3. 메인 프로그램

        static void Main(string[] args)
        {
            Console.WriteLine("🎯 델리게이트 완전 초보자 가이드 🎯\n");

            // 기본 개념 설명
            ExplainDelegateBasics();

            // 1. 기본 델리게이트 사용법
            DemoBasicDelegateUsage();

            // 2. 멀티캐스트 델리게이트 (여러 메서드 연결)
            DemoMulticastDelegate();

            // 3. 델리게이트 추가/제거
            DemoAddRemoveMethods();

            // 4. 실전 예제
            //DemoRealWorldExample();

            Console.WriteLine("\n🎉 델리게이트 학습 완료!");
        }

        #endregion

        #region 4. 기본 개념 설명

        /// <summary>
        /// 델리게이트 기본 개념 설명
        /// </summary>
        static void ExplainDelegateBasics()
        {
            Console.WriteLine("📚 델리게이트란 무엇인가요?");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("🔹 델리게이트 = 메서드를 가리키는 '포인터' 또는 '리모컨'");
            Console.WriteLine("🔹 일반 변수는 '값'을 저장하지만, 델리게이트는 '메서드'를 저장");
            Console.WriteLine("🔹 리모컨 버튼을 누르면 연결된 기능이 실행되는 것과 같음");
            Console.WriteLine();

            Console.WriteLine("🎮 리모컨 비유:");
            Console.WriteLine("  - 리모컨(델리게이트): Calculate calc");
            Console.WriteLine("  - 전원 버튼: Add 메서드에 연결");
            Console.WriteLine("  - 볼륨 버튼: Subtract 메서드에 연결");
            Console.WriteLine("  - 채널 버튼: Multiply 메서드에 연결");
            Console.WriteLine("  → 버튼을 누르면 연결된 기능이 실행!");
            Console.WriteLine();
        }

        #endregion

        #region 5. 기본 델리게이트 사용법

        /// <summary>
        /// 기본 델리게이트 사용법 데모
        /// </summary>
        static void DemoBasicDelegateUsage()
        {
            Console.WriteLine("1️⃣ 기본 델리게이트 사용법");
            Console.WriteLine(new string('=', 50));

            // 1단계: 델리게이트 변수 생성
            Console.WriteLine("📝 1단계: 델리게이트 변수 생성");
            Calculate calc = null;  // 리모컨을 만들었지만 아직 아무것도 연결 안됨
            Console.WriteLine("   Calculate calc = null; (빈 리모컨 생성)");
            Console.WriteLine();

            // 2단계: 메서드 연결 (Add)
            Console.WriteLine("📝 2단계: Add 메서드 연결");
            calc = Add;  // 리모컨을 Add 메서드에 연결
            Console.WriteLine("   calc = Add; (리모컨을 Add 버튼에 연결)");
            Console.WriteLine("   → 이제 calc(5, 3)을 하면 Add(5, 3)이 실행됨");

            Console.WriteLine("\n🎬 실행 결과:");
            int result1 = calc(5, 3);  // Add 메서드가 실행됨
            Console.WriteLine($"   반환값: {result1}");
            Console.WriteLine();

            // 3단계: 다른 메서드로 변경 (Subtract)
            Console.WriteLine("📝 3단계: Subtract 메서드로 변경");
            calc = Subtract;  // 리모컨을 Subtract 메서드에 연결
            Console.WriteLine("   calc = Subtract; (리모컨을 Subtract 버튼으로 변경)");
            Console.WriteLine("   → 이제 calc(5, 3)을 하면 Subtract(5, 3)이 실행됨");

            Console.WriteLine("\n🎬 실행 결과:");
            int result2 = calc(5, 3);  // Subtract 메서드가 실행됨
            Console.WriteLine($"   반환값: {result2}");
            Console.WriteLine();

            // 4단계: 또 다른 메서드로 변경 (Multiply)
            Console.WriteLine("📝 4단계: Multiply 메서드로 변경");
            calc = Multiply;  // 리모컨을 Multiply 메서드에 연결
            Console.WriteLine("   calc = Multiply; (리모컨을 Multiply 버튼으로 변경)");

            Console.WriteLine("\n🎬 실행 결과:");
            int result3 = calc(5, 3);  // Multiply 메서드가 실행됨
            Console.WriteLine($"   반환값: {result3}");
            Console.WriteLine();

            Console.WriteLine("✨ 핵심 포인트:");
            Console.WriteLine("   같은 calc(5, 3) 호출이지만, 연결된 메서드에 따라 다른 결과!");
            Console.WriteLine("   이것이 델리게이트의 마법입니다! 🎭");
            Console.WriteLine();
        }

        #endregion

        #region 6. 멀티캐스트 델리게이트

        /// <summary>
        /// 멀티캐스트 델리게이트 데모 (여러 메서드를 한 번에 실행)
        /// </summary>
        static void DemoMulticastDelegate()
        {
            Console.WriteLine("2️⃣ 멀티캐스트 델리게이트 (여러 메서드 한 번에!)");
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("🎮 업그레이드된 리모컨 비유:");
            Console.WriteLine("   일반 리모컨: 한 번에 하나 기능만");
            Console.WriteLine("   스마트 리모컨: 한 번에 여러 기능 동시 실행!");
            Console.WriteLine("   예) '홈 모드' 버튼 → TV 켜기 + 조명 조절 + 에어컨 켜기");
            Console.WriteLine();

            // 빈 델리게이트부터 시작
            Console.WriteLine("📝 1단계: 빈 델리게이트 생성");
            Calculate multiCalc = null;
            Console.WriteLine("   Calculate multiCalc = null;");
            Console.WriteLine();

            // 메서드들을 하나씩 추가 (+= 연산자 사용)
            Console.WriteLine("📝 2단계: 메서드들을 하나씩 추가 (+= 연산자)");

            multiCalc += Add;       // Add 메서드 추가
            Console.WriteLine("   multiCalc += Add; (Add 기능 추가)");

            multiCalc += Subtract;  // Subtract 메서드 추가  
            Console.WriteLine("   multiCalc += Subtract; (Subtract 기능 추가)");

            multiCalc += Multiply;  // Multiply 메서드 추가
            Console.WriteLine("   multiCalc += Multiply; (Multiply 기능 추가)");
            Console.WriteLine();

            Console.WriteLine("📝 3단계: 현재 상태");
            Console.WriteLine("   multiCalc에는 이제 3개의 메서드가 연결됨:");
            Console.WriteLine("   [Add] → [Subtract] → [Multiply]");
            Console.WriteLine("   → multiCalc(5, 3) 호출 시 3개 메서드가 순서대로 모두 실행!");
            Console.WriteLine();

            // 한 번에 모든 메서드 실행
            Console.WriteLine("🎬 실행 결과: multiCalc(5, 3)");
            Console.WriteLine("   (3개 메서드가 모두 실행됩니다!)");
            Console.WriteLine();

            int finalResult = multiCalc(5, 3);  // 모든 메서드가 순서대로 실행됨
            Console.WriteLine();
            Console.WriteLine($"📊 최종 반환값: {finalResult}");
            Console.WriteLine("   (마지막에 실행된 Multiply의 결과)");
            Console.WriteLine();

            Console.WriteLine("✨ 핵심 포인트:");
            Console.WriteLine("   멀티캐스트 델리게이트는 마지막 메서드의 반환값만 받습니다!");
            Console.WriteLine("   하지만 모든 메서드가 실행되므로 각각의 작업은 모두 수행됩니다!");
            Console.WriteLine();
        }

        #endregion

        #region 7. 델리게이트 추가/제거

        /// <summary>
        /// 델리게이트에서 메서드 추가/제거 데모
        /// </summary>
        static void DemoAddRemoveMethods()
        {
            Console.WriteLine("3️⃣ 델리게이트 메서드 추가/제거하기");
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("🎮 리모컨 버튼 관리하기:");
            Console.WriteLine("   += : 새 기능 버튼 추가");
            Console.WriteLine("   -= : 기존 기능 버튼 제거");
            Console.WriteLine();

            // 여러 메서드가 연결된 델리게이트 생성
            Console.WriteLine("📝 1단계: 여러 메서드가 연결된 델리게이트 생성");
            Calculate calc = null;
            calc += Add;
            calc += Subtract;
            calc += Multiply;
            calc += Divide;

            Console.WriteLine("   현재 연결된 메서드들:");
            Console.WriteLine("   [Add] → [Subtract] → [Multiply] → [Divide]");
            Console.WriteLine();

            // 첫 번째 실행
            Console.WriteLine("🎬 첫 번째 실행: calc(10, 2)");
            Console.WriteLine("   (4개 메서드가 모두 실행됩니다!)");
            Console.WriteLine();
            calc(10, 2);
            Console.WriteLine();

            // Subtract 메서드 제거
            Console.WriteLine("📝 2단계: Subtract 메서드 제거 (-= 연산자)");
            calc -= Subtract;
            Console.WriteLine("   calc -= Subtract; (Subtract 기능 제거)");
            Console.WriteLine("   현재 연결된 메서드들:");
            Console.WriteLine("   [Add] → [Multiply] → [Divide] (Subtract 제거됨)");
            Console.WriteLine();

            // 두 번째 실행 (Subtract 제거 후)
            Console.WriteLine("🎬 두 번째 실행: calc(10, 2) (Subtract 제거 후)");
            Console.WriteLine("   (3개 메서드만 실행됩니다!)");
            Console.WriteLine();
            calc(10, 2);
            Console.WriteLine();

            // 여러 메서드 한 번에 제거
            Console.WriteLine("📝 3단계: 여러 메서드 제거");
            calc -= Multiply;
            calc -= Divide;
            Console.WriteLine("   calc -= Multiply; calc -= Divide;");
            Console.WriteLine("   현재 연결된 메서드들:");
            Console.WriteLine("   [Add] (Add만 남음)");
            Console.WriteLine();

            // 세 번째 실행 (Add만 남은 후)
            Console.WriteLine("🎬 세 번째 실행: calc(10, 2) (Add만 남음)");
            Console.WriteLine();
            calc(10, 2);
            Console.WriteLine();

            // 새로운 메서드 추가
            Console.WriteLine("📝 4단계: 새로운 메서드 추가");
            calc += Power;
            Console.WriteLine("   calc += Power; (Power 기능 추가)");
            Console.WriteLine("   현재 연결된 메서드들:");
            Console.WriteLine("   [Add] → [Power]");
            Console.WriteLine();

            // 마지막 실행
            Console.WriteLine("🎬 마지막 실행: calc(3, 4) (Add + Power)");
            Console.WriteLine();
            calc(3, 4);
            Console.WriteLine();

            Console.WriteLine("✨ 핵심 포인트:");
            Console.WriteLine("   += : 메서드 추가 (기존 것에 새로 더함)");
            Console.WriteLine("   -= : 메서드 제거 (기존 것에서 빼기)");
            Console.WriteLine("   동적으로 기능을 추가/제거할 수 있어 매우 유연합니다!");
            Console.WriteLine();
        }

        #endregion

        //#region 8. 실전 예제

        ///// <summary>
        ///// 실전 예제: 이벤트 처리 시뮬레이션
        ///// </summary>
        //static void DemoRealWorldExample()
        //{
        //    Console.WriteLine("4️⃣ 실전 예제: 게임 이벤트 시스템");
        //    Console.WriteLine("=" * 50);

        //    Console.WriteLine("🎮 게임 상황:");
        //    Console.WriteLine("   플레이어가 적을 처치했을 때 일어나는 일들:");
        //    Console.WriteLine("   1) 점수 추가");
        //    Console.WriteLine("   2) 경험치 증가");
        //    Console.WriteLine("   3) 아이템 드랍");
        //    Console.WriteLine("   4) 효과음 재생");
        //    Console.WriteLine();

        //    // 게임 이벤트 메서드들 정의
        //    Console.WriteLine("📝 게임 이벤트 메서드들:");

        //    // 점수 관련 메서드
        //    int AddScore(int baseScore, int multiplier)
        //    {
        //        int score = baseScore * multiplier;
        //        Console.WriteLine($"   🏆 점수 추가: +{score}점");
        //        return score;
        //    }

        //    // 경험치 관련 메서드
        //    int AddExperience(int baseExp, int level)
        //    {
        //        int exp = baseExp + (level * 10);
        //        Console.WriteLine($"   ⭐ 경험치 획득: +{exp} EXP");
        //        return exp;
        //    }

        //    // 아이템 드랍 메서드
        //    int DropItem(int enemyLevel, int luckFactor)
        //    {
        //        int itemValue = enemyLevel * luckFactor;
        //        Console.WriteLine($"   🎁 아이템 드랍: 가치 {itemValue}골드");
        //        return itemValue;
        //    }

        //    // 게임 이벤트 델리게이트 생성
        //    Console.WriteLine("\n📝 게임 이벤트 델리게이트 설정:");
        //    Calculate onEnemyDefeated = null;

        //    // 모든 이벤트 메서드들을 델리게이트에 연결
        //    onEnemyDefeated += AddScore;
        //    onEnemyDefeated += AddExperience;
        //    onEnemyDefeated += DropItem;

        //    Console.WriteLine("   적 처치 이벤트에 3개 핸들러 연결:");
        //    Console.WriteLine("   [점수 추가] → [경험치 증가] → [아이템 드랍]");
        //    Console.WriteLine();

        //    // 게임 이벤트 발생!
        //    Console.WriteLine("🎬 게임 상황: 레벨 5 적을 처치!");
        //    Console.WriteLine("   onEnemyDefeated(100, 5) 실행:");
        //    Console.WriteLine("   (점수 100, 레벨 5를 매개변수로 전달)");
        //    Console.WriteLine();

        //    int finalResult = onEnemyDefeated(100, 5);
        //    Console.WriteLine();
        //    Console.WriteLine($"📊 이벤트 처리 완료! 최종 값: {finalResult}");
        //    Console.WriteLine();

        //    // 특별한 상황: 보스 몬스터 처치 시 추가 이벤트
        //    Console.WriteLine("🔥 특별 상황: 보스 몬스터 처치!");
        //    Console.WriteLine("   보스 처치 시에는 특별 보상도 추가!");

        //    // 특별 보상 메서드 추가
        //    int BossReward(int damage, int difficulty)
        //    {
        //        int reward = damage * difficulty * 2;
        //        Console.WriteLine($"   👑 보스 특별 보상: +{reward} 골드");
        //        return reward;
        //    }

        //    onEnemyDefeated += BossReward;
        //    Console.WriteLine("   보스 보상 이벤트 추가!");
        //    Console.WriteLine("   현재 이벤트: [점수] → [경험치] → [아이템] → [보스보상]");
        //    Console.WriteLine();

        //    Console.WriteLine("🎬 보스 처치 이벤트: onEnemyDefeated(500, 10)");
        //    Console.WriteLine();
        //    onEnemyDefeated(500, 10);
        //    Console.WriteLine();

        //    Console.WriteLine("✨ 실전 활용 포인트:");
        //    Console.WriteLine("   🔹 이벤트 시스템: 하나의 상황에 여러 반응을 연결");
        //    Console.WriteLine("   🔹 플러그인 시스템: 기능을 동적으로 추가/제거");
        //    Console.WriteLine("   🔹 옵저버 패턴: 상태 변경을 여러 객체에 알림");
        //    Console.WriteLine("   🔹 콜백 함수: 작업 완료 후 호출할 함수들 등록");
        //    Console.WriteLine();
        //}

        //#endregion
    }
}

// 📚 델리게이트 핵심 정리:
//
// 1. 델리게이트란?
//    - 메서드를 가리키는 "포인터" 또는 "리모컨"
//    - 메서드를 변수처럼 저장하고 전달 가능
//
// 2. 선언과 사용:
//    delegate 반환타입 이름(매개변수);  // 델리게이트 타입 정의
//    이름 변수 = 메서드;              // 메서드 할당
//    변수(매개변수);                  // 메서드 실행
//
// 3. 멀티캐스트:
//    += : 메서드 추가
//    -= : 메서드 제거
//    한 번 호출로 여러 메서드 실행 가능
//
// 4. 실전 활용:
//    - 이벤트 처리
//    - 콜백 함수
//    - 플러그인 시스템
//    - 함수형 프로그래밍