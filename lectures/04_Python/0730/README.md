# Python 필수 라이브러리와 기능

이 폴더는 Python 프로그래밍에 필수적인 표준 라이브러리와 고급 기능들을 학습하는 자료입니다.

## 학습 목표

1. 필수 표준 라이브러리 사용법 습득
2. 파일 입출력 완벽 이해
3. 예외 처리를 통한 안정적인 프로그램 작성
4. enumerate, 데코레이터 등 고급 기능 활용
5. HTTP 요청 처리 기초

## 파일 구성

### 01_Python_Essential_Libraries.py (1.py)
**학습 내용:**
- datetime 라이브러리: 날짜와 시간 처리
- time 라이브러리: 시간 측정과 대기
- math 라이브러리: 수학 함수들
- random 라이브러리: 랜덤 함수들

**주요 기능:**
- 현재 날짜/시간 가져오기
- 날짜 계산 (timedelta)
- 시간 측정 (perf_counter)
- 수학 함수 (sqrt, pow, sin, cos)
- 랜덤 데이터 생성 (randint, choice, shuffle)

**실전 예제:**
- 주사위 게임
- 나이 계산기
- 원의 넓이 계산기
- 랜덤 패스워드 생성기
- 실행 시간 측정 데코레이터

### 02_Python_System_Libraries.py (2.py)
**학습 내용:**
- sys 라이브러리: 시스템 정보와 제어
- os 라이브러리: 운영체제와 상호작용
- json 라이브러리: JSON 데이터 처리

**주요 기능:**
- Python 버전 및 플랫폼 정보
- 명령줄 인수 처리
- 파일/디렉토리 작업
- 환경 변수 접근
- JSON 읽기/쓰기

**실전 예제:**
- 시스템 정보 수집기
- 설정 파일 관리자
- 로그 파일 생성

### 03_Python_File_IO.py (3.py)
**학습 내용:**
- 파일 입출력 기본 개념
- 텍스트 파일 읽기/쓰기
- 파일 경로 (절대 경로 vs 상대 경로)
- 다양한 파일 모드

**주요 기능:**
- open(), read(), write(), close()
- with 문을 사용한 안전한 파일 처리
- readline(), readlines()
- CSV 파일 처리
- JSON 파일 처리

**실전 예제:**
- 학생 성적 관리 시스템
- 로그 파일 기록
- CSV 데이터 읽기/쓰기
- 설정 파일 관리

### 04_Python_Enumerate.py (4.py)
**학습 내용:**
- enumerate() 함수의 개념과 활용
- 인덱스와 값을 동시에 반환
- 시작 인덱스 지정

**주요 예제:**
```python
for i, value in enumerate(fruits, start=5):
    print(f"인덱스: {i}, 값: {value}")
```

### 05_Python_Exception_Handling.py (5.py)
**학습 내용:**
- 예외(Exception)의 개념
- try-except-else-finally 구조
- 주요 예외 타입들
- raise문으로 예외 발생시키기
- 사용자 정의 예외

**주요 예외 타입:**
- ZeroDivisionError: 0으로 나누기 오류
- IndexError: 인덱스 범위 초과
- KeyError: 존재하지 않는 키
- TypeError: 타입 불일치
- ValueError: 잘못된 값
- FileNotFoundError: 파일 없음

**실전 예제:**
- 안전한 계산기 함수
- 나이 유효성 검사
- 사용자 정의 예외 클래스

### 06_Python_HTTP_Request.py (6.py)
**학습 내용:**
- requests 라이브러리 기초
- HTTP GET 요청
- API 호출 기본

**주요 예제:**
```python
import requests
url = "https://koreanjson.com/posts"
res = requests.get(url)
```

## 실행 방법

각 파일을 개별적으로 실행할 수 있습니다:

```bash
python 01_Python_Essential_Libraries.py
python 02_Python_System_Libraries.py
python 03_Python_File_IO.py
python 04_Python_Enumerate.py
python 05_Python_Exception_Handling.py
python 06_Python_HTTP_Request.py
```

## 필요한 패키지

### 표준 라이브러리 (설치 불필요)
```python
import datetime
import time
import math
import random
import sys
import os
import json
```

### 외부 라이브러리 (설치 필요)
```bash
pip install requests
pip install psutil  # 선택 사항 (메모리 정보)
```

## 주요 개념 정리

### 파일 입출력 모드
- `'r'`: 읽기 전용 (파일이 존재해야 함)
- `'w'`: 쓰기 전용 (기존 내용 덮어쓰기)
- `'a'`: 추가 모드 (기존 내용 뒤에 추가)
- `'r+'`: 읽기+쓰기

### with 문의 장점
```python
# 자동으로 파일을 닫아 메모리 누수 방지
with open("file.txt", "r") as f:
    content = f.read()
```

### 예외 처리 구조
```python
try:
    # 예외가 발생할 수 있는 코드
    pass
except 예외타입:
    # 예외 처리 코드
    pass
else:
    # 예외가 발생하지 않았을 때
    pass
finally:
    # 항상 실행되는 코드
    pass
```

### JSON 처리
```python
# Python 객체 → JSON 문자열
json.dumps(data, ensure_ascii=False, indent=2)

# JSON 문자열 → Python 객체
json.loads(json_string)

# JSON 파일 읽기/쓰기
json.dump(data, file)
json.load(file)
```

## 베스트 프랙티스

1. **파일 처리**: 항상 with문 사용
2. **인코딩**: 한글 사용 시 `encoding='utf-8'` 명시
3. **예외 처리**: 중요한 작업에는 try-except 적용
4. **경로 조합**: `os.path.join()` 사용
5. **시간 측정**: `time.perf_counter()` 권장

## 학습 팁

1. 각 라이브러리의 공식 문서 참고하기
2. 실제 파일을 생성하고 읽어보며 연습하기
3. 예외 처리를 다양한 상황에 적용해보기
4. JSON 형식으로 데이터 저장/로드 연습하기

## 참고 자료

- [Python 공식 문서 - 표준 라이브러리](https://docs.python.org/ko/3/library/index.html)
- [Real Python - File I/O](https://realpython.com/read-write-files-python/)
- [Python 예외 처리 가이드](https://docs.python.org/ko/3/tutorial/errors.html)
