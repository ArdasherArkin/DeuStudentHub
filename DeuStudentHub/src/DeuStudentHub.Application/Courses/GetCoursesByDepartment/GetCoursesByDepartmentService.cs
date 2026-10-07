using DeuStudentHub.Application.Courses.DTOs;
using DeuStudentHub.Application.Interfaces;

namespace DeuStudentHub.Application.Courses.GetCoursesByDepartment;

public class GetCoursesByDepartmentService
{
    private readonly ICourseRepository _courseRepository;

    public GetCoursesByDepartmentService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<List<CourseDto>> ExecuteAsync(int departmentId)
    {
        var courses =
            await _courseRepository.GetByDepartmentIdAsync(departmentId);

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