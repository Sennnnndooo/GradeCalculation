using GradeCalculationDataModel;

namespace GradeCalculationDataLogicLayer
{
    public class GradeCalculationInitiator
    {
        private readonly GradeCalculationIni data;

        public GradeCalculationInitiator(GradeCalculationIni DATA)
        {
            data = DATA;
        }
        public void Add(StudentGrade grade)
        {
            data.Add(grade);
        }
        public List<StudentGrade> GetInfo()
        {
            return data.GetInfo();
        }
        public void Update(StudentGrade grade)
        {
            data.Update(grade);
        }
        public void Delete(string name)
        {   
            data.Delete(name);
        }
    }
}