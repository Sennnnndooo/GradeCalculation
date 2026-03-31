using GradeCalculationDataModel;


namespace GradeCalculationDataLogicLayer
{
    public interface IGradeDataService
    {
        void Add(StudentGrade grade);
        List<StudentGrade> GetInfo();
        void Update(StudentGrade grade);
        void Delete(string name);
    }
}
