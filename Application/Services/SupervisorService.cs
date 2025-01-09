using DataAccess.Entities;
using DataAccess.Repositories;

namespace Application.Services;

public class SupervisorService
{
    private readonly ISupervisorRepository _supervisorRepository;

    public SupervisorService(ISupervisorRepository supervisorRepository)
    {
        _supervisorRepository = supervisorRepository;
    }

    public async Task<Supervisor?> GetSupervisorByIdAsync(int id)
    {
        return await _supervisorRepository.GetByIdAsync(id);
    }

    public async Task<List<Supervisor?>> GetAllSupervisorsAsync()
    {
        return await _supervisorRepository.GetAllAsync();
    }

    public async Task AddSupervisorAsync(Supervisor supervisor)
    {
        await _supervisorRepository.AddAsync(supervisor);
    }

    public async Task UpdateSupervisorAsync(Supervisor supervisor)
    {
        await _supervisorRepository.UpdateAsync(supervisor);
    }

    public async Task DeleteSupervisorAsync(int id)
    {
        await _supervisorRepository.DeleteAsync(id);
    }
}