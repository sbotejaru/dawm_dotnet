using DataLayer.Enums;

namespace DataLayer.Entities;

public class Booking : BaseEntity
{
    public int CustomerID{ get; set; }
    public int RoomID{ get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public bool Deleted { get; set; }
    public double TotalPrice { get; set; }
}
