# ============================================================
# 📦 상속(Inheritance)과 클래스 확장 실습 예제
# ============================================================

# datetime 모듈: 날짜 비교에 사용
import datetime


# =========================
# 1. Product (부모 클래스)
# =========================
class Product:
    """
    상품의 기본 정보를 담는 부모 클래스
    name: 상품 이름
    price: 가격
    quantity: 재고 수량
    """

    def __init__(self, name, price, quantity):
        self.name = name
        self.price = price
        self.quantity = quantity

    def update_quantity(self, amount):
        """
        재고를 증감시키는 메서드
        amount > 0이면 입고, < 0이면 출고
        """
        self.quantity += amount
        print(
            f"{self.name} 재고가 {amount}만큼 {'증가' if amount > 0 else '감소'}했습니다. 현재 재고: {self.quantity}")

    def display_info(self):
        """상품 기본 정보를 출력하는 메서드"""
        print(f"상품명: {self.name}")
        print(f"가격: {self.price}원")
        print(f"재고: {self.quantity}개")


# =========================
# 2. Electronic (자식 클래스)
# =========================
class Electronic(Product):
    """
    전자제품 클래스
    - 기본 Product 속성 외에 warranty_period(보증 기간)를 포함
    """

    def __init__(self, name, price, quantity, warranty_period=12):
        super().__init__(name, price, quantity)  # 부모 클래스 초기화
        self.warranty_period = warranty_period

    def extend_warranty(self, months):
        """
        보증 기간을 연장하는 메서드
        """
        self.warranty_period += months
        return f"보증 기간이 {months}개월 연장되었습니다. 현재 보증기간: {self.warranty_period}개월"

    def display_info(self):
        """전자제품 정보 출력 (보증 기간 포함)"""
        super().display_info()
        print(f"보증 기간: {self.warranty_period}개월")


# =========================
# 3. Food (자식 클래스)
# =========================
class Food:
    """
    식품 클래스 (datetime 없이 유통기한 비교)
    """

    def __init__(self, name, price, quantity, expiration_date_str):
        self.name = name
        self.price = price
        self.quantity = quantity
        self.expiration_date = expiration_date_str  # 예: "2025-08-29"

    def is_expired(self, current_date_str):
        """
        문자열 날짜를 정수로 변환해 비교: "2025-08-29" → 20250829
        """
        # "-" 제거 후 정수로 변환하여 비교
        current = int(current_date_str.replace("-", ""))
        expiry = int(self.expiration_date.replace("-", ""))

        if current > expiry:
            print(f"{self.name}는 유통기한이 지났습니다.")
        else:
            print(f"{self.name}는 유통기한이 지나지 않았습니다.")

    def display_info(self):
        print(f"상품명: {self.name}")
        print(f"가격: {self.price}원")
        print(f"재고: {self.quantity}개")
        print(f"유통기한: {self.expiration_date}")

# ============================================================
# ✅ 사용 예제
# ============================================================


print("===== 전자제품 예제 =====")
tv = Electronic("Tv", 1500000, 3, 24)
tv.display_info()  # 초기 정보 출력

print(tv.extend_warranty(12))  # 보증 기간 연장
tv.display_info()  # 갱신된 정보 출력

print("\n===== 식품 예제 =====")
apple = Food("사과", 5000, 10, "2025-08-29")
apple.display_info()

apple.is_expired("2025-07-29")  # 유통기한 전
apple.is_expired("2025-09-29")  # 유통기한 후
