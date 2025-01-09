using Amazon.S3.Model;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementation;

public class SupervisorRepository : ISupervisorRepository
{
    private readonly ApplicationDbContext _context;

    public SupervisorRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Supervisor?> GetByIdAsync(int id)
    {
        return await _context.Supervisors
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Supervisor?> GetByDetailsAsync(string firstName, string lastName, string? middleName, string department)
    {
        return await _context.Supervisors
        .FirstOrDefaultAsync(s =>
            s.FirstName == firstName &&
            s.LastName == lastName &&
            (middleName == null || s.MiddleName == middleName) &&
            s.Department.Name == department);

    }

    public async Task<List<Supervisor?>> GetAllAsync()
    {
        return await _context.Supervisors.ToListAsync();
    }

    public async Task AddAsync(Supervisor supervisor)
    {
        await _context.Supervisors.AddAsync(supervisor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Supervisor supervisor)
    {
        _context.Supervisors.Update(supervisor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var supervisor = await _context.Supervisors.FindAsync(id);
        if (supervisor != null)
        {
            _context.Supervisors.Remove(supervisor);
            await _context.SaveChangesAsync();
        }
    }
}