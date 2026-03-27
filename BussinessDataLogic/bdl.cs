using DataLogicDataService;
using DataModel;
namespace BusinessDataLogicAppservice
{
    public class bdl
    {//
           public dl data = new dl();
           public dm listing = new dm();
            public double FinalQuiz1, FinalQuiz2, FinalQuiz3;
            public double FinalLongQuiz1, FinalLongQuiz2;
            public double FinalProject, FinalPerform, FinalMid, FinalFinals;
            public double TotalGrade;
        

        public double ComputeGrade(dm grade)
        {


            FinalQuiz1 = listing.Quiz1 / data.quizscore1;
            FinalQuiz2 = listing.Quiz2 / data.quizscore2;
           FinalQuiz3 = listing.Quiz3 / data.quizscore3;

            FinalLongQuiz1 = listing.LongQuiz1 / data.lngquizscore1;
            FinalLongQuiz2 = listing.LongQuiz2 / data.lngquizscore2;

            FinalProject = listing.Project / data.project1;
            FinalPerform = listing.Perform / data.perform1;
          FinalMid = listing.Mid / data.midterms1;
            FinalFinals = listing.Finals / data.finals1;

            double rawscore = (data.quizscore1 * FinalQuiz1) + (data.quizscore2 * FinalQuiz2) + (data.quizscore3 * FinalQuiz3) + (data.lngquizscore1 * FinalLongQuiz1) + (data.lngquizscore2 * FinalLongQuiz2) + (data.project1 * FinalProject) + (data.perform1 * FinalPerform) + (data.midterms1 * FinalMid) + (data.finals1 * FinalFinals);

            TotalGrade = (rawscore / data.totalscore) * data.hundredpercent;

            
            return TotalGrade;

        }
//



    }
}
