using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 클래스로 만들기

namespace _0813
{
    class Student
    {
        // 속성(Property) 정의
        public string Name { get; set; }
        public int Age { get; set; }
        public double Score { get; set; }
        public string Grade { get; set; }

        // 생성자 (Constructor) - 객체 생성할 때 실행
        public Student(string name, int age , double score) { 
            Name = name;
            Age = age;
            Score = score;
            Grade = CalculaterGrade(score);
    
        }

        private string CalculaterGrade(double score)
        {
            if (score >= 90) return "A";
            else if (score >= 80) return "B";
            else if (score >= 70) return "C";
            else if (score >= 60) return "D";
            else return "F";
        }
    }
}
