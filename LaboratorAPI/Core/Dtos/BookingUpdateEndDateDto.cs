using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class BookingUpdateEndDateDto
    {
        public int ID { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        [Required]
        public double TotalPrice { get; set; }
    }
}
