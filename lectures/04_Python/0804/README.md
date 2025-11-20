# Pandas 고급 - 데이터 정제와 분석

이 폴더는 Pandas의 고급 기능인 파일 입출력, GroupBy, 결측값 처리, 정렬을 학습하는 자료입니다.

## 학습 목표

1. CSV, JSON 파일 읽기/쓰기
2. GroupBy를 통한 그룹별 분석
3. 피봇 테이블 생성과 활용
4. 결측값과 중복 데이터 처리
5. 데이터 정렬과 순위 매기기

## 파일 구성

### 01_Pandas_File_IO.py (pandas_file.py)
**학습 내용:**
- CSV 파일 읽기/쓰기
- JSON 파일 처리
- 다양한 파일 형식 다루기
- 파일 입출력 옵션 활용

**주요 기능:**

#### 1. CSV 파일 처리
```python
# 읽기
df = pd.read_csv('file.csv',
                 encoding='utf-8',
                 sep=',',
                 na_values=['N/A', '없음'])

# 쓰기
df.to_csv('output.csv',
          index=False,
          encoding='utf-8')
```

#### 2. JSON 파일 처리
```python
# 읽기
df = pd.read_json('file.json')

# 쓰기
df.to_json('output.json',
           orient='records',
           force_ascii=False)
```

#### 3. 읽기 최적화
```python
# 특정 열만 읽기
df = pd.read_csv('file.csv', usecols=['이름', '점수'])

# 일부 행만 읽기
df = pd.read_csv('file.csv', nrows=100)

# 청크 단위 읽기 (대용량 파일)
for chunk in pd.read_csv('file.csv', chunksize=1000):
    process(chunk)
```

**실전 예제:**
- 도서관 관리 시스템
- 분야별 통계 분석
- 다양한 파일 형식 저장

### 02_Pandas_GroupBy.py (pandas_groupby.py)
**학습 내용:**
- GroupBy의 개념과 활용
- 집계 함수 사용법
- 피봇 테이블 생성
- 다중 그룹 분석

**주요 기능:**

#### 1. 기본 GroupBy
```python
# 그룹 생성
grouped = df.groupby('학년')

# 집계 함수 적용
grouped.mean()     # 평균
grouped.sum()      # 합계
grouped.count()    # 개수
grouped.max()      # 최댓값
```

#### 2. agg() 다중 집계
```python
# 여러 함수 동시 적용
df.groupby('반')['수학'].agg([
    'count', 'mean', 'median', 'std'
])

# 사용자 정의 함수
df.groupby('학년')['수학'].agg([
    ('평균', 'mean'),
    ('범위', lambda x: x.max() - x.min())
])
```

#### 3. 피봇 테이블
```python
# 피봇 테이블 생성
pd.pivot_table(
    df,
    values='매출',     # 분석할 값
    index='지역',      # 행 기준
    columns='분기',    # 열 기준
    aggfunc='sum'     # 집계 함수
)
```

**실전 예제:**
- 학생 성적 그룹 분석
- 직원 데이터 부서별 분석
- 매출 데이터 피봇 테이블

### 03_Pandas_Missing_Value.py (pandas_missing_value.py)
**학습 내용:**
- 결측값 확인과 처리
- 중복 데이터 제거
- 데이터 정제 프로세스

**주요 기능:**

#### 1. 결측값 확인
```python
df.isnull()           # 결측값 위치 (True/False)
df.isnull().sum()     # 열별 결측값 개수
df.notnull()          # 결측값이 아닌 위치
```

#### 2. 결측값 처리
```python
# 행/열 제거
df.dropna()                    # 결측값 있는 행 제거
df.dropna(subset=['수학'])     # 특정 열 기준
df.dropna(how='all')           # 모두 결측값인 행만

# 값으로 채우기
df.fillna(0)                   # 0으로 채우기
df.fillna(df.mean())           # 평균으로
df.fillna({
    '나이': df['나이'].median(),
    '이름': '알 수 없음'
})
```

#### 3. 중복 데이터 처리
```python
# 중복 확인
df.duplicated()                # 중복 행 (True/False)

# 중복 제거
df.drop_duplicates()           # 완전 중복 제거
df.drop_duplicates(
    subset=['이름'],           # 이름 기준
    keep='first'               # 첫 번째 유지
)
```

**실전 예제:**
- 단계별 데이터 정리
- 고객 데이터 정제

### 04_Pandas_Sorting.py (pandas_sort.py)
**학습 내용:**
- 값 기준 정렬
- 인덱스 기준 정렬
- 다중 열 정렬
- 순위 매기기

**주요 기능:**

#### 1. 값 기준 정렬
```python
# 단일 열 정렬
df.sort_values('수학')                # 오름차순
df.sort_values('수학', ascending=False) # 내림차순

# 다중 열 정렬
df.sort_values(['학년', '수학'])
df.sort_values(['학년', '수학'],
               ascending=[True, False])
```

#### 2. 인덱스 정렬
```python
df.sort_index()           # 행 인덱스 정렬
df.sort_index(axis=1)     # 열 이름 정렬
```

#### 3. 인덱스 활용
```python
# 열을 인덱스로
df.set_index('이름')

# 인덱스를 열로
df.reset_index()
```

#### 4. 상위/하위 선택
```python
df.nlargest(3, '수학')    # 상위 3개
df.nsmallest(3, '수학')   # 하위 3개
```

**실전 예제:**
- 성적 순위 매기기
- 학년별 정렬
- 이름 기반 조회 시스템

## 실행 방법

```bash
python 01_Pandas_File_IO.py
python 02_Pandas_GroupBy.py
python 03_Pandas_Missing_Value.py
python 04_Pandas_Sorting.py
```

## 필요한 패키지

```bash
pip install pandas numpy openpyxl
```

## 주요 개념 정리

### GroupBy의 Split-Apply-Combine
1. **Split**: 데이터를 그룹으로 분할
2. **Apply**: 각 그룹에 함수 적용
3. **Combine**: 결과를 하나로 결합

```python
df.groupby('학년')['수학'].mean()
# 1. 학년별로 분할
# 2. 각 그룹의 수학 평균 계산
# 3. 결과를 하나의 Series로 결합
```

### 피봇 테이블 vs GroupBy
- **GroupBy**: 유연한 그룹 분석
- **피봇 테이블**: 2차원 교차표 형태로 요약

### 결측값 처리 전략
1. **삭제**: 데이터가 충분할 때
2. **대체**: 평균, 중앙값, 최빈값으로
3. **예측**: 머신러닝으로 추정
4. **무시**: 분석에 영향 없을 때

### 파일 인코딩
- `utf-8`: 일반적인 유니코드 (권장)
- `cp949`: Windows 한글
- `euc-kr`: 구형 한글 시스템

## 학습 팁

1. **GroupBy 마스터**: 실전에서 가장 많이 사용
2. **결측값 주의**: 항상 데이터 정제 후 분석
3. **인덱스 활용**: 의미있는 인덱스로 검색 최적화
4. **파일 저장**: 분석 단계마다 중간 결과 저장

## 실전 활용 패턴

### 1. 데이터 정제 파이프라인
```python
# 1단계: 빈 행 제거
df = df.dropna(how='all')

# 2단계: 핵심 열 결측값 제거
df = df.dropna(subset=['ID'])

# 3단계: 중복 제거
df = df.drop_duplicates(subset=['ID'])

# 4단계: 결측값 채우기
df['나이'] = df['나이'].fillna(df['나이'].median())
```

### 2. 그룹별 분석
```python
# 부서별 평균 연봉
df.groupby('부서')['연봉'].mean()

# 부서+직급별 통계
df.groupby(['부서', '직급'])['연봉'].agg([
    '최고', 'max'),
    ('최저', 'min'),
    ('평균', 'mean')
])
```

### 3. 파일 작업 흐름
```python
# 읽기
df = pd.read_csv('input.csv', encoding='utf-8')

# 분석 및 처리
result = df.groupby('카테고리')['매출'].sum()

# 저장
result.to_csv('result.csv', encoding='utf-8', index=False)
```

## 성능 최적화

1. **대용량 파일**: chunksize 사용
2. **필요한 열만**: usecols 지정
3. **데이터 타입**: dtype 명시로 메모리 절약
4. **인덱스 활용**: 자주 조회하는 열을 인덱스로

## 참고 자료

- [Pandas GroupBy 공식 문서](https://pandas.pydata.org/docs/user_guide/groupby.html)
- [Pandas 결측값 처리](https://pandas.pydata.org/docs/user_guide/missing_data.html)
- [Pandas I/O 도구](https://pandas.pydata.org/docs/user_guide/io.html)
