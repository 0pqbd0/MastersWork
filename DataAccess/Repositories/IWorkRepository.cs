using DataAccess.Entities;

namespace DataAccess.Repositories;

public interface IWorkRepository
{
    Task<Work?> GetWorkByIdAsync(int workId);
    Task<List<Work?>> GetAllWorksAsync();
    Task AddWorkAsync(Work work);
    Task UpdateWorkAsync(Work work);
    Task DeleteWorkAsync(int workId);
    Task<IEnumerable<Work>> GetWorksByStudentIdAsync(int studentId);
}