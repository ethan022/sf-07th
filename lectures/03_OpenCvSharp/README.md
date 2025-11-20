# OpenCvSharp 학습 자료

C# 환경에서 OpenCV를 사용하기 위한 OpenCvSharp 라이브러리 학습 프로젝트입니다.
이미지 처리, 컴퓨터 비전의 기초부터 실전 응용까지 단계별로 학습합니다.

## 학습 목표

- OpenCvSharp 라이브러리의 기본 사용법 이해
- 이미지 처리 및 변환 기법 습득
- 실시간 카메라 영상 처리 구현
- 컴퓨터 비전 알고리즘 적용 (필터링, 엣지 검출, 윤곽선 검출 등)
- 실전 프로젝트 (명함 검출 및 OCR) 구현

## 폴더별 학습 내용

### 0819 - OpenCvSharp 기초
**학습 주제:** OpenCvSharp 설치 및 기본 사용법

**주요 내용:**
- OpenCV 버전 확인
- 이미지 읽기 및 표시
- 이미지에 텍스트 추가 (PutText)
- WPF와 OpenCV 연동 (BitmapSource 변환)
- OpenCV 창에 이미지 표시

**파일:**
- `MainWindow.xaml.cs` - WPF 기반 이미지 처리 기초

---

### 0819_2 - OpenCV 기본 데이터 구조
**학습 주제:** OpenCV의 핵심 데이터 구조 이해

**주요 내용:**
- **Point**: 2D/3D 좌표 표현 (Point, Point2f, Point3d)
- **Size**: 이미지 크기 표현
- **Scalar**: 색상 값 표현 (BGR 순서)
- **Range**: 범위 지정
- **Rect**: 사각형 영역 정의
- **Mat**: 이미지 및 행렬 데이터 저장 (핵심 클래스)

**파일:**
- `Program.cs` - OpenCV 데이터 구조 실습

---

### 0820 - WPF 프로젝트
**학습 주제:** WPF와 OpenCvSharp 통합

**주요 내용:**
- WPF 애플리케이션에서 OpenCvSharp 사용
- XAML과 Mat 객체 연동

**파일:**
- `MainWindow.xaml.cs` - WPF 기반 이미지 처리

---

### 0820_1 - Mat 클래스 심화
**학습 주제:** Mat 클래스의 생성과 조작

**주요 내용:**
- Mat 기본 생성 (높이, 너비, MatType, 색상)
- 행렬 생성 함수들
  - `Mat.Zeros()` - 영행렬 (검정색)
  - `Mat.Ones()` - 일행렬 (흰색)
  - `Mat.Eye()` - 단위행렬 (대각선)
  - `Cv2.Randu()` - 난수 행렬
- Mat 복사 (얕은 복사 vs 깊은 복사)
- 도형 그리기 (원, 사각형)
- 텍스트 추가

**파일:**
- `Program.cs` - Mat 클래스 활용 실습

---

### 0820_2 - ROI와 픽셀 접근
**학습 주제:** 관심 영역(ROI) 설정 및 픽셀 단위 조작

**주요 내용:**
- **ROI (Region of Interest)**
  - Rect를 사용한 ROI 설정
  - Range를 사용한 ROI 설정
- **픽셀 접근 방법**
  - `GetGenericIndexer<T>()` - 빠른 픽셀 접근
  - `At<T>()` / `Set<T>()` - 직관적인 픽셀 조작
- 패턴 이미지 생성
  - 체크보드 패턴
  - 십자가 패턴
  - 사분면 색상 패턴

**파일:**
- `Program.cs` - ROI 및 픽셀 조작 실습

---

### 0821 - 이미지 파일 입출력
**학습 주제:** 다양한 이미지 파일 형식 처리

**주요 내용:**
- **이미지 읽기 모드**
  - `ImreadModes.Unchanged` - 원본 그대로
  - `ImreadModes.Color` - 컬러
  - `ImreadModes.Grayscale` - 흑백
- **이미지 파일 형식**
  - JPEG (.jpg) - 손실 압축, 작은 용량
  - PNG (.png) - 무손실 압축, 투명도 지원
  - BMP (.bmp) - 비압축, 큰 용량
  - TIFF (.tif) - 고품질, 메타데이터 지원
- 이미지 저장 (다양한 품질 설정)
- 파일 크기 비교

**파일:**
- `Program.cs` - 이미지 파일 입출력 실습

---

### 0821_2 - 마우스 및 키보드 이벤트
**학습 주제:** 사용자 입력 이벤트 처리

**주요 내용:**
- **마우스 이벤트**
  - 왼쪽/오른쪽 클릭 처리
  - 더블 클릭 감지
  - 마우스 이동 추적
  - 마우스 휠 이벤트
  - 드래그 앤 드롭으로 그리기
- **키보드 이벤트**
  - 키 입력 감지
  - 특수키 조합 처리
- 클릭 카운터 구현

**파일:**
- `BasicMouseEvents.cs` - 마우스 이벤트 처리
- `BasicDragDrawing.cs` - 드래그 그리기
- `BasicKeyBoardEvents.cs` - 키보드 이벤트 처리
- `ClickCounter.cs` - 클릭 카운터
- `Program.cs` - 메인 실행

---

### 0822 - 실시간 카메라 및 비디오 처리
**학습 주제:** VideoCapture를 이용한 실시간 영상 처리

**주요 내용:**
- **카메라 기본 사용법**
  - VideoCapture 초기화
  - 카메라 속성 설정 (해상도, FPS)
  - 실시간 프레임 읽기
  - 영상에 텍스트 오버레이
- **비디오 플레이어**
  - 비디오 파일 재생
  - 재생 속도 조절
  - 프레임 탐색
- **카메라 제어**
  - 카메라 속성 조정
  - 실시간 영상 효과 적용
- **카메라 효과 연습**
  - 필터 효과 실시간 적용

**파일:**
- `BasicCameraDemo.cs` - 기본 카메라 사용
- `BasicVideoPlayerDemo.cs` - 비디오 재생
- `CameraControlDemo.cs` - 카메라 제어
- `CameraEffectsPractice.cs` - 실시간 효과 적용
- `Program.cs` - 메인 실행

---

### 0822_1 - 색상 공간 변환
**학습 주제:** 다양한 색상 공간으로 변환

**주요 내용:**
- **색상 공간 종류**
  - BGR - OpenCV 기본 색상 공간
  - Grayscale - 흑백 이미지
  - HSV - 색상(Hue), 채도(Saturation), 명도(Value)
  - Lab - 사람의 시각 특성 반영
- **변환 함수**
  - `Cv2.CvtColor()` - 색상 공간 변환
- 색상 테스트 이미지 생성

**파일:**
- `BasicColorConversion.cs` - 색상 공간 변환 실습
- `Program.cs` - 메인 실행

---

### 0825 - 블러링(흐림 효과) 비교
**학습 주제:** 다양한 블러 필터 비교 및 적용

**주요 내용:**
- **블러링 기법**
  - **Gaussian Blur** - 가우시안 분포 기반 블러
  - **Box Filter** - 단순 평균 블러
  - **Median Blur** - 중앙값 필터 (소금-후추 노이즈 제거)
  - **Bilateral Filter** - 양방향 필터 (경계 보존)
- 커널 크기 조정
- 소금-후추 노이즈 추가 및 제거

**파일:**
- `BlurringComparison.cs` - 블러링 비교 실습
- `Program.cs` - 메인 실행

---

### 0825_2 - 임계값 처리(Thresholding)
**학습 주제:** 이미지 이진화 기법

**주요 내용:**
- **임계값 처리 기법**
  - **Simple Thresholding** - 단순 이진화
  - **Adaptive Mean Thresholding** - 적응형 평균 임계값
  - **Adaptive Gaussian Thresholding** - 적응형 가우시안 임계값
  - **Otsu's Thresholding** - 오츠 자동 임계값
- 조명 변화에 강한 이진화
- 노이즈 처리

**파일:**
- `ThresholdingComparison.cs` - 임계값 처리 비교
- `Program.cs` - 메인 실행

---

### 0825_3 - 엣지 검출
**학습 주제:** 이미지의 경계선 검출

**주요 내용:**
- **엣지 검출 알고리즘**
  - **Sobel** - 그래디언트 기반 (X, Y 방향)
  - **Scharr** - Sobel 개선 버전 (미세한 엣지 검출)
  - **Laplacian** - 2차 미분 기반
  - **Canny** - 가장 많이 사용되는 엣지 검출기
- 엣지 검출 결과 비교
- 임계값 조정

**파일:**
- `EdgeDetection.cs` - 엣지 검출 실습
- `Program.cs` - 메인 실행

---

### 0825_4 - 윤곽선 검출
**학습 주제:** 객체의 윤곽선 찾기

**주요 내용:**
- **윤곽선 검출**
  - `Cv2.FindContours()` - 윤곽선 검출
  - `Cv2.DrawContours()` - 윤곽선 그리기
- 윤곽선 계층 구조 (hierarchy)
- 윤곽선 근사 (ApproxSimple)
- 전처리 (그레이스케일, 이진화)

**파일:**
- `BasicContour.cs` - 윤곽선 검출 실습
- `Program.cs` - 메인 실행

---

### 0826 - 명함 검출 프로젝트 (종합 실습)
**학습 주제:** 실전 프로젝트 - 명함 자동 검출 및 OCR

**주요 내용:**
- **전처리 과정**
  - 그레이스케일 변환
  - 가우시안 블러 (노이즈 제거)
  - Canny 엣지 검출
  - 형태학적 연산 (Dilate, Erode)
- **명함 검출 알고리즘**
  - 윤곽선 검출 및 필터링
  - 사각형 근사화 (4개 꼭짓점)
  - 볼록 도형 검사
  - 종횡비 계산 (명함 비율 1.59:1)
- **신뢰도 계산**
  - 종횡비 점수 (40% 가중치)
  - 면적 점수 (30% 가중치)
  - 중앙 위치 점수 (20% 가중치)
  - 각도 점수 (10% 가중치)
- **명함 추출**
  - 꼭짓점 정렬
  - 원근 변환 (Perspective Transform)
  - 정면 이미지로 변환
- **OCR (광학 문자 인식)**
  - Tesseract 엔진 사용
  - Mat to Bitmap 변환
  - 텍스트 추출

**파일:**
- `PreprocessForCardDetection.cs` - 명함 검출 및 OCR 구현
- `Program.cs` - 메인 실행

---

## 이미지 처리 기법 요약

### 1. 기본 이미지 처리
- 이미지 읽기/쓰기
- 색상 공간 변환 (BGR, Grayscale, HSV, Lab)
- ROI (관심 영역) 설정
- 픽셀 단위 조작

### 2. 필터링
- Gaussian Blur - 가우시안 블러
- Box Filter - 박스 필터
- Median Blur - 중앙값 필터
- Bilateral Filter - 양방향 필터

### 3. 이진화
- Simple Thresholding - 단순 임계값
- Adaptive Thresholding - 적응형 임계값
- Otsu's Method - 오츠 자동 임계값

### 4. 엣지 검출
- Sobel - 그래디언트 기반
- Scharr - Sobel 개선 버전
- Laplacian - 2차 미분
- Canny - 최적 엣지 검출

### 5. 형태학적 연산
- Dilate - 팽창
- Erode - 침식
- Opening - 열림 (침식 후 팽창)
- Closing - 닫힘 (팽창 후 침식)

### 6. 윤곽선 처리
- FindContours - 윤곽선 검출
- DrawContours - 윤곽선 그리기
- ApproxPolyDP - 다각형 근사
- ContourArea - 면적 계산
- BoundingRect - 경계 사각형

### 7. 기하학적 변환
- GetPerspectiveTransform - 원근 변환 행렬
- WarpPerspective - 원근 변환 적용
- Resize - 크기 조정
- Rotate - 회전

---

## 필요한 NuGet 패키지

### 기본 패키지 (필수)
```xml
<PackageReference Include="OpenCvSharp4" Version="4.11.0.20250507" />
<PackageReference Include="OpenCvSharp4.runtime.win" Version="4.11.0.20250507" />
```

### WPF 프로젝트용 추가 패키지
```xml
<PackageReference Include="OpenCvSharp4.Extensions" Version="4.11.0.20250507" />
```

### OCR 기능 사용 시 (0826 프로젝트)
```xml
<PackageReference Include="Tesseract" Version="5.2.0" />
```

---

## 프로젝트 구조

- **Console 프로젝트**: 대부분의 실습 (0819_2, 0820_1, 0820_2, 0821, 0821_2, 0822, 0822_1, 0825, 0825_2, 0825_3, 0825_4, 0826)
- **WPF 프로젝트**: WPF 연동 실습 (0819, 0820)

---

## 실행 방법

### 1. Visual Studio에서 실행
1. 원하는 폴더의 `.csproj` 파일을 Visual Studio에서 열기
2. NuGet 패키지 복원 (자동 또는 수동)
3. F5 키를 눌러 실행

### 2. 명령줄에서 실행
```bash
# 프로젝트 폴더로 이동
cd 03_OpenCvSharp/0825

# 패키지 복원
dotnet restore

# 빌드
dotnet build

# 실행
dotnet run
```

### 3. 이미지 파일 준비
- 일부 프로젝트는 테스트용 이미지 파일 필요
- 프로젝트 폴더에 `img1.jpg`, `img2.jpg`, `img3.jpg` 등을 준비
- 또는 코드 내에서 이미지 경로 수정

---

## 학습 순서 추천

1. **기초 개념** (0819, 0819_2, 0820_1) - OpenCV 데이터 구조 이해
2. **이미지 조작** (0820_2, 0821) - ROI, 픽셀 접근, 파일 입출력
3. **사용자 입력** (0821_2) - 마우스/키보드 이벤트
4. **실시간 처리** (0822, 0822_1) - 카메라, 비디오, 색상 변환
5. **필터링** (0825) - 다양한 블러 기법
6. **이진화 및 엣지** (0825_2, 0825_3) - 임계값 처리, 엣지 검출
7. **윤곽선 검출** (0825_4) - 객체 인식 기초
8. **실전 프로젝트** (0826) - 명함 검출 및 OCR (종합 실습)

---

## 주요 개념 정리

### Mat 클래스
- OpenCV의 핵심 데이터 구조
- 이미지 및 행렬 데이터 저장
- 헤더(메타정보) + 데이터(픽셀값) 구조
- 얕은 복사 vs 깊은 복사 주의

### BGR vs RGB
- OpenCV는 BGR 순서 사용 (Blue, Green, Red)
- 일반적인 이미지 포맷은 RGB 순서
- 색상 변환 시 순서 주의

### 좌표 체계
- 픽셀 접근: [행(y), 열(x)] 순서
- Point: (x, y) 순서
- 이미지 원점: 왼쪽 상단 (0, 0)

### using 문 사용
- Mat 객체는 반드시 Dispose 필요
- using 블록으로 자동 메모리 해제
- 메모리 누수 방지

---

## 참고 자료

- [OpenCvSharp 공식 GitHub](https://github.com/shimat/opencvsharp)
- [OpenCV 공식 문서](https://docs.opencv.org/)
- [OpenCvSharp Wiki](https://github.com/shimat/opencvsharp/wiki)

---

## 문제 해결 (Troubleshooting)

### 카메라가 열리지 않는 경우
- 카메라 번호 확인 (0, 1, 2...)
- 다른 프로그램에서 카메라 사용 중인지 확인
- 카메라 드라이버 설치 확인

### 이미지 파일을 찾을 수 없는 경우
- 파일 경로 확인 (절대 경로 또는 상대 경로)
- 파일 존재 여부 확인
- `File.Exists()` 사용 권장

### OpenCV 창이 응답 없음
- `Cv2.WaitKey()` 호출 확인
- 적절한 대기 시간 설정 (0 = 무한 대기, 1~n = ms 단위)

### NuGet 패키지 복원 실패
- Visual Studio 재시작
- NuGet 캐시 삭제: `dotnet nuget locals all --clear`
- 수동 복원: `dotnet restore`

---

## 라이선스

이 프로젝트는 학습 목적으로 작성되었습니다.
OpenCvSharp는 Apache License 2.0을 따릅니다.
