namespace PropertyManagementSystem.Domain;

public class Guest
{
    public int GuestId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public List<Stay> Stays { get; set; }
}
