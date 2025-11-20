# enumerate
# 반복 가능한 객체를 받아서 인덱스와 값을 함께 반환하는 내장 함수

print("=========== enumerate - nums ===============")
nums = [10, 20, 30, 40, 50, 60]
for i, num in enumerate(nums, 12):
    print(f"숫자: {i}, 값: {num}")
print()

print("=========== enumerate - fruits ===============")
fruits = ["사과", "바나나", "수박", "포도", "복숭아"]
for i, value in enumerate(fruits, 5):
    print(f"숫자?: {i}, 값: {value}")
