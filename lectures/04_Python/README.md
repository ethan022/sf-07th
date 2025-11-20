# 04_Python - Python 데이터 분석 완전 학습 자료

Python 프로그래밍의 기초부터 데이터 분석, 시각화까지 체계적으로 학습할 수 있는 자료입니다.

## 전체 구성

```
04_Python/
├── 0729/    # Python 기초 - 클래스와 객체지향 프로그래밍
├── 0730/    # Python 필수 라이브러리와 기능
├── 0731/    # NumPy - 수치 계산 라이브러리
├── 0801/    # Pandas 기초 - Series와 DataFrame
├── 0804/    # Pandas 고급 - 데이터 정제와 분석
└── 0805/    # Matplotlib - 데이터 시각화
```

## 학습 로드맵

### 1단계: Python 기초 (0729)
**예상 학습 시간: 2-3일**

객체지향 프로그래밍의 핵심 개념을 학습합니다.

- 클래스와 객체의 개념
- 상속과 다형성
- 추상 클래스와 인터페이스
- 캡슐화와 접근 제어자

**학습 포인트:**
- 실생활 객체를 클래스로 모델링하는 연습
- 상속을 통한 코드 재사용
- @property, @classmethod, @staticmethod 이해

### 2단계: Python 필수 라이브러리 (0730)
**예상 학습 시간: 2-3일**

실전 프로그래밍에 필수적인 표준 라이브러리를 마스터합니다.

- datetime, time: 날짜/시간 처리
- math, random: 수학 연산
- sys, os: 시스템 제어
- json: 데이터 직렬화
- 파일 입출력
- 예외 처리

**학습 포인트:**
- with문을 활용한 안전한 파일 처리
- try-except로 안정적인 프로그램 작성
- JSON 형식으로 데이터 저장/로드

### 3단계: NumPy (0731)
**예상 학습 시간: 2-3일**

빠른 수치 계산을 위한 NumPy를 학습합니다.

- 배열 생성과 조작
- 인덱싱과 슬라이싱
- 수학 연산과 통계 함수
- 브로드캐스팅

**학습 포인트:**
- Python 리스트 대비 10-100배 빠른 속도
- 벡터 연산으로 간결한 코드 작성
- Pandas의 기초가 되는 개념

### 4단계: Pandas 기초 (0801)
**예상 학습 시간: 3-4일**

데이터 분석의 핵심 도구인 Pandas를 시작합니다.

- Series: 1차원 데이터
- DataFrame: 2차원 표 데이터
- loc와 iloc
- 데이터 선택과 필터링

**학습 포인트:**
- Series는 DataFrame의 한 열
- loc(라벨 기반) vs iloc(위치 기반)
- 불린 인덱싱으로 조건부 선택

### 5단계: Pandas 고급 (0804)
**예상 학습 시간: 4-5일**

실전 데이터 분석 기술을 익힙니다.

- 파일 입출력 (CSV, JSON)
- GroupBy 집계 분석
- 피봇 테이블
- 결측값과 중복 처리
- 데이터 정렬

**학습 포인트:**
- GroupBy의 Split-Apply-Combine 패턴
- 결측값 처리 전략
- 실전 데이터 정제 파이프라인

### 6단계: Matplotlib (0805)
**예상 학습 시간: 3-4일**

데이터를 시각적으로 표현하는 방법을 학습합니다.

- 선 그래프, 막대 그래프
- 산점도, 히스토그램
- 그래프 커스터마이징
- 실전 비즈니스 시각화

**학습 포인트:**
- 목적에 맞는 그래프 선택
- 색상과 스타일로 의미 전달
- 데이터 스토리텔링

## 빠른 시작

### 환경 설정

```bash
# 필요한 패키지 설치
pip install numpy pandas matplotlib requests openpyxl
```

### 폴더별 학습 순서

```bash
# 1. 0729 폴더에서 시작
cd 0729
python 01_Python_Class_Basics.py
python 02_Python_Inheritance.py
# ... 순서대로 실행

# 2. 다음 폴더로 이동
cd ../0730
python 01_Python_Essential_Libraries.py
# ...
```

## 각 폴더의 상세 내용

### 0729 - Python 기초
- 5개 파일: 클래스부터 클래스 메서드까지
- 실습 예제: 비즈니스 로직, 상속 관계
- [상세 README.md](./0729/README.md)

### 0730 - Python 필수 라이브러리
- 6개 파일: 표준 라이브러리와 고급 기능
- 실습 예제: 파일 처리, 예외 처리, HTTP 요청
- [상세 README.md](./0730/README.md)

### 0731 - NumPy
- 1개 파일: NumPy 완전 가이드
- 실습 예제: 야구 성적, 매출 데이터
- [상세 README.md](./0731/README.md)

### 0801 - Pandas 기초
- 2개 파일: Series와 DataFrame
- 실습 예제: 성적 관리, 상품 정보
- [상세 README.md](./0801/README.md)

### 0804 - Pandas 고급
- 4개 파일: 파일 IO, GroupBy, 결측값, 정렬
- 실습 예제: 도서관 시스템, 직원 분석
- [상세 README.md](./0804/README.md)

### 0805 - Matplotlib
- 4개 파일: 선, 막대, 산점도, 히스토그램
- 실습 예제: 매출 분석, 고객 분석
- [상세 README.md](./0805/README.md)

## 학습 가이드

### 효과적인 학습 방법

1. **순서대로 학습**
   - 각 폴더는 이전 내용을 기반으로 구성됨
   - 건너뛰지 말고 순서대로 진행

2. **실습 중심**
   - 코드를 읽기만 하지 말고 직접 실행
   - 파라미터를 바꿔가며 결과 확인
   - 에러를 만나면 직접 해결 시도

3. **주석 활용**
   - 모든 파일에 상세한 한글 주석 포함
   - 개념, 문법, 실전 팁 모두 설명

4. **자신만의 예제**
   - 학습한 내용을 응용한 코드 작성
   - 실생활 문제를 코드로 해결

5. **복습과 정리**
   - 각 폴더의 README.md로 핵심 개념 복습
   - 모르는 부분은 반복 학습

### 프로젝트 제안

학습 완료 후 시도해볼 프로젝트:

1. **개인 가계부 분석기**
   - CSV로 지출 기록
   - Pandas로 월별/카테고리별 분석
   - Matplotlib로 시각화

2. **학급 성적 관리 시스템**
   - 학생 정보와 성적 관리
   - 통계 분석 (평균, 표준편차 등)
   - 성적 분포 그래프

3. **날씨 데이터 분석**
   - 공공 API에서 데이터 수집
   - 시계열 데이터 분석
   - 기온 변화 시각화

4. **주식 데이터 분석**
   - yfinance로 주가 데이터 수집
   - 이동평균선 계산
   - 캔들스틱 차트

## 문제 해결

### 자주 발생하는 오류

#### 1. 한글 깨짐
```python
# 파일 읽기 시
pd.read_csv('file.csv', encoding='utf-8')

# 그래프에서
plt.rcParams['font.family'] = 'Malgun Gothic'
```

#### 2. 패키지 없음
```bash
# 개별 설치
pip install 패키지명

# 일괄 설치
pip install numpy pandas matplotlib
```

#### 3. 파일 경로 오류
```python
# 절대 경로 사용 권장
import os
file_path = os.path.join(os.getcwd(), 'data.csv')
```

## 추가 학습 자료

### 공식 문서
- [Python 공식 문서](https://docs.python.org/ko/3/)
- [NumPy 공식 문서](https://numpy.org/doc/stable/)
- [Pandas 공식 문서](https://pandas.pydata.org/docs/)
- [Matplotlib 공식 문서](https://matplotlib.org/stable/contents.html)

### 온라인 강의
- [Kaggle Learn](https://www.kaggle.com/learn)
- [DataCamp](https://www.datacamp.com/)
- [Real Python](https://realpython.com/)

### 실습 플랫폼
- [LeetCode](https://leetcode.com/) - 알고리즘 문제
- [Kaggle](https://www.kaggle.com/) - 데이터 분석 대회
- [HackerRank](https://www.hackerrank.com/) - Python 문제

## 라이선스 및 저작권

이 자료는 교육 목적으로 작성되었습니다.

## 기여 및 피드백

개선 사항이나 오류를 발견하시면 이슈를 등록해주세요.

---

**학습을 시작하기 전에:**
- [ ] Python 3.7 이상 설치 확인
- [ ] 필요한 패키지 설치 완료
- [ ] 코드 에디터 준비 (VS Code 추천)
- [ ] 학습 계획 수립

**학습 완료 체크리스트:**
- [ ] 0729 - Python 기초 완료
- [ ] 0730 - 필수 라이브러리 완료
- [ ] 0731 - NumPy 완료
- [ ] 0801 - Pandas 기초 완료
- [ ] 0804 - Pandas 고급 완료
- [ ] 0805 - Matplotlib 완료
- [ ] 개인 프로젝트 1개 완성

좋은 학습 되세요!
