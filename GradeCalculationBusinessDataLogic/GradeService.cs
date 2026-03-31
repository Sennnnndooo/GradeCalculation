using GradeCalculationDataLogicLayer;
using GradeCalculationDataModel;
using System.Linq;  
namespace GradeCalculationBusinessDataLogic
{
    public class GradeService

    {
        public GradeCalculationIni data;  // This will be JSON for storage
        public GradeTotals constants = new GradeTotals();  // This is for calculation constants only
        public StudentGrade listing = new StudentGrade();
        

        public double FinalQuiz1, FinalQuiz2, FinalQuiz3, PercentQuiz1, PercentQuiz2, PercentQuiz3;
        public double FinalLongQuiz1, FinalLongQuiz2, PercentLongQuiz1, PercentLongQuiz2;
        public double FinalProject, FinalPerform, FinalMid, FinalFinals, PercentProject, PercentPerform, PercentMid, PercentFinals;
        public double TotalGrade;
        public GradeService(GradeCalculationIni repo)
        {
            data = repo;  // This will be StudentJson for storage
        }
        public class GradeTotals
        {
            public double quizscore1 = 10;
            public double quizscore2 = 10;
            public double quizscore3 = 10;
            public double lngquizscore1 = 20;
            public double lngquizscore2 = 30;
            public double project1 = 50;
            public double perform1 = 50;
            public double midterms1 = 50;
            public double finals1 = 50;
            public double totalscore = 280;
            public double hundredpercent = 100;
        }
        public double ComputeGrade(StudentGrade grade)
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

            double rawscore = (constants.quizscore1 * FinalQuiz1) + (constants.quizscore2 * FinalQuiz2) + (constants.quizscore3 * FinalQuiz3) + (constants.lngquizscore1 * FinalLongQuiz1) + (constants.lngquizscore2 * FinalLongQuiz2) + (constants.project1 * FinalProject) + (constants.perform1 * FinalPerform) + (constants.midterms1 * FinalMid) + (constants.finals1 * FinalFinals);

            TotalGrade = (rawscore / constants.totalscore) * constants.hundredpercent;


            return TotalGrade;

        }
        public bool UpdateInfo(string name, StudentGrade newData)
        {
            var student = data.GetInfo().FirstOrDefault(s => s.StudentName == name);

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


            data.Update(student);

            return true;
        }

        public bool Deleteinfo(string name)
        {
            var students = data.GetInfo()
                .FirstOrDefault(s => s.StudentName == name);

            if (students == null)
            {
                return false;
            }
            else
            {
                data.Delete(name);
                return true;
            }
        }
        public StudentGrade GetGrade(string studentName)
        {
            return data.GetInfo().FirstOrDefault(g =>
                g.StudentName.Equals(studentName, StringComparison.OrdinalIgnoreCase));
        }
        public List<StudentGrade> GetInfo()
        {
            return data.GetInfo();
        }

        public void AddInfo(StudentGrade student)
        {
            data.Add(student);
        }


    }
}
