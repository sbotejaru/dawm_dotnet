using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DataLayer.Entities;

public class Role : BaseEntity
{
    public string RoleName { get; set; }
}

