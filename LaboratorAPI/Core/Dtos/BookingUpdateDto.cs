using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    internal class BookingUpdateDto
    {
        public int ID { get; set; }

        [Required]
        public int RoomID { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        [Required]
        public float TotalPrice { get; set; }
    }
}
