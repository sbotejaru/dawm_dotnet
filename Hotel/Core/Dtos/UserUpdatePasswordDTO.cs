using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class UserUpdatePasswordDTO
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

    }
}
