// ✅ 저장/불러오기 대화상자 (SaveFileDialog, OpenFileDialog)
using Microsoft.Win32;

// ✅ 컬렉션 자료구조 (ObservableCollection 사용)
using System.Collections.ObjectModel;

// ✅ 파일 입출력 (CSV 저장/불러오기)
using System.IO;

// ✅ LINQ (Average, Count, Cast, Where 등 확장 메서드 사용)
using System.Linq;

// ✅ 문자열 처리 (StringBuilder, Encoding)
using System.Text;

// ✅ WPF 기본 네임스페이스들
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

// ⛔ 아래 네임스페이스들은 현재 코드에서 사용하지 않으므로 삭제해도 됩니다.
// using System.Collections.Generic;                 // 미사용
// using System.Runtime.Intrinsics.X86;              // 미사용
// using System.Windows.Documents;                   // 미사용
// using System.Windows.Input;                       // 미사용
// using System.Windows.Media;                       // 미사용
// using System.Windows.Media.Imaging;               // 미사용
// using System.Windows.Navigation;                  // 미사용
// using System.Windows.Shapes;                      // 미사용
// using static System.Reflection.Metadata.BlobBuilder; // 미사용

namespace _0813
{
    /// <summary>
    /// MainWindow: WPF DataGrid 예제
    /// - ObservableCollection<Student>를 사용해 "실시간 추가/삭제" 시 UI 자동 갱신
    /// - CollectionViewSource로 "보이는 목록"에만 필터 적용(원본 보존)
    /// - Update()로 화면에 보이는 데이터 기준 통계(총원/평균/합격/불합격) 표시
    /// - CSV 내보내기/가져오기 기능
    /// 
    /// ※ XAML에 다음 요소들이 존재해야 합니다.
    ///   - DataGrid: x:Name="myDataGrid"
    ///   - TextBox(검색): x:Name="txtSearch", TextChanged="txtSearch_TextChanged"
    ///   - ComboBox(등급필터): x:Name="cmbGradeFilter", SelectionChanged="cmbGradeFilter_SelectionChanged"
    ///   - 통계 TextBlock: x:Name="total", x:Name="avgScore", x:Name="passCount", x:Name="failCount"
    ///   - 입력 TextBox: x:Name="txtName", x:Name="txtAge", x:Name="txtScore"
    ///   - 버튼: btnAdd_Click / btnDel_Click / btnClear_Click / btnExport_Click / btnImport_Click 핸들러 연결
    /// </summary>
    public partial class MainWindow : Window
    {
        // ✅ DataGrid에 바인딩되는 "원본 컬렉션"
        // ObservableCollection<T>는 Add/Remove 시 INotifyCollectionChanged 이벤트를 발생시켜
        // 바인딩된 UI(DataGrid)가 자동으로 갱신됩니다.
        private ObservableCollection<Student> students;

        // ✅ "보이는 목록"을 제공하는 뷰 계층
        // CollectionViewSource를 통해 원본(students)을 건드리지 않고
        // 화면에 보이는 데이터만 필터/정렬/그룹 처리할 수 있습니다.
        private CollectionViewSource viewSource;

        public MainWindow()
        {
            InitializeComponent();

            // 1) 더미 데이터 준비 및 DataGrid 바인딩
            InitializeData();

            // 2) 필터(검색/등급) 이벤트 연결
            SetupFiltering();
        }

        /// <summary>
        /// 통계 정보(총원/평균/합격/불합격)를 "현재 화면에 보이는 데이터" 기준으로 갱신합니다.
        /// - 중요: students(원본) 기준이 아니라 viewSource.View 기준으로 계산해야
        ///         필터 결과가 통계에 반영됩니다.
        /// </summary>
        private void Update()
        {
            // viewSource.View는 ICollectionView.
            // Cast<Student>()로 구체 타입 열거 가능 (System.Linq 필요)
            var visibleStudent = viewSource.View.Cast<Student>().ToList();

            // 총 학생 수 표시
            total.Text = $"총 학생: {visibleStudent.Count}명";

            if (visibleStudent.Count > 0)
            {
                // 평균 점수 (Average는 LINQ 확장 메서드)
                double avg = visibleStudent.Average(s => s.Score);
                avgScore.Text = $"평균 점수: {avg:F1}점";

                // 합격/불합격 분리 (여기서는 80점 이상 합격으로 가정)
                int pass = visibleStudent.Count(s => s.Score >= 80);
                int fail = visibleStudent.Count - pass;

                passCount.Text = $"합격: {pass}명";
                failCount.Text = $"불합격: {fail}명";
            }
            else
            {
                // 보이는 행이 하나도 없는 경우(필터로 모두 제외되었을 수도 있음)
                total.Text = $"총 학생: 0명";
                avgScore.Text = $"평균 점수: 0점";
                passCount.Text = $"합격: 0명";
                failCount.Text = $"불합격: 0명";
            }
        }

        /// <summary>
        /// 초기 데이터 생성 및 DataGrid 바인딩.
        /// - students에 더미 데이터를 넣고
        /// - CollectionViewSource(viewSource)를 통해 DataGrid.ItemsSource에 "뷰"를 연결합니다.
        /// </summary>
        private void InitializeData()
        {
            // ✅ 더미 데이터
            //  - Student는 Name(string), Age(int), Score(double), Grade(string) 등의 속성이 있다고 가정
            //  - Grade는 Score 기반 계산 프로퍼티일 수도 있고, 생성자에서 셋팅할 수도 있습니다.
            students = new ObservableCollection<Student>
            {
                new Student("김철수", 20, 80),
                new Student("이영희", 24, 85),
                new Student("박민수", 26, 90),
                new Student("홍길동", 19, 60),
                new Student("정호석", 21, 40),
            };

            // ✅ CollectionViewSource를 생성하고 원본을 연결
            viewSource = new CollectionViewSource
            {
                Source = students
            };

            // ✅ DataGrid에 "뷰"를 바인딩
            //    이렇게 하면 이후 필터/정렬을 해도 원본은 그대로 유지되고,
            //    화면에는 필터링된 결과만 보이게 됩니다.
            myDataGrid.ItemsSource = viewSource.View;

            // 초기 통계 갱신
            Update();
        }

        /// <summary>
        /// 필터 로직 연결.
        /// - viewSource.Filter 이벤트에 핸들러를 등록하면,
        ///   viewSource.View.Refresh()가 호출될 때마다 각 항목의 표시 여부를 판단합니다.
        /// </summary>
        private void SetupFiltering()
        {
            viewSource.Filter += ViewSource_Filter;
        }

        /// <summary>
        /// 필터 이벤트 핸들러:
        /// - 이름 검색(txtSearch.Text 포함 여부)
        /// - 등급 필터(cmbGradeFilter에서 선택한 등급과 학생 Grade 비교)
        /// 
        /// ※ e.Accepted = true  → 화면에 표시
        ///           = false → 화면에서 제외
        /// </summary>
        private void ViewSource_Filter(object sender, FilterEventArgs e)
        {
            var student = e.Item as Student;

            // null 또는 타입 미스매치 시 제외
            if (student == null)
            {
                e.Accepted = false;
                return;
            }

            // 🔎 이름 검색 필터
            // - string.Contains는 기본적으로 대소문자 구분(한국어 환경에서는 보통 문제없지만,
            //   필요하면 IndexOf(..., StringComparison.OrdinalIgnoreCase)로 대소문자 무시 가능)
            string searchText = txtSearch.Text;
            bool nameMatch = string.IsNullOrEmpty(searchText) || student.Name.Contains(searchText);

            // 🏷️ 등급 필터
            // - ComboBoxItem의 Content를 문자열로 꺼내 비교
            // - "전체"일 때는 모두 허용
            string selectedGrade = (cmbGradeFilter.SelectedItem as ComboBoxItem)?.Content?.ToString();
            bool gradeMatch = selectedGrade == "전체" || selectedGrade == student.Grade;

            // 두 조건을 모두 만족해야 화면에 표시
            e.Accepted = nameMatch && gradeMatch;
        }

        /// <summary>
        /// 검색 텍스트 변경 시: 필터 재평가 + 통계 갱신
        /// </summary>
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 🔁 필터 재평가(모든 항목에 대해 ViewSource_Filter가 다시 호출됨)
            viewSource.View.Refresh();

            // 📊 필터 결과 기준으로 통계 갱신
            Update();
        }

        /// <summary>
        /// 등급 콤보박스 선택 변경 시: 필터 재평가 + 통계 갱신
        /// </summary>
        private void cmbGradeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (viewSource != null)
            {
                viewSource.View.Refresh();
                Update();
            }
        }

        /// <summary>
        /// (테스트용) 무조건 한 명 추가하는 버튼
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // ✅ ObservableCollection이므로 Add 시 DataGrid가 자동 반영
            students.Add(new Student("김철수2", 24, 40));

            // 사용자 알림
            MessageBox.Show("추가가 되었습니다.", "데이터 추가",
                MessageBoxButton.OK, MessageBoxImage.Information);

            MessageBox.Show(students.Count.ToString(), "데이터 수");

            // 통계 갱신
            Update();
        }

        /// <summary>
        /// 입력값으로 새 학생 추가 (유효성 검사 포함)
        /// </summary>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 입력값 가져오기
                // Trim(): 앞뒤 공백 제거
                string name = txtName.Text.Trim();
                int age = int.Parse(txtAge.Text.Trim());         // ⚠️ 숫자 미입력시 예외 → try-catch로 처리
                double score = double.Parse(txtScore.Text.Trim()); // ⚠️ 문화권(소수점 기호) 영향 → TryParse 권장

                // 간단 유효성 검사
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("이름을 입력해 주세요!", "오류",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // 새 학생 생성 및 추가(→ DataGrid 자동 반영)
                var newStudent = new Student(name, age, score);
                students.Add(newStudent);

                // 통계 갱신
                Update();

                // 입력 컨트롤 초기화
                ClearInputFields();

                MessageBox.Show($"{name} 학생이 추가 되었습니다.", "추가",
                    MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (System.Exception ex)
            {
                // 숫자 변환 오류 등
                MessageBox.Show($"입력 오류: {ex.Message}");
            }
        }

        /// <summary>
        /// 선택된 행(학생) 삭제
        /// </summary>
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            // DataGrid에서 현재 선택된 항목 가져오기
            var selectedStudent = myDataGrid.SelectedItem as Student;

            if (selectedStudent != null)
            {
                // 삭제 확인 다이얼로그
                var result = MessageBox.Show(
                    $"{selectedStudent.Name} 학생을 삭제 하겠습니까?",
                    "삭제확인",
                    MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    // ObservableCollection.Remove → DataGrid 자동 반영
                    students.Remove(selectedStudent);

                    // 통계 갱신
                    Update();

                    MessageBox.Show("삭제되었습니다.");
                }
            }
            else
            {
                MessageBox.Show("삭제할 학생을 선택해주세요!");
            }
        }

        /// <summary>
        /// 전체 삭제(모든 학생 제거)
        /// </summary>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (students.Count == 0)
            {
                MessageBox.Show("삭제할 데이터가 없습니다.");
                return;
            }

            var result = MessageBox.Show(
                "모든 학생 데이터를 삭제하시겠습니까?",
                "전체 삭제 확인",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                // ObservableCollection.Clear → DataGrid 자동 반영
                students.Clear();

                // 통계 갱신
                Update();

                MessageBox.Show("모든 데이터가 삭제 되었습니다.");
            }
        }

        /// <summary>
        /// 입력 TextBox들 초기화 + 포커스 이동
        /// </summary>
        private void ClearInputFields()
        {
            txtName.Text = "";
            txtAge.Text = "";
            txtScore.Text = "";

            txtName.Focus();
        }

        /// <summary>
        /// CSV 내보내기
        /// - 현재 students(원본) 기준으로 저장합니다. (필터 반영 저장을 원하면 viewSource.View를 열거하세요)
        /// - 값에 쉼표/따옴표/줄바꿈이 포함될 경우 CSV 이스케이프 처리가 필요합니다(여기선 단순 버전).
        /// - Excel 호환성 위해 UTF-8 with BOM 권장(new UTF8Encoding(true))이지만, 여기선 기본 UTF-8 사용.
        /// </summary>
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var saveDialog = new SaveFileDialog
                {
                    Filter = "CSV 파일 (*.csv)|*.csv",
                    DefaultExt = "csv",
                    FileName = $"학생 목록_{System.DateTime.Now:yyyyMMdd_HHmmss}.csv"
                };

                if (saveDialog.ShowDialog() == true)
                {
                    var csv = new StringBuilder();

                    // 헤더 추가
                    csv.AppendLine("이름, 나이, 점수, 등급");

                    // 🔸 원본 students 기준으로 저장 (필터 무시)
                    //     → 필터 적용된 화면만 저장하려면 viewSource.View.Cast<Student>()를 순회하세요.
                    foreach (var student in students)
                    {
                        // 단순 CSV(값에 쉼표/따옴표가 없는 전제). 안전하게 하려면 이스케이프 유틸 작성 권장.
                        csv.AppendLine($"{student.Name}, {student.Age}, {student.Score}, {student.Grade}");
                    }

                    // 파일 쓰기 (UTF-8). Excel 완전 호환을 원하면 new UTF8Encoding(true) 사용 권장.
                    File.WriteAllText(saveDialog.FileName, csv.ToString(), Encoding.UTF8);

                    // 통계 갱신(필수는 아님)
                    Update();

                    MessageBox.Show("파일이 저장되었습니다.");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"파일 저장 오류: {ex.Message}");
            }
        }

        /// <summary>
        /// CSV 가져오기
        /// - 첫 줄을 헤더로 가정하고, 2번째 줄부터 파싱합니다.
        /// - "이름,나이,점수[,등급]" 형태를 기대(등급은 점수로부터 자동계산일 수도 있음).
        /// - 단순 Split(',') 사용 → 값 안에 쉼표가 들어있는 경우엔 한계가 있습니다(실무에선 CSV 파서 권장).
        /// </summary>
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openDialog = new OpenFileDialog
                {
                    Filter = "CSV 파일 (*.csv)|*.csv",
                    Title = "학생 데이터 파일 선택"
                };

                if (openDialog.ShowDialog() == true)
                {
                    // UTF-8로 모든 라인 읽기
                    string[] lines = File.ReadAllLines(openDialog.FileName, Encoding.UTF8);

                    if (lines.Length < 2)
                    {
                        MessageBox.Show("데이터가 없습니다.");
                        return;
                    }

                    int importCount = 0;

                    // i=1부터 시작: 0번 라인은 헤더로 가정
                    for (int i = 1; i < lines.Length; i++)
                    {
                        // ⚠️ 단순 파싱(값에 쉼표 포함 시 깨질 수 있음)
                        string[] parts = lines[i].Split(',');

                        // 최소 3개(이름, 나이, 점수) 확보
                        if (parts.Length >= 3)
                        {
                            string name = parts[0].Trim();

                            // TryParse 사용으로 안전하게 숫자 파싱(실패 시 건너뜀)
                            bool okAge = int.TryParse(parts[1].Trim(), out int age);
                            bool okScore = double.TryParse(parts[2].Trim(), out double score);

                            if (okAge && okScore)
                            {
                                students.Add(new Student(name, age, score));
                                importCount++;
                            }
                        }
                    }

                    // 통계 갱신
                    Update();

                    MessageBox.Show($"{importCount}명의 학생 데이터를 가져왔습니다!");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"파일 읽기 오류: {ex.Message}");
            }
        }
    }
}
