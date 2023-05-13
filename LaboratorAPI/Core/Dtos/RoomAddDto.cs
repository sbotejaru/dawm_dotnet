using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class RoomAddDto
    {
        [Required]
        public string RoomType { get; set; }

        [Required]
        public int RoomNr { get; set; }

        [Required]
        public DateTime IsAvailableFrom { get; set; }

        public bool Deleted { get; set; }

        [Required]
        public float Price { get; set; }
    }
}
