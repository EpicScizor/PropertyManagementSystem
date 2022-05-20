using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;
using PropertyManagementSystem.Application.Guests;
using PropertyManagementSystem.Domain;

namespace PropertyManagementSystem.Controllers;

public class GuestController : BaseApiController
{

    [HttpGet]
    public async Task<ActionResult<List<Guest>>> GetGuest()
    {
        return await Mediator.Send(new GuestList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Guest>> GetGuestId(int id)
    {
        return await Mediator.Send(new Details.Query { Id = id });
    }

    [HttpPost]
    public async Task<IActionResult> AddGuest(Guest newGuest)
    {
        return Ok(await Mediator.Send(new CreateGuest.Command { Guest = newGuest }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditGuest(int id, Guest guest)
    {
        guest.GuestId = id;
        return Ok(await Mediator.Send(new EditGuest.Command { Guest = guest }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGuest(int id)
    {
        return Ok(await Mediator.Send(new DeleteGuest.Command { Id = id }));
    }
}