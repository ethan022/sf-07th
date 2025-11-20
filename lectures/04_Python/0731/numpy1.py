# numpy: 숫자 계산을 빠르고 쉽게 할 수 있도록 도와주는 라이브러리
import numpy as np  # np 라는 이름으로 numpy를 사용하겠다.

# ✅ 리스트를 이용한 연산 vs numpy 연산 비교

# 일반 리스트에서 각 요소를 2배로 만드는 방법 (반복문 사용)
numbers = [1, 2, 3, 4, 5]
result = []
for num in numbers:
    result.append(num * 2)
print("result: ", result)  # [2, 4, 6, 8, 10]

# numpy 배열에서는 벡터 연산으로 간단히 처리 가능
numbers = np.array([1, 2, 3, 4, 5])
result = numbers * 2
print("numpy result: ", result)  # [2 4 6 8 10]

# ✅ 두 리스트를 더하기

# 일반 리스트 덧셈 (인덱스 기반 반복)
list1 = [1, 2, 3]
list2 = [4, 5, 6]
result = []
for i in range(len(list1)):
    result.append(list1[i] + list2[i])
print("result: ", result)  # [5, 7, 9]

# numpy 배열의 덧셈
list1 = np.array([1, 2, 3])
list2 = np.array([4, 5, 6])
result = list1 + list2
print("numpy result: ", result)  # [5 7 9]

# ✅ numpy 장점
# - 빠른 계산 속도
# - 적은 메모리 사용
# - 다양한 수학 연산 가능
# - 다차원 배열 지원

# ✅ 1차원 배열
list_1d = [1, 2, 3, 4, 5]
np_list_1d = np.array(list_1d)
print("1차원 배열: ", np_list_1d)
print("배열 타입: ", type(np_list_1d))  # <class 'numpy.ndarray'>

# ✅ 2차원 배열
list_2d = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]
np_list_2d = np.array(list_2d)
print("2차원 배열: ", np_list_2d)
print("배열 타입: ", type(np_list_2d))

# ✅ 데이터 타입 지정
np_list_float = np.array([1, 2, 3], dtype=float)
np_list_int = np.array([1.1, 2.2, 3.5], dtype=int)
print("실수 배열: ", np_list_float)  # [1. 2. 3.]
print("정수 배열: ", np_list_int)    # [1 2 3]

# ✅ 정수 인덱싱 예시 (특정 위치 값 가져오기)
# [
#     [1 (0,0), 2 (0,1), 3 (0,2)],
#     [4 (1,0), 5 (1,1), 6 (1,2)],
#     [7 (2,0), 8 (2,1), 9 (2,2)]
# ]
print("np_list_2d[[1, 1], [2, 2]]:", np_list_2d[[1, 1], [2, 2]])  # [6 6]
print("np_list_2d[[0, 1], [0, 2]]:", np_list_2d[[0, 1], [0, 2]])  # [1 6]
print("np_list_2d[[2, 1], [2, 1]]:", np_list_2d[[2, 1], [2, 1]])  # [9 5]
print("np_list_2d[[0, 2], [2, 0]]:", np_list_2d[[0, 2], [2, 0]])  # [3 7]

# ✅ 학생 성적 예시: 행과 열 인덱스를 이용한 점수 추출
# 국어 영어 수학
scores = np.array([
    [79, 80, 40],
    [75, 82, 70],
    [72, 84, 69]
])
rows = [1, 0, 2]
cols = [2, 1, 0]
print(scores[rows, cols])  # [70 80 72]

# ✅ 조건 필터링과 값 변경
arr1 = np.array([11, 20, 31, 40, 51])
print("arr1[arr1 > 31]:", arr1[arr1 > 31])        # [40 51]
print("arr1[arr1 % 2 == 0]:", arr1[arr1 % 2 == 0])  # [20 40]
arr1[arr1 > 31] = 0
print("arr1:", arr1)  # [11 20 31 0 0]
lists = [0, 2, 4]
print("arr1[lists]:", arr1[lists])  # [11 31 0]

# ✅ 0으로 채운 배열 만들기
zeros_array = np.zeros((2, 3))
print("zeros_array:", zeros_array)

# ✅ 1로 채운 배열 만들기
ones_array = np.ones((3, 2))
print("ones_array:", ones_array)

# ✅ 특정 범위의 수 생성 (간격 기준)
range_array = np.arange(1, 10, 2)
print("range_array:", range_array)  # [1 3 5 7 9]

# ✅ 일정 간격으로 나누기 (개수 기준)
linspace_array = np.linspace(0, 10, 5)
print("linspace_array:", linspace_array)  # [ 0.   2.5  5.   7.5 10. ]

# ✅ 배열 형태 변경: reshape
array2 = np.array([1, 2, 3, 4, 5, 6])
reshape = np.reshape(array2, (2, 3))
print("reshape:", reshape)
# [[1 2 3]
#  [4 5 6]]

# ✅ 배열 크기 변경: resize (원소가 부족하면 반복)
resized = np.resize(array2, (3, 5))
print("resized:", resized)
# [[1 2 3 4 5]
#  [6 1 2 3 4]
#  [5 6 1 2 3]]

# ✅ 기본 사칙연산 (배열끼리)
arr1 = np.array([1, 2, 3])
arr2 = np.array([4, 5, 6])
print("arr1 + arr2:", arr1 + arr2)
print("arr1 - arr2:", arr1 - arr2)
print("arr1 * arr2:", arr1 * arr2)
print("arr1 / arr2:", arr1 / arr2)

# ✅ 수학 함수 사용: 제곱근
arr1 = np.array([1, 4, 9, 16, 25])
sqrt_values = np.sqrt(arr1)
print("제곱근:", sqrt_values)  # [1. 2. 3. 4. 5.]

# ✅ 로그 함수
arr1 = np.array([1, 2.718, 10, 20])
log_values = np.log(arr1)
print("로그:", log_values)

# ✅ 삼각 함수
angles = np.array([0, np.pi/6, np.pi/4, np.pi/3, np.pi/2])
sin_values = np.sin(angles)
print("사인:", sin_values)
cos_values = np.cos(angles)
print("코사인:", cos_values)

# ✅ 배열 합치기
arr1 = np.array([1, 2, 3])
arr2 = np.array([4, 5, 6])

result = np.hstack((arr1, arr2))  # 수평 합치기 (1차원 기준으로 연결)
print("수평 합치기:", result)     # [1 2 3 4 5 6]

result = np.vstack((arr1, arr2))  # 수직 합치기 (2차원으로 아래로 쌓기)
print("수직 합치기:", result)
# [[1 2 3]
#  [4 5 6]]

result = np.column_stack((arr1, arr2))  # 열 기준 합치기 (세로로 짝지음)
print("열 기준 합치기:", result)
# [[1 4]
#  [2 5]
#  [3 6]]

# ✅ 배열 분할
arr1 = np.array([[1, 2, 3], [4, 5, 6]])

result = np.hsplit(arr1, 3)  # 열을 기준으로 분할 (좌우 나눔)
print("수평 분할:", result)

result = np.vsplit(arr1, 2)  # 행을 기준으로 분할 (위아래 나눔)
print("수직 분할:", result)

# ✅ 브로드캐스팅 (스칼라 or 다른 차원과 자동 연산)
arr1 = np.array([1, 2, 3, 4])
scalar = 10
result = arr1 + scalar
print("스칼라 더하기:", result)  # [11 12 13 14]

# ✅ 브로드캐스팅: 1차원 + 2차원
arr1 = np.array([[1, 2, 3], [4, 5, 6]])
arr2 = np.array([10, 20, 30])
result = arr1 + arr2
print("브로드캐스팅 (행별):", result)
# [[11 22 33]
#  [14 25 36]]

# ✅ 브로드캐스팅: 열 방향 더하기
arr1 = np.array([[1, 2, 3], [4, 5, 6]])
arr2 = np.array([[10], [20]])
result = arr1 + arr2
print("브로드캐스팅 (열별):", result)
# [[11 12 13]
#  [24 25 26]]


# ✅ 원본 팀 데이터: 팀명, 승, 패, 무, 승률
teams = [
    ["LG", 63, 55, 2, 0.534],
    ["SSG", 58, 62, 1, 0.483],
    ["KIA", 71, 48, 2, 0.597],
    ["NC", 52, 63, 2, 0.452],
    ["KT", 59, 61, 2, 0.492],
    ["롯데", 51, 61, 3, 0.455],
    ["두산", 62, 60, 0, 0.508],
    ["삼성", 66, 54, 2, 0.550],
    ["키움", 53, 67, 0, 0.442],
    ["한화", 56, 60, 2, 0.483],
]

# ✅ NumPy 배열로 변환 (dtype=object는 문자열+숫자 혼합을 허용)
np_team = np.array(teams, dtype=object)

# ✅ 승률 기준으로 내림차순 정렬
# np_team[:, 4] → 모든 행의 '승률' 열만 추출
# astype(float) → 문자열일 수도 있으므로 실수형으로 변환
# -np_team[:, 4] → 부호를 반대로 하여 내림차순 정렬
sorted_indices = np.argsort(-np_team[:, 4].astype(float))
print("sorted_indices: ", sorted_indices)

# ✅ 정렬된 인덱스를 이용하여 팀 정보 정렬
sorted_team = np_team[sorted_indices]
print("sorted_team: ", sorted_team)

# ✅ 정렬된 데이터를 텍스트 파일로 저장
file_path = "kbo_sorted.txt"
with open(file_path, "w", encoding="utf-8") as file:
    file.write("============ 2024 한국 프로야구 성적표 ============\n\n")
    file.write("순위  팀    승   패  무   승률\n")

    # 각 팀 정보를 순위와 함께 출력
    for i, row in enumerate(sorted_team, 1):
        # 순위  팀이름   승  패  무  승률  → 각각 칸 맞추기
        file.write(
            f"{i:<5}{row[0]:<5}{row[1]:<4}{row[2]:<4}{row[3]:<4}{float(row[4]):.3f}\n")

# ✅ NumPy argsort 예제 (개념 설명용)
# 1. np.argsort() 예제
# 배열을 정렬했을 때, 정렬된 순서대로 원래 인덱스를 반환
arr1 = np.array([3, 1, 4, 2, 5])

# 오름차순 정렬 결과는: [1, 2, 3, 4, 5]
# 그 순서대로 원래의 인덱스는: [1, 3, 0, 2, 4]
sorted_arr = np.argsort(arr1)

print("sorted_arr: ", sorted_arr)         # [1 3 0 2 4]
print("arr1: ", arr1[sorted_arr])         # [1 2 3 4 5]
print()

# 2. 학생별 과목 점수 데이터
scores = np.array([[85, 92, 78, 96],    # 김철수
                   [88, 85, 90, 92],    # 이영희
                   [90, 88, 85, 94]])   # 박민수

students = ['김철수', '이영희', '박민수']
subjects = ['국어', '수학', '영어', '과학']

print("전체 점수 배열:")
print(scores)
print()

# 2-1. 이영희(1번 인덱스)의 모든 과목 점수
print("이영희의 점수:", scores[1])        # 방법 1
print("이영희의 점수 (슬라이싱):", scores[1, :])  # 방법 2 (전체 열)
print()

# 2-2. 모든 학생의 수학 점수 (1번 열)
print("수학 점수:", scores[:, 1])
print()

# 2-3. 90점 이상인 점수만 추출 (조건 필터링)
high_score = scores[scores >= 90]
print("90점 이상 점수:", high_score)
print()

# 2-4. 김철수의 영어 점수(2번 열)를 95점으로 수정
scores[0, 2] = 95
print("김철수 영어 점수 수정 후:")
print(scores)
print()


# 3. 슬라이싱 예제: 리스트에서 부분 선택
arr = [1, 2, 3, 4, 5]

# 인덱스 1부터 2까지 → [2]
print("arr[1:2]:", arr[1:2])

# 인덱스 1부터 3까지 → [2, 3]
print("arr[1:3]:", arr[1:3])

# 처음부터 인덱스 3 전까지 → [1, 2, 3]
print("arr[:3]:", arr[:3])

# 인덱스 2부터 끝까지 → [3, 4, 5]
print("arr[2:]:", arr[2:])

# 인덱스 2부터 -1전까지 → [3, 4]
print("arr[2:-1]:", arr[2:-1])

# 처음부터 -1 전까지 → [1, 2, 3, 4]
print("arr[:-1]:", arr[:-1])

# -3부터 -1전까지 → [3, 4]
print("arr[-3:-1]:", arr[-3:-1])

# 2칸씩 건너뛰며 선택 → [1, 3, 5]
print("arr[::2]:", arr[::2])

# 거꾸로 뒤집기 → [5, 4, 3, 2, 1]
print("arr[::-1]:", arr[::-1])
print()


# 4. 지점별 분기 매출 데이터
sales = np.array([
    [120, 135, 148, 162],  # 서울점
    [98, 110, 125, 140],   # 부산점
    [75, 82, 95, 110]      # 대구점
])

branches = ['서울점', '부산점', '대구점']
quarters = ['1분기', '2분기', '3분기', '4분기']

# 4-1. 각 지점별 최고 매출
print("각 지점별 최고 매출:")
print("행 기준 최대값 (지점별):",  np.max(sales, axis=1))
print("열 기준 최대값 (분기별):",  np.max(sales, axis=0))
print()

for i, branch in enumerate(branches):
    max_idx = np.argmax(sales[i])              # 해당 지점에서 최고 매출의 분기 인덱스
    max_value = sales[i, max_idx]              # 최고 매출 금액
    print(f"{branch}: {quarters[max_idx]} {max_value}만원")
print()

# 4-2. 전체에서 100만원 이상인 매출만 필터링
high_sales = sales[sales >= 100]
print("100만원 이상 매출만 추출:", high_sales)
print()

# 4-3. 서울지점(0번 행)의 2분기(1열), 4분기(3열) 매출 추출
seoul_2_4 = sales[0, [1, 3]]
print("서울점 2, 4분기 매출:", seoul_2_4)
print()

# 4-4. 모든 지점의 3분기(2열) 매출을 105로 수정
sales[:, 2] = 105
print("3분기 매출을 105로 수정 후:")
print(sales)
