using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class BookingAddDto
    {
        public int ID { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        public int RoomID { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        public bool Deleted { get; set; }

        [Required]
        public float TotalPrice { get; set; }
    }
}
