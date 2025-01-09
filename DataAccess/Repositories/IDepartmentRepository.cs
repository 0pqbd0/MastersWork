using DataAccess.Entities;

namespace DataAccess.Repositories;

public interface IDepartmentRepository
{
    Task<Department?> GetByIdAsync(int id);
    Task<List<Department?>> GetAllAsync();
    Task AddAsync(Department department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(int id);
}