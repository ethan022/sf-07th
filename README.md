# SFS07th 학습 프로젝트

## 프로젝트 개요

이 저장소는 SFS (Software Foundational Study) 7기 과정에서 학습한 내용을 정리한 것입니다. C# 기초부터 WPF, OpenCvSharp, Python 데이터 분석까지 다양한 기술 스택을 다룹니다.

## 학습 목표

- C# 프로그래밍 언어의 기초부터 고급 개념까지 완전히 이해하기
- WPF를 활용한 데스크톱 애플리케이션 개발 능력 배양
- OpenCvSharp을 통한 컴퓨터 비전과 이미지 처리 기술 습득
- Python을 이용한 데이터 분석과 시각화 기술 익히기
- 기본 자료구조의 구현과 활용 방법 학습

## 프로젝트 구조

```
SFS07th/
├── lectures/                      # 학습 자료 모음
│   ├── 01_CSharp_Basic/          # C# 기초 프로그래밍
│   ├── 02_WPF/                   # WPF 데스크톱 애플리케이션
│   ├── 03_OpenCvSharp/           # OpenCV 이미지 처리
│   ├── 04_Python/                # Python 데이터 분석
│   └── 05_DataStructures/        # 자료구조 구현
├── data/                          # 데이터 파일
├── ConsoleApp1.sln               # Visual Studio 솔루션
└── README.md                     # 이 파일
```

## 각 폴더별 상세 내용

### 01_CSharp_Basic - C# 기초 프로그래밍

C#의 기초 문법부터 객체지향 프로그래밍, 고급 기능까지 단계별로 학습합니다.

**주요 학습 내용:**
- 변수, 자료형, 연산자, 조건문, 반복문
- 메서드, 구조체, 클래스
- 상속, 다형성, 추상 클래스, 인터페이스
- 정적 멤버, 프로퍼티, 생성자
- 델리게이트, 람다식, LINQ
- 컬렉션, 예외 처리

**학습 순서:**
1. 기초 문법 (변수, 연산자, 조건문)
2. 반복문과 배열
3. 메서드와 함수
4. 클래스와 객체
5. 상속과 다형성
6. 고급 기능 (델리게이트, LINQ)

**상세 내용:** [lectures/01_CSharp_Basic/README.md](./lectures/01_CSharp_Basic/README.md)

### 02_WPF - Windows Presentation Foundation

XAML을 사용한 GUI 애플리케이션 개발과 MVVM 디자인 패턴을 학습합니다.

**주요 학습 내용:**
- XAML 기초 문법
- 레이아웃 컨트롤 (Grid, StackPanel, Canvas)
- 입력 컨트롤 (TextBox, Button, ComboBox 등)
- 데이터 바인딩
- MVVM 패턴 (Model-View-ViewModel)
- INotifyPropertyChanged, ICommand
- ObservableCollection
- 실전 프로젝트 (계산기, Todo 리스트)

**학습 순서:**
1. WPF 기초 (컨트롤과 레이아웃)
2. 데이터 바인딩
3. MVVM 패턴 입문
4. 완전한 MVVM 애플리케이션

**상세 내용:** [lectures/02_WPF/README.md](./lectures/02_WPF/README.md)

### 03_OpenCvSharp - 컴퓨터 비전과 이미지 처리

OpenCvSharp 라이브러리를 사용하여 이미지와 비디오 처리 기술을 학습합니다.

**주요 학습 내용:**
- OpenCvSharp 기초 (Mat, Point, Size, Scalar)
- 이미지 파일 입출력
- ROI와 픽셀 접근
- 색상 공간 변환 (BGR, Grayscale, HSV)
- 블러링 (Gaussian, Median, Bilateral)
- 임계값 처리 (Simple, Adaptive, Otsu)
- 엣지 검출 (Sobel, Canny)
- 윤곽선 검출
- 실시간 카메라 처리
- 마우스/키보드 이벤트
- 실전 프로젝트 (명함 검출 및 OCR)

**학습 순서:**
1. OpenCvSharp 기초와 Mat 클래스
2. 이미지 파일 처리
3. 필터링과 이진화
4. 엣지 검출과 윤곽선
5. 실시간 카메라 처리
6. 종합 프로젝트

**상세 내용:** [lectures/03_OpenCvSharp/README.md](./lectures/03_OpenCvSharp/README.md)

### 04_Python - Python 프로그래밍과 데이터 분석

Python 기초부터 NumPy, Pandas, Matplotlib을 활용한 데이터 분석까지 학습합니다.

**주요 학습 내용:**
- Python 기초 (클래스, 함수, 모듈)
- 표준 라이브러리 (datetime, math, random, os, json)
- 파일 입출력
- NumPy 배열과 연산
- Pandas (Series, DataFrame, 데이터 조작)
- 데이터 정렬, 그룹화, 피봇 테이블
- 결측값과 중복 데이터 처리
- Matplotlib 시각화 (선 그래프, 막대 그래프, 산점도, 히스토그램)

**학습 순서:**
1. Python 기초 문법
2. 표준 라이브러리
3. NumPy 배열 연산
4. Pandas 데이터 처리
5. Matplotlib 시각화

**상세 내용:** [lectures/04_Python/README.md](./lectures/04_Python/README.md)

### 05_DataStructures - 자료구조 구현

기본 자료구조를 직접 구현하고 활용 방법을 학습합니다.

**주요 학습 내용:**
- 연결 리스트 (LinkedList)
  - 단일 연결 리스트
  - 이중 연결 리스트
  - 노드 추가, 삭제, 탐색
- 스택 (Stack)
  - LIFO 구조
  - Push, Pop, Peek 연산
  - 실제 활용 사례

**시간 복잡도 분석:**
- 연결 리스트: AddFirst O(1), Find O(n), Remove O(n)
- 스택: Push O(1), Pop O(1), Peek O(1)

**상세 내용:** [lectures/05_DataStructures/README.md](./lectures/05_DataStructures/README.md)

### data/ - 데이터 파일

학습 과정에서 사용한 데이터 파일들을 보관합니다.

**포함된 파일:**
- CSV 파일 (library_books.csv, pandas_csv.csv, output.csv)
- JSON 파일 (pandas_json.json, output.json)
- 텍스트 파일 (kbo_sorted.txt)

## 개발 환경

### C# / WPF / OpenCvSharp
- **IDE:** Visual Studio 2022 또는 Visual Studio Code
- **언어:** C# 10.0 이상
- **프레임워크:** .NET 6.0 이상
- **NuGet 패키지:**
  - OpenCvSharp4: 4.11.0.20250507
  - OpenCvSharp4.runtime.win: 4.11.0.20250507
  - OpenCvSharp4.Extensions (WPF용)

### Python
- **버전:** Python 3.8 이상
- **필요 패키지:**
  - numpy
  - pandas
  - matplotlib
  - jupyter (선택사항)

## 실행 방법

### C# 프로젝트 실행

**방법 1: Visual Studio 사용**
1. `ConsoleApp1.sln` 파일을 Visual Studio로 엽니다.
2. 실행하고 싶은 프로젝트를 시작 프로젝트로 설정합니다.
   - 솔루션 탐색기에서 프로젝트 우클릭 → "시작 프로젝트로 설정"
3. F5 키를 눌러 디버그 모드로 실행하거나 Ctrl+F5로 실행합니다.

**방법 2: 명령줄 사용**
```bash
# 특정 프로젝트 폴더로 이동
cd lectures/01_CSharp_Basic/0717

# 프로젝트 빌드
dotnet build

# 프로젝트 실행
dotnet run
```

### Python 프로젝트 실행

**필요 패키지 설치:**
```bash
pip install numpy pandas matplotlib
```

**Python 파일 실행:**
```bash
cd lectures/04_Python/0729
python 0729_1.py
```

**Jupyter Notebook 사용 (선택사항):**
```bash
pip install jupyter
jupyter notebook
```

## 학습 로드맵

### 1단계: C# 기초 (2-3주)
- lectures/01_CSharp_Basic 폴더의 내용을 순서대로 학습
- 각 개념을 이해하고 직접 코드를 작성해보기
- 연습 문제를 풀어보며 실력 향상

### 2단계: WPF GUI 개발 (2주)
- lectures/02_WPF 폴더의 기초 내용부터 시작
- 간단한 GUI 애플리케이션 만들어보기
- MVVM 패턴을 이해하고 적용하기

### 3단계: 이미지 처리 (2주)
- lectures/03_OpenCvSharp 폴더의 내용 학습
- 다양한 이미지 처리 기법 실습
- 실전 프로젝트 완성하기

### 4단계: 데이터 분석 (2주)
- Python 기초 복습
- NumPy와 Pandas 활용법 익히기
- Matplotlib으로 데이터 시각화

### 5단계: 자료구조 (1주)
- 기본 자료구조 이해
- 직접 구현해보기
- 알고리즘 문제에 적용하기

## 학습 팁

1. **순서대로 학습하기**: 각 폴더는 체계적인 순서로 구성되어 있습니다. 기초부터 차근차근 학습하세요.

2. **직접 코드 작성하기**: 코드를 읽기만 하지 말고 직접 타이핑하면서 이해하세요.

3. **주석 활용하기**: 모든 파일에 상세한 주석이 작성되어 있습니다. 주석을 꼼꼼히 읽으면 이해가 쉽습니다.

4. **실습 중심 학습**: 개념을 배운 후에는 반드시 직접 구현해보세요.

5. **오류 해결 경험 쌓기**: 오류가 발생하면 직접 해결해보는 과정에서 많이 배웁니다.

6. **README 문서 활용**: 각 폴더의 README.md를 먼저 읽고 전체 구조를 파악하세요.

7. **프로젝트 만들기**: 배운 내용을 종합하여 자신만의 프로젝트를 만들어보세요.

## 문제 해결 (Troubleshooting)

### Visual Studio 빌드 오류
```
문제: NuGet 패키지 복원 실패
해결: 솔루션 탐색기에서 솔루션 우클릭 → "NuGet 패키지 복원"
```

### Python 모듈 Import 오류
```
문제: ModuleNotFoundError: No module named 'numpy'
해결: pip install numpy pandas matplotlib
```

### OpenCvSharp 실행 오류
```
문제: DllNotFoundException: opencv_world
해결: OpenCvSharp4.runtime.win 패키지 설치 확인
```

### WPF 디자이너 오류
```
문제: XAML 디자이너가 표시되지 않음
해결: Visual Studio를 재시작하거나 프로젝트를 다시 로드
```

## 추가 학습 자료

### 공식 문서
- [Microsoft C# 문서](https://docs.microsoft.com/ko-kr/dotnet/csharp/)
- [WPF 문서](https://docs.microsoft.com/ko-kr/dotnet/desktop/wpf/)
- [OpenCvSharp 문서](https://github.com/shimat/opencvsharp)
- [Python 공식 문서](https://docs.python.org/ko/3/)
- [Pandas 문서](https://pandas.pydata.org/docs/)

### 추천 학습 사이트
- [Microsoft Learn](https://learn.microsoft.com/ko-kr/)
- [W3Schools C# Tutorial](https://www.w3schools.com/cs/)
- [Real Python](https://realpython.com/)
- [DataCamp](https://www.datacamp.com/)

### 연습 문제 사이트
- [백준 온라인 저지](https://www.acmicpc.net/)
- [프로그래머스](https://programmers.co.kr/)
- [LeetCode](https://leetcode.com/)
- [HackerRank](https://www.hackerrank.com/)

## 프로젝트 아이디어

학습을 마친 후 다음과 같은 프로젝트를 만들어보세요:

### C# / WPF
- 메모장 애플리케이션
- 간단한 계산기 (이미 포함됨)
- Todo 리스트 (이미 포함됨)
- 가계부 애플리케이션
- 미니 게임 (테트리스, 뱀 게임 등)

### OpenCvSharp
- 얼굴 인식 프로그램
- 문서 스캐너
- 차선 인식 시스템
- 객체 추적 프로그램
- 이미지 필터 애플리케이션

### Python
- 주식 데이터 분석
- 날씨 데이터 시각화
- 영화 추천 시스템
- 웹 크롤링 및 데이터 분석
- 머신러닝 기초 프로젝트

## 기여 및 피드백

이 프로젝트는 학습 목적으로 작성되었습니다. 개선 사항이나 질문이 있다면 언제든지 Issue를 등록하거나 Pull Request를 보내주세요.

## 라이선스

이 프로젝트는 학습 목적으로 제작되었으며, 자유롭게 사용할 수 있습니다.

## 작성자

SFS 7기 학생

## 마지막 업데이트

2025년 1월
