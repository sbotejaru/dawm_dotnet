using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class ClassAddDto
    {
        [Required]
        public string Name { get; set; }
    }
}
