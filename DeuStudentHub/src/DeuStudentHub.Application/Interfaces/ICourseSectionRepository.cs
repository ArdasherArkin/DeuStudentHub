using DeuStudentHub.Domain.Entities;

namespace DeuStudentHub.Application.Interfaces;

public interface ICourseSectionRepository
{
    Task<List<CourseSection>> GetByCourseIdAsync(int courseId);
}