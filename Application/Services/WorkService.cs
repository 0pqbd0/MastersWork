using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.Repositories.Implementation;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services;

public class WorkService
{
    private readonly IWorkRepository _workRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly ISupervisorRepository _supervisorRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IConsultantRepository _consultantRepository;
    private readonly IS3Repository _s3Repository;

    public WorkService(
        IWorkRepository workRepository,
        IStudentRepository studentRepository,
        ISupervisorRepository supervisorRepository,
        ICategoryRepository categoryRepository,
        IConsultantRepository consultantRepository,
        IS3Repository s3Repository)
    {
        _workRepository = workRepository;
        _studentRepository = studentRepository;
        _supervisorRepository = supervisorRepository;
        _categoryRepository = categoryRepository;
        _consultantRepository = consultantRepository;
        _s3Repository = s3Repository;
    }

    public async Task<List<Work?>> GetAllWorksAsync()
    {
        return await _workRepository.GetAllWorksAsync();
    }

    public async Task<Work?> GetWorkByIdAsync(int id)
    {
        return await _workRepository.GetWorkByIdAsync(id);
    }

    public async Task AddWorkAsync(Work work)
    {
        work.Status = WorkStatus.NeedsUploudWorkFile;
        await _workRepository.AddWorkAsync(work);
    }

    public async Task AddReviewAsync(int workId, IFormFile file)
    {
        var work = await _workRepository.GetWorkByIdAsync(workId);
        if (work == null) throw new Exception("Work not found");

        var uniqueFileName = $"{work.Student.Name}_{work.Student.SecondName}_Review_{Guid.NewGuid()}.pdf";

        using (var fileStream = file.OpenReadStream())
        {
            var fileUrl = await _s3Repository.UploadFileAsync(fileStream, uniqueFileName);
            work.ReviewFileLink = fileUrl;
        }

        await _workRepository.UpdateWorkAsync(work);
    }

    public async Task AddWorkAsync(int workId, IFormFile file)
    {
        var work = await _workRepository.GetWorkByIdAsync(workId);
        if (work == null) throw new Exception("Work not found");
        
        var uniqueFileName = $"{work.Student.Name}_{work.Student.SecondName}_Work_{Guid.NewGuid()}.pdf";

        using (var fileStream = file.OpenReadStream())
        {
            var fileUrl = await _s3Repository.UploadFileAsync(fileStream, uniqueFileName);
            work.WorkFileLink = fileUrl;
        }
        work.Status = WorkStatus.NeedsReview;
        await _workRepository.UpdateWorkAsync(work);
    }

    public async Task UpdateWorkAsync(Work work)
    {
        await _workRepository.UpdateWorkAsync(work);
    }

    public async Task DeleteWorkAsync(int id)
    {
        await _workRepository.DeleteWorkAsync(id);
    }
    
    public async Task UpdateWorkStatusAsync(int workId, WorkStatus status, string? comment = null)
    {
        var work = await _workRepository.GetWorkByIdAsync(workId);
        if (work == null) throw new Exception("Work not found");

        work.Status = status;

        await _workRepository.UpdateWorkAsync(work);
    }
    
    public async Task<IEnumerable<Work>> GetWorksByStudentIdAsync(int studentId)
    {
        return await _workRepository.GetWorksByStudentIdAsync(studentId);
    }
}