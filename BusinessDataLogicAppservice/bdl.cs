using DataLogicDataService;
namespace BusinessDataLogicAppservice
{
    public class bdl
    {
        dl data = new dl();

        public class GradeResult
        {
            public double FinalQuiz1, FinalQuiz2, FinalQuiz3;
            public double FinalLongQuiz1, FinalLongQuiz2;
            public double FinalProject, FinalPerform, FinalMid, FinalFinals;
            public double TotalGrade;
        }

        public GradeResult ComputeGrade(double QUIZ1, double QUIZ2, double QUIZ3, double LNGQUIZ1, double LNGQUIZ2, double PROJECT, double PERFORM, double MIDTERMS, double FINALS)
        {
            GradeResult result = new GradeResult();

            result.FinalQuiz1 = QUIZ1 / data.quizscore1;
            result.FinalQuiz2 = QUIZ2 / data.quizscore2;
            result.FinalQuiz3 = QUIZ3 / data.quizscore3;

            result.FinalLongQuiz1 = LNGQUIZ1 / data.lngquizscore1;
            result.FinalLongQuiz2 = LNGQUIZ2 / data.lngquizscore2;

            result.FinalProject = PROJECT / data.project1;
            result.FinalPerform = PERFORM / data.perform1;
            result.FinalMid = MIDTERMS / data.midterms1;
            result.FinalFinals = FINALS / data.finals1;

            double rawscore = (data.quizscore1 * result.FinalQuiz1) + (data.quizscore2 * result.FinalQuiz2) + (data.quizscore3 * result.FinalQuiz3) + (data.lngquizscore1 * result.FinalLongQuiz1) + (data.lngquizscore2 * result.FinalLongQuiz2) + (data.project1 * result.FinalProject) + (data.perform1 * result.FinalPerform) + (data.midterms1 * result.FinalMid) + (data.finals1 * result.FinalFinals);

            result.TotalGrade = (rawscore / data.totalscore) * data.hundredpercent;

            return result;
        }
    }
}
