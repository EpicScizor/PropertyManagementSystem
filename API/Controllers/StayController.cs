using Application.Stays;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class StayController : BaseApiController
{
    [HttpGet]

    public async Task<ActionResult<List<Stay>>> GetStay()
    {
        return await Mediator.Send(new StayList.Query());
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Stay>> GetStayId(Guid id)
    {
        return await Mediator.Send(new StayDetails.Query {Id = id});
    }

    [HttpPost]

    public async Task<IActionResult> AddStay(Stay newStay)
    {
        return Ok(await Mediator.Send(new CreateStay.Command {Stay = newStay}));
    }

    [HttpPut]

    public async Task<IActionResult> EditStay(Guid id, Stay stay)
    {
        stay.StayId = id;
        return Ok(await Mediator.Send(new EditStay.Command {Stay = stay}));
    }

    [HttpDelete]

    public async Task<IActionResult> DeleteStay(Guid id)
    {
        return Ok(await Mediator.Send(new DeleteStay.Command {Id = id}));
    }
}