using DeuStudentHub.Application.Interfaces;
using DeuStudentHub.Domain.Entities;
using DeuStudentHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DeuStudentHub.Infrastructure.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly ApplicationDbContext _context;

    public TeacherRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Teacher>> GetAllAsync()
    {
        return await _context.Teachers
            .AsNoTracking()
            .OrderBy(t => t.LastName)
            .ThenBy(t => t.FirstName)
            .ToListAsync();
    }

    public async Task<Teacher?> GetByIdAsync(int id)
    {
        return await _context.Teachers
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
    }
    public async Task<Teacher?> GetDetailsByIdAsync(int id)
    {
        return await _context.Teachers
            .Include(t => t.CourseSectionTeachers)
                .ThenInclude(cst => cst.CourseSection)
                    .ThenInclude(cs => cs.Course)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}