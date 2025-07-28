// LINQ (Language Integrated Query) 완전 가이드
//
// 🎯 LINQ란?
// - Language Integrated Query의 줄임말
// - C#에서 데이터를 쉽게 찾고 정리하는 강력한 도구
// - SQL과 비슷한 방식으로 데이터를 다룰 수 있음
//
// 🌟 일상 예시:
// - 교실에서 키가 170cm 이상인 친구들을 찾아서 이름순으로 정렬
// - 음악 앱에서 발라드 장르 중 2020년 이후 나온 노래를 인기순으로 정렬
// - 쇼핑몰에서 가격이 5만원 이하인 상품을 평점 높은 순으로 정렬

using System;
using System.Linq;

namespace LinqComprehensiveGuide
{
    internal class Program
    {
        #region 함수와 람다식 기초

        /// <summary>
        /// 일반 함수: 짝수인지 확인
        /// </summary>
        /// <param name="x">확인할 숫자</param>
        /// <returns>짝수면 true, 홀수면 false</returns>
        static bool IsEven(int x)
        //     ↑      ↑     ↑
        // 반환타입  함수명  매개변수
        {
            return x % 2 == 0;
            //  ↑        ↑
            // 반환    반환값
        }

        /// <summary>
        /// 람다식으로 정의한 함수: 홀수인지 확인
        /// Func<입력타입, 출력타입> 형태
        /// </summary>
        static Func<int, bool> IsOdd = x => x % 2 == 1;
        //          ↑    ↑      ↑      ↑       ↑
        //    매개변수  반환값  함수명  매개변수  반환값
        //      타입    타입

        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("🎯 LINQ 완전 마스터 가이드 🎯\n");

            // 함수 테스트
            Console.WriteLine($"IsEven(2): {IsEven(2)}");     // True
            Console.WriteLine($"IsOdd(1): {IsOdd(1)}");       // True

            Console.WriteLine("\n📝 람다식 설명:");
            Console.WriteLine("   x => x % 2 == 0");
            Console.WriteLine("   ↑         ↑");
            Console.WriteLine("매개변수    반환값");

            // 테스트 데이터 준비
            SetupTestData();

            // LINQ 학습 단계
            DemoTraditionalWay();           // 1. 전통적인 방법 (복잡함)
            DemoLinqWhere();               // 2. Where - 필터링
            DemoLinqSelect();              // 3. Select - 변환
            DemoLinqOrderBy();             // 4. OrderBy - 정렬
            DemoMethodChaining();          // 5. 메서드 체이닝
            DemoAggregation();             // 6. 집계 함수
            DemoAnyAll();                  // 7. Any, All - 조건 확인
        }

        #region 테스트 데이터

        static int[] numbers;
        static string[] names;
        static int[] ages;
        static int[] scores;
        static string[] fruits;
        static string[] studentNames;

        static void SetupTestData()
        {
            numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            names = new string[] { "철수", "영희", "민수", "영수" };
            ages = new int[] { 20, 30, 21, 33, 40 };
            scores = new int[] { 85, 92, 78, 88, 95, 89, 91, 67, 73 };
            fruits = new string[] { "자몽", "사과", "포도", "바나나", "키위" };
            studentNames = new string[] { "철수", "이영희", "민수", "최영수", "미희", "윤서연" };

            Console.WriteLine("\n📊 테스트 데이터:");
            Console.WriteLine($"numbers: [{string.Join(", ", numbers)}]");
            Console.WriteLine($"names: [{string.Join(", ", names)}]");
            Console.WriteLine($"ages: [{string.Join(", ", ages)}]");
            Console.WriteLine($"scores: [{string.Join(", ", scores)}]");
        }

        #endregion

        #region 1. 전통적인 방법 (LINQ 없이)

        /// <summary>
        /// LINQ 없이 짝수를 찾는 전통적인 방법
        /// 3단계 과정을 거쳐야 함: 개수 세기 → 배열 생성 → 값 복사
        /// </summary>
        static void DemoTraditionalWay()
        {
            Console.WriteLine("\n" + "=".PadRight(50, '='));
            Console.WriteLine("❌ LINQ 없이 (복잡한 전통적인 방법)");
            Console.WriteLine("=".PadRight(50, '='));

            // 문제: numbers 배열에서 짝수만 찾아서 새 배열 만들기
            Console.WriteLine("🎯 목표: 짝수만 찾아서 새 배열 만들기");
            Console.WriteLine($"원본 배열: [{string.Join(", ", numbers)}]");

            // 1단계: 짝수의 개수 세기
            Console.WriteLine("\n📝 1단계: 짝수 개수 세기");
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    count++;
                    Console.WriteLine($"   짝수 발견: {numbers[i]} (현재 개수: {count})");
                }
            }
            Console.WriteLine($"   총 짝수 개수: {count}개");

            // 2단계: 짝수 개수만큼 새 배열 생성
            Console.WriteLine("\n📝 2단계: 새 배열 생성");
            int[] evenNumbers = new int[count];
            Console.WriteLine($"   크기 {count}인 새 배열 생성");

            // 3단계: 짝수들을 새 배열에 복사
            Console.WriteLine("\n📝 3단계: 짝수들을 새 배열에 복사");
            int index = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenNumbers[index] = numbers[i];
                    Console.WriteLine($"   evenNumbers[{index}] = {numbers[i]}");
                    index++;
                }
            }

            // 4단계: 결과 출력
            Console.WriteLine("\n📝 4단계: 결과 출력");
            Console.Write("   결과: ");
            foreach (int num in evenNumbers)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
            Console.WriteLine("\n😰 이렇게 복잡한 과정을 거쳐야 함!");
        }

        #endregion

        #region 2. Where - 필터링 (조건에 맞는 것들만 골라내기)

        /// <summary>
        /// Where: 조건에 맞는 요소들만 선택하는 LINQ 메서드
        /// </summary>
        static void DemoLinqWhere()
        {
            Console.WriteLine("\n" + "=".PadRight(50, '='));
            Console.WriteLine("✅ Where - 조건에 맞는 것들만 골라내기");
            Console.WriteLine("=".PadRight(50, '='));

            // 예제 1: 짝수만 선택
            Console.WriteLine("🔸 예제 1: 짝수만 선택");
            Console.WriteLine($"원본: [{string.Join(", ", numbers)}]");
            Console.WriteLine("코드: numbers.Where(num => num % 2 == 0)");
            Console.WriteLine("설명: num => num % 2 == 0 (람다식)");
            Console.WriteLine("      '각 num에 대해 num을 2로 나눈 나머지가 0인가?'");

            var evenNumbers = numbers.Where(num => num % 2 == 0).ToArray();
            Console.WriteLine($"결과: [{string.Join(", ", evenNumbers)}]");
            Console.WriteLine("😍 한 줄로 해결!");

            // 예제 2: 87점 이상 점수만 선택
            Console.WriteLine("\n🔸 예제 2: 87점 이상 점수만 선택");
            Console.WriteLine($"원본: [{string.Join(", ", scores)}]");
            Console.WriteLine("코드: scores.Where(score => score >= 87)");

            var highScores = scores.Where(score => score >= 87).ToArray();
            Console.WriteLine($"결과: [{string.Join(", ", highScores)}]");

            // 예제 3: 다양한 조건들
            Console.WriteLine("\n🔸 예제 3: 다양한 Where 조건들");

            // 5보다 큰 수
            var bigNumbers = numbers.Where(x => x > 5).ToArray();
            Console.WriteLine($"5보다 큰 수: [{string.Join(", ", bigNumbers)}]");

            // 홀수
            var oddNumbers = numbers.Where(x => x % 2 == 1).ToArray();
            Console.WriteLine($"홀수: [{string.Join(", ", oddNumbers)}]");

            // 두 자리 수
            var twoDigits = numbers.Where(x => x >= 10).ToArray();
            Console.WriteLine($"두 자리 수: [{string.Join(", ", twoDigits)}]");

            // 문자열 조건: 2글자 이름
            var shortNames = names.Where(name => name.Length == 2).ToArray();
            Console.WriteLine($"2글자 이름: [{string.Join(", ", shortNames)}]");
        }

        #endregion

        #region 3. Select - 변환하기 (데이터를 다른 형태로 바꾸기)

        /// <summary>
        /// Select: 각 요소를 다른 형태로 변환하는 LINQ 메서드
        /// </summary>
        static void DemoLinqSelect()
        {
            Console.WriteLine("\n" + "=".PadRight(50, '='));
            Console.WriteLine("✅ Select - 데이터 변환하기");
            Console.WriteLine("=".PadRight(50, '='));

            // 예제 1: 모든 숫자에 2 곱하기
            Console.WriteLine("🔸 예제 1: 모든 숫자에 2 곱하기");
            Console.WriteLine($"원본: [{string.Join(", ", numbers)}]");
            Console.WriteLine("코드: numbers.Select(x => x * 2)");
            Console.WriteLine("설명: 각 x에 대해 x * 2를 반환");

            var doubled = numbers.Select(x => x * 2).ToArray();
            Console.WriteLine($"결과: [{string.Join(", ", doubled)}]");

            // 예제 2: 제곱하기
            Console.WriteLine("\n🔸 예제 2: 제곱하기");
            Console.WriteLine("코드: numbers.Select(x => x * x)");

            var squares = numbers.Select(x => x * x).ToArray();
            Console.WriteLine($"결과: [{string.Join(", ", squares)}]");

            // 예제 3: 이름 앞에 "학생" 붙이기
            Console.WriteLine("\n🔸 예제 3: 이름 앞에 '학생' 붙이기");
            Console.WriteLine($"원본: [{string.Join(", ", names)}]");
            Console.WriteLine("코드: names.Select(name => $\"학생 {name}\")");

            var studentNames = names.Select(name => $"학생 {name}").ToArray();
            Console.WriteLine($"결과: [{string.Join(", ", studentNames)}]");

            // 예제 4: 다양한 변환들
            Console.WriteLine("\n🔸 예제 4: 다양한 변환들");

            // 숫자를 문자열로
            var numberStrings = numbers.Select(x => $"숫자{x}").ToArray();
            Console.WriteLine($"문자열 변환: [{string.Join(", ", numberStrings.Take(5))}...]");

            // 이름을 대문자로
            var upperNames = names.Select(name => name.ToUpper()).ToArray();
            Console.WriteLine($"대문자 변환: [{string.Join(", ", upperNames)}]");

            // 나이에 10 더하기
            var futureAges = ages.Select(age => age + 10).ToArray();
            Console.WriteLine($"10년 후 나이: [{string.Join(", ", futureAges)}]");
        }

        #endregion

        #region 4. OrderBy - 정렬하기

        /// <summary>
        /// OrderBy/OrderByDescending: 데이터를 정렬하는 LINQ 메서드
        /// </summary>
        static void DemoLinqOrderBy()
        {
            Console.WriteLine("\n" + "=".PadRight(50, '='));
            Console.WriteLine("✅ OrderBy - 정렬하기");
            Console.WriteLine("=".PadRight(50, '='));

            // 예제 1: 나이 오름차순 정렬
            Console.WriteLine("🔸 예제 1: 나이 오름차순 정렬");
            Console.WriteLine($"원본: [{string.Join(", ", ages)}]");
            Console.WriteLine("코드: ages.OrderBy(x => x)");
            Console.WriteLine("설명: x를 기준으로 오름차순 정렬 (작은 수부터)");

            var ascending = ages.OrderBy(x => x).ToArray();
            Console.WriteLine($"결과: [{string.Join(", ", ascending)}]");

            // 예제 2: 나이 내림차순 정렬
            Console.WriteLine("\n🔸 예제 2: 나이 내림차순 정렬");
            Console.WriteLine("코드: ages.OrderByDescending(x => x)");
            Console.WriteLine("설명: x를 기준으로 내림차순 정렬 (큰 수부터)");

            var descending = ages.OrderByDescending(x => x).ToArray();
            Console.WriteLine($"결과: [{string.Join(", ", descending)}]");

            // 예제 3: 문자열 정렬 (가나다순)
            Console.WriteLine("\n🔸 예제 3: 과일 이름 가나다순 정렬");
            Console.WriteLine($"원본: [{string.Join(", ", fruits)}]");
            Console.WriteLine("코드: fruits.OrderBy(x => x)");

            var sortedFruits = fruits.OrderBy(x => x).ToArray();
            Console.WriteLine($"결과: [{string.Join(", ", sortedFruits)}]");

            // 예제 4: 길이별 정렬
            Console.WriteLine("\n🔸 예제 4: 이름 길이별 정렬");
            Console.WriteLine($"원본: [{string.Join(", ", studentNames)}]");
            Console.WriteLine("코드: studentNames.OrderBy(name => name.Length)");
            Console.WriteLine("설명: 이름의 길이(Length)를 기준으로 정렬");

            var byLength = studentNames.OrderBy(name => name.Length).ToArray();
            Console.WriteLine($"결과: [{string.Join(", ", byLength)}]");
        }

        #endregion

        #region 5. 메서드 체이닝 - 여러 메서드 연결하기

        /// <summary>
        /// 메서드 체이닝: 여러 LINQ 메서드를 연결해서 복잡한 작업 수행
        /// </summary>
        static void DemoMethodChaining()
        {
            Console.WriteLine("\n" + "=".PadRight(50, '='));
            Console.WriteLine("✅ 메서드 체이닝 - 여러 메서드 연결하기");
            Console.WriteLine("=".PadRight(50, '='));

            // 예제 1: 단계별로 보여주기
            Console.WriteLine("🔸 예제 1: 단계별 메서드 체이닝");
            Console.WriteLine($"원본: [{string.Join(", ", numbers)}]");
            Console.WriteLine("\n📝 단계별 실행:");

            // 1단계: 짝수만 선택
            var step1 = numbers.Where(x => x % 2 == 0);
            Console.WriteLine($"1단계 (짝수만): [{string.Join(", ", step1)}]");

            // 2단계: 각 숫자에 2를 곱하고 1을 더함
            var step2 = step1.Select(x => x * 2 + 1);
            Console.WriteLine($"2단계 (x*2+1): [{string.Join(", ", step2)}]");

            // 3단계: 내림차순 정렬
            var step3 = step2.OrderByDescending(x => x);
            Console.WriteLine($"3단계 (내림차순): [{string.Join(", ", step3)}]");

            var result = step3.ToArray();
            Console.WriteLine($"최종 결과: [{string.Join(", ", result)}]");

            // 예제 2: 한 줄로 연결하기 (메서드 체이닝)
            Console.WriteLine("\n🔸 예제 2: 한 줄로 연결 (메서드 체이닝)");
            Console.WriteLine("코드:");
            Console.WriteLine("numbers");
            Console.WriteLine("  .Where(x => x % 2 == 0)     // 짝수만");
            Console.WriteLine("  .Select(x => x * 2 + 1)     // x*2+1");
            Console.WriteLine("  .OrderByDescending(x => x)  // 내림차순");
            Console.WriteLine("  .ToArray()                  // 배열로 변환");

            var chainedResult = numbers
                .Where(x => x % 2 == 0)     // 짝수만
                .Select(x => x * 2 + 1)     // x*2+1
                .OrderByDescending(x => x)  // 내림차순
                .ToArray();                 // 배열로 변환

            Console.WriteLine($"결과: [{string.Join(", ", chainedResult)}]");
            Console.WriteLine("😍 같은 결과, 훨씬 깔끔!");

            // 예제 3: 복잡한 문자열 처리
            Console.WriteLine("\n🔸 예제 3: 복잡한 문자열 처리");
            Console.WriteLine($"원본: [{string.Join(", ", studentNames)}]");
            Console.WriteLine("목표: 3글자 이름 → '학생' 붙이기 → 가나다순 정렬");

            var processedNames = studentNames
                .Where(name => name.Length == 3)        // 3글자 이름만
                .Select(name => $"학생 {name}")         // "학생" 붙이기
                .OrderBy(name => name)                  // 가나다순 정렬
                .ToArray();

            Console.WriteLine($"결과: [{string.Join(", ", processedNames)}]");
        }

        #endregion

        #region 6. 집계 함수 - 계산하기

        /// <summary>
        /// 집계 함수들: Count, Sum, Average, Max, Min
        /// </summary>
        static void DemoAggregation()
        {
            Console.WriteLine("\n" + "=".PadRight(50, '='));
            Console.WriteLine("✅ 집계 함수 - 계산하기");
            Console.WriteLine("=".PadRight(50, '='));

            int[] testScores = { 85, 92, 78, 88, 95, 89, 91, 67, 73, 84 };
            Console.WriteLine($"테스트 점수: [{string.Join(", ", testScores)}]");

            // Count - 개수 세기
            Console.WriteLine("\n🔸 Count - 개수 세기");
            int totalCount = testScores.Count();
            Console.WriteLine($"전체 점수 개수: {totalCount}개");

            int highScoreCount = testScores.Count(x => x > 90);
            Console.WriteLine($"90점 초과 개수: {highScoreCount}개");

            int lowScoreCount = testScores.Count(x => x < 75);
            Console.WriteLine($"75점 미만 개수: {lowScoreCount}개");

            // Sum - 합계
            Console.WriteLine("\n🔸 Sum - 합계");
            Console.WriteLine("예제 점수: [85, 75, 90]");
            int[] simpleScores = { 85, 75, 90 };

            int totalSum = simpleScores.Sum();
            Console.WriteLine($"전체 합계: {totalSum}점");

            int highSum = simpleScores.Where(x => x > 80).Sum();
            Console.WriteLine($"80점 초과 합계: {highSum}점 (85 + 90)");

            // Average - 평균
            Console.WriteLine("\n🔸 Average - 평균");
            double average = simpleScores.Average();
            Console.WriteLine($"전체 평균: {average:F1}점");

            double highAverage = simpleScores.Where(x => x > 80).Average();
            Console.WriteLine($"80점 초과 평균: {highAverage:F1}점");

            // Max, Min - 최대값, 최소값
            Console.WriteLine("\n🔸 Max, Min - 최대값, 최소값");
            int maxScore = testScores.Max();
            Console.WriteLine($"최고 점수: {maxScore}점");

            int minScore = testScores.Min();
            Console.WriteLine($"최저 점수: {minScore}점");

            // 조건부 최대값, 최소값
            int maxUnder90 = testScores.Where(x => x < 90).Max();
            Console.WriteLine($"90점 미만 중 최고점: {maxUnder90}점");
        }

        #endregion

        #region 7. Any, All - 조건 확인하기

        /// <summary>
        /// Any: 하나라도 조건을 만족하는가?
        /// All: 모두 조건을 만족하는가?
        /// </summary>
        static void DemoAnyAll()
        {
            Console.WriteLine("\n" + "=".PadRight(50, '='));
            Console.WriteLine("✅ Any, All - 조건 확인하기");
            Console.WriteLine("=".PadRight(50, '='));

            Console.WriteLine($"나이 데이터: [{string.Join(", ", ages)}]");

            // Any - 하나라도 있는가?
            Console.WriteLine("\n🔸 Any - 하나라도 조건을 만족하는가?");

            bool hasAdult = ages.Any(age => age >= 30);
            Console.WriteLine($"30세 이상이 있나요? {hasAdult}");
            Console.WriteLine("설명: 30, 33, 40이 있으므로 True");

            bool has21 = ages.Any(age => age == 21);
            Console.WriteLine($"21세가 있나요? {has21}");
            Console.WriteLine("설명: 21이 있으므로 True");

            bool has50 = ages.Any(age => age >= 50);
            Console.WriteLine($"50세 이상이 있나요? {has50}");
            Console.WriteLine("설명: 50세 이상이 없으므로 False");

            // All - 모두 만족하는가?
            Console.WriteLine("\n🔸 All - 모두 조건을 만족하는가?");

            bool allAdult = ages.All(age => age >= 30);
            Console.WriteLine($"모두 30세 이상인가요? {allAdult}");
            Console.WriteLine("설명: 20, 21이 30세 미만이므로 False");

            bool all20Plus = ages.All(age => age >= 20);
            Console.WriteLine($"모두 20세 이상인가요? {all20Plus}");
            Console.WriteLine("설명: 모든 나이가 20 이상이므로 True");

            bool allEven = numbers.Take(5).All(x => x % 2 == 0);
            Console.WriteLine($"처음 5개 숫자가 모두 짝수인가요? {allEven}");
            Console.WriteLine($"확인: [{string.Join(", ", numbers.Take(5))}] → False (1, 3, 5가 홀수)");

            // 실용적인 예제
            Console.WriteLine("\n🔸 실용적인 예제");

            bool hasHighScore = scores.Any(score => score >= 95);
            Console.WriteLine($"95점 이상 고득점자가 있나요? {hasHighScore}");

            bool allPassed = scores.All(score => score >= 60);
            Console.WriteLine($"모든 학생이 60점 이상으로 합격했나요? {allPassed}");

            // 빈 컬렉션에서의 동작
            int[] emptyArray = new int[0];
            Console.WriteLine($"\n🔸 빈 배열에서의 Any/All:");
            Console.WriteLine($"빈 배열.Any(): {emptyArray.Any()}");           // False
            Console.WriteLine($"빈 배열.All(): {emptyArray.All(x => x > 0)}"); // True (논리적으로)
        }

        #endregion
    }
}