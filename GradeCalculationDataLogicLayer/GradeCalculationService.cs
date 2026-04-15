using GradeCalculationDataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeCalculationDataLogicLayer
{
    public class GradeCalculationService
    {
        GradeCalculationIni DataService;

        public GradeCalculationService(GradeCalculationIni gradeCalculationIni)
        {
            DataService = gradeCalculationIni;
        }

        public void Add(StudentGrade grade)
        {
            DataService.Add(grade);
        }

        public List<StudentGrade> GetInfo()
        {
            return DataService.GetInfo();
        }

        public StudentGrade? GetByName(string name)
        {
            return DataService.GetInfo().FirstOrDefault(s => s.StudentID == name);
        }

        public void Update(StudentGrade grade)
        {
            DataService.Update(grade);
        }

        public void Delete(string name)
        {
            DataService.Delete(name);
        }


    }
}