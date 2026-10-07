using DeuStudentHub.Application.Courses.DTOs;
using DeuStudentHub.Application.Interfaces;

namespace DeuStudentHub.Application.Courses.GetCourses;

public class GetCoursesService
{
    private readonly ICourseRepository _courseRepository;

    public GetCoursesService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<List<CourseDto>> ExecuteAsync()
    {
        var courses = await _courseRepository.GetAllAsync();

        return courses.Select(course => new CourseDto
        {
            Id = course.Id,
            Code = course.Code,
            Name = course.Name,
            Description = course.Description,
            DepartmentId = course.DepartmentId,
            DepartmentName = course.Department.Name
        }).ToList();
    }
}