using DataLayer.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DataLayer.Entities;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public RoleType RoleID { get; set; }
    public bool Deleted { get; set; }
}

