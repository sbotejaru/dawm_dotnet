using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class StudentsRepository : RepositoryBase<Student>
    {
        private readonly AppDbContext dbContext;

        public StudentsRepository(AppDbContext dbContext) : base(dbContext) 
        {
            this.dbContext = dbContext;
        }

        public Student GetByIdWithGrades(int studentId, CourseType type)
        {
            var result = dbContext.Students
               .Select(e => new Student
               {
                    FirstName= e.FirstName,
                    LastName= e.LastName,
                    Id = e.Id,
                    ClassId= e.ClassId,
                    Grades = e.Grades
                        .Where(g => g.Course == type)
                        .OrderByDescending(g => g.Value)
                        .ToList()
               })
               .FirstOrDefault(e => e.Id == studentId);

            return result;
        }

        public List<string> GetClassStudents(int classId)
        {
            var results = dbContext.Students
                .Include(e => e.Grades.Where(e => e.Value > 5))

                .Where(e => e.ClassId == classId)

                .OrderByDescending(e => e.FirstName)
                    .ThenByDescending(e => e.LastName)

                .Select(e => e.FirstName + "" + e.LastName)

                .ToList();

            return results;
        }

        public Dictionary<int, List<Student>> GetGroupedStudents()
        {
            var results = dbContext.Students
                .GroupBy(e => e.ClassId)
                .Select(e => new { ClassId = e.Key, Students = e.ToList() })
                .ToDictionary(e => e.ClassId, e => e.Students);

            return results;
        }
    }
}
