using DataLayer.Entities;
using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class GradesRepository : RepositoryBase<Grade>
    {
        private readonly AppDbContext dbContext;

        public GradesRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        /*public Dictionary<CourseType, double> GetAllGradesByStudentId(int studentId)
        {
            var results = dbContext.
        }*/

        public List<Grade> GetGradesByStudentId(int studentId)
        {
            var grades = dbContext.Grades
                .Where(data => data.StudentId == studentId)
                .OrderBy(data => data.DateCreated)
                .ToList();

            return grades;
        }

        public List<IGrouping<CourseType, Grade>> GetGroupedGradesByStudentId(int studentId)
        {
            var grades = dbContext.Grades
                .Where(data => data.StudentId == studentId)
                .GroupBy(data => data.Course)
                .ToList();

            return grades;
        }

        public double GetAverageForStudent(int studentId)
        {
            var grades = dbContext.Grades
                .Where(data => data.StudentId == studentId)
                .ToList();

            double sum = 0;
            uint count = 0;

            foreach(var grade in grades)
            {
                sum += grade.Value;
                ++count;
            }

            return sum / count;
        }

        public double GetAverageForStudentCourse(int studentId, CourseType course)
        {
            var grades = dbContext.Grades
                .Where(data => data.StudentId == studentId)
                .Where(data => data.Course == course)
                .ToList();

            double sum = 0;
            uint count = 0;

            foreach(var grade in grades)
            {
                sum += grade.Value;
                ++count;
            }

            return sum / count;
        }
    }
}
