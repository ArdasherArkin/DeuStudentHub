using DeuStudentHub.Application.Courses.DTOs;
using DeuStudentHub.Application.Courses.GetCourses;
using Microsoft.AspNetCore.Mvc;
using DeuStudentHub.Application.Courses.CreateCourse;
using DeuStudentHub.Application.Courses.GetCourseById;
using DeuStudentHub.Application.Courses.UpdateCourse;
using DeuStudentHub.Application.Courses.DeleteCourse;
using DeuStudentHub.Application.CourseSections.DTOs;
using DeuStudentHub.Application.CourseSections.GetCourseSections;
namespace DeuStudentHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly GetCoursesService _getCoursesService;
    private readonly CreateCourseService _createCourseService;
    private readonly GetCourseByIdService _getCourseByIdService;
    private readonly UpdateCourseService _updateCourseService;
    private readonly DeleteCourseService _deleteCourseService;
    private readonly GetCourseSectionsService _getCourseSectionsService;
    public CoursesController(
        GetCoursesService getCoursesService,
        CreateCourseService createCourseService,
        GetCourseByIdService getCourseByIdService,
        UpdateCourseService updateCourseService,
        DeleteCourseService deleteCourseService,
        GetCourseSectionsService getCourseSectionsService)
    {
        _getCoursesService = getCoursesService;
        _createCourseService = createCourseService;
        _getCourseByIdService = getCourseByIdService;
        _updateCourseService = updateCourseService;
        _deleteCourseService = deleteCourseService;
        _getCourseSectionsService = getCourseSectionsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CourseDto>>> GetAll()
    {
        var courses = await _getCoursesService.ExecuteAsync();

        return Ok(courses);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CourseDto>> GetById(int id)
    {
        var course = await _getCourseByIdService.ExecuteAsync(id);

        if (course is null)
        {
            return NotFound();
        }

        return Ok(course);
    }

    [HttpPost]
    public async Task<ActionResult<CourseDto>> Create(CreateCourseDto dto)
    {
        var course = await _createCourseService.ExecuteAsync(dto);

        return Ok(course);
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<CourseDto>> Update(
        int id,
        UpdateCourseDto dto)
    {
        var course = await _updateCourseService.ExecuteAsync(id, dto);

        if (course is null)
        {
            return NotFound();
        }

        return Ok(course);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _deleteCourseService.ExecuteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
    [HttpGet("{courseId:int}/sections")]
    public async Task<ActionResult<List<CourseSectionDto>>> GetSections(
        int courseId)
    {
        var sections =
            await _getCourseSectionsService.ExecuteAsync(courseId);

        return Ok(sections);
    }
}