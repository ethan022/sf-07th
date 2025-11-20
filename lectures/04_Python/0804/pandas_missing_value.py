# 결측값(Missing Data)과 중복 데이터 처리
# 실제 데이터에서는 빠진 값이나 중복된 값이 자주 발생함
# 이런 데이터를 정리하는 것이 데이터 분석의 첫 단계

import pandas as pd
import numpy as np

# 결측값이 포함된 학생 데이터 생성
students = pd.DataFrame({
    '이름': ['김철수', '이영희', '박민수', '최지영', '정다운', None],           # None: 파이썬의 결측값
    # np.nan: 숫자형 결측값
    '나이': [20, np.nan, 19, 22, 20, np.nan],
    # 일부 점수가 누락됨
    '수학': [85, 92, np.nan, 96, 83, np.nan],
    # 일부 점수가 누락됨
    '영어': [88, 85, 90, np.nan, 89, np.nan],
    # 빈 문자열과 None
    '전화번호': ['010-1234-5678', None, '010-9876-5432', '010-5555-1234', '', None]
})

print("=== 결측값이 있는 데이터 ===")
print(students)
print()

# 추가: 실제 데이터에서는 다양한 형태의 결측값이 나타납니다.
# None(파이썬), np.nan(넘파이), 빈 문자열('') 등이 모두 결측값으로 처리될 수 있습니다.

print("=== 결측값 확인 ===")

# 결측값 위치를 True/False로 표시
print("1) 각 셀의 결측값 여부 (True = 결측값):")
print(students.isnull())  # 결측값이면 True, 아니면 False
print()

# 추가: isnull()과 isna()는 같은 기능입니다. 둘 다 결측값을 확인합니다.
# 반대로 notnull()이나 notna()는 결측값이 아닌 값들을 True로 표시합니다.

print("2) 각 열별 결측값 개수:")
print(students.isnull().sum())  # True를 1로 계산하여 열별 결측값 개수 구하기
print()

print("3) 전체 결측값 개수:")
print(students.isnull().sum().sum())  # 모든 열의 결측값 개수를 다시 합계
print()

# 추가: isnull().sum()은 각 열의 결측값 개수를,
# isnull().sum().sum()은 전체 DataFrame의 총 결측값 개수를 구합니다.

print("=== 결측값 처리 방법 1: 행 제거 ===")

# 결측값이 있는 행을 모두 제거
clean_data = students.dropna()  # 하나라도 결측값이 있는 행은 삭제
print("1) 결측값이 있는 모든 행 제거:")
print(clean_data)
print(f"원본: {len(students)}행 → 정리 후: {len(clean_data)}행")
print()

# 특정 열의 결측값만 있는 행 제거
math_clean_data = students.dropna(subset=['수학'])  # '수학' 열에 결측값이 있는 행만 제거
print("2) 수학 점수가 없는 행만 제거:")
print(math_clean_data)
print(f"원본: {len(students)}행 → 정리 후: {len(math_clean_data)}행")
print()

# 모든 값이 결측값인 행만 제거 (일부 결측값은 허용)
all_na_clean_data = students.dropna(how='all')  # 모든 열이 결측값인 행만 제거
print("3) 모든 값이 결측값인 행만 제거:")
print(all_na_clean_data)
print(f"원본: {len(students)}행 → 정리 후: {len(all_na_clean_data)}행")
print()

# 추가: dropna() 옵션들
# - how='any' (기본값): 하나라도 결측값이 있으면 제거
# - how='all': 모든 값이 결측값일 때만 제거
# - subset=['열이름']: 특정 열에서만 결측값 확인

print("=== 결측값 처리 방법 2: 값으로 채우기 ===")

# 모든 결측값을 0으로 채우기
filled_zero = students.fillna(0)  # 모든 결측값을 0으로 대체
print("1) 모든 결측값을 0으로 채우기:")
print(filled_zero)
print()

# 열별로 다른 값으로 채우기 (더 현실적인 방법)
filled_custom = students.fillna({
    '나이': students['나이'].median(),      # 나이는 중간값(median)으로 채우기
    '수학': students['수학'].mean(),        # 수학은 평균값(mean)으로 채우기
    '영어': students['영어'].mean(),        # 영어는 평균값으로 채우기
    '전화번호': '정보 없음',                # 전화번호는 '정보 없음'으로 채우기
})
print("2) 열별로 적절한 값으로 채우기:")
print(filled_custom)
print()

# 각 채움값 확인
print("사용된 채움값들:")
print(f"나이 중간값: {students['나이'].median()}")
print(f"수학 평균: {students['수학'].mean():.1f}")
print(f"영어 평균: {students['영어'].mean():.1f}")
print()

# 추가: 결측값 채우기 전략
# - 숫자 데이터: 평균(mean), 중간값(median), 최빈값(mode) 사용
# - 범주형 데이터: 최빈값이나 '알 수 없음' 같은 기본값 사용
# - 시계열 데이터: 앞뒤 값으로 보간(interpolation) 사용 가능

print("\n" + "="*50)
print("중복 데이터 처리")
print("="*50)

# 중복 데이터가 포함된 DataFrame 생성
duplicate_data = pd.DataFrame({
    '이름': ['김철수', '이영희', '김철수', '박민수', '이영희', '최지영'],  # 김철수, 이영희가 중복
    '나이': [20, 21, 20, 19, 21, 22],
    '전공': ['컴퓨터', '수학', '컴퓨터', '물리', '수학', '화학']
})

print("=== 중복 데이터 ===")
print(duplicate_data)
print()

# 추가: 실제 데이터에서는 실수로 같은 데이터를 여러 번 입력하거나,
# 여러 소스에서 데이터를 합칠 때 중복이 발생할 수 있습니다.

print("=== 중복 데이터 확인 ===")

# 중복된 행을 True/False로 표시 (첫 번째 등장은 False, 중복은 True)
print("1) 각 행의 중복 여부 (True = 중복된 행):")
print(duplicate_data.duplicated())  # 두 번째 등장부터 True로 표시
print()

print("2) 중복된 행의 개수:")
print(f"중복 행 개수: {duplicate_data.duplicated().sum()}개")
print()

# 추가: duplicated()는 첫 번째로 나타나는 행은 False로,
# 그 이후에 나타나는 동일한 행들을 True로 표시합니다.

print("=== 중복 데이터 제거 ===")

# 완전히 동일한 행 제거 (모든 열의 값이 같아야 중복으로 판단)
unique_data = duplicate_data.drop_duplicates()  # 중복 행 제거 (첫 번째만 유지)
print("1) 완전히 동일한 행 제거:")
print(unique_data)
print(f"원본: {len(duplicate_data)}행 → 정리 후: {len(unique_data)}행")
print()

# 특정 열을 기준으로 중복 제거
name_unique_data = duplicate_data.drop_duplicates(
    subset=['이름'])  # 이름이 같으면 중복으로 판단
print("2) 이름을 기준으로 중복 제거:")
print(name_unique_data)
print(f"원본: {len(duplicate_data)}행 → 정리 후: {len(name_unique_data)}행")
print()

# 추가: subset 매개변수로 특정 열들만 기준으로 중복을 판단할 수 있습니다.
# 예: subset=['이름', '나이']로 하면 이름과 나이가 모두 같을 때만 중복으로 판단

print("=== 중복 제거 옵션 ===")

# 마지막 중복 행 유지 (기본은 첫 번째 유지)
keep_last = duplicate_data.drop_duplicates(subset=['이름'], keep='last')
print("3) 중복 시 마지막 행 유지:")
print(keep_last)
print()

# 중복된 모든 행 제거 (중복된 행들을 모두 삭제)
keep_none = duplicate_data.drop_duplicates(subset=['이름'], keep=False)
print("4) 중복된 모든 행 제거:")
print(keep_none)
print()

# 추가: keep 매개변수 옵션
# - keep='first' (기본값): 첫 번째 등장하는 행 유지
# - keep='last': 마지막에 등장하는 행 유지
# - keep=False: 중복된 모든 행 제거

print("\n" + "="*50)
print("실습 예제: 종합적인 데이터 정리")
print("="*50)

# 실제 상황을 모방한 복잡한 데이터
messy_data = pd.DataFrame({
    '고객ID': [1001, 1002, 1001, 1003, 1004, 1002, None],
    '이름': ['김철수', '이영희', '김철수', '박민수', '', '이영희', None],
    '나이': [25, np.nan, 25, 30, 35, np.nan, 28],
    '구매금액': [50000, 75000, 50000, np.nan, 120000, 75000, 0],
    '등급': ['실버', '골드', '실버', None, '플래티넘', '골드', '브론즈']
})

print("정리 전 데이터:")
print(messy_data)
print(f"데이터 크기: {messy_data.shape}")
print()

# 단계별 데이터 정리 과정
print("=== 단계별 데이터 정리 ===")

# 1단계: 완전히 빈 행 제거
step1 = messy_data.dropna(how='all')
print("1단계 - 모든 값이 결측값인 행 제거:")
print(step1)
print(f"크기 변화: {messy_data.shape} → {step1.shape}")
print()

# 2단계: 고객ID가 없는 행 제거 (핵심 정보)
step2 = step1.dropna(subset=['고객ID'])
print("2단계 - 고객ID가 없는 행 제거:")
print(step2)
print(f"크기 변화: {step1.shape} → {step2.shape}")
print()

# 3단계: 중복 제거 (고객ID 기준)
step3 = step2.drop_duplicates(subset=['고객ID'], keep='first')
print("3단계 - 고객ID 기준 중복 제거:")
print(step3)
print(f"크기 변화: {step2.shape} → {step3.shape}")
print()

# 4단계: 결측값 채우기
step4 = step3.copy()  # 원본 보존을 위한 복사본 생성
step4['이름'] = step4['이름'].fillna('이름 없음')        # 이름 결측값
step4['나이'] = step4['나이'].fillna(step4['나이'].median())  # 나이는 중간값으로
step4['구매금액'] = step4['구매금액'].fillna(0)           # 구매금액은 0으로
step4['등급'] = step4['등급'].fillna('일반')             # 등급은 '일반'으로

print("4단계 - 결측값 채우기:")
print(step4)
print()

# 빈 문자열을 결측값으로 처리하고 다시 채우기
step4['이름'] = step4['이름'].replace('', '이름 없음')   # 빈 문자열 처리

print("최종 정리된 데이터:")
print(step4)
print(f"최종 크기: {step4.shape}")
print()

# 정리 결과 요약
print("=== 데이터 정리 결과 요약 ===")
print(f"원본 데이터: {messy_data.shape[0]}행")
print(f"정리 후 데이터: {step4.shape[0]}행")
print(f"제거된 행: {messy_data.shape[0] - step4.shape[0]}행")
print()

print("정리 전 결측값 개수:")
print(messy_data.isnull().sum())
print()

print("정리 후 결측값 개수:")
print(step4.isnull().sum())
print()

# 추가: 실제 데이터 정리는 여러 단계를 거쳐 신중하게 진행해야 합니다.
# 데이터의 특성과 분석 목적에 따라 정리 방법을 선택해야 합니다.

print("\n" + "="*50)
print("핵심 정리")
print("="*50)
print("""
결측값과 중복 데이터 처리 핵심 개념:

1. 결측값 확인:
   - .isnull() / .isna(): 결측값 위치 확인
   - .isnull().sum(): 열별 결측값 개수
   - .notnull() / .notna(): 결측값이 아닌 값 확인

2. 결측값 처리:
   - .dropna(): 결측값이 있는 행/열 제거
     * how='any': 하나라도 결측값이 있으면 제거 (기본값)
     * how='all': 모든 값이 결측값일 때만 제거
     * subset=['열이름']: 특정 열에서만 확인
   - .fillna(): 결측값을 다른 값으로 채우기
     * 고정값: fillna(0)
     * 통계값: fillna(df['열'].mean())
     * 열별 다름: fillna({'열1': 값1, '열2': 값2})

3. 중복 데이터 처리:
   - .duplicated(): 중복 행 확인 (True/False)
   - .drop_duplicates(): 중복 행 제거
     * subset=['열이름']: 특정 열 기준 중복 판단
     * keep='first': 첫 번째 유지 (기본값)
     * keep='last': 마지막 유지
     * keep=False: 중복된 모든 행 제거

4. 실무 팁:
   - 데이터 정리는 단계적으로 진행
   - 원본 데이터는 항상 보존 (.copy() 사용)
   - 정리 전후 데이터 크기와 결측값 개수 확인
   - 비즈니스 로직에 맞는 채움값 선택

데이터 품질이 분석 결과를 좌우하므로 정리 과정이 매우 중요합니다!
""")
