﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class RoomUpdatePriceDto
    {
        public int ID { get; set; }

        [Required]
        public float Price { get; set; }

    }
}
