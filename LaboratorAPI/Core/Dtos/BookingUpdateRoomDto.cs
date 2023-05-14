using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class BookingUpdateRoomDto
    {
        public int ID { get; set; }

        [Required]
        public int RoomID { get; set; }

        [Required]
        public double TotalPrice { get; set; }
    }
}
