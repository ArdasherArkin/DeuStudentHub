using DeuStudentHub.Application.Interfaces;
using DeuStudentHub.Domain.Entities;
using DeuStudentHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace DeuStudentHub.Infrastructure.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _context;

    public CourseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Course>> GetAllAsync()
    {
        return await _context.Courses
            .Include(c => c.Department)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<Course> AddAsync(Course course)
    {
        _context.Courses.Add(course);

        await _context.SaveChangesAsync();

        return course;
    }
    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _context.Courses
            .Include(c => c.Department)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<Course> UpdateAsync(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();

        return course;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course is null)
        {
            return false;
        }

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

        return true;
    }
    public async Task<List<Course>> GetByDepartmentIdAsync(int departmentId)
    {
        return await _context.Courses
            .Include(c => c.Department)
            .AsNoTracking()
            .Where(c => c.DepartmentId == departmentId)
            .OrderBy(c => c.Code)
            .ToListAsync();
    }
}