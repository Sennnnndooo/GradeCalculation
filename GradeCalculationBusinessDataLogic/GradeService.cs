
using GradeCalculationDataLogicLayer;
using GradeCalculationDataModel;
using System.Linq;

namespace GradeCalculationBusinessDataLogic
{
    public class GradeService
    {


        private GradeCalculationService gradeDataService = new GradeCalculationService(new GradeDataBase());

       
       


        public GradeTotals constants = new GradeTotals();

        public decimal FinalQuiz1, FinalQuiz2, FinalQuiz3, PercentQuiz1, PercentQuiz2, PercentQuiz3;
        public decimal FinalLongQuiz1, FinalLongQuiz2, PercentLongQuiz1, PercentLongQuiz2;
        public decimal FinalProject, FinalPerform, FinalMid, FinalFinals, PercentProject, PercentPerform, PercentMid, PercentFinals;
        public decimal TotalGrade;

        public class GradeTotals
        {
            public decimal quizscore1 = 10m;
            public decimal quizscore2 = 10m;
            public decimal quizscore3 = 10m;
            public decimal lngquizscore1 = 20m;
            public decimal lngquizscore2 = 30m;
            public decimal project1 = 50m;
            public decimal perform1 = 50m;
            public decimal midterms1 = 50m;
            public decimal finals1 = 50m;
            public decimal totalscore = 280m;
            public decimal hundredpercent = 100m;
        }

        public decimal ComputeGrade(StudentGrade grade)
        {
            FinalQuiz1 = grade.Quiz1 / constants.quizscore1;
            PercentQuiz1 = FinalQuiz1 * constants.hundredpercent;
            FinalQuiz2 = grade.Quiz2 / constants.quizscore2;
            PercentQuiz2 = FinalQuiz2 * constants.hundredpercent;
            FinalQuiz3 = grade.Quiz3 / constants.quizscore3;
            PercentQuiz3 = FinalQuiz3 * constants.hundredpercent;

            FinalLongQuiz1 = grade.LongQuiz1 / constants.lngquizscore1;
            PercentLongQuiz1 = FinalLongQuiz1 * constants.hundredpercent;
            FinalLongQuiz2 = grade.LongQuiz2 / constants.lngquizscore2;
            PercentLongQuiz2 = FinalLongQuiz2 * constants.hundredpercent;

            FinalProject = grade.Project / constants.project1;
            PercentProject = FinalProject * constants.hundredpercent;
            FinalPerform = grade.Perform / constants.perform1;
            PercentPerform = FinalPerform * constants.hundredpercent;
            FinalMid = grade.Mid / constants.midterms1;
            PercentMid = FinalMid * constants.hundredpercent;
            FinalFinals = grade.Finals / constants.finals1;
            PercentFinals = FinalFinals * constants.hundredpercent;

            decimal rawscore = (constants.quizscore1 * FinalQuiz1) + (constants.quizscore2 * FinalQuiz2) +
                              (constants.quizscore3 * FinalQuiz3) + (constants.lngquizscore1 * FinalLongQuiz1) +
                              (constants.lngquizscore2 * FinalLongQuiz2) + (constants.project1 * FinalProject) +
                              (constants.perform1 * FinalPerform) + (constants.midterms1 * FinalMid) +
                              (constants.finals1 * FinalFinals);

            TotalGrade = (rawscore / constants.totalscore) * constants.hundredpercent;
            return TotalGrade;
        }

        public bool UpdateInfo(string name, StudentGrade newData)
        {
            var student = gradeDataService.GetByName(name);

            if (student == null)
            {
                return false;
            }

            student.Quiz1 = newData.Quiz1;
            student.Quiz2 = newData.Quiz2;
            student.Quiz3 = newData.Quiz3;
            student.LongQuiz1 = newData.LongQuiz1;
            student.LongQuiz2 = newData.LongQuiz2;
            student.Project = newData.Project;
            student.Perform = newData.Perform;
            student.Mid = newData.Mid;
            student.Finals = newData.Finals;

         
            student.TotalGrade = ComputeGrade(student);

            gradeDataService.Update(student);
            return true;
        }

        public bool Deleteinfo(string name)
        {
            var student = gradeDataService.GetByName(name);

            if (student == null)
            {
                return false;
            }

            gradeDataService.Delete(name);
            return true;
        }

        public List<StudentGrade> GetInfo()
        {
            return gradeDataService.GetInfo();
        }

        public void AddInfo(StudentGrade student)
        {
            decimal finalGrade = ComputeGrade(student);
            student.TotalGrade = finalGrade;
            gradeDataService.Add(student);
        }
        public StudentGrade? GetGrade(string studentName)
        {
            return gradeDataService.GetByName(studentName);
        }
    }
}
