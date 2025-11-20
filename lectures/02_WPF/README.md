# WPF 학습 프로젝트

## 학습 목표

이 프로젝트는 C# WPF (Windows Presentation Foundation)의 기본 개념부터 MVVM 패턴까지 단계적으로 학습하는 과정을 담고 있습니다. XAML을 활용한 UI 구성, 데이터 바인딩, 이벤트 처리, 그리고 현대적인 MVVM 아키텍처 패턴을 익히는 것을 목표로 합니다.

## 주요 학습 내용

### 1. WPF 기본 개념
- XAML 문법 및 레이아웃 시스템
- 컨트롤 사용법 및 이벤트 처리
- 데이터 바인딩 기초
- 리소스 관리 및 스타일링

### 2. MVVM 패턴
- Model-View-ViewModel 아키텍처 이해
- INotifyPropertyChanged 인터페이스 활용
- ICommand 패턴을 통한 명령 처리
- ObservableCollection을 활용한 컬렉션 바인딩

### 3. 실전 응용
- 데이터 관리 애플리케이션
- 계산기 구현
- Todo 리스트 애플리케이션
- 차트/그래프 시각화

## 폴더별 학습 내용

### 0811 - WPF 기본 레이아웃과 컨트롤

**학습 주제:**
- Grid 레이아웃 시스템
- StackPanel을 활용한 컨트롤 배치
- 기본 입력 컨트롤 (TextBox, PasswordBox)
- 선택 컨트롤 (CheckBox, RadioButton, ComboBox, ListBox)
- 이벤트 핸들러 기초

**주요 파일:**
- `MainWindow.xaml`: Grid와 StackPanel을 활용한 레이아웃 구성
- `MainWindow.xaml.cs`: 버튼 클릭 이벤트 처리

**핵심 개념:**
- Grid의 RowDefinition과 ColumnDefinition 사용법
- StackPanel의 Orientation (Vertical/Horizontal)
- GroupBox를 통한 컨트롤 그룹화
- ScrollViewer를 활용한 스크롤 영역 생성

### 0811_2 - Canvas 레이아웃

**학습 주제:**
- Canvas를 활용한 절대 좌표 배치
- Left, Right, Top, Bottom 속성 활용

**주요 파일:**
- `MainWindow.xaml`: Canvas 기반 절대 위치 지정 레이아웃

**핵심 개념:**
- Canvas의 절대 좌표 시스템
- 픽셀 단위 정밀 배치

### 0811_3 - 로그인 폼 예제

**학습 주제:**
- Grid를 활용한 실전 로그인 UI 구성
- PasswordBox 활용
- 버튼 이벤트 처리

**주요 파일:**
- `MainWindow.xaml`: 로그인 폼 레이아웃
- `MainWindow.xaml.cs`: 로그인 버튼 클릭 이벤트

**핵심 개념:**
- Auto Height를 활용한 동적 크기 조정
- Grid.ColumnSpan을 활용한 열 병합

### 0812 - 다양한 컨트롤 활용

**학습 주제:**
- Slider와 ProgressBar
- ListBox와 데이터 표시
- ToggleButton 활용
- 값 변경 이벤트 처리

**주요 파일:**
- `MainWindow.xaml`: 다양한 컨트롤 예제
- `MainWindow.xaml.cs`: ValueChanged, Checked, Unchecked 이벤트

**핵심 개념:**
- Slider의 ValueChanged 이벤트
- ProgressBar의 Value 속성
- ToggleButton의 Checked/Unchecked 상태

### 0812_2 - RGB 색상 선택기

**학습 주제:**
- 데이터 바인딩 기초 (Binding 구문)
- 실시간 UI 업데이트
- 다중 Slider 연동

**주요 파일:**
- `MainWindow.xaml`: RGB Slider와 색상 미리보기 영역
- `MainWindow.xaml.cs`: 색상 계산 및 변환 로직

**핵심 개념:**
- `{Binding ElementName=..., Path=Value}` 문법
- StringFormat을 활용한 데이터 포맷팅
- RadioButton을 통한 색상 모드 전환

### 0812_3 - 빈 프로젝트

**학습 주제:**
- 새 프로젝트 템플릿

### 0812_4 - 이미지 리소스 관리

**학습 주제:**
- WPF에서 이미지 리소스 사용
- Image 컨트롤
- ImageBrush를 활용한 버튼 배경

**주요 파일:**
- `MainWindow.xaml`: Image 컨트롤과 ImageBrush
- `Resources/`: 이미지 리소스 폴더

**핵심 개념:**
- 프로젝트 리소스 추가 및 참조
- `/Resources/이미지명.jpg` 경로 지정
- ImageBrush를 통한 배경 이미지 적용

### 0813 - DataGrid와 클래스 활용

**학습 주제:**
- DataGrid 컨트롤 심화
- 클래스 기반 데이터 모델링
- CSV 파일 입출력
- 필터링 및 검색 기능
- 통계 정보 계산

**주요 파일:**
- `MainWindow.xaml`: DataGrid와 필터링 UI
- `Student.cs`: 학생 데이터 모델 (Name, Age, Score, Grade)
- `Book.cs`: 도서 데이터 모델
- `MainWindow.xaml.cs`: CRUD 기능 및 CSV 처리

**핵심 개념:**
- DataGrid의 AutoGenerateColumns vs 수동 열 정의
- DataGridTextColumn의 Binding 설정
- 클래스 생성자와 속성 (Property)
- 비즈니스 로직 (등급 계산)
- TextChanged 이벤트를 통한 실시간 필터링
- SelectionChanged를 활용한 ComboBox 필터

### 0814 - ScottPlot 차트 라이브러리

**학습 주제:**
- 외부 NuGet 패키지 사용 (ScottPlot.WPF)
- 선 그래프, 점 그래프, 막대 그래프
- 동적 차트 생성 및 업데이트

**주요 파일:**
- `MainWindow.xaml`: ScottPlot WpfPlot 컨트롤
- `MainWindow.xaml.cs`: 그래프 생성 로직

**핵심 개념:**
- NuGet 패키지 관리
- xmlns 네임스페이스 추가
- WpfPlot 컨트롤 사용법
- 차트 데이터 동적 업데이트

### 0814_2 - MVVM 패턴 입문

**학습 주제:**
- MVVM 아키텍처 기초
- Model-View-ViewModel 분리
- ObservableCollection
- RelayCommand (GalaSoft.MvvmLight)

**주요 파일:**
- `Models/Student.cs`: 비즈니스 로직을 담은 모델
- `ViewModels/StudentViewModel.cs`: UI 로직과 데이터 관리
- `Views/MainWindow.xaml`: 순수 UI (Code-behind 최소화)

**핵심 개념:**
- 폴더 구조 분리 (Models, ViewModels, Views)
- ICommand를 통한 버튼 바인딩
- ObservableCollection의 자동 UI 업데이트
- ViewModel의 AddStudentCommand 구현

### 0814_3 - MVVM 데이터 바인딩

**학습 주제:**
- ViewModel 속성과 View 바인딩
- 단방향 데이터 바인딩

**주요 파일:**
- `Models/Student.cs`: Grade, IsPassed 계산 속성
- `ViewModels/StudentViewModel.cs`: 간단한 속성 바인딩
- `Views/MainWindow.xaml`: TextBox 바인딩

**핵심 개념:**
- `{Binding 속성명}` 문법
- 계산된 속성 (Computed Property)
- 읽기 전용 속성 (get만 구현)

### 0818 - C# 기초 연습

**학습 주제:**
- 반복문과 조건문
- 제곱근 계산 알고리즘

**주요 파일:**
- `Program.cs`: 콘솔 애플리케이션 (WPF 아님)

### 0818_2 - MVVM 계산기 애플리케이션

**학습 주제:**
- 완전한 MVVM 패턴 구현
- INotifyPropertyChanged 인터페이스
- RelayCommand 커스텀 구현
- BaseViewModel 패턴
- 사칙연산 비즈니스 로직

**주요 파일:**
- `Commands/RelayCommand.cs`: ICommand 구현체 (상세 주석 포함)
- `Models/Calculator.cs`: 계산 로직 모델
- `ViewModels/BaseViewModel.cs`: INotifyPropertyChanged 구현 기반 클래스
- `ViewModels/CalculatorViewModel.cs`: 계산기 ViewModel (상세 주석)
- `MainWindow.xaml`: 계산기 UI

**핵심 개념:**
- ICommand 패턴의 Execute와 CanExecute
- CommandManager.InvalidateRequerySuggested()
- PropertyChanged 이벤트를 통한 UI 자동 업데이트
- Mode=TwoWay 양방향 바인딩
- UpdateSourceTrigger=PropertyChanged
- 예외 처리 (DivideByZeroException, FormatException)

### 0818_3 - Todo 리스트 애플리케이션

**학습 주제:**
- ObservableCollection을 활용한 컬렉션 관리
- ItemsControl과 DataTemplate
- RelativeSource 바인딩
- 완전한 CRUD 기능 구현

**주요 파일:**
- `Infrastructure/ObservableObject.cs`: INotifyPropertyChanged 기반 클래스
- `Infrastructure/RelayCommand.cs`: ICommand 구현
- `Models/TodoItem.cs`: Todo 모델 (Title, IsCompleted)
- `ViewModels/MainWindowViewModel.cs`: Todo 관리 ViewModel
- `MainWindow.xaml`: Todo 리스트 UI

**핵심 개념:**
- ObservableCollection의 자동 UI 동기화
- ItemsControl.ItemTemplate
- DataTemplate을 통한 항목 템플릿 정의
- RelativeSource를 통한 상위 DataContext 접근
- CommandParameter를 통한 매개변수 전달
- Window.Resources를 활용한 스타일 정의

## MVVM 패턴 상세 설명

### MVVM이란?

MVVM (Model-View-ViewModel)은 WPF 애플리케이션 개발에서 가장 널리 사용되는 디자인 패턴입니다. UI 코드와 비즈니스 로직을 분리하여 코드의 재사용성, 테스트 용이성, 유지보수성을 향상시킵니다.

### 구성 요소

**1. Model (모델)**
- 비즈니스 로직과 데이터를 담당
- UI와 독립적인 순수한 데이터 구조
- 예: Student.cs, TodoItem.cs, Calculator.cs

**2. View (뷰)**
- 사용자에게 보여지는 UI (XAML)
- Code-behind는 최소화 (UI 초기화만)
- 데이터 바인딩을 통해 ViewModel과 연결
- 예: MainWindow.xaml

**3. ViewModel (뷰모델)**
- View와 Model 사이의 중재자
- UI 상태와 명령(Command)을 관리
- INotifyPropertyChanged를 구현하여 UI 업데이트
- 예: CalculatorViewModel.cs, MainWindowViewModel.cs

### 핵심 인터페이스

**INotifyPropertyChanged**
```csharp
public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```

**ICommand**
```csharp
public class RelayCommand : ICommand
{
    private readonly Action<object> _execute;
    private readonly Func<object, bool> _canExecute;

    public bool CanExecute(object parameter) { ... }
    public void Execute(object parameter) { ... }
    public event EventHandler CanExecuteChanged;
}
```

### 데이터 바인딩

**바인딩 모드:**
- OneWay: ViewModel → View (기본값)
- TwoWay: ViewModel ↔ View (입력 컨트롤)
- OneTime: 최초 한 번만

**UpdateSourceTrigger:**
- PropertyChanged: 값 변경 즉시
- LostFocus: 포커스를 잃을 때 (기본값)

**예제:**
```xml
<TextBox Text="{Binding FirstNumber, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
<Button Command="{Binding AddCommand}" />
```

## 실행 방법

### 사전 요구사항
- Visual Studio 2019 이상
- .NET Framework 4.7.2 이상 또는 .NET 6.0 이상
- Windows 운영체제

### 프로젝트 실행
1. Visual Studio에서 원하는 폴더의 `.csproj` 파일 열기
2. NuGet 패키지 복원 (자동으로 진행됨)
3. F5 키를 눌러 디버그 모드로 실행

### NuGet 패키지
일부 프로젝트는 외부 패키지가 필요합니다:
- **0814**: ScottPlot.WPF (차트 라이브러리)
- **0814_2**: GalaSoft.MvvmLight (MVVM 헬퍼)

## 학습 순서 추천

### 1단계: WPF 기초 (1-2주차)
1. **0811**: Grid와 StackPanel 레이아웃 이해
2. **0811_2**: Canvas 레이아웃
3. **0811_3**: 로그인 폼 실습
4. **0812**: 다양한 컨트롤 활용
5. **0812_2**: 데이터 바인딩 기초 (RGB 선택기)
6. **0812_4**: 이미지 리소스 관리

### 2단계: 데이터 관리 (3주차)
7. **0813**: DataGrid와 클래스 활용, CRUD 기능
8. **0814**: ScottPlot 차트 라이브러리

### 3단계: MVVM 패턴 입문 (4주차)
9. **0814_2**: MVVM 기초 구조 이해
10. **0814_3**: 데이터 바인딩 심화

### 4단계: MVVM 완성 (5주차)
11. **0818_2**: 완전한 MVVM 계산기 (ICommand, INotifyPropertyChanged)
12. **0818_3**: Todo 리스트 (ObservableCollection, DataTemplate)

## 주요 개념 정리

### 레이아웃 컨트롤
- **Grid**: 행과 열로 구성된 표 형태 레이아웃 (가장 많이 사용)
- **StackPanel**: 수직 또는 수평으로 컨트롤을 나열
- **Canvas**: 절대 좌표 기반 배치
- **WrapPanel**: 자동 줄바꿈 패널
- **DockPanel**: 도킹 기반 레이아웃

### 데이터 컨트롤
- **ListBox**: 항목 목록 표시
- **ComboBox**: 드롭다운 목록
- **DataGrid**: 표 형태 데이터 편집기
- **ItemsControl**: 사용자 정의 목록 (템플릿 활용)

### 이벤트 vs 커맨드
- **이벤트**: Code-behind에서 직접 처리 (초기 학습)
- **커맨드**: ICommand를 통해 ViewModel에서 처리 (MVVM 권장)

## 학습 팁

1. **XAML 먼저 이해하기**: UI 구조를 먼저 파악한 후 코드 로직 분석
2. **단계적 접근**: 기본 이벤트 처리 → 바인딩 → MVVM 순서로 학습
3. **코드 주석 활용**: 0818_2와 0818_3의 상세 주석을 꼭 읽어보기
4. **실습 위주**: 예제를 직접 수정하며 동작 확인
5. **디버깅**: 바인딩 오류는 Output 창에서 확인 가능

## WPF 주요 특징

### 선언적 UI (XAML)
- XML 기반의 UI 정의 언어
- 디자이너와 개발자의 협업 용이
- 코드와 UI의 명확한 분리

### 데이터 바인딩
- UI와 데이터의 자동 동기화
- 코드 양 대폭 감소
- 변경 알림 시스템 (INotifyPropertyChanged)

### 강력한 스타일링
- 리소스와 스타일을 통한 일관된 디자인
- 템플릿을 통한 컨트롤 커스터마이징
- 애니메이션 및 트리거 지원

### MVVM 친화적
- 데이터 바인딩과 커맨드 시스템
- 테스트 가능한 구조
- 관심사의 명확한 분리

## 추가 학습 자료

### 공식 문서
- Microsoft WPF Documentation
- .NET API Browser

### 권장 학습 주제
- Dependency Property
- Attached Property
- ControlTemplate과 DataTemplate
- Trigger와 Animation
- 비동기 프로그래밍 (async/await)
- MVVM 프레임워크 (Prism, MVVM Light, CommunityToolkit.Mvvm)

## 프로젝트 구조 베스트 프랙티스

```
프로젝트/
├── Models/          # 비즈니스 로직과 데이터 모델
├── ViewModels/      # UI 로직과 상태 관리
├── Views/           # XAML UI 파일
├── Commands/        # ICommand 구현체
├── Infrastructure/  # 공통 기반 클래스 (BaseViewModel 등)
├── Resources/       # 이미지, 아이콘 등 리소스
└── Services/        # 외부 서비스 연동 (API, DB 등)
```

## 문제 해결

### 바인딩이 작동하지 않을 때
1. Output 창에서 바인딩 오류 확인
2. DataContext가 올바르게 설정되었는지 확인
3. 속성명 오타 확인
4. INotifyPropertyChanged 구현 확인

### 커맨드 버튼이 비활성화될 때
1. CanExecute 메서드 확인
2. CommandManager.InvalidateRequerySuggested() 호출 확인
3. 바인딩 경로 확인

### NuGet 패키지 오류
1. 프로젝트 우클릭 → "NuGet 패키지 복원"
2. .NET Framework 버전 호환성 확인
3. packages.config 또는 .csproj 파일 확인

## 마치며

이 학습 프로젝트는 WPF의 기초부터 MVVM 패턴까지 체계적으로 다루고 있습니다. 각 폴더를 순서대로 학습하면서 점진적으로 난이도를 높여가며, 최종적으로는 실무에서 사용 가능한 MVVM 구조의 애플리케이션을 작성할 수 있게 됩니다.

특히 0818_2 (계산기)와 0818_3 (Todo 리스트)는 상세한 주석과 함께 MVVM 패턴의 모범 사례를 보여주므로, 이 두 프로젝트를 집중적으로 분석하고 이해하는 것을 권장합니다.
