using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public List<GradeDto> Grades { get; set; }
    }
}
