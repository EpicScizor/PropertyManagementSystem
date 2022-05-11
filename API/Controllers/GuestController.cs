using Application.Guests;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers;

public class GuestController : BaseApiController
{

    [HttpGet]
    public async Task<ActionResult<List<Guest>>> GetGuest()
    {
        return await Mediator.Send(new List.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Guest>> GetGuestId(Guid id)
    {
        return await Mediator.Send(new Details.Query {Id = id});
    }

    [HttpPost]
    public async Task<IActionResult> AddGuest(Guest newGuest)
    {
        return Ok(await Mediator.Send(new CreateGuest.Command {Guest = newGuest}));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditGuest(Guid id, Guest guest)
    {
        guest.Id = id;
        return Ok(await Mediator.Send(new EditGuest.Command{Guest = guest}));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGuest(Guid id)
    {
        return Ok(await Mediator.Send(new DeleteGuest.Command {Id = id}));
    }
}