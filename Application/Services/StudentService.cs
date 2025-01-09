using DataAccess.Entities;
using DataAccess.Repositories;

namespace Application.Services;

public class StudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await _studentRepository.GetByIdAsync(id);
    }

    public async Task<List<Student?>> GetAllStudentsAsync()
    {
        return await _studentRepository.GetAllAsync();
    }

    public async Task AddStudentAsync(Student student)
    {
        await _studentRepository.AddAsync(student);
    }

    public async Task UpdateStudentAsync(Student student)
    {
        await _studentRepository.UpdateAsync(student);
    }

    public async Task DeleteStudentAsync(int id)
    {
        await _studentRepository.DeleteAsync(id);
    }
}