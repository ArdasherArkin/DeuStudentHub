using DeuStudentHub.Application.Courses.DTOs;
using DeuStudentHub.Application.Interfaces;

namespace DeuStudentHub.Application.Courses.UpdateCourse;

public class UpdateCourseService
{
    private readonly ICourseRepository _courseRepository;

    public UpdateCourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseDto?> ExecuteAsync(int id, UpdateCourseDto dto)
    {
        var course = await _courseRepository.GetByIdAsync(id);

        if (course is null)
        {
            return null;
        }

        course.Code = dto.Code;
        course.Name = dto.Name;
        course.Description = dto.Description;
        course.DepartmentId = dto.DepartmentId;

        await _courseRepository.UpdateAsync(course);

        var updatedCourse = await _courseRepository.GetByIdAsync(id);

        if (updatedCourse is null)
        {
            return null;
        }

        return new CourseDto
        {
            Id = updatedCourse.Id,
            Code = updatedCourse.Code,
            Name = updatedCourse.Name,
            Description = updatedCourse.Description,
            DepartmentId = updatedCourse.DepartmentId,
            DepartmentName = updatedCourse.Department.Name
        };
    }
}