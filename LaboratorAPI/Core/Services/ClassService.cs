using Core.Dtos;
using DataLayer;
using DataLayer.Entities;

namespace Core.Services
{
    public class ClassService
    {
        private readonly UnitOfWork unitOfWork;

        public ClassService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public ClassAddDto Add(ClassAddDto payload)
        {
            if (payload == null) return null;

            var hasNameConflict = unitOfWork.Classes
                .Any(c => c.Name == payload.Name);

            if (hasNameConflict) return null;

            var newClass = new Class
            {
                Name = payload.Name
            };

            unitOfWork.Classes.Insert(newClass);
            unitOfWork.SaveChanges();

            return payload;
        }

        public List<ClassViewDto> GetAll()
        {
            var classes = unitOfWork.Classes.GetAllWithStudentCount();
            
            
            return classes.Select(c => new ClassViewDto
            {
                Id = c.Id,
                Name = c.Name,
                StudentCount = c.StudentCount
            }).ToList();
        }
    }
}
