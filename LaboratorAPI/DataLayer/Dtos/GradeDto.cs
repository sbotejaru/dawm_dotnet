using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos
{
    public class GradeDto
    {
        public double Value { get; set; }   
        public CourseType Course { get; set; }   
        public DateTime DateCreated { get; set; }
        public int StudentId { get; set; }
    }
}
