using DataLayer.Dtos;
using DataLayer.Entities;

namespace DataLayer.Mapping
{
    public static class StudentsMappingExtensions
    {

        public static List<StudentDto> ToStudentDtos(this List<Student> students) 
        {
            var results = students.Select(e => e.ToStudentDto()).ToList();

            return results;
        }

        public static StudentDto ToStudentDto(this Student student)
        {
            if (student == null) return null;

            var result = new StudentDto();
            result.Id = student.Id;
            result.FullName = student.FirstName + " " + student.LastName;
            result.ClassId = student.ClassId;
            result.ClassName = student.Class?.Name;
            result.Grades = student.Grades.ToGradeDtos();

            return result;
        }
    }
}
