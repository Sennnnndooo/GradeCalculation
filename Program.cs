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



                    Console.WriteLine("Quizzes:");
                    Console.WriteLine("1:");
                    int quiz1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("2:");
                    int quiz2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("3:");
                    int quiz3 = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Long quizzes:");
                    Console.WriteLine("1:");
                    int lngquiz1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("2:");
                    int lngquiz2 = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Project:");
                    Console.WriteLine("1:");
                    int project = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Performance Task:");
                    Console.WriteLine("1:");
                    int performtask = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Midterms:");
                    Console.WriteLine("1:");
                    int mid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Finals:");
                    Console.WriteLine("1:");
                    int finals = Convert.ToInt32(Console.ReadLine());
                }
            }

        }
    }
}
