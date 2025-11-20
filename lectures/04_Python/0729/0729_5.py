# Person이라는 클래스를 정의합니다.
class Person:
    # 생성자 메서드입니다. 객체가 생성될 때 이름(name)과 나이(age)를 받습니다.
    def __init__(self, name, age):
        self.name = name  # 객체의 이름 속성에 name 값을 저장합니다.
        self.age = age    # 객체의 나이 속성에 age 값을 저장합니다.

    # 클래스 메서드: 인스턴스를 생성하는 또 다른 방법을 제공합니다.
    @classmethod
    def from_birth_year(cls, name, birth_year):
        # 현재 연도(2025)에서 태어난 해를 빼서 나이를 계산합니다.
        age = 2025 - birth_year
        # cls는 현재 클래스를 가리킵니다. cls(name, age)는 Person(name, age)와 같습니다.
        return cls(name, age)


# 클래스 메서드를 사용해 객체를 생성합니다.
p = Person.from_birth_year("홍길동", 1980)
# 이름과 나이를 출력합니다.
print(p.name, p.age)  # 출력: 홍길동 45


# 일반 함수: 클래스와 상관없이 사용할 수 있는 독립적인 함수입니다.
def add(a, b):
    return a + b  # 두 수를 더해서 반환


def mul(a, b):
    return a * b  # 두 수를 곱해서 반환


# MathUtils 클래스는 수학 관련 기능을 모아놓은 클래스입니다.
class MathUtils:
    # 정적 메서드(static method)는 객체를 생성하지 않고도 사용할 수 있는 메서드입니다.
    @staticmethod
    def add(a, b):
        return a + b  # 클래스 이름으로 바로 호출 가능

    @staticmethod
    def mul(a, b):
        return a * b


# MathUtils의 정적 메서드를 사용한 예시
print(MathUtils.add(1, 2))  # 출력: 3
print(MathUtils.mul(1, 2))  # 출력: 2

# 일반 함수로 연산한 결과
print(add(1, 2))  # 출력: 3
print(mul(1, 2))  # 출력: 2
