# Pandas 정렬(Sorting)과 인덱싱(Indexing)
# 데이터를 원하는 순서로 정렬하고, 효율적으로 접근하는 방법
# 엑셀의 정렬 기능과 비슷하지만 더 강력한 기능 제공

import pandas as pd

# 학생 데이터 생성
students = pd.DataFrame({
    '이름': ['김철수', '이영희', '박민수', '최지영', '정다운'],
    '수학': [85, 92, 78, 96, 83],
    '영어': [88, 85, 90, 87, 89],
    '나이': [20, 21, 19, 22, 20]
})

print("=== 원본 데이터 ===")
print(students)
print()

# 추가: 정렬은 데이터 분석에서 매우 중요한 기능입니다.
# 상위/하위 데이터 찾기, 패턴 파악, 순위 매기기 등에 활용됩니다.

print("=== 열 기준 정렬 (sort_values) ===")

# 단일 열 기준 오름차순 정렬
math_asc = students.sort_values('수학')  # 기본값: ascending=True (오름차순)
print("1) 수학 점수 오름차순 (낮은 점수부터):")
print(math_asc)
print()

# 단일 열 기준 내림차순 정렬
math_desc = students.sort_values(
    '수학', ascending=False)  # ascending=False (내림차순)
print("2) 수학 점수 내림차순 (높은 점수부터):")
print(math_desc)
print()

# 추가: sort_values()는 원본 데이터를 변경하지 않고 새로운 DataFrame을 반환합니다.
# 원본을 변경하려면 inplace=True 옵션을 사용하거나 결과를 다시 할당해야 합니다.

print("=== 다중 열 기준 정렬 ===")

# 여러 열을 기준으로 정렬 (우선순위 존재)
multi_asc = students.sort_values(['나이', '수학'])  # 1순위: 나이, 2순위: 수학 (둘 다 오름차순)
print("3) 나이 오름차순 → 수학 오름차순:")
print(multi_asc)
print()

# 각 열마다 다른 정렬 방향 적용
multi_desc = students.sort_values(
    ['나이', '수학'], ascending=[True, False])  # 나이↑, 수학↓
print("4) 나이 오름차순 → 수학 내림차순:")
print(multi_desc)
print()

# 추가: 다중 정렬에서는 첫 번째 기준으로 먼저 정렬하고,
# 같은 값들 내에서 두 번째 기준으로 다시 정렬합니다.
# ascending 리스트의 순서는 정렬 기준 열의 순서와 일치해야 합니다.

print("=== 인덱스 기준 정렬 (sort_index) ===")

# 행 인덱스 기준 정렬
index_sort = students.sort_index()  # 기본적으로 0, 1, 2, 3, 4 순서로 정렬
print("5) 인덱스 기준 정렬 (행 번호 순):")
print(index_sort)
print()

# 열 이름 기준 정렬
column_sort = students.sort_index(axis=1)  # axis=1은 열(column) 방향
print("6) 열 이름 기준 정렬 (가나다순):")
print(column_sort)
print()

# 추가: sort_index()는 인덱스나 열 이름을 기준으로 정렬합니다.
# axis=0 (기본값): 행 인덱스 기준, axis=1: 열 이름 기준

print("\n" + "="*50)
print("인덱스 활용하기")
print("="*50)

print("=== 열을 인덱스로 설정 ===")

# 특정 열을 인덱스로 설정 (새로운 DataFrame 반환)
students_indexed = students.set_index('이름')  # '이름' 열을 인덱스로 변경
print("1) 이름을 인덱스로 설정 (원본 유지):")
print(students_indexed)
print()

print("원본 데이터 (변경되지 않음):")
print(students)
print()

# 원본 DataFrame을 직접 변경
students.set_index('이름', inplace=True)  # inplace=True로 원본 직접 수정
print("2) 원본을 직접 변경:")
print(students)
print()

# 추가: set_index()는 특정 열을 행의 이름(인덱스)으로 만듭니다.
# 이렇게 하면 해당 열은 일반 데이터 열에서 사라지고 인덱스가 됩니다.
# inplace=True를 사용하면 원본 DataFrame이 변경됩니다.

print("=== 인덱스를 다시 열로 복원 ===")

# 인덱스를 다시 일반 열로 변환
students_reset = students.reset_index()  # 인덱스를 '이름'이라는 열로 복원
print("3) 인덱스를 다시 열로 복원:")
print(students_reset)
print()

# 추가: reset_index()는 인덱스를 다시 일반 열로 만들고,
# 새로운 숫자 인덱스(0, 1, 2, ...)를 생성합니다.

print("=== 이름 기반 데이터 접근 ===")

# 특정 이름(인덱스)의 데이터 선택
kim_info = students.loc['김철수']  # '김철수'라는 인덱스의 모든 데이터
print("4) 김철수의 정보:")
print(kim_info)
print(f"김철수의 수학 점수: {kim_info['수학']}점")
print()

# 여러 이름의 데이터 선택
selected_info = students.loc[['김철수', '이영희']]  # 여러 인덱스 선택
print("5) 김철수와 이영희의 정보:")
print(selected_info)
print()

# 추가: 의미있는 인덱스를 설정하면 데이터에 더 직관적으로 접근할 수 있습니다.
# 학생 이름, 날짜, 상품 코드 등을 인덱스로 설정하면 데이터 검색이 편리합니다.

print("\n" + "="*50)
print("다중 인덱스 (MultiIndex)")
print("="*50)

# 매출 데이터 생성 (지역과 분기라는 두 가지 기준)
sales_data = pd.DataFrame({
    '지역': ['서울', '서울', '부산', '부산', '서울', '부산'],
    '분기': ['Q1', 'Q2', 'Q1', 'Q2', 'Q3', 'Q3'],
    '매출': [100, 120, 80, 90, 110, 95],
    '직원수': [10, 12, 8, 9, 11, 8]
})

print("원본 매출 데이터:")
print(sales_data)
print()

# 두 개의 열을 인덱스로 설정 (다중 인덱스 생성)
multi_indexed = sales_data.set_index(['지역', '분기'])  # 지역과 분기를 모두 인덱스로
print("=== 다중 인덱스 생성 ===")
print(multi_indexed)
print()

# 추가: 다중 인덱스는 계층적 구조를 만들어 복잡한 데이터를 체계적으로 관리할 수 있습니다.
# 첫 번째 레벨이 지역, 두 번째 레벨이 분기가 됩니다.

print("=== 다중 인덱스 데이터 접근 ===")

# 특정 지역의 특정 분기 데이터 선택
seoul_q1 = multi_indexed.loc[('서울', 'Q1')]  # 튜플 형태로 다중 인덱스 접근
print("1) 서울 Q1 데이터:")
print(seoul_q1)
print()

# 특정 지역의 모든 분기 데이터 선택
seoul_all = multi_indexed.loc['서울']  # 첫 번째 레벨만 지정하면 해당하는 모든 하위 데이터
print("2) 서울의 모든 분기 데이터:")
print(seoul_all)
print()

# 추가: 다중 인덱스에서는 튜플 형태로 접근하거나,
# 상위 레벨만 지정해서 하위의 모든 데이터를 가져올 수 있습니다.

print("\n" + "="*50)
print("실습 예제: 학생 성적 종합 분석")
print("="*50)

# 더 복잡한 학생 데이터로 종합 실습
students_scores = pd.DataFrame({
    '이름': ['김철수', '이영희', '박민수', '최지영', '정다운', '홍길동'],
    '수학': [85, 92, 78, 96, 83, 88],
    '영어': [88, 85, 90, 87, 89, 82],
    '과학': [92, 88, 85, 90, 86, 91],
    '학년': [2, 3, 1, 3, 2, 1],
    '반': ['A', 'B', 'A', 'B', 'A', 'B']
})

print("=== 종합 실습용 데이터 ===")
print(students_scores)
print()

print("=== 다양한 정렬 실습 ===")

# 1. 수학 점수 내림차순 정렬
print("1) 수학 점수 내림차순 (수학 고득점자 순):")
math_desc = students_scores.sort_values("수학", ascending=False)
print(math_desc[['이름', '수학']])  # 이름과 수학 점수만 표시
print()

# 2. 학년 오름차순, 수학 점수 오름차순 정렬
print("2) 학년별 → 수학 점수 순 정렬:")
grade_math_asc = students_scores.sort_values(['학년', "수학"])
print(grade_math_asc[['이름', '학년', '수학']])
print()

# 3. 학년 오름차순, 수학 점수 내림차순 정렬
print("3) 학년별 → 수학 고득점자 순:")
grade_math = students_scores.sort_values(['학년', "수학"], ascending=[True, False])
print(grade_math[['이름', '학년', '수학']])
print()

# 추가: 실무에서는 이런 식으로 "학년별로 나누어서 성적 순으로 정렬"하는 경우가 많습니다.
# 먼저 그룹을 나누고, 그 안에서 순위를 매기는 방식입니다.

print("=== 계산된 열로 정렬 ===")

# 4. 총점 계산 후 총점 기준 내림차순 정렬
students_scores['총점'] = (students_scores['수학'] +
                         students_scores['영어'] +
                         students_scores['과학'])  # 새로운 열 생성

print("4) 총점 계산 후 총점 순 정렬:")
total_desc = students_scores.sort_values('총점', ascending=False)
print(total_desc[['이름', '수학', '영어', '과학', '총점']])
print()

# 추가: 기존 열들을 조합해서 새로운 열을 만들고, 그 열로 정렬하는 것도 가능합니다.
# 총점, 평균, 비율 등을 계산해서 정렬 기준으로 활용할 수 있습니다.

print("=== 상위 데이터 선택 방법 비교 ===")

# 방법 1: 정렬 후 head() 사용
print("5-1) 영어 점수 상위 3명 (정렬 → head 방식):")
en_sorted = students_scores.sort_values('영어', ascending=False)
en_top3_method1 = en_sorted.head(3)
print(en_top3_method1[['이름', '영어']])
print()

# 방법 2: nlargest() 함수 사용 (더 간단하고 효율적)
print("5-2) 영어 점수 상위 3명 (nlargest 방식):")
en_top3_method2 = students_scores.nlargest(3, '영어')  # 한 번에 상위 3명 선택
print(en_top3_method2[['이름', '영어']])
print()

# 추가: nlargest(n, '열이름')는 지정한 열에서 가장 큰 n개 값을 선택합니다.
# nsmallest()는 반대로 가장 작은 값들을 선택합니다.
# sort_values() + head()보다 더 효율적이고 간단합니다.

print("=== 하위 데이터 선택 ===")

print("6) 총점 하위 2명:")
total_bottom2 = students_scores.nsmallest(2, '총점')  # 총점이 낮은 2명
print(total_bottom2[['이름', '총점']])
print()

print("=== 학년별 1등 찾기 (고급 활용) ===")

# 학년별로 총점 1등 찾기
print("7) 각 학년별 총점 1등:")
grade_top_students = students_scores.groupby('학년').apply(
    lambda x: x.loc[x['총점'].idxmax(), ['이름', '총점']]
)
print(grade_top_students)
print()

# 추가: groupby()와 함께 사용하면 그룹별로 최고/최저값을 찾을 수 있습니다.
# 각 부서별 최고 성과자, 각 지역별 매출 1위 등을 찾을 때 유용합니다.

print("=== 이름을 인덱스로 한 성적 조회 시스템 ===")

# 이름을 인덱스로 설정하여 성적 관리 시스템 구축
grade_system = students_scores.set_index('이름')
print("8) 이름 기반 성적 조회 시스템:")
print(grade_system)
print()

# 특정 학생 성적 조회
print("김철수 성적 조회:")
kim_grades = grade_system.loc['김철수']
print(
    f"수학: {kim_grades['수학']}점, 영어: {kim_grades['영어']}점, 과학: {kim_grades['과학']}점")
print(f"총점: {kim_grades['총점']}점")
print()

# 여러 학생 성적 비교
print("상위 3명 학생 성적 비교:")
top3_names = total_desc.head(3)['이름'].tolist()  # 상위 3명의 이름 추출
top3_comparison = grade_system.loc[top3_names]
print(top3_comparison[['수학', '영어', '과학', '총점']])
print()

# 추가: 인덱스를 잘 활용하면 데이터베이스처럼 효율적인 조회 시스템을 만들 수 있습니다.
# 학생 이름, 상품 코드, 날짜 등을 인덱스로 설정하여 빠른 검색이 가능합니다.

print("\n" + "="*50)
print("핵심 정리")
print("="*50)
print("""
정렬과 인덱싱 핵심 개념:

1. 데이터 정렬 (sort_values):
   - 단일 열: df.sort_values('열이름')
   - 다중 열: df.sort_values(['열1', '열2'])
   - 정렬 방향: ascending=True(오름차순), False(내림차순)
   - 열별 다른 방향: ascending=[True, False]

2. 인덱스 정렬 (sort_index):
   - 행 인덱스: df.sort_index()
   - 열 이름: df.sort_index(axis=1)

3. 인덱스 활용:
   - 설정: df.set_index('열이름')
   - 복원: df.reset_index()
   - 접근: df.loc['인덱스이름']
   - 다중 인덱스: df.set_index(['열1', '열2'])

4. 상위/하위 데이터 선택:
   - 정렬 후 선택: sort_values() + head()/tail()
   - 직접 선택: nlargest(n, '열'), nsmallest(n, '열')

5. 실무 활용 팁:
   - 의미있는 열을 인덱스로 설정 (이름, 날짜, 코드 등)
   - 다중 정렬로 우선순위 있는 순위 매기기
   - 계산된 열(총점, 평균 등)로 정렬하기
   - groupby와 조합하여 그룹별 순위 찾기

6. 성능 고려사항:
   - nlargest/nsmallest가 sort_values + head보다 효율적
   - 자주 검색하는 열은 인덱스로 설정
   - 대용량 데이터에서는 불필요한 정렬 피하기

정렬과 인덱싱은 데이터의 순서를 만들고 효율적으로 접근하는 
데이터 분석의 기본 도구입니다!
""")
