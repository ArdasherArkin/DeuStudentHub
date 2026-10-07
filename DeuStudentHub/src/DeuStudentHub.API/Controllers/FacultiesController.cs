using DeuStudentHub.Application.Faculties.DTOs;
using DeuStudentHub.Application.Faculties.GetFaculties;
using Microsoft.AspNetCore.Mvc;
using DeuStudentHub.Application.Departments.DTOs;
using DeuStudentHub.Application.Departments.GetDepartmentsByFaculty;
namespace DeuStudentHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacultiesController : ControllerBase
{
    private readonly GetFacultiesService _getFacultiesService;
    private readonly GetDepartmentsByFacultyService _getDepartmentsByFacultyService;
    public FacultiesController(
    GetFacultiesService getFacultiesService,
    GetDepartmentsByFacultyService getDepartmentsByFacultyService)
    {
        _getFacultiesService = getFacultiesService;
        _getDepartmentsByFacultyService = getDepartmentsByFacultyService;
    }

    [HttpGet]
    public async Task<ActionResult<List<FacultyDto>>> GetAll()
    {
        var faculties = await _getFacultiesService.ExecuteAsync();  

        return Ok(faculties);
    }
    [HttpGet("{facultyId:int}/departments")]
    public async Task<ActionResult<List<DepartmentDto>>> GetDepartments(
        int facultyId)
    {
        var departments =
            await _getDepartmentsByFacultyService.ExecuteAsync(facultyId);

        return Ok(departments);
    }
}