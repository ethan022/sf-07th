# Pandas 기초 - 데이터 분석의 시작

이 폴더는 Pandas 라이브러리의 기초인 Series와 DataFrame을 학습하는 자료입니다.

## 학습 목표

1. Series의 개념과 생성 방법 이해
2. DataFrame의 구조와 활용법 마스터
3. 데이터 선택과 필터링 기법 학습
4. loc와 iloc의 차이점 이해
5. 데이터 수정과 추가 방법 습득

## 파일 구성

### 01_Pandas_Series.py (pandas1.py)
**학습 내용:**
- Series의 개념 (1차원 데이터)
- Series 생성 방법 3가지
- 기본 속성과 통계 함수
- 데이터 접근과 필터링

**주요 기능:**

#### 1. Series 생성
```python
# 리스트로 생성
pd.Series([85, 92, 78], index=['김철수', '이영희', '박민수'])

# 딕셔너리로 생성
pd.Series({'A': 90, 'B': 80, 'C': 70})

# NumPy 배열로 생성
pd.Series(np.array([70, 80, 90]))
```

#### 2. 기본 속성
```python
series.values      # 값들 (NumPy 배열)
series.index       # 인덱스
series.size        # 크기
series.dtype       # 데이터 타입
series.name        # Series 이름
```

#### 3. 데이터 접근
```python
series['김철수']              # 단일 값
series[['김철수', '박민수']]  # 여러 값
series[series > 80]          # 조건 필터링
```

#### 4. 통계 함수
```python
series.mean()   # 평균
series.max()    # 최댓값
series.min()    # 최솟값
series.std()    # 표준편차
series.sum()    # 합계
```

**실습 예제:**
1. 과일 가격 데이터 분석
2. 수학 점수 통계 분석

### 02_Pandas_DataFrame.py (pandas2.py)
**학습 내용:**
- DataFrame의 개념 (2차원 표)
- DataFrame 생성 방법 4가지
- 열과 행 선택하기
- loc와 iloc 차이점
- 데이터 수정과 추가

**주요 기능:**

#### 1. DataFrame 생성
```python
# 딕셔너리로 생성
pd.DataFrame({
    '이름': ['철수', '영희'],
    '나이': [20, 21]
})

# 리스트의 리스트로 생성
pd.DataFrame([['철수', 20], ['영희', 21]],
             columns=['이름', '나이'])

# Series들을 합쳐서 생성
pd.DataFrame({'이름': names, '나이': ages})
```

#### 2. 기본 속성
```python
df.shape       # (행, 열) 크기
df.size        # 전체 셀 개수
df.columns     # 열 이름들
df.index       # 행 인덱스
df.dtypes      # 각 열의 타입
df.info()      # 전체 정보
```

#### 3. 데이터 미리보기
```python
df.head()      # 처음 5행
df.tail()      # 마지막 5행
df.describe()  # 기본 통계
```

#### 4. 데이터 선택
```python
# 열 선택
df['이름']           # 단일 열
df[['이름', '나이']]  # 여러 열

# loc: 라벨 기반
df.loc['a']              # 특정 행
df.loc['a':'b']          # 행 범위
df.loc[:, '이름':'나이']  # 열 범위

# iloc: 위치 기반
df.iloc[0]          # 첫 번째 행
df.iloc[0:2]        # 행 범위
df.iloc[:, 0:2]     # 열 범위
```

#### 5. 데이터 수정
```python
# 행 추가
pd.concat([df, new_row], ignore_index=True)

# 열 추가
df['새열'] = [값들]

# 값 수정
df.at[2, 'City'] = '인천'
df.loc[df['이름'] == '김철수', 'City'] = '서울'
```

**실습 예제:**
1. 학생 성적 데이터 분석
2. 상품 정보 관리
3. loc와 iloc 비교 실습

## 실행 방법

```bash
python 01_Pandas_Series.py
python 02_Pandas_DataFrame.py
```

## 필요한 패키지

```bash
pip install pandas numpy
```

## 주요 개념 정리

### Series vs DataFrame
- **Series**: 1차원 데이터 (엑셀의 한 열)
- **DataFrame**: 2차원 표 (엑셀의 전체 시트)

### loc vs iloc
| 구분 | loc | iloc |
|------|-----|------|
| 기준 | 라벨(이름) | 위치(숫자) |
| 사용 | df.loc['a'] | df.iloc[0] |
| 범위 | 끝점 포함 | 끝점 제외 |
| 예시 | df.loc['a':'c'] → a, b, c | df.iloc[0:2] → 0, 1 |

### 불린 인덱싱
```python
# 조건을 만족하는 행만 선택
df[df['나이'] > 20]
df[df['이름'] == '김철수']
df[(df['나이'] > 20) & (df['반'] == 'A')]
```

### DataFrame의 구조
```
      이름  수학  영어  과학
0    철수   85   88   92
1    영희   92   85   88
2    민수   78   90   85
```
- 인덱스(Index): 0, 1, 2 (행 이름)
- 컬럼(Columns): 이름, 수학, 영어, 과학
- 값(Values): 실제 데이터

## 학습 팁

1. **Series부터 시작**: DataFrame은 Series의 모음
2. **인덱스 활용**: 의미있는 인덱스 설정하기
3. **loc/iloc 구분**: 상황에 맞게 선택
4. **조건 필터링**: 비즈니스 로직에 자주 사용
5. **실습 위주**: 실제 데이터로 연습하기

## 실전 활용 패턴

### 1. 데이터 탐색
```python
df.info()        # 전체 구조 파악
df.describe()    # 통계 요약
df.head()        # 샘플 확인
```

### 2. 조건부 선택
```python
# 특정 조건의 데이터만
high_scores = df[df['수학'] >= 90]

# 여러 조건 조합
good_students = df[
    (df['수학'] >= 80) &
    (df['영어'] >= 80)
]
```

### 3. 데이터 요약
```python
# 열별 평균
df.mean()

# 특정 열만
df['수학'].mean()

# 조건부 평균
df[df['반'] == 'A']['수학'].mean()
```

## 다음 단계

Pandas 기초를 익힌 후:
1. **파일 입출력**: CSV, Excel, JSON 처리
2. **GroupBy**: 그룹별 집계 분석
3. **결측값 처리**: 실전 데이터 정제
4. **정렬과 인덱싱**: 데이터 재구조화
5. **시각화**: Matplotlib과 연계

## 참고 자료

- [Pandas 공식 문서](https://pandas.pydata.org/docs/)
- [Pandas 치트시트](https://pandas.pydata.org/Pandas_Cheat_Sheet.pdf)
- [10분 Pandas](https://pandas.pydata.org/docs/user_guide/10min.html)
