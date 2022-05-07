using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers;

public class GuestController : BaseApiController
{
    private readonly DataContext _context;

    public GuestController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Guest>>> GetGuest()
    {
        return await _context.Guests.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Guest>> GetLastNameGuest(Guid id)
    {
        return await _context.Guests.FindAsync(id);
    }
}