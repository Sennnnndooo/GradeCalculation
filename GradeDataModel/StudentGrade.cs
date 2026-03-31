namespace GradeCalculationDataModel
{
    public class StudentGrade
    {
        public string StudentName { get; set; } = string.Empty;
        public decimal Quiz1 { get; set; }
        public decimal Quiz2 { get; set; }

        public decimal Quiz3 { get; set; }
        public decimal LongQuiz1 { get; set; }
        public decimal LongQuiz2 { get; set; }
        public decimal Project { get; set; }
        public decimal Perform { get; set; }
        public decimal Mid { get; set; }
        public decimal Finals { get; set; }
        public decimal TotalGrade { get; set; }
    }
}
