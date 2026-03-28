
using GradeCalculationBusinessDataLogic;
using GradeCalculationDataLogicLayer;
using GradeCalculationDataModel;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;


public class GradeComputation

{
    static dm grade = new dm();
    static bdl compute = new bdl();
    static dl storages = new dl();
    static List<string> students = new List<string>();

    static void inputgrade()
    {
        Console.WriteLine("Enter a Name:");
        string name = Console.ReadLine();

        students.Add(name);

        bdl gradeLogic = new bdl();
        List<double> grades = new List<double>();
        //0
        Console.WriteLine("Quizzes:");
        Console.Write("1(10): ");
        grades.Add(Convert.ToDouble(Console.ReadLine()));
        //1
        Console.Write("2(10): ");
        grades.Add(Convert.ToDouble(Console.ReadLine()));
        //2
        Console.Write("3(10): ");
        grades.Add(Convert.ToDouble(Console.ReadLine()));
        //3
        Console.WriteLine("Long quizzes:");
        Console.Write("1(20): ");
        grades.Add(Convert.ToDouble(Console.ReadLine()));
        //4
        Console.Write("2(30): ");
        grades.Add(Convert.ToDouble(Console.ReadLine()));
        //5
        Console.WriteLine("Project:");
        Console.Write("1(50): ");
        grades.Add(Convert.ToDouble(Console.ReadLine()));
        //6
        Console.WriteLine("Performance Task:");
        Console.Write("1(50): ");
        grades.Add(Convert.ToDouble(Console.ReadLine()));
        //7
        Console.WriteLine("Midterms:");
        Console.Write("1(50): ");
        grades.Add(Convert.ToDouble(Console.ReadLine()));
        //8
        Console.WriteLine("Finals:");
        Console.Write("1(50): ");
        grades.Add(Convert.ToDouble(Console.ReadLine()));

        dm grade = new dm()
        {
            StudentName = name,
            Quiz1 = grades[0],
            Quiz2 = grades[1],
            Quiz3 = grades[2],
            LongQuiz1 = grades[3],
            LongQuiz2 = grades[4],
            Project = grades[5],
            Perform = grades[6],
            Mid = grades[7],
            Finals = grades[8],

        };


        storages.adding(grade);
        Console.WriteLine("The Grade has been add.");

 
        
        while (true)
                {
            Console.WriteLine("1.Input Grade");
            Console.WriteLine("2.Update Grade");
            Console.WriteLine("3.Review Grade");
            Console.WriteLine("4.Delete Grade");
            Console.WriteLine("5.Exit");
            int pick = Convert.ToInt32(Console.ReadLine());

            switch (pick)
            {
                case 1:
                    inputgrade();
                    break;
                case 2:
                    updategrade();
                    break;
                case 3:
                    reviewgrade();
                    break;
                case 4:
                    deletegrade();
                    break;
                case 5:
                    UI1();
                    break;

            }
        }     
        

    }
    //
    static void updategrade() {
        Console.WriteLine("Enter a Name:");
        students.Add(Console.ReadLine());
    }
    

    static void reviewgrade() {
        Console.WriteLine("Enter a Name to search:");
        string name = Console.ReadLine();
        dm grade = storages.GetGrade(name);
        var Students = storages.GetInfo();
        var existingname = Students.FirstOrDefault(checker => checker.StudentName == name);
        bool existnames = false;

        if (grade == null)
        {
            Console.WriteLine("Student not found.");
            
        }
        else
        {
            if (existingname != null)
            {

                compute.listing = grade;
                double final = compute.ComputeGrade(grade);

                List<double> converter = new List<double>();
                
                converter.Add(compute.PercentQuiz1);
                 converter.Add(compute.PercentQuiz2);
                converter.Add(compute.PercentQuiz3);
                converter.Add(compute.PercentLongQuiz1);
                converter.Add(compute.PercentLongQuiz2);
                converter.Add(compute.PercentProject);
                converter.Add(compute.PercentPerform);
                converter.Add(compute.PercentMid);
                converter.Add(compute.PercentFinals);
              
               

                Console.WriteLine("Name:" + (existingname.StudentName));
                Console.WriteLine("Quiz 1: Grade:" + converter[0].ToString("F2"));
                Console.WriteLine("Quiz 2: Grade:" + converter[1].ToString("F2"));
                Console.WriteLine("Quiz 3: Grade:" + converter[2].ToString("F2"));
                Console.WriteLine("Long Quiz 1: Grade:" + converter[3].ToString("F2"));
                Console.WriteLine("Long Quiz 2: Grade:" + converter[4].ToString("F2"));
                Console.WriteLine("Project Grade: Grade:" + converter[5].ToString("F2"));
                Console.WriteLine("Performance Task: Grade:" + converter[6].ToString("F2"));
                Console.WriteLine("Midterm: Grade:" + converter[7].ToString("F2"));
                Console.WriteLine("Finals: Grade:" + converter[8].ToString("F2"));
                Console.WriteLine("Final Grade:" + final.ToString("F2"));
                existnames = true;
                return;
            }
            
        }
    }

  
    static void deletegrade() {
      


    }
    static void UI1() {

        Console.WriteLine("-------Grade Computation------");
        Console.WriteLine("1.INPUT GRADE");
        Console.WriteLine("2.UPDATE / CHANGE GRADE");
        Console.WriteLine("3.REVIEW GRADE");
        Console.WriteLine("4.DELETE GRADE");
        Console.WriteLine("5.Exit");
     
        Console.WriteLine("Enter your Choice:");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {

            case 1:
                inputgrade();
                break;
            case 2:
                updategrade();
                break;
            case 3:
                reviewgrade();
                break;
            case 4:
                deletegrade();
                break;
            case 5:

                Console.WriteLine("Thank you for using the app");
                return;
              
          
        }


    }

    public static void Main(string[] args)
    {

        UI1();

    }
}