using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DataLayer.Entities;

public class Employee : BaseEntity
{
    public int UserID { get; set; }
    public string Name { get; set; }
    public bool Deleted { get; set; }
}

