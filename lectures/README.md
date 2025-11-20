# Lectures - 학습 자료 모음

## 개요

이 폴더는 SFS 7기 과정에서 학습한 모든 강의 자료를 체계적으로 정리한 곳입니다. C# 기초부터 WPF, OpenCvSharp, Python 데이터 분석, 자료구조까지 5개의 주요 학습 영역으로 구성되어 있습니다.

## 폴더 구조

```
lectures/
├── 01_CSharp_Basic/          # C# 프로그래밍 기초
├── 02_WPF/                   # WPF 데스크톱 애플리케이션
├── 03_OpenCvSharp/           # 컴퓨터 비전과 이미지 처리
├── 04_Python/                # Python 데이터 분석
└── 05_DataStructures/        # 자료구조 구현
```

## 학습 모듈 소개

### 01_CSharp_Basic - C# 프로그래밍 기초

**학습 기간**: 2-3주
**난이도**: 초급
**파일 수**: 38개

C# 언어의 기초부터 객체지향 프로그래밍, 고급 기능까지 단계별로 학습합니다.

**핵심 주제:**
- 변수, 자료형, 연산자
- 조건문, 반복문, 배열
- 메서드와 함수
- 클래스와 객체지향 프로그래밍
- 상속, 다형성, 인터페이스
- 델리게이트, 람다식, LINQ
- 컬렉션과 예외 처리

**시작하기:** [01_CSharp_Basic/README.md](./01_CSharp_Basic/README.md)

---

### 02_WPF - WPF 데스크톱 애플리케이션

**학습 기간**: 2주
**난이도**: 중급
**프로젝트 수**: 14개

XAML을 사용한 GUI 애플리케이션 개발과 MVVM 디자인 패턴을 마스터합니다.

**핵심 주제:**
- XAML 문법과 레이아웃
- 데이터 바인딩
- MVVM 패턴 (Model-View-ViewModel)
- INotifyPropertyChanged, ICommand
- ObservableCollection
- 실전 프로젝트 (계산기, Todo 리스트)

**완성 프로젝트:**
- 계산기 애플리케이션
- Todo 리스트 애플리케이션
- 학생 관리 시스템

**시작하기:** [02_WPF/README.md](./02_WPF/README.md)

---

### 03_OpenCvSharp - 컴퓨터 비전과 이미지 처리

**학습 기간**: 2주
**난이도**: 중급
**프로젝트 수**: 14개

OpenCvSharp 라이브러리를 활용한 이미지 처리와 컴퓨터 비전 기술을 학습합니다.

**핵심 주제:**
- OpenCvSharp 기초 (Mat, Point, Size, Scalar)
- 이미지 파일 입출력 및 ROI
- 색상 공간 변환
- 블러링과 필터링
- 임계값 처리와 이진화
- 엣지 검출 (Sobel, Canny)
- 윤곽선 검출
- 실시간 카메라 처리

**최종 프로젝트:**
- 명함 검출 및 OCR 시스템

**시작하기:** [03_OpenCvSharp/README.md](./03_OpenCvSharp/README.md)

---

### 04_Python - Python 데이터 분석

**학습 기간**: 2주
**난이도**: 초급-중급
**파일 수**: 22개

Python 기초부터 NumPy, Pandas, Matplotlib을 활용한 데이터 분석까지 학습합니다.

**핵심 주제:**
- Python 기초 (클래스, 모듈, 파일 입출력)
- 표준 라이브러리 활용
- NumPy 배열 연산
- Pandas DataFrame 조작
- 데이터 정렬, 그룹화, 피봇 테이블
- 결측값 및 중복 데이터 처리
- Matplotlib 시각화

**학습 데이터셋:**
- 도서관 도서 데이터
- KBO 야구 데이터
- 판다스 실습 데이터

**시작하기:** [04_Python/README.md](./04_Python/README.md)

---

### 05_DataStructures - 자료구조 구현

**학습 기간**: 1주
**난이도**: 중급
**프로젝트 수**: 2개

기본 자료구조를 직접 구현하며 알고리즘의 기초를 다집니다.

**핵심 주제:**
- 연결 리스트 (LinkedList)
  - 단일 연결 리스트
  - 이중 연결 리스트
  - 노드 추가/삭제/탐색
- 스택 (Stack)
  - LIFO 구조
  - Push, Pop, Peek 연산
  - 실제 활용 사례

**시간 복잡도 분석:**
- 각 연산의 Big-O 표기법 이해
- 최적화 기법 학습

**시작하기:** [05_DataStructures/README.md](./05_DataStructures/README.md)

---

## 추천 학습 순서

### 순차 학습 경로 (총 9-10주)

```
1주차-3주차: 01_CSharp_Basic
    ↓
4주차-5주차: 02_WPF
    ↓
6주차-7주차: 03_OpenCvSharp
    ↓
8주차-9주차: 04_Python
    ↓
10주차: 05_DataStructures
```

### 병렬 학습 경로 (C#과 Python 동시 학습)

**C# 트랙 (6주)**
```
1주차-3주차: 01_CSharp_Basic
4주차-5주차: 02_WPF
6주차: 03_OpenCvSharp
```

**Python 트랙 (3주)**
```
1주차-2주차: 04_Python (기초 + NumPy/Pandas)
3주차: 04_Python (Matplotlib + 실전 프로젝트)
```

**공통**
```
마지막 주: 05_DataStructures
```

### 프로젝트 중심 학습 경로

각 모듈의 기초를 빠르게 학습한 후, 프로젝트를 만들며 심화 학습:

1. C# 기초 (1주) → WPF 계산기 프로젝트 (1주)
2. OpenCvSharp 기초 (1주) → 이미지 필터 앱 (1주)
3. Python 기초 (1주) → 데이터 분석 프로젝트 (1주)

---

## 학습 방법 가이드

### 효과적인 학습을 위한 팁

1. **순차적 학습**
   - 각 폴더는 체계적인 순서로 구성되어 있습니다
   - 날짜 순서대로 학습하면 자연스럽게 난이도가 증가합니다

2. **실습 중심**
   - 코드를 읽기만 하지 말고 직접 타이핑하세요
   - 각 예제를 실행하고 결과를 확인하세요
   - 코드를 변형해보며 실험하세요

3. **주석 활용**
   - 모든 파일에 상세한 한글 주석이 작성되어 있습니다
   - 주석을 꼼꼼히 읽으면 이해가 쉽습니다
   - 이해한 내용을 자신의 말로 다시 주석을 작성해보세요

4. **프로젝트 완성**
   - 각 모듈의 학습을 마친 후 반드시 프로젝트를 만드세요
   - 배운 내용을 종합하는 과정에서 진짜 실력이 향상됩니다

5. **오류 해결 경험**
   - 오류가 발생하면 직접 해결을 시도하세요
   - 오류 메시지를 읽고 이해하는 연습을 하세요
   - 해결 과정을 문서화하세요

6. **복습과 반복**
   - 어려운 개념은 반복해서 학습하세요
   - 이전에 학습한 내용을 정기적으로 복습하세요

---

## 학습 목표 체크리스트

### 01_CSharp_Basic
- [ ] 변수와 자료형을 이해하고 적절히 사용할 수 있다
- [ ] 조건문과 반복문으로 프로그램 흐름을 제어할 수 있다
- [ ] 메서드를 작성하고 활용할 수 있다
- [ ] 클래스를 설계하고 객체를 생성할 수 있다
- [ ] 상속과 다형성을 이해하고 구현할 수 있다
- [ ] LINQ를 사용하여 데이터를 조작할 수 있다

### 02_WPF
- [ ] XAML로 UI를 디자인할 수 있다
- [ ] 데이터 바인딩을 이해하고 구현할 수 있다
- [ ] MVVM 패턴을 이해하고 적용할 수 있다
- [ ] ICommand를 구현하여 이벤트를 처리할 수 있다
- [ ] 완전한 MVVM 애플리케이션을 만들 수 있다

### 03_OpenCvSharp
- [ ] 이미지를 읽고 쓸 수 있다
- [ ] 다양한 필터를 적용할 수 있다
- [ ] 엣지 검출과 윤곽선 검출을 구현할 수 있다
- [ ] 실시간 카메라 영상을 처리할 수 있다
- [ ] 이미지 처리 프로젝트를 완성할 수 있다

### 04_Python
- [ ] Python 기초 문법을 이해하고 사용할 수 있다
- [ ] NumPy로 배열 연산을 수행할 수 있다
- [ ] Pandas로 데이터를 읽고 조작할 수 있다
- [ ] Matplotlib으로 데이터를 시각화할 수 있다
- [ ] 실제 데이터를 분석하는 프로젝트를 만들 수 있다

### 05_DataStructures
- [ ] 연결 리스트를 이해하고 구현할 수 있다
- [ ] 스택을 이해하고 구현할 수 있다
- [ ] 시간 복잡도를 분석할 수 있다
- [ ] 적절한 자료구조를 선택하여 사용할 수 있다

---

## 문제 해결 가이드

### 자주 발생하는 문제

#### C# / WPF
```
문제: "빌드 오류 - NuGet 패키지 복원 실패"
해결: Visual Studio에서 솔루션 우클릭 → "NuGet 패키지 복원"
```

#### OpenCvSharp
```
문제: "DllNotFoundException: opencv_world"
해결: OpenCvSharp4.runtime.win 패키지 설치 확인
```

#### Python
```
문제: "ModuleNotFoundError: No module named 'pandas'"
해결: pip install numpy pandas matplotlib
```

### 추가 도움말

각 폴더의 README.md에 더 자세한 문제 해결 가이드가 있습니다.

---

## 추가 학습 자료

### 공식 문서
- [Microsoft C# 문서](https://docs.microsoft.com/ko-kr/dotnet/csharp/)
- [WPF 문서](https://docs.microsoft.com/ko-kr/dotnet/desktop/wpf/)
- [OpenCvSharp GitHub](https://github.com/shimat/opencvsharp)
- [Python 공식 문서](https://docs.python.org/ko/3/)
- [Pandas 문서](https://pandas.pydata.org/docs/)

### 추천 책
- C#: "C# 완벽 가이드" (제프리 리처)
- WPF: "WPF MVVM 패턴" (폴 셰리프)
- Python: "Python for Data Analysis" (웨스 맥키니)

### 온라인 강의
- [Microsoft Learn](https://learn.microsoft.com/ko-kr/)
- [Real Python](https://realpython.com/)
- [DataCamp](https://www.datacamp.com/)

---

## 프로젝트 아이디어

학습을 완료한 후 다음 프로젝트를 만들어보세요:

### C# + WPF
- [ ] 메모장 애플리케이션
- [ ] 가계부 애플리케이션
- [ ] 음악 플레이어
- [ ] 미니 게임 (테트리스, 뱀 게임)

### OpenCvSharp
- [ ] 얼굴 인식 프로그램
- [ ] 문서 스캐너
- [ ] 실시간 필터 카메라
- [ ] 객체 추적 시스템

### Python
- [ ] 주식 데이터 분석 대시보드
- [ ] 날씨 데이터 시각화
- [ ] 웹 크롤링 및 분석
- [ ] 간단한 머신러닝 프로젝트

---

## 학습 성과

이 모든 모듈을 완료하면 다음을 할 수 있게 됩니다:

- C#으로 객체지향 프로그램을 작성할 수 있습니다
- WPF로 전문적인 데스크톱 애플리케이션을 개발할 수 있습니다
- OpenCvSharp으로 이미지 처리 애플리케이션을 만들 수 있습니다
- Python으로 데이터를 분석하고 시각화할 수 있습니다
- 기본 자료구조를 이해하고 구현할 수 있습니다

---

## 다음 단계

모든 학습을 완료한 후:

1. **포트폴리오 프로젝트 만들기**
   - 배운 내용을 종합한 프로젝트
   - GitHub에 올리고 README 작성

2. **심화 학습**
   - ASP.NET Core (웹 개발)
   - Machine Learning (머신러닝)
   - Database (데이터베이스)

3. **커뮤니티 참여**
   - 오픈소스 프로젝트 기여
   - 스터디 그룹 참여
   - 기술 블로그 작성

---

## 기여

이 학습 자료에 대한 개선 사항이나 오류를 발견하면 언제든지 알려주세요.

## 라이선스

이 학습 자료는 교육 목적으로 자유롭게 사용할 수 있습니다.

---

**학습 여정을 응원합니다!**
