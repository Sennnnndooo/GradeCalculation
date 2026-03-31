using GradeCalculationDataModel;
using GradeCalculationDataLogicLayer;

namespace GradeCalculationDataLogicLayer
{
    public interface GradeCalculationIni
    {
        void Add(StudentGrade grade);
        List<StudentGrade> GetInfo();
        void Update(StudentGrade grade);
        void Delete(string name);
    }
}
