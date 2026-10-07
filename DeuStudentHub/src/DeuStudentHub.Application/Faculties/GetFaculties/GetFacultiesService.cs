using DeuStudentHub.Application.Faculties.DTOs;
using DeuStudentHub.Application.Interfaces;

namespace DeuStudentHub.Application.Faculties.GetFaculties;

public class GetFacultiesService
{
    private readonly IFacultyRepository _facultyRepository;

    public GetFacultiesService(IFacultyRepository facultyRepository)
    {
        _facultyRepository = facultyRepository;
    }

    public async Task<List<FacultyDto>> ExecuteAsync()
    {
        var faculties = await _facultyRepository.GetAllAsync();

        return faculties.Select(faculty => new FacultyDto
        {
            Id = faculty.Id,
            Name = faculty.Name
        }).ToList();
    }
}