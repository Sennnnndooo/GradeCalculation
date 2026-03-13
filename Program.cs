using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Xml.Serialization;
using BusinessDataLogicAppservice;

public class GradeComputation


{
    public static string useradmin,passadmin,choice;
    

    static void inputgrade()
    {
        bdl gradeLogic = new bdl();

        Console.WriteLine("Quizzes:");
        Console.Write("1(10): "); 
        double quiz1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("2(10): ");
        double quiz2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("3(10): ");
        double quiz3 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Long quizzes:");
        Console.Write("1(20): ");
        double lngquiz1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("2(30): ");
        double lngquiz2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Project:");
        Console.Write("1(50): ");
        double project = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Performance Task:");
        Console.Write("1(50): ");
        double performtask = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Midterms:");
        Console.Write("1(50): "); 
        double midterms = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Finals:");
        Console.Write("1(50): "); 
        double finals = Convert.ToDouble(Console.ReadLine());

     
        var result = gradeLogic.ComputeGrade(quiz1, quiz2, quiz3, lngquiz1, lngquiz2,project, performtask, midterms, finals);

        
        Console.WriteLine("Quiz 1 Grade: " + (result.FinalQuiz1 * 100));
        Console.WriteLine("Quiz 2 Grade: " + (result.FinalQuiz2 * 100));
        Console.WriteLine("Quiz 3 Grade: " + (result.FinalQuiz3 * 100));
        Console.WriteLine("Long Quiz 1 Grade: " + (result.FinalLongQuiz1 * 100));
        Console.WriteLine("Long Quiz 2 Grade: " + (result.FinalLongQuiz2 * 100));
        Console.WriteLine("Project Grade: " + (result.FinalProject * 100));
        Console.WriteLine("Performance Task Grade: " + (result.FinalPerform * 100));
        Console.WriteLine("Midterm Grade: " + (result.FinalMid * 100));
        Console.WriteLine("Final Exam Grade: " + (result.FinalFinals * 100));
        Console.WriteLine("Final Grade: " + result.TotalGrade);


    }
    static void UI1() {

        Console.WriteLine("-------Grade Computation------");
        Console.WriteLine("1.ADD STUDENT");
        Console.WriteLine("2.INPUT GRADE");
        Console.WriteLine("3.UPDATE / CHANGE GRADE");
        Console.WriteLine("4.REVIEW GRADE");
        Console.WriteLine("5.DELETE GRADE");
        Console.WriteLine("Enter your Choice:");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {

            case 1:
                List<string> usernames = new List<string>();
                Console.WriteLine("Enter A Student Name:");
                string studentname = Console.ReadLine();
                usernames.Add(studentname);

                break;

            case 2:
                inputgrade();
                

                break;
 
        }
 

    }


    static void Loginadmin()
    {
        
            Console.WriteLine("-------Grade Computation------");
            Console.WriteLine("Enter Admin:");
            string inputadmin = Console.ReadLine();
            Console.WriteLine("Enter Password Admin:");
            string inputpass = Console.ReadLine();

            if (inputadmin == useradmin && inputpass == passadmin)
            {
                UI1();

            }
            else
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("Try Again");
                Console.WriteLine("Would you like to go back to menu?(Yes or no)");
                choice = Console.ReadLine();
                if (choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    Menu();

                }
                else if (choice.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    Loginadmin();
                }
                else {

                    Console.WriteLine("Thank you for using!!");
                    break;

                }

            }

            }
        
    }

    static void Createadmin() {

        Console.WriteLine("-------Grade Computation-------");
        Console.WriteLine("Create an Username Admin:");
         useradmin = Console.ReadLine();
        Console.WriteLine("Create an Password Admin:");
         passadmin = Console.ReadLine();
        while (true)
        {
            Console.WriteLine("Do you want to go back to Menu?(Yes or No)");
             choice = Console.ReadLine();

            if (choice.Equals("yes",StringComparison.OrdinalIgnoreCase))
            {
                Menu();
                break;
                
            }
            else if (choice.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                Createadmin();
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.Please type (Yes Or No)");

            }
        }
    }


    static void Menu() {
        Console.WriteLine("-------Grade Computation-------");
        Console.WriteLine("1.Login Admin");
        Console.WriteLine("2.Create Admin");
        Console.WriteLine("3.Exit");
        Console.WriteLine("Enter your Choice:");
        int login = Convert.ToInt32(Console.ReadLine());
        switch (login)
        {
            case 1:        
                Loginadmin();

                break;
            case 2:
                Createadmin();
                break;

            case 3:
                break;
        }
    }

    public static void Main(string[] args)
    {

        Menu();

    }
}