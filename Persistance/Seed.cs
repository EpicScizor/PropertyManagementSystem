using Domain;

namespace Persistance;

public class Seed
{
    public static async Task SeedData(DataContext context)
    {
        if (context.Rooms.Any() || context.Guests.Any())
            return;

        var rooms = new List<Room>
        {
            new Room
            {
                RoomNumber = 100,
                RoomType = "Two Queen"
            },
            new Room
            {
                RoomNumber = 101,
                RoomType = "One King"
            },
            new Room
            {
                RoomNumber = 102,
                RoomType = "One King"
            },
            new Room
            {
                RoomNumber = 103,
                RoomType = "Two Queen"
            },
            new Room
            {
                RoomNumber = 104,
                RoomType = "Two Queen"
            }
        };
        var guests = new List<Guest>
        {
            new Guest
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "abc@gmail.com",
                PhoneNumber = "6135721442"
            },
            new Guest
            {
                FirstName = "Joe",
                LastName = "Mama",
                Email = null,
                PhoneNumber = "213721"
            },
            new Guest
            {
                FirstName = "Osama",
                LastName = "Bin Found",
                Email = "bigpoppa@isellfentanyl.com",
                PhoneNumber = null
            }
        };
        await context.Rooms.AddRangeAsync(rooms);
        await context.Guests.AddRangeAsync(guests);
        await context.SaveChangesAsync();
    }
}