using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DataLayer.Entities;

public class Admin : BaseEntity
{
    public int UserID { get; set; }
    public string Name { get; set; }
}

