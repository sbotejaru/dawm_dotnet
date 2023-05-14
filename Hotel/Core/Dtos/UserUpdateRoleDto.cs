using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class UserUpdateRoleDto
    {
        public int Id { get; set; }

        [Required]
        public RoleType Role { get; set; }
    }
}
