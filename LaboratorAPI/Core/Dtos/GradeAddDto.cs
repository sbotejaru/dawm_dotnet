using DataLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class GradeAddDto
    {
        [Required]
        public double Value { get; set; }

        [Required]
        public CourseType Course { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public int StudentId { get; set; }
    }
}
