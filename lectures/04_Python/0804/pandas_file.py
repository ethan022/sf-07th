# CSV (Comma Separated Values)
# 가장 일반적인 데이터 파일 형식
# 쉼표(,)로 값들을 구분하여 저장하는 텍스트 파일
# 엑셀, 구글 시트, 데이터베이스 등과 호환 가능

import pandas as pd
import numpy as np

print("==== 파일 읽기와 쓰기 기본 ====")

# 추가: CSV는 데이터 분석에서 가장 많이 사용하는 파일 형식입니다.
# 텍스트 기반이라 용량이 작고, 대부분의 프로그램에서 지원합니다.

# CSV 파일 읽기 시도 (실제 파일이 없을 경우를 대비한 예외 처리)
try:
    df = pd.read_csv('pandas_csv.csv',          # 읽을 파일 경로
                     encoding='utf-8',          # 문자 인코딩 (한글 깨짐 방지)
                     sep=',',                   # 구분자 (기본값: 쉼표)
                     # header=0,                # 헤더 행 번호 (0: 첫 번째 행을 열 이름으로)
                     # index_col=0,             # 인덱스로 사용할 열 번호
                     # names=['A', 'B', 'C', 'D'],  # 직접 열 이름 지정
                     # skiprows=1,              # 처음 n행 건너뛰기
                     # nrows=2,                 # n행만 읽기
                     na_values=['N/A', '없음']   # 결측값으로 처리할 문자들
                     )
    print("CSV 파일 읽기 성공:")
    print(df)

    # CSV 파일로 저장 (일부 열만 선택해서 저장)
    df.to_csv('output.csv',
              encoding='utf-8',          # 문자 인코딩
              index=False,              # 인덱스 저장 안 함 (행 번호 제외)
              columns=['이름', '나이'])    # 특정 열만 저장
    print("output.csv 파일로 저장 완료")

except FileNotFoundError:
    print("pandas_csv.csv 파일을 찾을 수 없습니다.")
except Exception as e:
    print(f"파일 읽기 중 오류 발생: {e}")
print()

# 추가: read_csv() 주요 매개변수
# - encoding: 'utf-8'(일반적), 'cp949'(윈도우 한글), 'euc-kr'(구형 한글)
# - sep: 구분자 변경 (','→';', '\t'→탭 등)
# - header: None이면 열 이름 없음
# - index_col: 특정 열을 인덱스로 사용
# - na_values: 결측값으로 인식할 문자 지정

print("==== JSON 파일 처리 ====")

# JSON (JavaScript Object Notation) 파일 처리
try:
    df = pd.read_json('pandas_json.json')      # JSON 파일 읽기
    print("JSON 파일 읽기 성공:")
    print(df)

    # JSON 파일로 저장
    df.to_json('output.json',
               orient='records',        # 데이터 구조 형태 ('records': 각 행이 객체)
               force_ascii=False)       # 한글 그대로 저장 (False: 유니코드 유지)
    print("output.json 파일로 저장 완료")

except FileNotFoundError:
    print("pandas_json.json 파일을 찾을 수 없습니다.")
except Exception as e:
    print(f"JSON 파일 처리 중 오류 발생: {e}")
print()

# 추가: JSON은 웹 API나 NoSQL 데이터베이스에서 많이 사용합니다.
# orient 옵션: 'records', 'index', 'values', 'table' 등 다양한 형태로 저장 가능

print("\n" + "="*50)
print("실무 예제: 도서관 관리 시스템")
print("="*50)

# 실제 도서관에서 사용할 수 있는 도서 데이터 생성
book_data = {
    '도서명': ['파이썬 기초', '데이터 분석', '머신러닝', '웹 개발', '소설 읽기'],
    '저자': ['김파이썬', '박데이터', '이머신', '최웹개발', '한소설'],
    '가격': [25000, 30000, 35000, 28000, 15000],
    '재고': [20, 15, 10, 25, 30],
    '분야': ['IT', 'IT', 'IT', 'IT', '문학']
}

book_df = pd.DataFrame(book_data)
print("=== 도서관 도서 목록 생성 ===")
print(book_df)
print()

# 추가: 실무에서는 이런 식으로 데이터를 생성하거나 다른 시스템에서 가져와서
# DataFrame으로 만든 후, 분석하고, 다시 파일로 저장하는 과정을 반복합니다.

print("=== 도서 데이터 기본 분석 ===")
print(f"총 도서 수: {len(book_df)}권")
print(f"평균 가격: {book_df['가격'].mean():,.0f}원")
print(f"총 재고: {book_df['재고'].sum()}권")
print(f"분야별 도서 수:")
print(book_df['분야'].value_counts())  # 분야별 개수 세기
print()

# CSV 파일로 저장 (실제 파일 생성)
print("=== CSV 파일로 저장 ===")
book_df.to_csv('library_books.csv',    # 저장할 파일 이름
               index=False,            # 행 번호(인덱스) 저장하지 않음
               encoding='utf-8')       # 한글 깨짐 방지
print("library_books.csv 파일 저장 완료")
print()

# 추가: index=False는 매우 중요합니다.
# True로 하면 0,1,2,3... 같은 행 번호가 첫 번째 열로 저장됩니다.

try:
    print("=== 저장된 파일 다시 읽어오기 ===")
    loaded_books = pd.read_csv('library_books.csv', encoding='utf-8')
    print("파일 읽기 성공:")
    print(loaded_books)
    print()

    # 읽어온 데이터 검증
    print("=== 데이터 검증 ===")
    print(f"원본과 동일한지 확인: {book_df.equals(loaded_books)}")  # 데이터 일치 여부
    print()

    print("=== 파일에서 읽은 데이터의 기본 정보 ===")
    print(f"데이터 모양 (행, 열): {loaded_books.shape}")
    print(f"열 이름들: {list(loaded_books.columns)}")
    print(f"각 열의 데이터 타입:")
    print(loaded_books.dtypes)
    print()

    # 추가: 파일에서 읽어온 데이터는 모든 열이 문자열일 수 있습니다.
    # 필요시 astype()으로 데이터 타입을 변경해야 합니다.

    print("=== 실무 데이터 분석 예제 ===")

    # 1. IT 분야 도서만 필터링
    print("1) IT 분야 도서 필터링:")
    it_books = loaded_books[loaded_books['분야'] == 'IT']
    print(f"IT 분야 도서: {len(it_books)}권")
    print(it_books[['도서명', '저자', '가격']])  # 주요 정보만 표시
    print()

    # 2. 가격이 30,000원 이상인 고가 도서
    print("2) 30,000원 이상 고가 도서:")
    expensive_books = loaded_books[loaded_books['가격'] >= 30000]
    print(f"30,000원 이상 도서: {len(expensive_books)}권")
    print(expensive_books[['도서명', '가격', '재고']])
    print()

    # 3. 재고가 부족한 도서 (15권 미만)
    print("3) 재고 부족 도서 (15권 미만):")
    low_stock = loaded_books[loaded_books['재고'] < 15]
    print(f"재고 부족 도서: {len(low_stock)}권")
    print(low_stock[['도서명', '재고']])
    print()

    # 4. 분야별 평균 가격
    print("4) 분야별 평균 가격:")
    avg_price_by_field = loaded_books.groupby('분야')['가격'].mean()
    print(avg_price_by_field)
    print()

    # 5. 가장 비싼 도서와 가장 저렴한 도서
    print("5) 최고가/최저가 도서:")
    most_expensive = loaded_books.loc[loaded_books['가격'].idxmax()]
    cheapest = loaded_books.loc[loaded_books['가격'].idxmin()]

    print(f"최고가 도서: {most_expensive['도서명']} - {most_expensive['가격']:,}원")
    print(f"최저가 도서: {cheapest['도서명']} - {cheapest['가격']:,}원")
    print()

    # 추가: 실무에서는 이런 식으로 데이터를 여러 관점에서 분석합니다.
    # 필터링, 그룹화, 통계 계산 등을 조합하여 의미있는 인사이트를 도출합니다.

    print("=== 분석 결과를 새로운 파일로 저장 ===")

    # IT 분야 도서만 별도 파일로 저장
    it_books.to_csv('it_books_only.csv', index=False, encoding='utf-8')
    print("IT 분야 도서를 it_books_only.csv로 저장")

    # 고가 도서 목록 저장
    expensive_books.to_csv('expensive_books.csv',
                           index=False, encoding='utf-8')
    print("고가 도서 목록을 expensive_books.csv로 저장")

    # 분야별 통계를 새로운 DataFrame으로 만들어 저장
    field_stats = loaded_books.groupby('분야').agg({
        '가격': ['mean', 'min', 'max'],    # 가격의 평균, 최소, 최대
        '재고': ['sum', 'mean'],           # 재고의 합계, 평균
        '도서명': 'count'                  # 도서 개수
    }).round(0)  # 소수점 반올림

    # 다중 인덱스 열 이름을 단순화
    field_stats.columns = ['평균가격', '최저가격', '최고가격', '총재고', '평균재고', '도서수']
    field_stats.to_csv('field_statistics.csv', encoding='utf-8')
    print("분야별 통계를 field_statistics.csv로 저장")
    print(field_stats)
    print()

    # 추가: groupby().agg()로 복잡한 통계를 한번에 계산할 수 있습니다.
    # 결과를 다시 CSV로 저장하여 보고서나 다른 시스템에서 활용할 수 있습니다.

except FileNotFoundError:
    print("library_books.csv 파일을 찾을 수 없습니다.")
except Exception as e:
    print(f"파일 처리 중 오류 발생: {e}")

print("\n" + "="*50)
print("다양한 파일 형식 처리")
print("="*50)

# 실제 데이터로 다양한 형식 저장 예제
sample_data = pd.DataFrame({
    '제품명': ['노트북', '마우스', '키보드', '모니터'],
    '가격': [800000, 25000, 45000, 300000],
    '카테고리': ['컴퓨터', '주변기기', '주변기기', '컴퓨터'],
    '평점': [4.5, 4.2, 4.0, 4.8]
})

print("=== 샘플 제품 데이터 ===")
print(sample_data)
print()

# 1. CSV 형식으로 저장 (가장 일반적)
sample_data.to_csv('products.csv', index=False, encoding='utf-8')
print("1) CSV 형식으로 저장: products.csv")

# 2. TSV 형식으로 저장 (탭으로 구분)
sample_data.to_csv('products.tsv', sep='\t', index=False, encoding='utf-8')
print("2) TSV 형식으로 저장: products.tsv")

# 3. JSON 형식으로 저장
sample_data.to_json('products.json', orient='records',
                    force_ascii=False, indent=2)
print("3) JSON 형식으로 저장: products.json")

# 4. Excel 형식으로 저장 (openpyxl 라이브러리 필요)
try:
    sample_data.to_excel('products.xlsx', index=False, sheet_name='제품목록')
    print("4) Excel 형식으로 저장: products.xlsx")
except ImportError:
    print("4) Excel 저장을 위해 openpyxl 라이브러리가 필요합니다: pip install openpyxl")

print()

# 추가: 실무에서는 용도에 따라 다른 파일 형식을 선택합니다.
# - CSV: 가장 호환성 좋음, 용량 작음
# - TSV: 데이터에 쉼표가 많을 때
# - JSON: 웹 API, NoSQL 데이터베이스 연동
# - Excel: 비개발자와 공유, 서식 필요시

print("=== 파일 읽기 옵션 비교 ===")

# 다양한 읽기 옵션 시연을 위한 테스트 데이터 생성
test_data = """이름,나이,점수,특이사항
김철수,20,85,없음
이영희,21,92,N/A
박민수,19,78,
최지영,22,96,우수"""

# 임시 파일 생성
with open('test_data.csv', 'w', encoding='utf-8') as f:
    f.write(test_data)

print("테스트용 CSV 파일 내용:")
print(test_data)
print()

# 기본 읽기
df1 = pd.read_csv('test_data.csv')
print("1) 기본 읽기:")
print(df1)
print(f"결측값 개수: {df1.isnull().sum().sum()}")
print()

# 결측값 처리 옵션 추가
df2 = pd.read_csv('test_data.csv', na_values=['없음', 'N/A', ''])
print("2) 결측값 처리 후:")
print(df2)
print(f"결측값 개수: {df2.isnull().sum().sum()}")
print()

# 특정 열만 읽기
df3 = pd.read_csv('test_data.csv', usecols=['이름', '점수'])
print("3) 특정 열만 읽기:")
print(df3)
print()

# 추가: usecols로 필요한 열만 읽으면 메모리 절약과 성능 향상에 도움됩니다.
# 대용량 파일에서 특히 유용합니다.

print("=== 대용량 파일 처리 팁 ===")

# 청크 단위로 파일 읽기 (대용량 파일 처리)
print("청크 단위 읽기 예제:")
chunk_size = 2  # 실제로는 10000 이상 사용
chunk_reader = pd.read_csv('test_data.csv', chunksize=chunk_size)

for i, chunk in enumerate(chunk_reader):
    print(f"청크 {i+1}:")
    print(chunk)
    print()
    if i >= 1:  # 예제이므로 2개 청크만 보여주기
        break

# 추가: chunksize 옵션으로 큰 파일을 작은 단위로 나누어 처리할 수 있습니다.
# 메모리 부족을 방지하고, 중간 결과를 저장하며 처리할 수 있습니다.

print("\n" + "="*50)
print("핵심 정리")
print("="*50)
print("""
파일 입출력 핵심 개념:

1. CSV 파일 처리:
   - 읽기: pd.read_csv('파일명.csv', encoding='utf-8')
   - 쓰기: df.to_csv('파일명.csv', index=False, encoding='utf-8')
   - 주요 옵션: sep(구분자), header(헤더), na_values(결측값)

2. 다양한 파일 형식:
   - JSON: read_json(), to_json(orient='records')
   - Excel: read_excel(), to_excel() (openpyxl 필요)
   - TSV: sep='\t' 옵션 사용

3. 읽기 최적화 옵션:
   - usecols: 필요한 열만 읽기
   - nrows: 일부 행만 읽기
   - chunksize: 대용량 파일을 청크로 분할
   - dtype: 데이터 타입 지정

4. 한글 처리:
   - encoding='utf-8': 일반적인 한글 인코딩
   - encoding='cp949': 윈도우 한글 인코딩
   - force_ascii=False: JSON에서 한글 보존

5. 실무 활용 패턴:
   - 데이터 읽기 → 분석/처리 → 결과 저장
   - 조건별 필터링 후 별도 파일 저장
   - 통계 결과를 요약 파일로 생성
   - 예외 처리로 안정적인 파일 처리

6. 성능 고려사항:
   - 대용량 파일은 chunksize 사용
   - 필요한 열만 usecols로 선택
   - 적절한 데이터 타입 지정으로 메모리 절약

파일 입출력은 데이터 분석의 시작과 끝입니다.
다양한 소스에서 데이터를 가져오고, 분석 결과를 공유하는 
핵심 기술입니다!
""")
