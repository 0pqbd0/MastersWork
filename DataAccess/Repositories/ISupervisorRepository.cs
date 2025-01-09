using DataAccess.Entities;

namespace DataAccess.Repositories;

public interface  ISupervisorRepository
{
    Task<Supervisor?> GetByIdAsync(int id);
    Task<List<Supervisor?>> GetAllAsync();
    Task AddAsync(Supervisor supervisor);
    Task UpdateAsync(Supervisor supervisor);
    Task DeleteAsync(int id);
}