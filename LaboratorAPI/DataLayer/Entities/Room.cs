using DataLayer.Enums;

namespace DataLayer.Entities;

public class Room : BaseEntity
{
    public int RoomNr { get; set; }
    public string RoomType { get; set; }
    public DateTime IsAvailableFrom { get; set; }
    public bool Deleted { get; set; }
    public float Price { get; set; }
}
