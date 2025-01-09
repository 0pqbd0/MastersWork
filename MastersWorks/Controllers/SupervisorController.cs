using Application.Services;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
    [ApiController]
    public class SupervisorController : ControllerBase
    {
        private readonly SupervisorService _supervisorService;

        public SupervisorController(SupervisorService supervisorService)
        {
            _supervisorService = supervisorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supervisor>>> GetSupervisors()
        {
            var supervisors = await _supervisorService.GetAllSupervisorsAsync();
            return Ok(supervisors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supervisor>> GetSupervisor(int id)
        {
            var supervisor = await _supervisorService.GetSupervisorByIdAsync(id);
            if (supervisor == null)
            {
                return NotFound();
            }
            return Ok(supervisor);
        }

        [HttpPost]
        public async Task<ActionResult<Supervisor>> CreateSupervisor(Supervisor supervisor)
        {
            await _supervisorService.AddSupervisorAsync(supervisor);
            return CreatedAtAction(nameof(GetSupervisor), new { id = supervisor.Id }, supervisor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupervisor(int id, Supervisor supervisor)
        {
            if (id != supervisor.Id)
            {
                return BadRequest();
            }

            await _supervisorService.UpdateSupervisorAsync(supervisor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupervisor(int id)
        {
            var supervisor = await _supervisorService.GetSupervisorByIdAsync(id);
            if (supervisor == null)
            {
                return NotFound();
            }

            await _supervisorService.DeleteSupervisorAsync(id);
            return NoContent();
        }
    }