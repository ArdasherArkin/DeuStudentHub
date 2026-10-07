using DeuStudentHub.Application.Teachers.DTOs;
using DeuStudentHub.Application.Teachers.GetTeacherById;
using DeuStudentHub.Application.Teachers.GetTeachers;
using Microsoft.AspNetCore.Mvc;
using DeuStudentHub.Application.Teachers.GetTeacherDetails;
namespace DeuStudentHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private readonly GetTeachersService _getTeachersService;
    private readonly GetTeacherByIdService _getTeacherByIdService;
    private readonly GetTeacherDetailsService _getTeacherDetailsService;

    public TeachersController(
        GetTeachersService getTeachersService,
        GetTeacherByIdService getTeacherByIdService,
        GetTeacherDetailsService getTeacherDetailsService)
    {
        _getTeachersService = getTeachersService;
        _getTeacherByIdService = getTeacherByIdService;
        _getTeacherDetailsService = getTeacherDetailsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TeacherDto>>> GetAll()
    {
        var teachers = await _getTeachersService.ExecuteAsync();

        return Ok(teachers);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TeacherDto>> GetById(int id)
    {
        var teacher = await _getTeacherByIdService.ExecuteAsync(id);

        if (teacher is null)
        {
            return NotFound();
        }

        return Ok(teacher);
    }
    [HttpGet("{id:int}/details")]
    public async Task<ActionResult<TeacherDetailsDto>> GetDetails(int id)
    {
        var teacher = await _getTeacherDetailsService.ExecuteAsync(id);

        if (teacher is null)
        {
            return NotFound();
        }

        return Ok(teacher);
    }
}