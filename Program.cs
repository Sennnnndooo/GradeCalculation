
using BusinessDataLogicAppservice;
using DataModel;
using DataLogicDataService;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.Serialization;


public class GradeComputation


{
    static dm grade = new dm();
    static bdl compute = new bdl();
    static dl storages = new dl();
    static List<string> students = new List<string>();


    static void inputgrade()
    {
 
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

        dm grade = new dm
        {

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
       
        compute.listing = grade;
        double final = compute.ComputeGrade(grade);


        Console.WriteLine("Final Grade:" +  final.ToString("F2"));
       
        //Console.WriteLine("Quiz 1 Grade: " + (result.FinalQuiz1 * 100));
        //Console.WriteLine("Quiz 2 Grade: " + (result.FinalQuiz2 * 100));
        //Console.WriteLine("Quiz 3 Grade: " + (result.FinalQuiz3 * 100));
        //Console.WriteLine("Long Quiz 1 Grade: " + (result.FinalLongQuiz1 * 100));
        //Console.WriteLine("Long Quiz 2 Grade: " + (result.FinalLongQuiz2 * 100));
        //Console.WriteLine("Project Grade: " + (result.FinalProject * 100));
        //Console.WriteLine("Performance Task Grade: " + (result.FinalPerform * 100));
        //Console.WriteLine("Midterm Grade: " + (result.FinalMid * 100));
        //Console.WriteLine("Final Exam Grade: " + (result.FinalFinals * 100));
        //Console.WriteLine("Final Grade: " + result.TotalGrade);

    }
    //
    static void updategrade() {
        Console.WriteLine("Enter a Name:");
        students.Add(Console.ReadLine());
    }

    static void reviewgrade() {
    
    }
    static void deletegrade() {
      
    }
    static void UI1() {

        Console.WriteLine("-------Grade Computation------");
        Console.WriteLine("1.INPUT GRADE");
        Console.WriteLine("2.UPDATE / CHANGE GRADE");
        Console.WriteLine("3.REVIEW GRADE");
        Console.WriteLine("4.DELETE GRADE");
       
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
        }


    }

    public static void Main(string[] args)
    {

        UI1();

    }
}