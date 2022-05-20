namespace PropertyManagementSystem.Domain;

public class Stay
{
    public Guid StayId { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public int RoomId { get; set; }
    public Room? Room { get; set; }
    public int GuestId { get; set; }
    public Guest Guest { get; set; }
}