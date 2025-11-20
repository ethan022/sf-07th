using System;
using System.Globalization;

namespace _0818_2.Models
{
    /// <summary>
    /// 계산 기능을 담당하는 순수 Model 클래스.
    /// UI / WPF 의존성 없이 **비즈니스 로직만** 포함합니다.
    /// 
    /// 설계 의도:
    /// - ViewModel은 이 클래스를 호출해 계산만 위임하고,
    ///   예외 처리/메시지 구성/버튼 활성 제어 등은 ViewModel이 담당합니다.
    /// - 단위 테스트가 쉽게 독립적으로 수행되도록 UI와 분리합니다.
    /// </summary>
    public class Calculator
    {
        #region 기본 사칙연산

        /// <summary>
        /// 두 수를 더합니다.
        /// </summary>
        /// <param name="x">첫 번째 피연산자</param>
        /// <param name="y">두 번째 피연산자</param>
        /// <returns>x + y</returns>
        public double Add(double x, double y) => x + y;

        /// <summary>
        /// 첫 번째 수에서 두 번째 수를 뺍니다.
        /// </summary>
        /// <param name="x">첫 번째 피연산자</param>
        /// <param name="y">두 번째 피연산자</param>
        /// <returns>x - y</returns>
        public double Subtract(double x, double y) => x - y;

        /// <summary>
        /// 두 수를 곱합니다.
        /// </summary>
        /// <param name="x">첫 번째 피연산자</param>
        /// <param name="y">두 번째 피연산자</param>
        /// <returns>x * y</returns>
        public double Multiply(double x, double y) => x * y;

        /// <summary>
        /// 첫 번째 수를 두 번째 수로 나눕니다.
        /// </summary>
        /// <param name="x">피제수</param>
        /// <param name="y">제수(0 불가)</param>
        /// <returns>x / y</returns>
        /// <exception cref="DivideByZeroException">제수가 0인 경우</exception>
        public double Divide(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException("0으로 나눌 수 없습니다.");

            return x / y;
        }

        #endregion

        #region 문자열 → 숫자 유효성 / 파싱

        /// <summary>
        /// 주어진 문자열이 현재 문화권(CultureInfo.CurrentCulture) 기준으로
        /// 유효한 숫자 형식인지 검사합니다.
        /// </summary>
        /// <param name="input">검사할 입력 문자열(예: "3.14", "1,234" 등)</param>
        /// <returns>숫자로 해석 가능하면 true, 아니면 false</returns>
        /// <remarks>
        /// - 문화권에 따라 소수점/천 단위 기호가 다릅니다.
        ///   (예: 한국/독일: 1.234,56 / 미국: 1,234.56)
        /// - UI에서 실시간 유효성 검사(버튼 활성/비활성)에 사용하기 좋습니다.
        /// </remarks>
        public bool IsValidNumber(string? input)
        {
            return double.TryParse(
                input,
                NumberStyles.Float | NumberStyles.AllowThousands,
                CultureInfo.CurrentCulture,
                out _);
        }

        /// <summary>
        /// 문자열을 현재 문화권(CultureInfo.CurrentCulture) 기준으로 double로 변환합니다.
        /// </summary>
        /// <param name="input">파싱할 입력 문자열</param>
        /// <returns>변환된 double 값</returns>
        /// <exception cref="FormatException">숫자로 해석할 수 없는 경우</exception>
        /// <remarks>
        /// - "실패 시 0 반환" 방식은 조용히 오류를 숨겨 디버깅/UX에 불리할 수 있습니다.
        ///   따라서 실패 시 예외를 던지고, ViewModel에서 사용자 친화적으로 처리하는 방식을 권장합니다.
        /// - 로그/네트워크 등 문화권 독립 포맷이 필요하면 InvariantCulture를 고려하세요.
        /// </remarks>
        public double ParseNumber(string? input)
        {
            if (double.TryParse(
                    input,
                    NumberStyles.Float | NumberStyles.AllowThousands,
                    CultureInfo.CurrentCulture,
                    out var result))
            {
                return result;
            }

            throw new FormatException("숫자 형식이 올바르지 않습니다.");
        }

        #endregion

        #region 통합 연산 라우팅

        /// <summary>
        /// 지정한 연산자 기호("+", "-", "*", "/")에 따라 연산을 수행합니다.
        /// </summary>
        /// <param name="x">첫 번째 피연산자</param>
        /// <param name="y">두 번째 피연산자</param>
        /// <param name="operation">연산자 기호: "+", "-", "*", "/"</param>
        /// <returns>연산 결과</returns>
        /// <exception cref="NotSupportedException">지원하지 않는 연산자 기호인 경우</exception>
        public double Calculate(double x, double y, string operation)
        {
            return operation switch
            {
                "+" => Add(x, y),
                "-" => Subtract(x, y),
                "*" => Multiply(x, y),
                "/" => Divide(x, y),
                _ => throw new NotSupportedException($"지원하지 않는 연산자입니다: '{operation}'"),
            };
        }

        #endregion
    }
}
