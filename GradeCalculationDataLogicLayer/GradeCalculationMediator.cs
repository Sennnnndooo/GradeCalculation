using GradeCalculationDataModel;

namespace GradeCalculationDataLogicLayer
{
    public class GradeDataService
    {
        private readonly IGradeDataService _data;

        public GradeDataService(IGradeDataService data)
        {
            _data = data;
        }

        public void Add(StudentGrade grade) => _data.Add(grade);
        public List<StudentGrade> GetInfo() => _data.GetInfo();
        public void Update(StudentGrade grade) => _data.Update(grade);
        public void Delete(string name) => _data.Delete(name);
    }
}