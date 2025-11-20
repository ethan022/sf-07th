using _0814_3.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _0814_3.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var student = new Student
            {
                Name = "김철수",
                Age = 20,
                Score = 80,
            };


            Console.WriteLine($"이름: {student.Name}");
            Console.WriteLine($"나이: {student.Age}");
            Console.WriteLine($"점수: {student.Score}");
            Console.WriteLine($"등급: {student.Grade}");
            Console.WriteLine($"합격: {student.IsPassed}");

        }
    }
}