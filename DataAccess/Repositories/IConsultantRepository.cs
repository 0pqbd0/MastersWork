using DataAccess.Entities;

namespace DataAccess.Repositories;

public interface  IConsultantRepository
{
    Task<Consultant?> GetByIdAsync(int id);
    Task<List<Consultant?>> GetAllAsync();
    Task AddAsync(Consultant consultant);
    Task UpdateAsync(Consultant consultant);
    Task DeleteAsync(int id);
}