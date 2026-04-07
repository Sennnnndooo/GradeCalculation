using GradeCalculationDataModel;
using GradeCalculationBusinessDataLogic;
using System;
using System.Collections.Generic;
using System.Text.Json;

public class GradeComputation
{
    
    public static GradeService compute = new GradeService();



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

        List<decimal> grades = new List<decimal>();

        Console.WriteLine("Quizzes:");
        Console.Write("1(10): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));
        Console.Write("2(10): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));
        Console.Write("3(10): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.WriteLine("Long quizzes:");
        Console.Write("1(20): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));
        Console.Write("2(30): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.WriteLine("Project:");
        Console.Write("1(50): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.WriteLine("Performance Task:");
        Console.Write("1(50): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.WriteLine("Midterms:");
        Console.Write("1(50): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

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

    static void reviewgrade()
    {
        Console.WriteLine("Enter a Name to search:");
        string name = Console.ReadLine().Trim();
        var existingname = compute.GetGrade(name);

        if (existingname == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        decimal final = compute.ComputeGrade(existingname);
        existingname.TotalGrade = final;

        Console.WriteLine($"Name: {existingname.StudentName}");
        Console.WriteLine($"Quiz 1: {existingname.Quiz1}/10");
        Console.WriteLine($"Quiz 2: {existingname.Quiz2}/10");
        Console.WriteLine($"Quiz 3: {existingname.Quiz3}/10");
        Console.WriteLine($"Long Quiz 1: {existingname.LongQuiz1}/20");
        Console.WriteLine($"Long Quiz 2: {existingname.LongQuiz2}/30");
        Console.WriteLine($"Project: {existingname.Project}/50");
        Console.WriteLine($"Performance Task: {existingname.Perform}/50");
        Console.WriteLine($"Midterm: {existingname.Mid}/50");
        Console.WriteLine($"Finals: {existingname.Finals}/50");
        Console.WriteLine($"Final Grade: {final:F2}%");
    }

    static void updategrade()
    {
        Console.WriteLine("Enter the Name to Update:");
        string name = Console.ReadLine();

        var existing = compute.GetGrade(name);

        if (existing == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        List<decimal> grades = new List<decimal>();

        Console.WriteLine("Enter Updated Grades:");

        Console.Write($"Quiz1 (previous: {existing.Quiz1}/10): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write($"Quiz2 (previous: {existing.Quiz2}/10): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write($"Quiz3 (previous: {existing.Quiz3}/10): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write($"Long Quiz1 (previous: {existing.LongQuiz1}/20): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write($"Long Quiz2 (previous: {existing.LongQuiz2}/30): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write($"Project (previous: {existing.Project}/50): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write($"Performance (previous: {existing.Perform}/50): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write($"Midterm (previous: {existing.Mid}/50): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.Write($"Finals (previous: {existing.Finals}/50): ");
        grades.Add(Convert.ToDecimal(Console.ReadLine()));

        StudentGrade newData = new StudentGrade()
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
    public static void Main(string[] args)
    {
        while (true)
        {
            UI1();
        }
    }
}