using DeuStudentHub.Application.Departments.DTOs;
using DeuStudentHub.Application.Interfaces;

namespace DeuStudentHub.Application.Departments.GetDepartmentsByFaculty;

public class GetDepartmentsByFacultyService
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetDepartmentsByFacultyService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<List<DepartmentDto>> ExecuteAsync(int facultyId)
    {
        var departments =
            await _departmentRepository.GetByFacultyIdAsync(facultyId);

        return departments.Select(department => new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            FacultyId = department.FacultyId
        }).ToList();
    }
}