# Python 클래스(Class) 학습 코드
# 클래스: 객체를 생성하기 위한 설계도나 틀
# 비유: 클래스는 붕어빵 틀, 객체는 실제 붕어빵
# 속성(변수): 붕어빵의 특징(크기, 맛, 색깔)
# 메서드(함수): 붕어빵이 할 수 있는 행동(먹히기, 식히기)

# ============================================================
# 1. 기본 클래스 정의 문법
# ============================================================

class 클래스명:
    """
    클래스의 기본 구조
    pass는 아무것도 하지 않는 키워드 (빈 클래스 생성시 사용)
    """
    pass

# ============================================================
# 1. Car 클래스 - @property와 캡슐화 개념
# ============================================================


class Car:
    def __init__(self):
        # __로 시작하는 변수는 클래스 외부에서 직접 접근할 수 없는 private 변수입니다.
        self.__name = "차"  # 초기 이름은 "차"로 설정됩니다.

    @property
    def name(self):
        """
        Getter 메서드
        - car.name 형태로 접근 가능하게 해줍니다.
        - 함수처럼 보이지만 속성처럼 사용할 수 있도록 합니다.
        """
        return self.__name

    @name.setter
    def name(self, name):
        """
        Setter 메서드
        - car.name = "자동차" 형태로 값을 설정할 수 있게 해줍니다.
        - 외부에서 값을 안전하게 수정할 수 있도록 도와줍니다.
        """
        self.__name = name


# ============================================================
# Car 클래스 사용 예제
# ============================================================

print("========= 차 =======")

# Car 객체 생성
car = Car()

# Getter 사용: car.name → 속성처럼 접근하지만 실제로는 함수입니다.
print(car.name)  # 출력: 차

# Setter 사용: car.name = "자동차" → 내부적으로 name.setter가 실행됩니다.
car.name = "자동차"

# 다시 Getter 사용
print(car.name)  # 출력: 자동차

print()  # 줄바꿈

# ============================================================
# 2. Person 클래스 - 생성자와 캡슐화 개념
# ============================================================


class Person:
    """
    사람을 표현하는 클래스
    생성자, 캡슐화, getter/setter 개념을 보여줌
    """

    def __init__(self, name, age):
        """
        생성자 메서드 (__init__)
        - 객체가 생성될 때 자동으로 호출되는 특별한 메서드
        - 객체의 초기 상태를 설정하는 역할

        self 키워드:
        - 현재 인스턴스(객체) 자신을 가리키는 참조
        - 모든 인스턴스 메서드의 첫 번째 매개변수로 사용
        - 인스턴스 변수와 메서드에 접근할 때 사용

        매개변수:
        - name: 사람의 이름
        - age: 사람의 나이
        """
        # __ (언더스코어 2개)로 시작하는 변수는 private 변수
        # 클래스 외부에서 직접 접근할 수 없음 (캡슐화)
        self.__name = name  # private 인스턴스 변수
        self.__age = age    # private 인스턴스 변수

    # 소멸자
    def __del__(self):
        # 객체가 사라질때 자동으로 호출되는 메서드
        print(f"삭제되었습니다.")

    def introduce(self):
        """
        인스턴스 메서드 - 자기소개를 하는 메서드
        self를 통해 인스턴스 변수에 접근
        """
        print(f"안녕하세요! 제 이름은 {self.__name}이고, {self.__age}살입니다.")

    # ========== Getter 메서드 ==========
    @property
    def name(self):
        """
        name에 대한 getter 메서드
        @property 데코레이터를 사용하여 메서드를 속성처럼 사용 가능
        """
        return self.__name

    @property
    def age(self):
        """
        age에 대한 getter 메서드
        """
        return self.__age

    # ========== Setter 메서드 ==========
    @name.setter
    def name(self, name):
        """
        name에 대한 setter 메서드
        @속성명.setter 데코레이터를 사용
        """
        self.__name = name

    @age.setter
    def age(self, age):
        """
        age에 대한 setter 메서드
        여기서 유효성 검사 등을 추가할 수 있음
        """
        if age >= 0:  # 나이는 0보다 크거나 같아야 함
            self.__age = age
        else:
            print("나이는 0보다 작을 수 없습니다.")


# ============================================================
# Person 클래스 사용 예제
# ============================================================

print("======= Person 클래스 예제 ========")

# 객체 생성 (인스턴스화)
person1 = Person("김철수", 25)  # Person 클래스의 인스턴스 생성
person2 = Person("이영희", 20)  # 또 다른 인스턴스 생성

# 메서드 호출
person1.introduce()  # 김철수의 자기소개
person2.introduce()  # 이영희의 자기소개

# Setter를 이용한 값 변경
person1.name = "홍길동"  # name setter 호출
person1.age = 30        # age setter 호출

# Getter를 이용한 값 조회
print(f"변경된 이름: {person1.name}")  # name getter 호출
print(f"변경된 나이: {person1.age}")   # age getter 호출

del person1

print()  # 줄바꿈


# ============================================================
# 3. Calculator 클래스 - 클래스 변수와 인스턴스 변수
# ============================================================

class Calculator:
    """
    계산기를 표현하는 클래스
    클래스 변수와 인스턴스 변수의 차이점을 보여줌
    """

    # 클래스 변수: 모든 인스턴스가 공유하는 변수
    # Calculator 클래스의 모든 객체가 같은 PI 값을 공유
    PI = 3.1415

    def __init__(self, val1, val2):
        """
        생성자: 두 개의 숫자를 받아서 계산기 객체 초기화
        """
        # 인스턴스 변수: 각 객체마다 고유한 변수
        self.val1 = val1  # 첫 번째 피연산자
        self.val2 = val2  # 두 번째 피연산자

    def add(self):
        """덧셈 연산 메서드"""
        return self.val1 + self.val2

    def sub(self):
        """뺄셈 연산 메서드"""
        return self.val1 - self.val2

    def mul(self):
        """곱셈 연산 메서드"""
        return self.val1 * self.val2

    def div(self):
        """
        나눗셈 연산 메서드
        0으로 나누는 경우를 방지하는 예외 처리 포함
        """
        if self.val2 != 0:
            return self.val1 / self.val2
        else:
            print("0으로 나눌 수 없습니다.")
            return 0


# ============================================================
# Calculator 클래스 사용 예제
# ============================================================

print("======= Calculator 클래스 예제 ========")

# 첫 번째 계산기 인스턴스 생성
cal1 = Calculator(1, 2)
print("=== cal1 (1, 2) ===")
print(f"덧셈: {cal1.add()}")     # 1 + 2 = 3
print(f"뺄셈: {cal1.sub()}")     # 1 - 2 = -1
print(f"곱셈: {cal1.mul()}")     # 1 * 2 = 2
print(f"나눗셈: {cal1.div()}")   # 1 / 2 = 0.5
print(f"PI 값: {cal1.PI}")       # 클래스 변수 접근

print()

# 두 번째 계산기 인스턴스 생성
cal2 = Calculator(5, 1)
print("=== cal2 (5, 1) ===")
print(f"덧셈: {cal2.add()}")     # 5 + 1 = 6
print(f"뺄셈: {cal2.sub()}")     # 5 - 1 = 4
print(f"곱셈: {cal2.mul()}")     # 5 * 1 = 5
print(f"나눗셈: {cal2.div()}")   # 5 / 1 = 5.0
print(f"PI 값: {cal2.PI}")       # 클래스 변수 접근

# 클래스 변수 변경 - 모든 인스턴스에 영향을 미침
Calculator.PI = 11.1
print("\n클래스 변수 PI를 11.1로 변경 후:")

print("\n=== cal1 (변경 후) ===")
print(f"덧셈: {cal1.add()}")
print(f"뺄셈: {cal1.sub()}")
print(f"곱셈: {cal1.mul()}")
print(f"나눗셈: {cal1.div()}")
print(f"PI 값: {cal1.PI}")  # 변경된 값: 11.1

print("\n=== cal2 (변경 후) ===")
print(f"덧셈: {cal2.add()}")
print(f"뺄셈: {cal2.sub()}")
print(f"곱셈: {cal2.mul()}")
print(f"나눗셈: {cal2.div()}")
print(f"PI 값: {cal2.PI}")  # 변경된 값: 11.1

print()


# ============================================================
# 4. Employee 클래스 - __str__ 메서드와 인스턴스 변수
# ============================================================

class Employee:
    """
    직원을 표현하는 클래스
    __str__ 메서드와 인스턴스별 고유 ID 생성을 보여줌
    """

    def __init__(self, name):
        """
        생성자: 직원 이름을 받아 직원 객체 초기화
        각 인스턴스마다 고유한 사번 생성
        """
        # 인스턴스 변수로 사번 관리 (각 객체마다 독립적)
        self.serial_num = 1000      # 기본 사번
        self.serial_num += 1        # 사번 증가
        self.id = self.serial_num   # 현재 사번을 ID로 설정
        self.name = name            # 직원 이름

    def __str__(self):
        """
        __str__ 메서드: 객체를 문자열로 표현할 때 호출되는 특별한 메서드
        print() 함수나 str() 함수에서 객체를 출력할 때 사용됨
        """
        return f"사번: {self.id}, 이름: {self.name}"


# ============================================================
# Employee 클래스 사용 예제
# ============================================================

print("======= Employee 클래스 예제 ========")

# 직원 인스턴스 생성
emp1 = Employee("김철수")
emp2 = Employee("이영희")

# __str__ 메서드가 자동으로 호출됨
print(emp1)  # "사번: 1001, 이름: 김철수" 출력
print(emp2)  # "사번: 1001, 이름: 이영희" 출력 (각각 독립적인 serial_num)

print()


# ============================================================
# 5. Supermarket 클래스 - 실제 비즈니스 로직 예제
# ============================================================

class Supermarket:
    """
    슈퍼마켓을 표현하는 클래스
    실제 비즈니스 로직을 포함한 메서드들을 보여줌
    """

    def __init__(self, location, name, product, customer):
        """
        생성자: 슈퍼마켓의 기본 정보 초기화

        매개변수:
        - location: 슈퍼마켓 위치
        - name: 슈퍼마켓 이름
        - product: 주요 상품 카테고리
        - customer: 현재 고객 수
        """
        self.location = location    # 위치
        self.name = name           # 마켓 이름
        self.product = product     # 상품 카테고리
        self.customer = customer   # 고객 수

    def print_location(self):
        """위치 정보를 출력하는 메서드"""
        print(f"위치: {self.location}")

    def change_category(self, new_product):
        """
        상품 카테고리를 변경하는 메서드

        매개변수:
        - new_product: 새로운 상품 카테고리
        """
        self.product = new_product
        print(f"상품 카테고리가 '{new_product}'로 변경되었습니다.")

    def show_list(self):
        """현재 상품 카테고리를 출력하는 메서드"""
        print(f"상품: {self.product}")

    def enter_customer(self):
        """
        고객이 입장할 때 호출하는 메서드
        고객 수를 1 증가시킴
        """
        self.customer += 1
        print("고객이 입장하셨습니다.")

    def show_info(self):
        """슈퍼마켓의 모든 정보를 출력하는 메서드"""
        print(f"위치: {self.location}, 이름: {self.name}, "
              f"상품: {self.product}, 고객 수: {self.customer}")


# ============================================================
# Supermarket 클래스 사용 예제
# ============================================================

print("======= Supermarket 클래스 예제 ========")

# 슈퍼마켓 인스턴스 생성
market = Supermarket("마포구", "마켓온", "음료", 12)

print("=== 초기 상태 ===")
market.show_info()  # 초기 정보 출력

print("\n=== 위치 및 상품 정보 ===")
market.print_location()  # 위치 출력
market.show_list()       # 상품 목록 출력

print("\n=== 고객 입장 후 ===")
market.enter_customer()  # 고객 1명 입장
market.show_info()       # 변경된 정보 출력

print("\n=== 상품 카테고리 변경 후 ===")
market.change_category("과자")  # 상품 카테고리 변경
market.show_info()              # 최종 정보 출력


# ============================================================
# 학습 정리
# ============================================================
"""
주요 개념 정리:

1. 클래스(Class): 객체를 만들기 위한 설계도
2. 객체(Object)/인스턴스(Instance): 클래스로부터 생성된 실체
3. 생성자(__init__): 객체 생성 시 자동 호출되는 초기화 메서드
4. self: 현재 인스턴스를 가리키는 참조
5. 인스턴스 변수: 각 객체마다 고유한 변수
6. 클래스 변수: 모든 인스턴스가 공유하는 변수
7. 메서드: 클래스 내부에 정의된 함수
8. 캡슐화: __ (언더스코어 2개)를 사용한 private 변수
9. @property: getter 메서드를 만드는 데코레이터
10. @속성.setter: setter 메서드를 만드는 데코레이터
11. __str__: 객체를 문자열로 표현할 때 사용되는 특별한 메서드
"""
