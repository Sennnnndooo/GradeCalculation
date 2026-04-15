using GradeCalculationDataModel;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace GradeCalculationDataLogicLayer
{
    public class GradeDataBase : GradeCalculationIni
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS01;Database=GRCalculation;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;";
      
        public void Add(StudentGrade grade)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO Grades 
                              (StudentID, Quiz1, Quiz2, Quiz3, LongQuiz1, LongQuiz2, 
                               Project, Perform, Mid, Finals, TotalGrade)
                              VALUES (@name, @quiz1, @quiz2, @quiz3, @lngquiz1, @lngquiz2, 
                                      @project, @perform, @mid, @final, @total)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", grade.StudentID);
                    cmd.Parameters.AddWithValue("@quiz1", grade.Quiz1);
                    cmd.Parameters.AddWithValue("@quiz2", grade.Quiz2);
                    cmd.Parameters.AddWithValue("@quiz3", grade.Quiz3);
                    cmd.Parameters.AddWithValue("@lngquiz1", grade.LongQuiz1);
                    cmd.Parameters.AddWithValue("@lngquiz2", grade.LongQuiz2);
                    cmd.Parameters.AddWithValue("@project", grade.Project);
                    cmd.Parameters.AddWithValue("@perform", grade.Perform);
                    cmd.Parameters.AddWithValue("@mid", grade.Mid);
                    cmd.Parameters.AddWithValue("@final", grade.Finals);
                    cmd.Parameters.AddWithValue("@total", grade.TotalGrade);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<StudentGrade> GetInfo()
        {
            List<StudentGrade> grades = new List<StudentGrade>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT StudentID, Quiz1, Quiz2, Quiz3, LongQuiz1, LongQuiz2, Project, Perform, Mid, Finals, TotalGrade FROM Grades";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StudentGrade grade = new StudentGrade
                            {
                                StudentID = reader["StudentID"].ToString(),
                                Quiz1 = Convert.ToDecimal(reader["Quiz1"]),
                                Quiz2 = Convert.ToDecimal(reader["Quiz2"]),
                                Quiz3 = Convert.ToDecimal(reader["Quiz3"]),
                                LongQuiz1 = Convert.ToDecimal(reader["LongQuiz1"]),
                                LongQuiz2 = Convert.ToDecimal(reader["LongQuiz2"]),
                                Project = Convert.ToDecimal(reader["Project"]),
                                Perform = Convert.ToDecimal(reader["Perform"]),
                                Mid = Convert.ToDecimal(reader["Mid"]),
                                Finals = Convert.ToDecimal(reader["Finals"]),
                                TotalGrade = Convert.ToDecimal(reader["TotalGrade"])
                            };
                            grades.Add(grade);
                        }
                    }
                }
            }

            return grades;
        }

        public void Update(StudentGrade grade)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE Grades SET 
                              Quiz1 = @quiz1, 
                              Quiz2 = @quiz2, 
                              Quiz3 = @quiz3,
                              LongQuiz1 = @lngquiz1, 
                              LongQuiz2 = @lngquiz2,
                              Project = @project, 
                              Perform = @perform,
                              Mid = @mid, 
                              Finals = @final,
                              TotalGrade = @total
                              WHERE StudentName = @name";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", grade.StudentID);
                    cmd.Parameters.AddWithValue("@quiz1", grade.Quiz1);
                    cmd.Parameters.AddWithValue("@quiz2", grade.Quiz2);
                    cmd.Parameters.AddWithValue("@quiz3", grade.Quiz3);
                    cmd.Parameters.AddWithValue("@lngquiz1", grade.LongQuiz1);
                    cmd.Parameters.AddWithValue("@lngquiz2", grade.LongQuiz2);
                    cmd.Parameters.AddWithValue("@project", grade.Project);
                    cmd.Parameters.AddWithValue("@perform", grade.Perform);
                    cmd.Parameters.AddWithValue("@mid", grade.Mid);
                    cmd.Parameters.AddWithValue("@final", grade.Finals);
                    cmd.Parameters.AddWithValue("@total", grade.TotalGrade);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Grades WHERE StudentName = @name";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}