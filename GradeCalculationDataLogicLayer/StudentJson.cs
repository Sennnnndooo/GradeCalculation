using GradeCalculationDataModel;
using System.Text.Json;
using System.Linq;     
using System.IO;
namespace GradeCalculationDataLogicLayer
{
    public class StudentJson : GradeCalculationIni
    {
        private List<StudentGrade> _grades = new List<StudentGrade>();
        private readonly string _filePath;

        public StudentJson()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "students.json");
            EnsureFileExists();
            LoadData();
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        private void LoadData()
        {
            var json = File.ReadAllText(_filePath);
            _grades = JsonSerializer.Deserialize<List<StudentGrade>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new List<StudentGrade>();
        }

        private void SaveData()
        {
            var json = JsonSerializer.Serialize(_grades, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public void Add(StudentGrade grade)
        {
            _grades.Add(grade);
            SaveData();
        }

        public List<StudentGrade> GetInfo()
        {
            LoadData();
            return _grades;
        }

        public void Update(StudentGrade grade)
        {
            LoadData();
            var existing = _grades.FirstOrDefault(s => s.StudentID == grade.StudentID);

            if (existing != null)
            {
                existing.Quiz1 = grade.Quiz1;
                existing.Quiz2 = grade.Quiz2;
                existing.Quiz3 = grade.Quiz3;
                existing.LongQuiz1 = grade.LongQuiz1;
                existing.LongQuiz2 = grade.LongQuiz2;
                existing.Project = grade.Project;
                existing.Perform = grade.Perform;
                existing.Mid = grade.Mid;
                existing.Finals = grade.Finals;
                SaveData();
            }
        }

        public void Delete(string name)
        {
            LoadData();
            var student = _grades.FirstOrDefault(s => s.StudentID == name);
            if (student != null)
            {
                _grades.Remove(student);
                SaveData();
            }
        }
    }
}