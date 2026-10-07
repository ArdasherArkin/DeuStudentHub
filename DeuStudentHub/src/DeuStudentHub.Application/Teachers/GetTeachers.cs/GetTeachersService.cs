using DeuStudentHub.Application.Interfaces;
using DeuStudentHub.Application.Teachers.DTOs;

namespace DeuStudentHub.Application.Teachers.GetTeachers;

public class GetTeachersService
{
    private readonly ITeacherRepository _teacherRepository;

    public GetTeachersService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<List<TeacherDto>> ExecuteAsync()
    {
        var teachers = await _teacherRepository.GetAllAsync();

        return teachers.Select(teacher => new TeacherDto
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Email = teacher.Email
        }).ToList();
    }
}