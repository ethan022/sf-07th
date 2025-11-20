# ============================================================
# Python 필수 라이브러리 - datetime, math, random, time
# ============================================================

# 라이브러리 import하기
import time                                    # 시간 관련 함수들
from datetime import datetime, timedelta, date  # 날짜/시간 처리
import math                                   # 수학 함수들
import random                                 # 랜덤 함수들

print("=" * 60)
print("🐍 Python 필수 라이브러리 학습")
print("=" * 60)

# ============================================================
# 1. datetime 라이브러리 - 날짜와 시간 처리
# ============================================================

print("\n📅 1. datetime 라이브러리 - 날짜와 시간")
print("-" * 40)

# 현재 날짜와 시간 가져오기
now = datetime.today()  # 또는 datetime.now()
print(f"현재 날짜와 시간: {now}")

# 날짜와 시간의 각 요소 추출하기
print(f"현재 년도: {now.year}")      # 2024
print(f"현재 월: {now.month}")       # 1~12
print(f"현재 일: {now.day}")         # 1~31
print(f"현재 시: {now.hour}")        # 0~23
print(f"현재 분: {now.minute}")      # 0~59
print(f"현재 초: {now.second}")      # 0~59

# 한국어 형식으로 날짜 출력
print(f"📆 오늘 날짜: {now.year}년 {now.month}월 {now.day}일")
print(f"🕐 현재 시간: {now.hour}시 {now.minute}분 {now.second}초")

# timedelta를 사용한 날짜 계산
print(f"\n⏰ 날짜 계산 (timedelta 사용):")
tomorrow = now + timedelta(days=1)              # 하루 후
next_week = now + timedelta(weeks=1)            # 일주일 후
past_month = now - timedelta(days=30)           # 30일 전
future_time = now + timedelta(weeks=1, days=1, hours=2, minutes=30)  # 복합 계산

print(f"내일: {tomorrow.strftime('%Y-%m-%d')}")
print(f"일주일 후: {next_week.strftime('%Y-%m-%d')}")
print(f"30일 전: {past_month.strftime('%Y-%m-%d')}")
print(f"1주일 1일 2시간 30분 후: {future_time}")

# 날짜 포맷팅 (strftime)
formatted_date = now.strftime("%Y-%m-%d %H:%M:%S")  # 기본 형식
korean_format = now.strftime("%Y년 %m월 %d일 %H시 %M분")  # 한국어 형식
us_format = now.strftime("%m/%d/%Y %I:%M %p")  # 미국식 (12시간제)

print(f"\n📝 다양한 날짜 포맷:")
print(f"기본 형식: {formatted_date}")
print(f"한국 형식: {korean_format}")
print(f"미국 형식: {us_format}")

# date 객체 사용하기 (시간 정보 없이 날짜만)
specific_date = date(year=2025, month=8, day=1)  # 특정 날짜 생성
today = date.today()                             # 오늘 날짜만

print(f"\n📅 특정 날짜: {specific_date}")
print(f"오늘 날짜: {today}")

# 요일 확인하기 (0=월요일, 6=일요일)
weekday_num = today.weekday()
weekdays = ["월요일", "화요일", "수요일", "목요일", "금요일", "토요일", "일요일"]
print(f"오늘은 {weekdays[weekday_num]}입니다. (숫자: {weekday_num})")

# 날짜 간 차이 계산
start_date = date(2025, 1, 1)  # 2025년 새해
days_passed = today - start_date
print(f"2025년 새해부터 {abs(days_passed.days)}일 지났습니다.")

# ============================================================
# 2. time 라이브러리 - 시간 측정과 대기
# ============================================================

print("\n⏱️ 2. time 라이브러리 - 시간 측정과 대기")
print("-" * 40)

# 현재 시간을 초 단위로 (1970년 1월 1일부터의 초)
current_timestamp = time.time()
print(f"현재 타임스탬프: {current_timestamp:.2f}초")

# 현재 시간을 구조체 형태로
local_time = time.localtime()
print(f"현재 시간 구조체: {local_time}")
print(f"구조체에서 년도: {local_time.tm_year}")
print(f"구조체에서 월: {local_time.tm_mon}")

# 시간 측정하기 (성능 측정용)
print(f"\n⏲️ 시간 측정 예제:")
print("1초 대기 중...")
start_time = time.perf_counter()  # 정확한 시간 측정 시작
time.sleep(1)                     # 1초 대기
end_time = time.perf_counter()    # 시간 측정 종료

elapsed_time = end_time - start_time
print(f"실제 소요 시간: {elapsed_time:.4f}초")

# 실제 작업 시간 측정 예제
print(f"\n🔄 반복 작업 시간 측정:")
start = time.perf_counter()
total = 0
for i in range(1000000):  # 백만 번 계산
    total += i
end = time.perf_counter()
print(f"백만 번 더하기 소요 시간: {end - start:.6f}초")
print(f"계산 결과: {total}")

# ============================================================
# 3. math 라이브러리 - 수학 함수들
# ============================================================

print("\n🧮 3. math 라이브러리 - 수학 함수들")
print("-" * 40)

# 수학 상수들
print(f"📐 수학 상수들:")
print(f"원주율 π: {math.pi:.6f}")
print(f"자연상수 e: {math.e:.6f}")
print(f"무한대: {math.inf}")

# 기본 수학 함수들
test_number = 25
print(f"\n🔢 기본 수학 함수들 (숫자: {test_number}):")
print(f"제곱근: √{test_number} = {math.sqrt(test_number)}")
print(f"거듭제곱: {test_number}² = {math.pow(test_number, 2)}")
print(f"절댓값: |{-test_number}| = {math.fabs(-test_number)}")

# 팩토리얼 (계승)
factorial_num = 5
print(f"\n🎯 팩토리얼:")
print(f"{factorial_num}! = {math.factorial(factorial_num)}")

# 올림, 반올림, 버림
decimal_num = 3.7
print(f"\n📊 소수점 처리 (숫자: {decimal_num}):")
print(f"올림 (ceil): {math.ceil(decimal_num)}")      # 4
print(f"버림 (floor): {math.floor(decimal_num)}")    # 3
print(f"반올림 (round): {round(decimal_num)}")        # 4

# 음수에서의 올림/버림
negative_num = -2.3
print(f"\n📊 음수 처리 (숫자: {negative_num}):")
print(f"올림 (ceil): {math.ceil(negative_num)}")     # -2
print(f"버림 (floor): {math.floor(negative_num)}")   # -3

# 삼각함수 (라디안 단위)
angle_degrees = 45
angle_radians = math.radians(angle_degrees)  # 도를 라디안으로 변환
print(f"\n📐 삼각함수 ({angle_degrees}도):")
print(f"sin({angle_degrees}°) = {math.sin(angle_radians):.4f}")
print(f"cos({angle_degrees}°) = {math.cos(angle_radians):.4f}")
print(f"tan({angle_degrees}°) = {math.tan(angle_radians):.4f}")

# 로그 함수
log_num = 100
print(f"\n📈 로그 함수 (숫자: {log_num}):")
print(f"자연로그 ln({log_num}) = {math.log(log_num):.4f}")
print(f"상용로그 log₁₀({log_num}) = {math.log10(log_num):.4f}")
print(f"이진로그 log₂({log_num}) = {math.log2(log_num):.4f}")

# ============================================================
# 4. random 라이브러리 - 랜덤 함수들
# ============================================================

print("\n🎲 4. random 라이브러리 - 랜덤 함수들")
print("-" * 40)

# 기본 랜덤 함수들
print(f"🎯 기본 랜덤 함수들:")

# 정수 랜덤
rand_int = random.randint(1, 10)  # 1부터 10까지 (양쪽 포함)
print(f"1~10 사이 정수: {rand_int}")

# 실수 랜덤
rand_float = random.uniform(1.0, 10.0)  # 1.0부터 10.0까지 실수
print(f"1.0~10.0 사이 실수: {rand_float:.3f}")

# 0과 1 사이 실수
rand_zero_one = random.random()  # 0 <= x < 1
print(f"0~1 사이 실수: {rand_zero_one:.6f}")

# 범위 랜덤 (끝값 제외)
rand_range = random.randrange(100, 1000)  # 100 <= x < 1000
print(f"100~999 사이 정수: {rand_range}")

# 범위 랜덤 (step 포함)
rand_step = random.randrange(0, 101, 5)  # 0, 5, 10, 15, ..., 100 중 하나
print(f"0~100 사이 5의 배수: {rand_step}")

# 리스트에서 랜덤 선택
fruits = ["사과", "바나나", "포도", "귤", "오렌지", "복숭아"]
random_fruit = random.choice(fruits)
print(f"랜덤 과일: {random_fruit}")

# 여러 개 랜덤 선택 (중복 없음)
random_fruits = random.sample(fruits, 3)  # 3개 선택
print(f"랜덤 과일 3개: {random_fruits}")

# 여러 개 랜덤 선택 (중복 가능)
random_with_replacement = random.choices(fruits, k=4)  # 4개 선택 (중복 가능)
print(f"랜덤 과일 4개(중복가능): {random_with_replacement}")

# 리스트 섞기
numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
original_numbers = numbers.copy()  # 원본 보존
random.shuffle(numbers)  # 원본 리스트를 직접 섞음
print(f"원본 숫자들: {original_numbers}")
print(f"섞인 숫자들: {numbers}")

# 가중치를 가진 랜덤 선택
colors = ["빨강", "파랑", "노랑", "초록"]
weights = [50, 30, 15, 5]  # 빨강 50%, 파랑 30%, 노랑 15%, 초록 5%
weighted_choice = random.choices(colors, weights=weights, k=1)[0]
print(f"가중치 기반 색상 선택: {weighted_choice}")

# ============================================================
# 5. 실제 활용 예제들
# ============================================================

print("\n🎨 5. 실제 활용 예제들")
print("-" * 40)

# 예제 1: 간단한 주사위 게임


def roll_dice():
    """주사위 두 개를 굴리는 함수"""
    dice1 = random.randint(1, 6)
    dice2 = random.randint(1, 6)
    total = dice1 + dice2
    return dice1, dice2, total


print("🎲 주사위 게임:")
d1, d2, total = roll_dice()
print(f"주사위 1: {d1}, 주사위 2: {d2}, 합계: {total}")

# 예제 2: 날짜 계산기


def calculate_age(birth_year, birth_month, birth_day):
    """나이 계산 함수"""
    birth_date = date(birth_year, birth_month, birth_day)
    today = date.today()
    age_days = (today - birth_date).days
    age_years = age_days // 365
    return age_years, age_days


print(f"\n📅 나이 계산기:")
birth_year, birth_month, birth_day = 2000, 5, 15
years, days = calculate_age(birth_year, birth_month, birth_day)
print(f"생년월일: {birth_year}년 {birth_month}월 {birth_day}일")
print(f"나이: 약 {years}세 (총 {days}일)")

# 예제 3: 원의 넓이 계산기


def circle_area_calculator(radius):
    """원의 넓이와 둘레 계산"""
    area = math.pi * radius ** 2
    circumference = 2 * math.pi * radius
    return area, circumference


print(f"\n🔵 원의 계산기:")
radius = 5
area, circumference = circle_area_calculator(radius)
print(f"반지름: {radius}cm")
print(f"넓이: {area:.2f}cm²")
print(f"둘레: {circumference:.2f}cm")

# 예제 4: 랜덤 패스워드 생성기


def generate_password(length=8):
    """랜덤 패스워드 생성"""
    import string
    characters = string.ascii_letters + string.digits  # 알파벳 + 숫자
    password = ''.join(random.choice(characters) for _ in range(length))
    return password


print(f"\n🔐 랜덤 패스워드 생성기:")
password = generate_password(12)
print(f"생성된 패스워드: {password}")

# 예제 5: 실행 시간 측정 데코레이터


def timer_decorator(func):
    """함수 실행 시간을 측정하는 데코레이터"""
    def wrapper(*args, **kwargs):
        start_time = time.perf_counter()
        result = func(*args, **kwargs)
        end_time = time.perf_counter()
        print(f"⏱️ {func.__name__} 실행 시간: {end_time - start_time:.6f}초")
        return result
    return wrapper


@timer_decorator
def slow_calculation():
    """느린 계산 예제"""
    total = 0
    for i in range(100000):
        total += math.sqrt(i + 1)
    return total


print(f"\n⏱️ 실행 시간 측정:")
result = slow_calculation()
print(f"계산 결과: {result:.2f}")

# ============================================================
# 6. 팁과 주의사항
# ============================================================

print(f"\n💡 팁과 주의사항")
print("-" * 40)

tips = [
    "1. random.seed(값)으로 랜덤 결과를 재현 가능하게 만들 수 있음",
    "2. time.sleep()은 프로그램을 정확히 멈추므로 필요할 때만 사용",
    "3. datetime 객체는 timezone을 고려해야 할 때가 있음",
    "4. math 함수들은 주로 float을 반환함",
    "5. 성능 측정할 때는 time.perf_counter() 사용 권장"
]

for tip in tips:
    print(f"💡 {tip}")

print("\n" + "=" * 60)
print("🎉 Python 라이브러리 학습 완료!")
print("=" * 60)

numbers = random.sample(range(1, 46), 6)
numbers.sort(reverse=False)
print(numbers)
