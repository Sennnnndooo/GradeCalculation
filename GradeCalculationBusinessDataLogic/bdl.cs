using GradeCalculationDataLogicLayer;
using GradeCalculationDataModel;


namespace GradeCalculationBusinessDataLogic
{
    public class bdl
    {
        public dl data = new dl();
        public dm listing = new dm();
        public double FinalQuiz1, FinalQuiz2, FinalQuiz3, PercentQuiz1, PercentQuiz2, PercentQuiz3;
        public double FinalLongQuiz1, FinalLongQuiz2, PercentLongQuiz1, PercentLongQuiz2;
        public double FinalProject, FinalPerform, FinalMid, FinalFinals, PercentProject, PercentPerform, PercentMid, PercentFinals;
        public double TotalGrade;


        public double ComputeGrade(dm grade)
        {


            FinalQuiz1 = grade.Quiz1 / data.quizscore1;
            PercentQuiz1 = FinalQuiz1 * data.hundredpercent;
            FinalQuiz2 = grade.Quiz2 / data.quizscore2;
            PercentQuiz2 = FinalQuiz2 * data.hundredpercent;
            FinalQuiz3 = grade.Quiz3 / data.quizscore3;
            PercentQuiz3 = FinalQuiz3 * data.hundredpercent;

            FinalLongQuiz1 = grade.LongQuiz1 / data.lngquizscore1;
            PercentLongQuiz1 = FinalLongQuiz1 * data.hundredpercent;
            FinalLongQuiz2 = grade.LongQuiz2 / data.lngquizscore2;
            PercentLongQuiz2 = FinalLongQuiz2 * data.hundredpercent;

            FinalProject = grade.Project / data.project1;
            PercentProject = FinalProject * data.hundredpercent;
            FinalPerform = grade.Perform / data.perform1;
            PercentPerform = FinalPerform * data.hundredpercent;
            FinalMid = grade.Mid / data.midterms1;
            PercentMid = FinalMid * data.hundredpercent;
            FinalFinals = grade.Finals / data.finals1;
            PercentFinals = FinalFinals * data.hundredpercent;

            double rawscore = (data.quizscore1 * FinalQuiz1) + (data.quizscore2 * FinalQuiz2) + (data.quizscore3 * FinalQuiz3) + (data.lngquizscore1 * FinalLongQuiz1) + (data.lngquizscore2 * FinalLongQuiz2) + (data.project1 * FinalProject) + (data.perform1 * FinalPerform) + (data.midterms1 * FinalMid) + (data.finals1 * FinalFinals);

            TotalGrade = (rawscore / data.totalscore) * data.hundredpercent;


            return TotalGrade;

        }

        public void checker()
        {



        }
    }
}
