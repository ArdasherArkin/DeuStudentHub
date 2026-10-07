using DeuStudentHub.Application.Interfaces;
using DeuStudentHub.Domain.Entities;
using DeuStudentHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DeuStudentHub.Infrastructure.Repositories;

public class FacultyRepository : IFacultyRepository
{
    private readonly ApplicationDbContext _context;

    public FacultyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Faculty>> GetAllAsync()
    {
        return await _context.Faculties
            .AsNoTracking()
            .OrderBy(f => f.Name)
            .ToListAsync();
    }
}