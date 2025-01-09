using DataAccess.Entities;

namespace DataAccess.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<User> GetByUsernameAsync(string username);
    Task<List<User?>> GetAllAsync();
    Task AddAsync(User? user);
    Task UpdateAsync(User? user);
    Task DeleteAsync(int id);
}
