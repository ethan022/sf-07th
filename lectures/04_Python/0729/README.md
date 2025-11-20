# Python 기초 - 클래스와 객체지향 프로그래밍

이 폴더는 Python의 객체지향 프로그래밍(OOP) 기초를 학습하는 자료입니다.

## 학습 목표

1. 클래스와 객체의 개념 이해
2. 생성자와 소멸자 사용법 학습
3. 캡슐화와 접근 제어자 이해
4. 상속과 다형성 개념 파악
5. 추상 클래스와 추상 메서드 활용
6. 클래스 메서드와 정적 메서드 구분

## 파일 구성

### 01_Python_Class_Basics.py (0729_1.py)
**학습 내용:**
- 클래스 정의와 객체 생성
- 생성자 `__init__` 메서드
- 소멸자 `__del__` 메서드
- @property와 @setter 데코레이터
- 클래스 변수 vs 인스턴스 변수
- `__str__` 메서드 오버라이딩

**주요 예제:**
- Car 클래스: 캡슐화와 property 사용
- Person 클래스: 생성자와 소멸자
- Calculator 클래스: 클래스 변수 활용
- Employee 클래스: 문자열 표현
- Supermarket 클래스: 비즈니스 로직

### 02_Python_Inheritance.py (0729_2.py)
**학습 내용:**
- 상속의 기본 개념
- 단일 상속과 다중 상속
- 메서드 오버라이딩
- super() 함수 사용법
- protected 변수 (_변수명)

**주요 예제:**
- Animal 부모 클래스
- Dog 클래스: 다중 상속 예제
- Cat, Bird 클래스: 단일 상속 예제

### 03_Python_Product_Classes.py (0729_3.py)
**학습 내용:**
- 실전 클래스 설계
- 날짜 비교와 유효성 검사
- 상속을 통한 기능 확장

**주요 예제:**
- Product 기본 클래스
- Electronic 자식 클래스
- Food 클래스: 날짜 처리

### 04_Python_Abstract_Classes.py (0729_4.py)
**학습 내용:**
- 추상 클래스 개념
- abc 모듈 사용법
- @abstractmethod 데코레이터
- 인터페이스 구현

**주요 예제:**
- PaymentSystem 추상 클래스
- CreditCard 구현 클래스

### 05_Python_Class_Methods.py (0729_5.py)
**학습 내용:**
- @classmethod 데코레이터
- @staticmethod 데코레이터
- 클래스 메서드 vs 정적 메서드 vs 인스턴스 메서드

**주요 예제:**
- Person 클래스: from_birth_year 클래스 메서드
- MathUtils 클래스: 정적 메서드 활용

## 실행 방법

각 파일을 개별적으로 실행할 수 있습니다:

```bash
python 01_Python_Class_Basics.py
python 02_Python_Inheritance.py
python 03_Python_Product_Classes.py
python 04_Python_Abstract_Classes.py
python 05_Python_Class_Methods.py
```

## 필요한 패키지

표준 라이브러리만 사용하므로 추가 패키지 설치가 필요 없습니다.

```python
import datetime  # 날짜 처리 (표준 라이브러리)
from abc import ABC, abstractmethod  # 추상 클래스 (표준 라이브러리)
```

## 주요 개념 정리

### 클래스 vs 객체
- **클래스**: 객체를 만들기 위한 설계도 (붕어빵 틀)
- **객체**: 클래스로부터 생성된 실체 (실제 붕어빵)

### 캡슐화
- `_변수명`: protected (관례적, 내부/상속 클래스에서 사용)
- `__변수명`: private (관례적, 클래스 내부에서만 사용)

### 상속
- 기존 클래스의 속성과 메서드를 새 클래스가 물려받음
- 코드 재사용성 증가
- `super()`: 부모 클래스 접근

### 메서드 종류
1. **인스턴스 메서드**: 객체마다 다르게 동작, `self` 사용
2. **클래스 메서드**: 클래스 전체에 영향, `@classmethod`, `cls` 사용
3. **정적 메서드**: 독립적인 함수, `@staticmethod`, `self`/`cls` 없음

## 학습 팁

1. 각 파일의 주석을 꼼꼼히 읽으며 실행하기
2. 코드를 직접 수정해보며 결과 확인하기
3. 자신만의 클래스를 설계해보기
4. 실생활의 객체를 클래스로 모델링해보기

## 참고 자료

- [Python 공식 문서 - 클래스](https://docs.python.org/ko/3/tutorial/classes.html)
- [Python OOP 개념](https://realpython.com/python3-object-oriented-programming/)
