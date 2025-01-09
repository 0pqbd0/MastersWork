using Application.Services;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MastersWorks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkController : ControllerBase
{
    private readonly WorkService _workService;

    public WorkController(WorkService workService)
    {
        _workService = workService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Work>>> GetWorks()
    {
        var works = await _workService.GetAllWorksAsync();
        return Ok(works);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Work>> GetWork(int id)
    {
        var work = await _workService.GetWorkByIdAsync(id);
        if (work == null)
        {
            return NotFound();
        }

        return Ok(work);
    }

    [HttpPost]
    public async Task<ActionResult<Work>> CreateWork([FromBody]Work work)
    {
        await _workService.AddWorkAsync(work);

        return CreatedAtAction(nameof(GetWork), new { id = work.Id }, work);
    }

    [HttpPost("upload-file/{workId}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadWorkFile(int workId, IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        await _workService.AddWorkAsync(workId, file);

        return Ok("Add");
    }


    [HttpPost("{id}/review")]
    public async Task<IActionResult> AddReviewFile([FromRoute] int workId, [FromForm] IFormFile reviewFile)
    {
        if (reviewFile == null || reviewFile.Length == 0)
        {
            return BadRequest("Файл обязателен");
        }

        try
        {
            await _workService.AddReviewAsync(workId, reviewFile);
            return Ok("Add");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ошибка при добавлении файла отзыва: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWork(int id, Work work)
    {
        if (id != work.Id)
        {
            return BadRequest();
        }

        await _workService.UpdateWorkAsync(work);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWork(int id)
    {
        var work = await _workService.GetWorkByIdAsync(id);
        if (work == null)
        {
            return NotFound();
        }

        await _workService.DeleteWorkAsync(id);
        return NoContent();
    }
    
    [HttpGet("student/{studentId}")]
    public async Task<ActionResult<IEnumerable<Work>>> GetStudentWorks(int studentId)
    {
        var works = await _workService.GetWorksByStudentIdAsync(studentId);
        return Ok(works);
    }
}