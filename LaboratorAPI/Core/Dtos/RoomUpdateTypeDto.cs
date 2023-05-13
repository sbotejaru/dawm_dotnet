using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class RoomUpdateTypeDto
    {
        public int ID { get; set; }

        [Required]
        public string RoomType { get; set; }
    }
}
