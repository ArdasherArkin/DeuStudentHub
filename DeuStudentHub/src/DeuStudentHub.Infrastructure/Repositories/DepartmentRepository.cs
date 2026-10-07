using DeuStudentHub.Application.Interfaces;
using DeuStudentHub.Domain.Entities;
using DeuStudentHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DeuStudentHub.Infrastructure.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> GetByFacultyIdAsync(int facultyId)
    {
        return await _context.Departments
            .AsNoTracking()
            .Where(d => d.FacultyId == facultyId)
            .OrderBy(d => d.Name)
            .ToListAsync();
    }
}