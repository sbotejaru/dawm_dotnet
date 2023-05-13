using DataLayer.Dtos;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public static class GradesMappingExtensions
    {
        public static List<GradeDto> ToGradeDtos(this List<Grade> grades)
        {
            if (grades == null)
            {
                return null;
            }

            var results = grades.Select(e => e.ToGradeDto()).ToList();  

            return results;
        }

        public static GradeDto ToGradeDto(this Grade grade)
        {
            if (grade == null) return null;

            var result = new GradeDto();
            result.Value = grade.Value;
            result.Course = grade.Course;
            result.DateCreated = grade.DateCreated;

            return result;
        }
    }
}
