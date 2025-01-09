using DataAccess.Entities;
using DataAccess.Repositories;

namespace Application.Services;

public class ConsultantService
{
    private readonly IConsultantRepository _consultantRepository;

    public ConsultantService(IConsultantRepository consultantRepository)
    {
        _consultantRepository = consultantRepository;
    }

    public async Task<Consultant?> GetConsultantByIdAsync(int id)
    {
        return await _consultantRepository.GetByIdAsync(id);
    }

    public async Task<List<Consultant?>> GetAllConsultantsAsync()
    {
        return await _consultantRepository.GetAllAsync();
    }

    public async Task AddConsultantAsync(Consultant consultant)
    {
        await _consultantRepository.AddAsync(consultant);
    }

    public async Task UpdateConsultantAsync(Consultant consultant)
    {
        await _consultantRepository.UpdateAsync(consultant);
    }

    public async Task DeleteConsultantAsync(int id)
    {
        await _consultantRepository.DeleteAsync(id);
    }
}