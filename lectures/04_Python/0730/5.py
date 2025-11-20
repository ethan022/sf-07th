# ============================================================
# Python 예외 처리 완전 가이드
# ============================================================

import traceback
import sys

print("=" * 60)
print("⚠️ Python 예외 처리 학습")
print("=" * 60)

# ============================================================
# 1. 예외(Exception)란?
# ============================================================

print("\n🚨 1. 예외(Exception)란?")
print("-" * 40)

"""
예외(Exception)란?
- 프로그램 실행 중에 발생하는 오류나 예상치 못한 상황
- 프로그램이 정상적으로 실행될 수 없는 상태
- 적절히 처리하지 않으면 프로그램이 강제 종료됨

예외 처리의 목적:
1. 프로그램의 비정상 종료 방지
2. 사용자에게 친화적인 오류 메시지 제공
3. 오류 상황에서도 프로그램이 계속 실행되도록 함
4. 디버깅과 로깅을 위한 정보 제공
"""

print("📋 예외 처리의 기본 구조:")
print("""
try:
    # 예외가 발생할 수 있는 코드
    pass
except 예외타입:
    # 예외 처리 코드
    pass
""")

# ============================================================
# 2. 주요 예외 타입들과 실제 예제
# ============================================================

print("\n💥 2. 주요 예외 타입들과 실제 예제")
print("-" * 40)

# ZeroDivisionError - 0으로 나누기 오류
print("🔢 ZeroDivisionError - 0으로 나누기 오류")
try:
    result = 10 / 0  # 0으로 나누기 시도
    print(f"결과: {result}")
except ZeroDivisionError as e:
    print(f"❌ 0으로 나눌 수 없습니다! 오류 상세: {e}")

print()

# IndexError - 리스트/문자열 인덱스 범위 초과
print("📝 IndexError - 인덱스 범위 초과")
try:
    numbers = [1, 2, 3]
    print(f"리스트: {numbers}")
    print(f"인덱스 5의 값: {numbers[5]}")  # 존재하지 않는 인덱스
except IndexError as e:
    print(f"❌ 리스트 범위를 벗어났습니다! 오류 상세: {e}")
    print(f"💡 리스트 길이: {len(numbers)}, 유효 인덱스: 0~{len(numbers)-1}")

print()

# KeyError - 딕셔너리에 존재하지 않는 키
print("🗝️ KeyError - 존재하지 않는 키")
try:
    person = {"name": "김철수", "age": 25}
    print(f"사람 정보: {person}")
    print(f"주소: {person['address']}")  # 존재하지 않는 키
except KeyError as e:
    print(f"❌ 존재하지 않는 키입니다! 오류 상세: {e}")
    print(f"💡 사용 가능한 키: {list(person.keys())}")

print()

# TypeError - 타입 불일치 오류
print("🔤 TypeError - 타입 불일치")
try:
    result = "문자열" + 100  # 문자열과 숫자 더하기
    print(f"결과: {result}")
except TypeError as e:
    print(f"❌ 타입이 맞지 않습니다! 오류 상세: {e}")
    print(f"💡 올바른 방법: '문자열' + str(100) = {'문자열' + str(100)}")

print()

# ValueError - 값 오류
print("🔢 ValueError - 잘못된 값")
try:
    number = int("abc")  # 문자열을 정수로 변환 시도
    print(f"변환된 숫자: {number}")
except ValueError as e:
    print(f"❌ 숫자로 변환할 수 없는 값입니다! 오류 상세: {e}")
    print(f"💡 올바른 예: int('123') = {int('123')}")

print()

# FileNotFoundError - 파일을 찾을 수 없음
print("📁 FileNotFoundError - 파일 없음")
try:
    with open("존재하지_않는_파일.txt", "r") as file:
        content = file.read()
except FileNotFoundError as e:
    print(f"❌ 파일을 찾을 수 없습니다! 오류 상세: {e}")
    print(f"💡 파일이 존재하는지 확인해주세요.")

# ============================================================
# 3. 복합 예외 처리 - 여러 예외를 한 번에 처리
# ============================================================

print("\n🎯 3. 복합 예외 처리")
print("-" * 40)


def safe_calculator(a, b, operation):
    """안전한 계산기 함수"""
    try:
        if operation == "+":
            result = a + b
        elif operation == "-":
            result = a - b
        elif operation == "*":
            result = a * b
        elif operation == "/":
            result = a / b
        elif operation == "**":
            result = a ** b
        else:
            raise ValueError(f"지원하지 않는 연산자입니다: {operation}")

        return result

    except ZeroDivisionError:
        print(f"❌ 0으로 나눌 수 없습니다!")
        return None
    except TypeError:
        print(f"❌ 숫자가 아닌 값이 입력되었습니다!")
        return None
    except ValueError as e:
        print(f"❌ 값 오류: {e}")
        return None
    except Exception as e:
        print(f"❌ 예상치 못한 오류: {e}")
        return None


print("🧮 안전한 계산기 테스트:")
test_cases = [
    (10, 2, "+"),   # 정상
    (10, 0, "/"),   # ZeroDivisionError
    ("a", 5, "*"),  # TypeError
    (10, 2, "%"),   # ValueError (지원하지 않는 연산자)
]

for a, b, op in test_cases:
    print(f"계산: {a} {op} {b}")
    result = safe_calculator(a, b, op)
    if result is not None:
        print(f"✅ 결과: {result}")
    print()

# ============================================================
# 4. raise문 - 직접 예외 발생시키기
# ============================================================

print("\n🚀 4. raise문 - 직접 예외 발생시키기")
print("-" * 40)


def validate_age(age):
    """나이 유효성 검사 함수"""
    if not isinstance(age, int):
        raise TypeError("나이는 정수여야 합니다!")

    if age < 0:
        raise ValueError("나이는 0보다 크거나 같아야 합니다!")

    if age > 150:
        raise ValueError("나이는 150 이하여야 합니다!")

    return True


print("👶 나이 유효성 검사 테스트:")
test_ages = [25, -5, "abc", 200, 0]

for age in test_ages:
    try:
        print(f"나이 {age} 검사 중...")
        if validate_age(age):
            print(f"✅ 유효한 나이입니다: {age}")
    except (TypeError, ValueError) as e:
        print(f"❌ {e}")
    print()

# 사용자 정의 예외 클래스


class CustomError(Exception):
    """사용자 정의 예외 클래스"""

    def __init__(self, message="사용자 정의 오류가 발생했습니다"):
        self.message = message
        super().__init__(self.message)


def process_user_input(user_input):
    """사용자 입력 처리 함수"""
    if user_input == "error":
        raise CustomError("사용자가 'error'를 입력했습니다!")

    if len(user_input) < 3:
        raise CustomError("입력은 3글자 이상이어야 합니다!")

    return f"처리 완료: {user_input}"


print("🎭 사용자 정의 예외 테스트:")
test_inputs = ["hello", "hi", "error", "python"]

for user_input in test_inputs:
    try:
        result = process_user_input(user_input)
        print(f"✅ {result}")
    except CustomError as e:
        print(f"❌ 사용자 정의 오류: {e}")
    print()

# ============================================================
# 5. try-except-else-finally 완전한 구조
# ============================================================

print("\n🏗️ 5. try-except-else-finally 완전한 구조")
print("-" * 40)


def demonstrate_full_structure(divide_by):
    """완전한 예외 처리 구조 시연"""
    print(f"🔢 10을 {divide_by}로 나누기 시도...")

    try:
        result = 10 / divide_by
        print(f"✅ 계산 성공!")

        # 추가 조건 검사
        if result > 5:
            raise Exception(f"결과값이 너무 큽니다: {result}")

    except ZeroDivisionError:
        print("❌ 0으로 나눌 수 없습니다!")
        result = None
    except Exception as e:
        print(f"❌ 기타 오류: {e}")
        result = None
    else:
        # 예외가 발생하지 않았을 때만 실행
        print("🎉 예외가 발생하지 않았습니다 (else 블록)")
        print(f"계산 결과: {result}")
    finally:
        # 예외 발생 여부와 관계없이 항상 실행
        print("🔚 계산 시도 완료 (finally 블록)")

    print("-" * 30)
    return result


print("📊 다양한 시나리오 테스트:")
test_values = [2, 0, 1, 0.5]

for value in test_values:
    demonstrate_full_structure(value)
