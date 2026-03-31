    using GradeCalculationDataLogicLayer;
    using GradeCalculationDataModel;
using GradeCalculationBusinessDataLogic;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;


public class GradeComputation

{
    static List<string> students = new List<string>();
    static GradeCalculationIni repo = new GradeDataBase();
    static GradeCalculationBusinessDataLogic.GradeService compute = new GradeCalculationBusinessDataLogic.GradeService(repo);
    public static void Main(string[] args)
    {
        while (true)
        {
            UI1();
        }
    }
    static void UI1()
    {

        Console.WriteLine("-------Grade Computation------");
        Console.WriteLine("-------------Grade------------");
        Console.WriteLine("-----------Calculator---------");
        Console.WriteLine("1.INPUT GRADE");
        Console.WriteLine("2.UPDATE / CHANGE GRADE");
        Console.WriteLine("3.REVIEW GRADE");
        Console.WriteLine("4.DELETE GRADE");
        Console.WriteLine("5.DISPLAY ALL STUDENTS (JSON OUTPUT)");
        Console.WriteLine("6.Exit");


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
                ShowAllStudents();
                break;

            case 6:

                Console.WriteLine("Thank you for using the app");
                Environment.Exit(0);
                return;
            default:
                Console.WriteLine("Try Again");
                break;
        }


    }


   

    static void inputgrade()
            {
        Console.WriteLine("Enter a Student Name:");
        string name = Console.ReadLine();
        var existing = compute.GetGrade(name);

        if (existing != null)
        {
            Console.WriteLine("Student already exists.");
            return;
        }
        students.Add(name);

        List<decimal> grades = new List<decimal>();
        //0
        Console.WriteLine("Quizzes:");
        Console.Write("1(10): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));
        //1
        Console.Write("2(10): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));
        //2
        Console.Write("3(10): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));
        //3
        Console.WriteLine("Long quizzes:");
        Console.Write("1(20): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));
        //4
        Console.Write("2(30): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));
        //5
        Console.WriteLine("Project:");
        Console.Write("1(50): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));
        //6
        Console.WriteLine("Performance Task:");
        Console.Write("1(50): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));
        //7
        Console.WriteLine("Midterms:");
        Console.Write("1(50): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));
        //8
        Console.WriteLine("Finals:");
        Console.Write("1(50): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        StudentGrade grade = new StudentGrade()
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

      
        compute.AddInfo(grade);
        Console.WriteLine("The Grade has been added.");

    }
    
    


    static void reviewgrade() {
        Console.WriteLine("Enter a Name to search:");
        string name = Console.ReadLine().Trim();
        var Students = compute.GetInfo();
        var existingname = compute.GetGrade(name);


        if (existingname == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }



        decimal final = compute.ComputeGrade(existingname);
        existingname.TotalGrade = final;

        List<decimal> converter = new List<decimal>();

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

        return;

    }
    static void updategrade()
    {
        Console.WriteLine("Enter the Name to Update:");
        string name = Console.ReadLine();

        List<decimal> grades = new List<decimal>();

        Console.WriteLine("Enter Update Grade Grades:");

        Console.Write("Quiz1(10): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write("Quiz2(10): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write("Quiz3(10): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write("Long Quiz1(20): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write("Long Quiz2(30): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write("Project(50): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write("Performance(50): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write("Midterm(50): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write("Finals:(50) ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        StudentGrade newData = new StudentGrade()
        {
            Quiz1 = grades[0],
            Quiz2 = grades[1],
            Quiz3 = grades[2],
            LongQuiz1 = grades[3],
            LongQuiz2 = grades[4],
            Project = grades[5],
            Perform = grades[6],
            Mid = grades[7],
            Finals = grades[8]
        };

        if (compute.UpdateInfo(name, newData))
        {
            Console.WriteLine("Updated successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void deletegrade()
    {
        Console.WriteLine("Enter a Name To Delete Grades:");
        string namesdel = Console.ReadLine();

       
        if (compute.Deleteinfo(namesdel))
        {
            Console.WriteLine("Deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
    static void ShowAllStudents()
    {
        var allStudents = compute.GetInfo();

        Console.WriteLine("\n--- Students (JSON Format) ---");

        if (allStudents.Count == 0)
        {
            Console.WriteLine("No students found.");
        }
        else
        {   
            var json = JsonSerializer.Serialize(allStudents, new JsonSerializerOptions
            {
                WriteIndented = true  
            });
            Console.WriteLine(json);
        }
        Console.WriteLine("-------------------------\n");
    }

}