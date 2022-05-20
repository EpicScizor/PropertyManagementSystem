namespace PropertyManagementSystem.Domain;

public class Room
{
    public int RoomId { get; set; }
    public int RoomNumber { get; set; }
    public string RoomType { get; set; }
    public List<Stay> Stays { get; set; }
}
