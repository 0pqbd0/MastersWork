using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementation;

public class ConsultantRepository : IConsultantRepository
{
    private readonly ApplicationDbContext _context;

    public ConsultantRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Consultant?> GetByIdAsync(int id)
    {
        return await _context.Consultants
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Consultant?>> GetAllAsync()
    {
        return await _context.Consultants.ToListAsync();
    }

    public async Task AddAsync(Consultant consultant)
    {
        await _context.Consultants.AddAsync(consultant);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Consultant consultant)
    {
        _context.Consultants.Update(consultant);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var consultant = await _context.Consultants.FindAsync(id);
        if (consultant != null)
        {
            _context.Consultants.Remove(consultant);
            await _context.SaveChangesAsync();
        }
    }
}