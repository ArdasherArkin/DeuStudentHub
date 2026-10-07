namespace DeuStudentHub.Application.Teachers.DTOs;

public class TeacherDetailsDto
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public List<TeacherSectionDto> Sections { get; set; } = new();
}