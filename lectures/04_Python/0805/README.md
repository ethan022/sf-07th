# Matplotlib - 데이터 시각화

이 폴더는 Matplotlib 라이브러리를 사용한 데이터 시각화 기법을 학습하는 자료입니다.

## 학습 목표

1. Matplotlib의 기본 사용법 이해
2. 다양한 그래프 유형 마스터
3. 그래프 커스터마이징 기법 습득
4. 비즈니스 데이터 시각화 적용
5. 실전 데이터 분석 스토리텔링

## 파일 구성

### 01_Matplotlib_Basics.py (matplotlib1.py)
**학습 내용:**
- Matplotlib 기본 개념
- 선 그래프 그리기
- 서브플롯 배치
- 그래프 스타일링

**주요 기능:**

#### 1. 기본 구조
```python
plt.figure(figsize=(10, 6))    # 그래프 창 생성
plt.plot(x, y)                 # 선 그래프
plt.title('제목')              # 제목
plt.xlabel('x축 라벨')         # x축 라벨
plt.ylabel('y축 라벨')         # y축 라벨
plt.grid(True)                 # 격자 표시
plt.legend()                   # 범례
plt.show()                     # 화면에 표시
```

#### 2. 서브플롯
```python
plt.subplot(2, 2, 1)  # 2행 2열의 1번째
plt.plot(x, y)

plt.subplot(2, 2, 2)  # 2행 2열의 2번째
plt.plot(x, y2)
```

#### 3. 스타일링
```python
# 축약 표기
plt.plot(x, y, 'ro--')  # 빨강, 원형 마커, 점선

# 개별 옵션
plt.plot(x, y,
         marker='o',       # 마커
         markersize=8,     # 마커 크기
         linewidth=2,      # 선 두께
         color='blue',     # 색상
         alpha=0.7)        # 투명도
```

**실습 예제:**
- 제곱값 그래프
- 삼각함수 그래프
- 다양한 스타일 비교

### 02_Matplotlib_Bar_Charts.py (matplotlib2.py)
**학습 내용:**
- 세로/가로 막대 그래프
- 그룹별 막대 그래프
- 막대 그래프 커스터마이징

**주요 기능:**

#### 1. 기본 막대 그래프
```python
# 세로 막대
plt.bar(categories, values,
        color='skyblue',
        edgecolor='black')

# 가로 막대
plt.barh(categories, values)
```

#### 2. 값 표시하기
```python
for i, val in enumerate(values):
    plt.text(i, val + 1, str(val),
             ha='center')
```

#### 3. 그룹별 비교
```python
x = np.arange(len(categories))
width = 0.35

plt.bar(x - width/2, values1, width, label='2020')
plt.bar(x + width/2, values2, width, label='2021')
```

**실습 예제:**
- 월별 매출 분석
- 색상별 구분
- 평균선 추가

### 03_Matplotlib_Scatter_Plots.py (matplotlib3.py)
**학습 내용:**
- 산점도 기본 개념
- 상관관계 분석
- 3차원 정보 표현
- 불리언 마스킹 활용

**주요 기능:**

#### 1. 기본 산점도
```python
plt.scatter(x, y,
            c='blue',        # 색상
            s=60,            # 크기
            marker='o',      # 마커
            alpha=0.7)       # 투명도
```

#### 2. 그룹별 구분
```python
for group, color in [('A', 'blue'), ('B', 'red')]:
    mask = data['group'] == group
    plt.scatter(x[mask], y[mask],
                c=color, label=group)
```

#### 3. 3차원 정보 표현
```python
plt.scatter(x, y,
            c=colors,        # 카테고리별 색상
            s=sizes * 20,    # 값에 비례한 크기
            alpha=0.7)
```

**실습 예제:**
- 고객 나이 vs 구매액
- 카페 지점별 성과 분석
- 온라인 쇼핑몰 분석

### 04_Matplotlib_Histograms.py (matplotlib4.py)
**학습 내용:**
- 히스토그램 기본 개념
- 데이터 분포 분석
- bin 개수 선택 방법
- 그룹 비교

**주요 기능:**

#### 1. 기본 히스토그램
```python
n, bins, patches = plt.hist(
    data,
    bins=10,              # 구간 개수
    color='lightblue',
    edgecolor='black',
    alpha=0.7
)
```

#### 2. 통계선 추가
```python
mean = np.mean(data)
plt.axvline(mean, color='red',
            linestyle='--',
            label=f'평균: {mean:.1f}')
```

#### 3. 그룹 비교
```python
plt.hist([data1, data2],
         bins=20,
         color=['blue', 'red'],
         label=['그룹1', '그룹2'],
         alpha=0.7)
```

**실습 예제:**
- 학생 키 분포
- 시험 점수 분석
- 구매액 분포 (치우친 분포)

## 실행 방법

```bash
python 01_Matplotlib_Basics.py
python 02_Matplotlib_Bar_Charts.py
python 03_Matplotlib_Scatter_Plots.py
python 04_Matplotlib_Histograms.py
```

## 필요한 패키지

```bash
pip install matplotlib numpy
```

## 주요 개념 정리

### 그래프 유형 선택 가이드

| 목적 | 그래프 유형 |
|------|------------|
| 시간에 따른 변화 | 선 그래프 |
| 카테고리별 비교 | 막대 그래프 |
| 두 변수의 관계 | 산점도 |
| 데이터 분포 | 히스토그램 |
| 비율 표시 | 원 그래프 |
| 범위와 중앙값 | 상자 그림 |

### 색상 지정 방법
```python
# 1. 영어명
color='red'

# 2. 축약형
color='r'

# 3. 헥스 코드
color='#FF0000'

# 4. RGB 튜플
color=(1.0, 0.0, 0.0)
```

### 마커 스타일
- `'o'`: 원
- `'s'`: 사각형
- `'^'`: 삼각형
- `'*'`: 별
- `'+'`: 플러스
- `'x'`: 엑스

### 선 스타일
- `'-'`: 실선
- `'--'`: 점선
- `':'`: 점점선
- `'-.'`: 일점쇄선

## 학습 팁

1. **목적 우선**: 어떤 인사이트를 전달할지 먼저 생각
2. **단순함**: 복잡한 것보다 명확한 것이 좋음
3. **색상 일관성**: 의미있는 색상 선택
4. **라벨 필수**: 제목, 축 라벨, 범례 꼭 포함
5. **실습**: 실제 데이터로 많이 그려보기

## 실전 활용 패턴

### 1. 시계열 데이터 시각화
```python
plt.figure(figsize=(12, 6))
plt.plot(dates, values, marker='o')
plt.title('월별 매출 추이')
plt.xlabel('날짜')
plt.ylabel('매출 (만원)')
plt.xticks(rotation=45)
plt.grid(True, alpha=0.3)
plt.tight_layout()
plt.show()
```

### 2. 상관관계 분석
```python
plt.figure(figsize=(10, 8))
plt.scatter(x, y, alpha=0.6)
plt.title('광고비 vs 매출')
plt.xlabel('광고비 (만원)')
plt.ylabel('매출 (만원)')
plt.grid(True, alpha=0.3)

# 추세선 추가
z = np.polyfit(x, y, 1)
p = np.poly1d(z)
plt.plot(x, p(x), "r--", alpha=0.8)
plt.show()
```

### 3. 분포 분석
```python
plt.figure(figsize=(10, 6))
plt.hist(data, bins=30, alpha=0.7, edgecolor='black')
plt.axvline(np.mean(data), color='r', linestyle='--',
            label=f'평균: {np.mean(data):.1f}')
plt.axvline(np.median(data), color='b', linestyle=':',
            label=f'중앙값: {np.median(data):.1f}')
plt.title('고객 나이 분포')
plt.xlabel('나이')
plt.ylabel('빈도')
plt.legend()
plt.show()
```

## 한글 폰트 설정

모든 파일에 다음 코드가 포함되어 있습니다:
```python
plt.rcParams['font.family'] = ['DejaVu Sans', 'Malgun Gothic']
plt.rcParams['axes.unicode_minus'] = False
```

Mac 사용자는 'AppleGothic'으로 변경할 수 있습니다.

## 그래프 저장

```python
# 파일로 저장
plt.savefig('graph.png', dpi=300, bbox_inches='tight')

# 다양한 형식
plt.savefig('graph.pdf')  # PDF
plt.savefig('graph.svg')  # SVG (벡터)
```

## 다음 단계

Matplotlib 기초를 익힌 후:
1. **Seaborn**: 통계 시각화 (Matplotlib 기반)
2. **Plotly**: 인터랙티브 그래프
3. **대시보드**: Streamlit, Dash 활용
4. **지도 시각화**: Folium, Geopandas

## 참고 자료

- [Matplotlib 공식 문서](https://matplotlib.org/stable/contents.html)
- [Matplotlib 갤러리](https://matplotlib.org/stable/gallery/index.html)
- [Matplotlib 치트시트](https://github.com/matplotlib/cheatsheets)
