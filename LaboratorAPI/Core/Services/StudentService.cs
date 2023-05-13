using Core.Dtos;
using DataLayer;
using DataLayer.Dtos;
using DataLayer.Entities;
using DataLayer.Enums;
using DataLayer.Mapping;

namespace Core.Services
{
    public class StudentService
    {
        private readonly UnitOfWork unitOfWork;

        public StudentService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public StudentAddDto AddStudent(StudentAddDto payload)
        {
            if (payload == null) return null;

            var existingClass = unitOfWork.Classes.GetById(payload.ClassId);
            if (existingClass == null) return null;

            var newStudent = new Student
            {
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                DateOfBirth = payload.DateOfBirth,
                Address = payload.Address,

                ClassId = existingClass.Id
            };

            unitOfWork.Students.Insert(newStudent);
            unitOfWork.SaveChanges();

            return payload;
        }

        public List<Student> GetAll()
        {
            var results = unitOfWork.Students.GetAll();

            return results;
        }

        public StudentDto GetById(int studentId)
        {
            var student = unitOfWork.Students.GetById(studentId);

            var result = student.ToStudentDto();

            return result;
        }

        public bool EditName(StudentUpdateDto payload)
        {
            if (payload == null || payload.FirstName == null || payload.LastName == null)
            {
                return false;
            }

            var result = unitOfWork.Students.GetById(payload.Id);
            if (result == null) return false;

            result.FirstName = payload.FirstName;
            result.LastName = payload.LastName;

            return true;
        }

        public GradesByStudent GetGradesById(int studentId, CourseType courseType)
        {
            var studentWithGrades = unitOfWork.Students.GetByIdWithGrades(studentId, courseType);
            
            var result = new GradesByStudent(studentWithGrades);

            return result;
        }

        public List<string> GetClassStudents(int classId)
        {
            var students = unitOfWork.Students.GetClassStudents(classId);

            //var results = students.ToStudentDtos();

            return students;
        }

        public Dictionary<int, List<Student>> GetGroupedStudents()
        {
            var results = unitOfWork.Students.GetGroupedStudents();

            return results;
        }
    }
}
