# ============================================================
# Python 시스템 라이브러리 - sys, os, json
# ============================================================

# 시스템 관련 라이브러리들 import
import psutil  # 추가 라이브러리 (설치 필요할 수 있음)
import sys   # 시스템 관련 정보와 기능
import os    # 운영체제와 상호작용
import json  # JSON 데이터 처리

print("=" * 60)
print("🐍 Python 시스템 라이브러리 학습")
print("=" * 60)

# ============================================================
# 1. sys 라이브러리 - 시스템 정보와 제어
# ============================================================

print("\n🖥️ 1. sys 라이브러리 - 시스템 정보와 제어")
print("-" * 40)

# Python 버전 정보
print("📋 Python 시스템 정보:")
print(f"Python 버전: {sys.version}")
print(f"버전 정보 (간단): {sys.version_info}")
print(f"플랫폼: {sys.platform}")  # 운영체제 정보
print(f"Python 실행 파일 경로: {sys.executable}")

# 명령줄 인수 (Command Line Arguments)
print(f"\n⌨️ 명령줄 인수:")
print(f"sys.argv: {sys.argv}")
print(f"스크립트 이름: {sys.argv[0]}")
if len(sys.argv) > 1:
    print(f"추가 인수들: {sys.argv[1:]}")
else:
    print("추가 인수 없음")

# 메모리 사용량 확인
try:
    memory_info = psutil.virtual_memory()
    print(f"\n💾 메모리 정보:")
    print(f"전체 메모리: {memory_info.total / (1024**3):.2f} GB")
    print(f"사용 중 메모리: {memory_info.used / (1024**3):.2f} GB")
    print(f"메모리 사용률: {memory_info.percent}%")
except ImportError:
    print("\n💾 메모리 정보: psutil 라이브러리가 필요합니다")

# Python 경로 정보
print(f"\n📁 Python 경로 정보:")
print(f"Python 모듈 검색 경로 (처음 3개):")
for i, path in enumerate(sys.path[:3]):
    print(f"  {i+1}. {path}")

# 재귀 한도 확인
print(f"\n🔄 시스템 제한:")
print(f"재귀 한도: {sys.getrecursionlimit()}")
print(f"최대 정수값: {sys.maxsize}")

# 프로그램 종료 (주석 처리됨)
print(f"\n🚪 프로그램 종료:")
print("sys.exit()를 사용하면 프로그램이 즉시 종료됩니다")
# sys.exit(0)  # 0: 정상 종료, 1: 오류로 인한 종료
# print("이 문장은 출력되지 않습니다!")

# stdin, stdout, stderr
print(f"\n📺 입출력 스트림:")
print(f"표준 입력: {sys.stdin}")
print(f"표준 출력: {sys.stdout}")
print(f"표준 오류: {sys.stderr}")

# ============================================================
# 2. os 라이브러리 - 운영체제와 상호작용
# ============================================================

print("\n💻 2. os 라이브러리 - 운영체제와 상호작용")
print("-" * 40)

# 현재 작업 디렉토리
current_dir = os.getcwd()
print(f"📂 현재 디렉토리: {current_dir}")

# 환경 변수
print(f"\n🌍 환경 변수:")
print(f"사용자 이름: {os.environ.get('USER', os.environ.get('USERNAME', '알 수 없음'))}")
print(
    f"홈 디렉토리: {os.environ.get('HOME', os.environ.get('USERPROFILE', '알 수 없음'))}")
print(f"PATH (처음 100자): {os.environ.get('PATH', '')[:100]}...")

# 운영체제 정보
print(f"\n🖥️ 운영체제 정보:")
print(f"운영체제 이름: {os.name}")  # 'posix' (Unix/Linux/Mac) 또는 'nt' (Windows)
try:
    import platform
    print(f"플랫폼 상세: {platform.platform()}")
    print(f"프로세서: {platform.processor()}")
except ImportError:
    print("플랫폼 상세 정보를 위해 platform 모듈이 필요합니다")

# 파일과 디렉토리 작업
print(f"\n📁 파일과 디렉토리 작업:")

# 디렉토리 내용 보기 (현재 디렉토리의 처음 5개 파일/폴더)
try:
    dir_contents = os.listdir('.')[:5]  # 현재 디렉토리의 처음 5개
    print(f"현재 디렉토리 내용 (처음 5개): {dir_contents}")
except PermissionError:
    print("디렉토리 접근 권한이 없습니다")

# 경로 조작
test_path = os.path.join("folder", "subfolder", "file.txt")
print(f"경로 조합: {test_path}")
print(f"경로 분리: {os.path.split(test_path)}")
print(f"파일명만: {os.path.basename(test_path)}")
print(f"디렉토리명만: {os.path.dirname(test_path)}")

# 파일/디렉토리 존재 확인
print(f"\n🔍 파일/디렉토리 존재 확인:")
print(f"현재 디렉토리 존재: {os.path.exists('.')}")
print(f"가상의 파일 존재: {os.path.exists('nonexistent_file.txt')}")

# 파일 정보
current_file = __file__  # 현재 실행 중인 파일
if os.path.exists(current_file):
    file_stat = os.stat(current_file)
    print(f"\n📄 현재 파일 정보:")
    print(f"파일 크기: {file_stat.st_size} bytes")
    print(f"수정 시간: {file_stat.st_mtime}")

# 새 디렉토리 만들기 (예제)
test_dir = "test_directory"
print(f"\n📁 디렉토리 작업 예제:")
if not os.path.exists(test_dir):
    try:
        os.mkdir(test_dir)
        print(f"'{test_dir}' 디렉토리 생성됨")

        # 테스트 파일 만들기
        test_file_path = os.path.join(test_dir, "test.txt")
        with open(test_file_path, 'w', encoding='utf-8') as f:
            f.write("테스트 파일입니다.")
        print(f"테스트 파일 생성: {test_file_path}")

        # 정리 (파일과 디렉토리 삭제)
        os.remove(test_file_path)
        os.rmdir(test_dir)
        print(f"테스트 파일과 디렉토리 삭제됨")

    except OSError as e:
        print(f"디렉토리 작업 중 오류: {e}")
else:
    print(f"'{test_dir}' 디렉토리가 이미 존재합니다")

# ============================================================
# 3. json 라이브러리 - JSON 데이터 처리
# ============================================================

print("\n📄 3. json 라이브러리 - JSON 데이터 처리")
print("-" * 40)

# 기본 JSON 변환
print("🔄 기본 JSON 변환:")

# Python 객체를 JSON 문자열로 변환
person_data = {
    "name": "홍길동",
    "age": 25,
    "city": "서울",
    "hobbies": ["독서", "영화감상", "코딩"],
    "married": False,
    "children": None
}

# dumps: Python 객체 → JSON 문자열
json_string = json.dumps(person_data, ensure_ascii=False, indent=2)
print(f"JSON 문자열:\n{json_string}")

# loads: JSON 문자열 → Python 객체
parsed_data = json.loads(json_string)
print(f"\nPython 객체로 변환: {type(parsed_data)}")
print(f"이름: {parsed_data['name']}")
print(f"나이: {parsed_data['age']}")
print(f"취미: {parsed_data['hobbies']}")

# 복잡한 데이터 구조
print(f"\n📊 복잡한 데이터 구조:")
complex_data = {
    "users": [
        {"id": 1, "name": "김철수", "department": "개발팀"},
        {"id": 2, "name": "이영희", "department": "디자인팀"},
        {"id": 3, "name": "박민수", "department": "기획팀"}
    ],
    "company": {
        "name": "테크컴퍼니",
        "location": "강남구",
        "founded": 2020
    },
    "active": True,
    "employee_count": 150
}

# 예쁜 형태로 JSON 출력
pretty_json = json.dumps(complex_data, ensure_ascii=False, indent=4)
print("복잡한 데이터의 JSON 형태:")
print(pretty_json[:200] + "..." if len(pretty_json) > 200 else pretty_json)

# JSON 파일 읽기/쓰기
print(f"\n💾 JSON 파일 작업:")

# JSON 파일에 저장
json_filename = "test_data.json"
try:
    with open(json_filename, 'w', encoding='utf-8') as f:
        json.dump(complex_data, f, ensure_ascii=False, indent=2)
    print(f"데이터를 '{json_filename}' 파일에 저장했습니다")

    # JSON 파일에서 읽기
    with open(json_filename, 'r', encoding='utf-8') as f:
        loaded_data = json.load(f)

    print(f"파일에서 읽은 데이터:")
    print(f"회사명: {loaded_data['company']['name']}")
    print(f"직원 수: {loaded_data['employee_count']}")
    print(f"첫 번째 사용자: {loaded_data['users'][0]['name']}")

    # 파일 정리
    os.remove(json_filename)
    print(f"테스트 파일 '{json_filename}' 삭제됨")

except Exception as e:
    print(f"JSON 파일 작업 중 오류: {e}")

# JSON 에러 처리
print(f"\n⚠️ JSON 에러 처리:")
invalid_json = '{"name": "홍길동", "age": 25,}'  # 마지막 콤마 때문에 잘못된 JSON

try:
    result = json.loads(invalid_json)
    print("JSON 파싱 성공")
except json.JSONDecodeError as e:
    print(f"JSON 파싱 오류: {e}")
    print("올바른 JSON 형식이 아닙니다")

# ============================================================
# 4. 실제 활용 예제들
# ============================================================

print(f"\n🎯 4. 실제 활용 예제들")
print("-" * 40)

# 예제 1: 시스템 정보 수집기


def get_system_info():
    """시스템 정보를 수집하는 함수"""
    info = {
        "python_version": sys.version.split()[0],
        "platform": sys.platform,
        "current_directory": os.getcwd(),
        "environment": {
            "user": os.environ.get('USER', os.environ.get('USERNAME')),
            "home": os.environ.get('HOME', os.environ.get('USERPROFILE'))
        },
        "script_name": os.path.basename(sys.argv[0]),
        "arguments": sys.argv[1:] if len(sys.argv) > 1 else []
    }
    return info


print("💻 시스템 정보 수집기:")
system_info = get_system_info()
system_json = json.dumps(system_info, ensure_ascii=False, indent=2)
print(system_json)

# 예제 2: 설정 파일 관리자


class ConfigManager:
    """JSON 기반 설정 파일 관리 클래스"""

    def __init__(self, config_file="config.json"):
        self.config_file = config_file
        self.config = self.load_config()

    def load_config(self):
        """설정 파일 로드"""
        if os.path.exists(self.config_file):
            try:
                with open(self.config_file, 'r', encoding='utf-8') as f:
                    return json.load(f)
            except Exception as e:
                print(f"설정 파일 로드 오류: {e}")
                return {}
        else:
            # 기본 설정
            default_config = {
                "theme": "light",
                "language": "ko",
                "auto_save": True,
                "font_size": 14
            }
            self.save_config(default_config)
            return default_config

    def save_config(self, config=None):
        """설정 파일 저장"""
        config_to_save = config or self.config
        try:
            with open(self.config_file, 'w', encoding='utf-8') as f:
                json.dump(config_to_save, f, ensure_ascii=False, indent=2)
            return True
        except Exception as e:
            print(f"설정 파일 저장 오류: {e}")
            return False

    def get_setting(self, key, default=None):
        """설정값 가져오기"""
        return self.config.get(key, default)

    def set_setting(self, key, value):
        """설정값 변경"""
        self.config[key] = value
        return self.save_config()


print(f"\n⚙️ 설정 파일 관리자 예제:")
config_manager = ConfigManager("app_config.json")
print(f"현재 테마: {config_manager.get_setting('theme')}")
print(f"언어 설정: {config_manager.get_setting('language')}")

# 설정 변경
config_manager.set_setting('theme', 'dark')
config_manager.set_setting('font_size', 16)
print("설정이 변경되었습니다")

# 예제 3: 로그 파일 관리


def create_log_entry(message, level="INFO"):
    """로그 엔트리 생성"""
    import datetime
    return {
        "timestamp": datetime.datetime.now().isoformat(),
        "level": level,
        "message": message,
        "process_id": os.getpid(),
        "python_version": sys.version.split()[0]
    }


print(f"\n📝 로그 시스템 예제:")
log_entry = create_log_entry("시스템 시작됨", "INFO")
print("로그 엔트리:")
print(json.dumps(log_entry, ensure_ascii=False, indent=2))

# ============================================================
# 5. 정리 및 팁
# ============================================================

print(f"\n💡 5. 정리 및 팁")
print("-" * 40)

tips = [
    "sys.argv로 명령줄 인수를 받아 스크립트를 유연하게 만들 수 있음",
    "os.path.join()으로 운영체제에 관계없이 경로를 안전하게 조합",
    "JSON 작업 시 ensure_ascii=False로 한글 문자가 깨지지 않게 설정",
    "json.dumps()의 indent 매개변수로 읽기 쉬운 형태로 출력",
    "파일 작업 시 항상 try-except로 예외 처리",
    "환경 변수는 os.environ.get()으로 안전하게 접근",
    "sys.exit()는 프로그램을 즉시 종료시키므로 신중하게 사용"
]

for i, tip in enumerate(tips, 1):
    print(f"💡 {i}. {tip}")

# 정리 작업
cleanup_files = ["app_config.json"]
for file in cleanup_files:
    if os.path.exists(file):
        try:
            os.remove(file)
            print(f"🗑️ 테스트 파일 '{file}' 정리됨")
        except Exception:
            pass

print("\n" + "=" * 60)
print("🎉 Python 시스템 라이브러리 학습 완료!")
print("=" * 60)
