namespace GradeCalculation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Grade Computation ");
            Console.WriteLine("Student Name:");
            string studentname = Console.ReadLine();
            Console.WriteLine("Year & Course:");
            var yearandcourse = Console.ReadLine();

            Console.WriteLine("First Sem Or Second Sem:");
            string Semester = Console.ReadLine();
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Attendance:(25 MEETINGS)");
                int Attendance = Convert.ToInt32(Console.ReadLine());

                if (Attendance > 22)
                {
                    Console.WriteLine("Drop Student ");
                    break;
                }
                else
                {


                    //40

                    double quizscore1 = 10, quizscore2 = 10, quizscore3 = 10, hundredpercent = 100, lngquizscore1 = 20, lngquizscore2 = 30, project1 = 50, perform1 = 50, midterms1 = 50, finals1 = 50;
                    
                  
                    
                    Console.WriteLine("Quizzes:");
                    Console.WriteLine("1(10):");
                    int quiz1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("2(10):");
                    int quiz2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("3(10):");
                    int quiz3 = Convert.ToInt32(Console.ReadLine());

                      double quizpercent1  = quiz1 / quizscore1;
                     double quizpercent2 = quiz2 / quizscore2;
                     double quizpercent3 = quiz3 / quizscore3;

                     double resquiz1 = quizpercent1 * hundredpercent;
                    double resquiz2 = quizpercent2 * hundredpercent;
                     double resquiz3 =quizpercent3 * hundredpercent;


                    Console.WriteLine("Long quizzes:");
                    Console.WriteLine("1(20):");
                    int lngquiz1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("2(30):");
                    int lngquiz2 = Convert.ToInt32(Console.ReadLine());

                    double percentlngquiz1 = lngquiz1 / lngquizscore1;
                    double percentlngquiz2 = lngquiz2 / lngquizscore2;

                    double lngquizres1 = percentlngquiz1 * hundredpercent;
                    double lngquizres2 = percentlngquiz2 * hundredpercent;

                    //40
                    Console.WriteLine("Project:");
                    Console.WriteLine("1(50):");
                    int project = Convert.ToInt32(Console.ReadLine());

                    double percentproj = project / project1;

                    double resproj = percentproj * hundredpercent;

                    Console.WriteLine("Performance Task:");
                    Console.WriteLine("1(50):");
                    int performtask = Convert.ToInt32(Console.ReadLine());

                    double percentperform = performtask / perform1;

                    double respertask = percentperform * hundredpercent;

                    //20
                    Console.WriteLine("Midterms:");
                    Console.WriteLine("1(50):");
                    int midterms = Convert.ToInt32(Console.ReadLine());

                    double percentmid = midterms  / midterms1;

                    double resmid = percentmid * hundredpercent;

                    Console.WriteLine("Finals:");
                    Console.WriteLine("1(50):");
                    int finals = Convert.ToInt32(Console.ReadLine());

                    double percentfinals = finals / finals1;
                    double resfinals = percentfinals * hundredpercent;


                }
            }

        }
    }
}
