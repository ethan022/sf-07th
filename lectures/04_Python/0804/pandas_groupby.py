# groupby
# 데이터를 특정 기준으로 그룹을 나누어 집계하는 기능
# 엑셀의 피봇 테이블과 비슷한 개념
# "그룹별로 나누어서 계산하기"

import pandas as pd

# 학생 데이터 생성 (그룹분석을 위한 다양한 기준 포함)
students = pd.DataFrame({
    '이름': ['김철수', '이영희', '박민수', '최지영', '정다운', '홍길동'],
    '학년': [2, 3, 1, 3, 2, 1],          # 그룹 기준 1: 학년
    '반': ['A', 'B', 'A', 'B', 'A', 'B'],  # 그룹 기준 2: 반
    '수학': [85, 92, 78, 96, 83, 88],     # 분석 대상 1: 수학 점수
    '영어': [88, 85, 90, 87, 89, 82],     # 분석 대상 2: 영어 점수
    '과학': [92, 88, 85, 90, 86, 91]      # 분석 대상 3: 과학 점수
})

print("=== 원본 데이터 ===")
print(students)
print()

# 추가: GroupBy는 "분할-적용-결합(Split-Apply-Combine)" 과정을 따릅니다.
# 1) 분할: 데이터를 그룹으로 나누기
# 2) 적용: 각 그룹에 함수 적용하기
# 3) 결합: 결과를 하나로 합치기

print("=== GroupBy 기본 사용법 ===")

# 학년별로 그룹 생성
grade_groups = students.groupby('학년')  # '학년' 열을 기준으로 그룹 나누기
print(f"그룹 개수: {grade_groups.ngroups}")           # 총 몇 개의 그룹이 만들어졌는지
# 어떤 그룹들이 있는지 (1학년, 2학년, 3학년)
print(f"그룹 키들: {list(grade_groups.groups.keys())}")
print()

# 각 그룹에 어떤 데이터가 있는지 확인
print("각 그룹의 인덱스:")
for name, group in grade_groups:  # 각 그룹별로 반복
    print(f"{name}학년: 인덱스 {list(group.index)}")
print()

# 추가: groupby() 결과는 GroupBy 객체로, 아직 계산이 실행되지 않은 상태입니다.
# 실제 계산은 집계 함수(mean, sum 등)를 적용할 때 실행됩니다.

print("=== 기본 집계 함수 ===")

# 학년별 평균 점수 계산
grade_mean = students.groupby('학년')[['수학', '영어', '과학']].mean()  # 숫자 열들의 평균
print("1) 학년별 평균 점수:")
print(grade_mean)
print()

# 학년별 최고 점수 계산
grade_max = students.groupby('학년')[['수학', '영어', '과학']].max()   # 숫자 열들의 최댓값
print("2) 학년별 최고 점수:")
print(grade_max)
print()

# 학년별 학생 수 계산
grade_size = students.groupby('학년').size()  # 각 그룹의 행 개수
print("3) 학년별 학생 수:")
print(grade_size)
print()

# 추가: 주요 집계 함수들
# - .mean(): 평균, .sum(): 합계, .count(): 개수
# - .min(): 최솟값, .max(): 최댓값, .std(): 표준편차
# - .size(): 그룹 크기 (NaN 포함), .count(): 유효한 값의 개수 (NaN 제외)

print("=== agg() 함수로 다중 집계 ===")

# 한 번에 여러 집계 함수 적용
math_stats = students.groupby('반')['수학'].agg([
    'count',    # 개수
    'mean',     # 평균
    'median',   # 중간값
    'std',      # 표준편차
    'min',      # 최솟값
    'max'       # 최댓값
])
print("반별 수학 점수 종합 통계:")
print(math_stats)
print()

# 추가: agg() 함수는 여러 집계 함수를 한 번에 적용할 수 있어 매우 유용합니다.
# 리스트 형태로 함수명을 나열하면 각각 계산되어 열로 표시됩니다.

print("=== 사용자 정의 함수와 함수 이름 변경 ===")

# 사용자 정의 집계 함수 생성


def score_range(scores):
    """점수의 범위(최댓값 - 최솟값)를 계산하는 함수"""
    return scores.max() - scores.min()


# 사용자 정의 함수와 이름 변경 적용
range_stats = students.groupby('학년')['수학'].agg([
    ('평균', 'mean'),           # ('새이름', '함수명') 형태로 이름 변경
    ('범위', score_range),      # 사용자 정의 함수 사용
    ('학생수', 'count'),
])

print("학년별 수학 점수 분석 (사용자 정의 함수 포함):")
print(range_stats)
print()

# 추가: ('새이름', '함수') 튜플 형태로 집계 결과 열의 이름을 원하는 대로 변경할 수 있습니다.
# 사용자 정의 함수를 만들어 특별한 계산도 가능합니다.

print("=== 여러 열에 대한 다른 집계 함수 적용 ===")

# 열마다 다른 집계 함수 적용
multi_agg = students.groupby('반').agg({
    '수학': ['mean', 'max'],        # 수학은 평균과 최댓값
    '영어': ['count', 'min'],       # 영어는 개수와 최솟값
    '과학': 'std'                   # 과학은 표준편차만
})
print("반별 과목 맞춤 분석:")
print(multi_agg)
print()

# 추가: 딕셔너리 형태로 열마다 다른 집계 함수를 적용할 수 있습니다.
# 실무에서는 각 열의 특성에 맞는 분석을 할 때 유용합니다.

print("\n" + "="*50)
print("피봇 테이블 (Pivot Table)")
print("="*50)

# 피봇 테이블
# 복잡한 데이터를 요약, 집계, 분석할 수 있도록 도와주는 도구
# 데이터의 행과 열을 기준으로 그룹을 나눈 뒤
# 그룹별로 합계, 평균, 개수 등 요약된 값을 보여주는 표

print("원본 데이터 (참고):")
print(students)
print()

# 피봇 테이블 생성: 학년(행) × 반(열) 기준으로 최고 점수 표시
pivot_basic = students.pivot_table(
    values=['수학', '영어', '과학'],    # 분석할 값들 (숫자 데이터)
    index='학년',                    # 행(세로) 기준
    columns='반',                    # 열(가로) 기준
    aggfunc='max'                    # 집계 함수 (최댓값)
)

print("피봇 테이블 - 학년별/반별 최고 점수:")
print(pivot_basic)
print()

# 추가: 피봇 테이블은 2차원 교차표 형태로 데이터를 요약합니다.
# index는 행 기준, columns는 열 기준, values는 분석할 데이터, aggfunc는 집계 방법입니다.

# 다른 집계 함수로 피봇 테이블 생성
pivot_mean = students.pivot_table(
    values='수학',                   # 수학 점수만 분석
    index='학년',                    # 행: 학년
    columns='반',                    # 열: 반
    aggfunc='mean',                  # 집계: 평균
    fill_value=0                     # 빈 값은 0으로 채우기
)

print("피봇 테이블 - 학년별/반별 수학 평균 점수:")
print(pivot_mean)
print()

# 추가: fill_value 매개변수로 데이터가 없는 셀의 값을 지정할 수 있습니다.
# 예를 들어, 1학년 B반 학생이 없다면 해당 셀이 비어있는데, 이를 0으로 채울 수 있습니다.

print("\n" + "="*50)
print("실무 예제: 직원 데이터 분석")
print("="*50)

# 실무에서 자주 사용하는 형태의 직원 데이터
employees = pd.DataFrame({
    '이름': ['김대리', '박과장', '이부장', '최사원', '정대리', '한과장', '송사원', '조대리'],
    '부서': ['개발', '영업', '기획', '개발', '인사', '영업', '개발', '기획'],
    '직급': ['대리', '과장', '부장', '사원', '대리', '과장', '사원', '대리'],
    '연봉': [4500, 6000, 8000, 3200, 4200, 5800, 3500, 4800],
    '경력': [3, 8, 15, 1, 5, 7, 2, 6],
    '성별': ['남', '남', '여', '남', '여', '여', '남', '남']
})

print("=== 직원 데이터 ===")
print(employees)
print()

# 추가: 실무 데이터는 보통 여러 기준(부서, 직급, 성별 등)으로 분석이 필요합니다.
# GroupBy를 활용하면 다양한 관점에서 데이터를 분석할 수 있습니다.

print("=== 다양한 관점의 그룹 분석 ===")

# 1. 부서별 평균 연봉
print("1) 부서별 평균 연봉:")
dept_avg_salary = employees.groupby('부서')['연봉'].mean()
print(dept_avg_salary)
print(
    f"가장 높은 평균 연봉 부서: {dept_avg_salary.idxmax()} ({dept_avg_salary.max():.0f}만원)")
print()

# 2. 직급별 직원 수
print("2) 직급별 직원 수:")
position_count = employees.groupby('직급').size()
print(position_count)
print(f"가장 많은 직급: {position_count.idxmax()} ({position_count.max()}명)")
print()

# 3. 부서별 연봉 종합 통계
print("3) 부서별 연봉 종합 통계:")
dept_salary_stats = employees.groupby('부서')['연봉'].agg([
    ('최고연봉', 'max'),
    ('최저연봉', 'min'),
    ('평균연봉', 'mean'),
    ('연봉편차', 'std')
])
print(dept_salary_stats)
print()

# 4. 성별 평균 연봉과 경력
print("4) 성별 평균 연봉과 경력:")
gender_stats = employees.groupby('성별')[['연봉', '경력']].mean()
print(gender_stats)
print()

# 5. 부서와 직급별 평균 연봉 (다중 그룹)
print("5) 부서와 직급별 평균 연봉:")
dept_position_salary = employees.groupby(['부서', '직급'])['연봉'].mean()
print(dept_position_salary)
print()

# 추가: 여러 열을 기준으로 그룹을 나눌 때는 리스트 형태로 전달합니다.
# 결과는 MultiIndex(다중 인덱스) 형태로 나타납니다.

print("=== 피봇 테이블로 복합 분석 ===")

# 부서(행) × 직급(열) 기준으로 평균 연봉 피봇 테이블
salary_pivot = employees.pivot_table(
    values='연봉',           # 분석 대상: 연봉
    index='부서',            # 행 기준: 부서
    columns='직급',          # 열 기준: 직급
    aggfunc='mean',          # 집계: 평균
    fill_value=0             # 빈 값은 0으로 표시
)

print("부서별/직급별 평균 연봉 (피봇 테이블):")
print(salary_pivot)
print()

# 성별 × 부서 기준으로 평균 경력 분석
experience_pivot = employees.pivot_table(
    values='경력',
    index='성별',
    columns='부서',
    aggfunc='mean',
    fill_value=0
)

print("성별/부서별 평균 경력 (피봇 테이블):")
print(experience_pivot)
print()

# 추가: 피봇 테이블은 복잡한 교차 분석을 한눈에 볼 수 있게 해줍니다.
# 행과 열의 교차점에서 특정 조건을 만족하는 데이터의 집계값을 확인할 수 있습니다.

print("\n" + "="*50)
print("GroupBy 고급 활용")
print("="*50)

# 조건부 그룹 분석
print("=== 조건부 그룹 분석 ===")

# 연봉이 5000만원 이상인 고연봉자만 분석
high_salary = employees[employees['연봉'] >= 5000]
high_salary_stats = high_salary.groupby('부서')['경력'].mean()

print("고연봉자(5000만원 이상)의 부서별 평균 경력:")
print(high_salary_stats)
print()

# 여러 조건을 조합한 분석
print("=== 다중 조건 분석 ===")

# 경력 3년 이상이면서 대리급 이상인 직원들의 부서별 평균 연봉
experienced_staff = employees[
    (employees['경력'] >= 3) &
    (employees['직급'].isin(['대리', '과장', '부장']))
]
experienced_stats = experienced_staff.groupby('부서')['연봉'].mean()

print("경력 3년 이상 & 대리급 이상 직원의 부서별 평균 연봉:")
print(experienced_stats)
print()

# 추가: 실무에서는 특정 조건을 만족하는 데이터만 골라서 그룹 분석하는 경우가 많습니다.
# 조건 필터링 후 GroupBy를 적용하면 더 정교한 분석이 가능합니다.

print("=== 그룹별 상위/하위 데이터 선택 ===")

# 각 부서에서 연봉이 가장 높은 직원
top_earners = employees.groupby('부서').apply(
    lambda x: x.loc[x['연봉'].idxmax(), ['이름', '직급', '연봉']]
)

print("각 부서 최고 연봉자:")
print(top_earners)
print()

# 추가: apply() 함수를 사용하면 각 그룹에 복잡한 함수를 적용할 수 있습니다.
# lambda 함수로 각 그룹에서 특정 조건의 행을 선택하는 등 고급 분석이 가능합니다.

print("\n" + "="*50)
print("핵심 정리")
print("="*50)
print("""
GroupBy와 피봇 테이블 핵심 개념:

1. GroupBy 기본 사용법:
   - df.groupby('기준열'): 그룹 생성
   - .mean(), .sum(), .count(), .max(), .min(): 기본 집계
   - .size(): 그룹별 행 개수, .ngroups: 총 그룹 수

2. 다중 집계 (agg):
   - .agg(['함수1', '함수2']): 여러 집계 함수 동시 적용
   - .agg({'열1': '함수1', '열2': '함수2'}): 열별 다른 함수
   - .agg([('새이름', '함수')]): 결과 열 이름 변경

3. 피봇 테이블:
   - pivot_table(values, index, columns, aggfunc)
   - index: 행 기준, columns: 열 기준
   - values: 분석할 데이터, aggfunc: 집계 함수
   - fill_value: 빈 값 채우기

4. 고급 활용:
   - 다중 그룹: groupby(['열1', '열2'])
   - 조건부 분석: 필터링 후 groupby 적용
   - apply(): 복잡한 사용자 정의 함수 적용

5. 실무 팁:
   - 먼저 데이터 구조 파악 후 적절한 그룹 기준 선택
   - 비즈니스 질문에 맞는 집계 함수 사용
   - 피봇 테이블로 교차 분석 결과를 직관적으로 표현

GroupBy는 데이터 분석의 핵심 도구로, 
"~별로 나누어서 ~를 계산하고 싶다"는 모든 분석에 활용됩니다!
""")
