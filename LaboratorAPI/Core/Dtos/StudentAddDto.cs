using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class StudentAddDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int ClassId { get; set; }

        public string Address { get; set; }
    }
}
