using DeuStudentHub.Application.Courses.DTOs;
using DeuStudentHub.Application.Interfaces;
using DeuStudentHub.Domain.Entities;

namespace DeuStudentHub.Application.Courses.CreateCourse;

public class CreateCourseService
{
    private readonly ICourseRepository _courseRepository;

    public CreateCourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseDto> ExecuteAsync(CreateCourseDto dto)
    {
        var course = new Course
        {
            Code = dto.Code,
            Name = dto.Name,
            Description = dto.Description,
            DepartmentId = dto.DepartmentId
        };

        var createdCourse = await _courseRepository.AddAsync(course);

        var courseWithDepartment =
            await _courseRepository.GetByIdAsync(createdCourse.Id);

        if (courseWithDepartment is null)
        {
            throw new InvalidOperationException(
                "Course was created but could not be retrieved.");
        }

        return new CourseDto
        {
            Id = courseWithDepartment.Id,
            Code = courseWithDepartment.Code,
            Name = courseWithDepartment.Name,
            Description = courseWithDepartment.Description,
            DepartmentId = courseWithDepartment.DepartmentId,
            DepartmentName = courseWithDepartment.Department.Name
        };
    }
}