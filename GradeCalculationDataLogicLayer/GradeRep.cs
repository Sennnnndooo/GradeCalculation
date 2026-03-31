using GradeCalculationDataModel;
using System.Linq;
using System.Collections.Generic;

namespace GradeCalculationDataLogicLayer
{
    public class GradeRep : IGradeDataService
    {
        public List<StudentGrade> grades = new List<StudentGrade>();
        
            public  double quizscore1 = 10;
            public  double quizscore2 = 10;
            public  double quizscore3 = 10;

            public  double lngquizscore1 = 20;
            public  double lngquizscore2 = 30;

            public  double project1 = 50;
            public  double perform1 = 50;
            public double midterms1 = 50;
            public  double finals1 = 50;

            public  double totalscore = 280;
            public  double hundredpercent = 100;
        
        public void Add(StudentGrade grade)
        {
            grades.Add(grade);
        }

        public List<StudentGrade> GetInfo()
        {
            return new List<StudentGrade>(grades);
        }

        public void Delete(string name)
        {
            var student = grades.FirstOrDefault(s => s.StudentName == name);
            if (student != null)
            {
                grades.Remove(student);
            }
        }

        public void Update(StudentGrade grade)
        {
            var existing = grades.FirstOrDefault(s => s.StudentName == grade.StudentName);

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
            }
        }
    }
}