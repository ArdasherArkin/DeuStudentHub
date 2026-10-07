using DeuStudentHub.Domain.Entities;

namespace DeuStudentHub.Application.Interfaces;

public interface ICourseRepository
{
    Task<List<Course>> GetAllAsync();
    Task<Course?> GetByIdAsync(int id);
    Task<List<Course>> GetByDepartmentIdAsync(int departmentId);
    Task<Course> AddAsync(Course course);
    Task<Course> UpdateAsync(Course course);
    Task<bool> DeleteAsync(int id);
    
}