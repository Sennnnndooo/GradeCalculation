
using GradeCalculationDataModel;
using System;
using System.Collections.Generic;
using System.Data;
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
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 200).Value = grade.StudentID;

                    var p = cmd.Parameters.Add("@quiz1", SqlDbType.Decimal);
                    p.Precision = 18; p.Scale = 2; p.Value = grade.Quiz1;
                    p = cmd.Parameters.Add("@quiz2", SqlDbType.Decimal);
                    p.Precision = 18; p.Scale = 2; p.Value = grade.Quiz2;
                    p = cmd.Parameters.Add("@quiz3", SqlDbType.Decimal);
                    p.Precision = 18; p.Scale = 2; p.Value = grade.Quiz3;

                    var pl1 = cmd.Parameters.Add("@lngquiz1", SqlDbType.Decimal);
                    pl1.Precision = 18; pl1.Scale = 2; pl1.Value = grade.LongQuiz1;
                    var pl2 = cmd.Parameters.Add("@lngquiz2", SqlDbType.Decimal);
                    pl2.Precision = 18; pl2.Scale = 2; pl2.Value = grade.LongQuiz2;

                    var pp = cmd.Parameters.Add("@project", SqlDbType.Decimal);
                    pp.Precision = 18; pp.Scale = 2; pp.Value = grade.Project;
                    var pperf = cmd.Parameters.Add("@perform", SqlDbType.Decimal);
                    pperf.Precision = 18; pperf.Scale = 2; pperf.Value = grade.Perform;

                    var pmid = cmd.Parameters.Add("@mid", SqlDbType.Decimal);
                    pmid.Precision = 18; pmid.Scale = 2; pmid.Value = grade.Mid;
                    var pfinal = cmd.Parameters.Add("@final", SqlDbType.Decimal);
                    pfinal.Precision = 18; pfinal.Scale = 2; pfinal.Value = grade.Finals;

                    var ptotal = cmd.Parameters.Add("@total", SqlDbType.Decimal);
                    ptotal.Precision = 18; ptotal.Scale = 2; ptotal.Value = grade.TotalGrade;

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
                              WHERE StudentID = @name";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 200).Value = grade.StudentID;

                    var q1 = cmd.Parameters.Add("@quiz1", SqlDbType.Decimal); 
                    q1.Precision = 18; 
                    q1.Scale = 2;
                    q1.Value = grade.Quiz1;
                    var q2 = cmd.Parameters.Add("@quiz2", SqlDbType.Decimal); 
                    q2.Precision = 18;
                    q2.Scale = 2; 
                    q2.Value = grade.Quiz2;
                    var q3 = cmd.Parameters.Add("@quiz3", SqlDbType.Decimal)
                        ; q3.Precision = 18; 
                    q3.Scale = 2;
                    q3.Value = grade.Quiz3;

                    var lq1 = cmd.Parameters.Add("@lngquiz1", SqlDbType.Decimal);
                    lq1.Precision = 18;
                    lq1.Scale = 2;
                    lq1.Value = grade.LongQuiz1;
                    var lq2 = cmd.Parameters.Add("@lngquiz2", SqlDbType.Decimal);
                    lq2.Precision = 18;
                    lq2.Scale = 2;
                    lq2.Value = grade.LongQuiz2;

                    var proj = cmd.Parameters.Add("@project", SqlDbType.Decimal); 
                    proj.Precision = 18; 
                    proj.Scale = 2; 
                    proj.Value = grade.Project;
                    var perf = cmd.Parameters.Add("@perform", SqlDbType.Decimal); 
                    perf.Precision = 18;
                    perf.Scale = 2;
                    perf.Value = grade.Perform;

                    var mid = cmd.Parameters.Add("@mid", SqlDbType.Decimal);
                    mid.Precision = 18;
                    mid.Scale = 2;
                    mid.Value = grade.Mid;
                    var fin = cmd.Parameters.Add("@final", SqlDbType.Decimal);
                    fin.Precision = 18; 
                    fin.Scale = 2; 
                    fin.Value = grade.Finals;

                    var tot = cmd.Parameters.Add("@total", SqlDbType.Decimal);
                    tot.Precision = 18; 
                    tot.Scale = 2; 
                    tot.Value = grade.TotalGrade;

                    conn.Open();
                    var rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        throw new InvalidOperationException($"Update failed, no row with StudentID='{grade.StudentID}'");
                    }
                }
            }
        }

        public void Delete(string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Grades WHERE StudentID = @name";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 200).Value = name;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
