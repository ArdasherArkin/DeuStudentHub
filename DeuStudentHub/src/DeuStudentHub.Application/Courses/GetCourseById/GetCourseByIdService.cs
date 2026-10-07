using DeuStudentHub.Application.Courses.DTOs;
using DeuStudentHub.Application.Interfaces;

namespace DeuStudentHub.Application.Courses.GetCourseById;

public class GetCourseByIdService
{
    private readonly ICourseRepository _courseRepository;

    public GetCourseByIdService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseDto?> ExecuteAsync(int id)
    {
        var course = await _courseRepository.GetByIdAsync(id);

        if (course is null)
        {
            return null;
        }

        return new CourseDto
        {
            Id = course.Id,
            Code = course.Code,
            Name = course.Name,
            Description = course.Description,
            DepartmentId = course.DepartmentId,
            DepartmentName = course.Department.Name
        };
    }
}