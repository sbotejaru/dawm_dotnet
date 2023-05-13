using Core.Dtos;
using DataLayer;
using DataLayer.Dtos;
using DataLayer.Entities;
using DataLayer.Enums;
using DataLayer.Mapping;

namespace Core.Services
{
    public class GradeService
    {
        private readonly UnitOfWork unitOfWork;

        public GradeService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public GradeAddDto AddGrade(GradeAddDto payload)
        {
            if (payload == null) return null;

            var newGrade = new Grade
            {
                Value = payload.Value,
                StudentId = payload.StudentId,
                Course = payload.Course,
                DateCreated = payload.DateCreated
            };

            unitOfWork.Grades.Insert(newGrade);
            unitOfWork.SaveChanges();

            return payload;
        }

        public List<Grade> GetAll()
        {
            var results = unitOfWork.Grades.GetAll();

            return results;
        }

        public List<Grade> GetStudentGrades(int studentId)
        {
            var grades = unitOfWork.Grades.GetGradesByStudentId(studentId);

            return grades;
        }

        public List<IGrouping<CourseType, Grade>> GetGroupedStudentGrades(int studentId)
        {
            var grades = unitOfWork.Grades.GetGroupedGradesByStudentId(studentId);

            return grades;
        }

        public double GetAverageGradeForStudent(int studentId)
        {
            var average = unitOfWork.Grades.GetAverageForStudent(studentId);

            return average;
        }

        public double GetAverageGradeForStudentCourse(int studentId, CourseType course)
        {
            var averageCourse = unitOfWork.Grades.GetAverageForStudentCourse(studentId, course);

            return averageCourse;
        }
    }
}
