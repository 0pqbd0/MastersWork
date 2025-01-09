using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementation;

public class WorkRepository : IWorkRepository
{
    private readonly ApplicationDbContext _context;

    public WorkRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<Work?> GetWorkByIdAsync(int workId)
    {
        return await _context.Works
            .FirstOrDefaultAsync(w => w.Id == workId);
    }

    public async Task<List<Work?>> GetAllWorksAsync()
    {
        return await _context.Works
            .ToListAsync();
    }

    public async Task AddWorkAsync(Work work)
    {
        await _context.Works.AddAsync(work);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateWorkAsync(Work work)
    {
        _context.Works.Update(work);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteWorkAsync(int workId)
    {
        var work = await _context.Works.FindAsync(workId);
        if (work != null)
        {
            _context.Works.Remove(work);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<IEnumerable<Work>> GetWorksByStudentIdAsync(int studentId)
    {
        return await _context.Works.Where(w => w.StudentId == studentId).ToListAsync();
    }
}