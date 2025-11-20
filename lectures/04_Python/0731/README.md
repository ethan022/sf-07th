# NumPy - 수치 계산 라이브러리

이 폴더는 NumPy 라이브러리의 기초부터 고급 활용까지 학습하는 자료입니다.

## 학습 목표

1. NumPy 배열의 개념과 장점 이해
2. 배열 생성과 조작 방법 학습
3. 배열 인덱싱과 슬라이싱 마스터
4. 수학 연산과 통계 함수 활용
5. 브로드캐스팅 개념 이해
6. 실전 데이터 분석 적용

## 파일 구성

### 01_NumPy_Basics_Complete.py (numpy1.py)
**학습 내용:**
- NumPy와 일반 리스트 비교
- 1차원, 2차원 배열 생성
- 배열 인덱싱과 슬라이싱
- 수학 연산과 함수
- 배열 정렬과 집계

**주요 기능:**

#### 1. 배열 생성
```python
# 리스트에서 배열 생성
np.array([1, 2, 3, 4, 5])

# 특정 값으로 채운 배열
np.zeros((2, 3))      # 0으로 채움
np.ones((3, 2))       # 1로 채움
np.arange(1, 10, 2)   # 범위 생성
np.linspace(0, 10, 5) # 균등 분할
```

#### 2. 배열 변형
```python
# 형태 변경
np.reshape(array, (2, 3))
np.resize(array, (3, 5))

# 배열 합치기
np.hstack((arr1, arr2))  # 수평 합치기
np.vstack((arr1, arr2))  # 수직 합치기
np.column_stack((arr1, arr2))  # 열 기준
```

#### 3. 인덱싱과 슬라이싱
```python
# 정수 인덱싱
arr[[1, 1], [2, 2]]  # 특정 위치 선택

# 조건 필터링
arr[arr > 31]        # 31보다 큰 값만
arr[arr % 2 == 0]    # 짝수만
```

#### 4. 수학 연산
```python
# 기본 연산
arr1 + arr2, arr1 - arr2
arr1 * arr2, arr1 / arr2

# 수학 함수
np.sqrt(arr)   # 제곱근
np.log(arr)    # 로그
np.sin(arr)    # 삼각함수
```

#### 5. 브로드캐스팅
```python
# 스칼라와 배열
arr + 10  # 모든 요소에 10 더하기

# 차원이 다른 배열
arr1 (2, 3) + arr2 (3,)  # 자동으로 확장
```

**실전 예제:**

1. **2024 KBO 야구 성적 정렬**
   - 팀별 승, 패, 무, 승률 데이터
   - 승률 기준 내림차순 정렬
   - 텍스트 파일로 저장

2. **학생 성적 관리**
   - 과목별 점수 배열
   - 조건부 선택 및 수정
   - 슬라이싱 연습

3. **매출 데이터 분석**
   - 지점별, 분기별 매출
   - 최고/최저 매출 찾기
   - 조건부 데이터 수정

## 실행 방법

```bash
python 01_NumPy_Basics_Complete.py
```

## 필요한 패키지

```bash
pip install numpy
```

## 주요 개념 정리

### NumPy의 장점
1. **빠른 속도**: C로 구현되어 Python 리스트보다 10~100배 빠름
2. **적은 메모리**: 같은 데이터를 저장할 때 메모리를 덜 사용
3. **벡터 연산**: 반복문 없이 배열 전체에 연산 적용 가능
4. **다양한 함수**: 수학, 통계, 선형대수 등 풍부한 함수

### 배열 vs 리스트
```python
# 리스트: 각 요소를 2배로 만들기
result = []
for num in numbers:
    result.append(num * 2)

# NumPy: 벡터 연산
result = numbers * 2  # 간단하고 빠름!
```

### 브로드캐스팅 규칙
1. 차원의 크기가 1인 배열은 자동으로 확장됨
2. 차원의 개수가 다르면 작은 쪽에 차원 추가
3. 호환되지 않는 차원은 오류 발생

### 슬라이싱 문법
```python
arr[start:end:step]
arr[2:5]    # 인덱스 2부터 4까지
arr[:3]     # 처음부터 2까지
arr[2:]     # 2부터 끝까지
arr[::2]    # 2칸씩 건너뛰기
arr[::-1]   # 역순
```

## 학습 팁

1. **실습 위주**: 직접 배열을 만들고 조작해보기
2. **브로드캐스팅**: 차원을 맞추는 연습 많이 하기
3. **인덱싱**: 다양한 방법으로 데이터 선택 연습
4. **Pandas 연계**: NumPy를 익히면 Pandas가 쉬워짐

## 성능 비교

```python
# 리스트 연산 (느림)
list_result = [x * 2 for x in range(1000000)]

# NumPy 연산 (빠름)
numpy_result = np.arange(1000000) * 2
```

NumPy가 약 10~100배 빠릅니다!

## 다음 단계

NumPy를 익힌 후에는 다음을 학습하세요:
1. **Pandas**: 표 형태 데이터 처리 (NumPy 기반)
2. **Matplotlib**: 데이터 시각화 (NumPy 배열 사용)
3. **SciPy**: 과학 계산 (NumPy 확장)
4. **Scikit-learn**: 머신러닝 (NumPy 배열 사용)

## 참고 자료

- [NumPy 공식 문서](https://numpy.org/doc/stable/)
- [NumPy 퀵스타트 가이드](https://numpy.org/doc/stable/user/quickstart.html)
- [Real Python - NumPy Tutorial](https://realpython.com/numpy-tutorial/)
