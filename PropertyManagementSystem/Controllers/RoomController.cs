using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManagementSystem.Application.Rooms;
using PropertyManagementSystem.Domain;
using PropertyManagementSystem.Persistance;

namespace PropertyManagementSystem.Controllers;

public class RoomController : BaseApiController
{
    private readonly DataContext _context;

    public RoomController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Room>>> GetRooms()
    {
        return await Mediator.Send(new RoomList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetSpecificRoom(int id)
    {
        return await Mediator.Send(new RoomDetails.Query {Id = id});
    }

    [HttpGet("{occupied}")]
    public async Task<ActionResult<List<Room>>> ShowRoomStatus(bool occupied)

    {
        throw new NotImplementedException();
    }

    [HttpPut("{occupied}")]
    public async Task<ActionResult<Room>> UpdateRoomStatus(bool occupied)
    {
        throw new NotImplementedException();
    }
}