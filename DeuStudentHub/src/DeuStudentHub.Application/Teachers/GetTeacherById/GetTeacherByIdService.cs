using DeuStudentHub.Application.Interfaces;
using DeuStudentHub.Application.Teachers.DTOs;

namespace DeuStudentHub.Application.Teachers.GetTeacherById;

public class GetTeacherByIdService
{
    private readonly ITeacherRepository _teacherRepository;

    public GetTeacherByIdService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<TeacherDto?> ExecuteAsync(int id)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id);

        if (teacher is null)
        {
            return null;
        }

        return new TeacherDto
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Email = teacher.Email
        };
    }
}   