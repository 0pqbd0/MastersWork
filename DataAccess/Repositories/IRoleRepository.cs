using DataAccess.Entities;

namespace DataAccess.Repositories;

public interface IRoleRepository
{
    Task<Role> GetByNameAsync(string name);
    Task<Role> GetByIdAsync(int id);
    Task<IEnumerable<Role>> GetAllAsync();
}