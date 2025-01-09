using Application.Services;
using DataAccess.Entities;
using MastersWorks.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MastersWorks.Controllers;

[ApiController]
[Route("api/review")]
public class ReviewController : ControllerBase
{
    private readonly WorkService _workService;
    private readonly ILogger<ReviewController> _logger;


    public ReviewController(WorkService workService, ILogger<ReviewController> logger)
    {
        _workService = workService;
        _logger = logger;
    }

    [HttpGet("works")]
    public async Task<IActionResult> GetWorks([FromQuery] WorkStatus? status)
    {
        var works = await _workService.GetAllWorksAsync();

        if (status.HasValue)
        {
            works = works.Where(w => w.Status == status).ToList();
        }

        return Ok(works);
    }
 
    [HttpPut("works/{workId}")]
    public async Task<IActionResult> UpdateWorkStatus(int workId, [FromBody] UpdateWorkStatusRequest request)
    {
        await _workService.UpdateWorkStatusAsync(workId, request.Status, request.Comment);
        return Ok(new { Message = "Work status updated successfully" });
    }
}