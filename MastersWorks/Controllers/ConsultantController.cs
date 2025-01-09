using Application.Services;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsultantController : ControllerBase
{
    private readonly ConsultantService _consultantService;

    public ConsultantController(ConsultantService consultantService)
    {
        _consultantService = consultantService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Consultant>>> GetConsultants()
    {
        var consultants = await _consultantService.GetAllConsultantsAsync();
        return Ok(consultants);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Consultant>> GetConsultant(int id)
    {
        var consultant = await _consultantService.GetConsultantByIdAsync(id);
        if (consultant == null)
        {
            return NotFound();
        }

        return Ok(consultant);
    }

    [HttpPost]
    public async Task<ActionResult<Consultant>> CreateConsultant(Consultant consultant)
    {
        await _consultantService.AddConsultantAsync(consultant);
        return CreatedAtAction(nameof(GetConsultant), new { id = consultant.Id }, consultant);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateConsultant(int id, Consultant consultant)
    {
        if (id != consultant.Id)
        {
            return BadRequest();
        }

        await _consultantService.UpdateConsultantAsync(consultant);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConsultant(int id)
    {
        var consultant = await _consultantService.GetConsultantByIdAsync(id);
        if (consultant == null)
        {
            return NotFound();
        }

        await _consultantService.DeleteConsultantAsync(id);
        return NoContent();
    }
}