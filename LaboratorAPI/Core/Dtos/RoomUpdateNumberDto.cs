﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class RoomUpdateNumberDto
    {
        [Required]
        public int RoomNr { get; set; }
    }
}
