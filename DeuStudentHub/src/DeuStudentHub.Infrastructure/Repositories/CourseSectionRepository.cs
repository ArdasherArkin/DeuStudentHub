using DeuStudentHub.Application.Interfaces;
using DeuStudentHub.Domain.Entities;
using DeuStudentHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DeuStudentHub.Infrastructure.Repositories;

public class CourseSectionRepository : ICourseSectionRepository
{
    private readonly ApplicationDbContext _context;

    public CourseSectionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CourseSection>> GetByCourseIdAsync(int courseId)
    {
        return await _context.CourseSections
            .Include(cs => cs.CourseSectionTeachers)
                .ThenInclude(cst => cst.Teacher)
            .AsNoTracking()
            .Where(cs => cs.CourseId == courseId)
            .OrderBy(cs => cs.SectionNumber)
            .ToListAsync();
    }
}