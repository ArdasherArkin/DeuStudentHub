using DeuStudentHub.Application.Courses.DTOs;
using DeuStudentHub.Application.Courses.GetCoursesByDepartment;
using Microsoft.AspNetCore.Mvc;

namespace DeuStudentHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly GetCoursesByDepartmentService _getCoursesByDepartmentService;

    public DepartmentsController(
        GetCoursesByDepartmentService getCoursesByDepartmentService)
    {
        _getCoursesByDepartmentService = getCoursesByDepartmentService;
    }

    [HttpGet("{departmentId:int}/courses")]
    public async Task<ActionResult<List<CourseDto>>> GetCourses(
        int departmentId)
    {
        var courses =
            await _getCoursesByDepartmentService.ExecuteAsync(departmentId);

        return Ok(courses);
    }
}