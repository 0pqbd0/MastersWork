using DataAccess.Entities;

namespace DataAccess.Repositories;

public interface IStudentRepository
{
    Task<Student?> GetByIdAsync(int id);
    Task<List<Student?>> GetAllAsync();
    Task AddAsync(Student student);
    Task UpdateAsync(Student student);
    Task DeleteAsync(int id);
}