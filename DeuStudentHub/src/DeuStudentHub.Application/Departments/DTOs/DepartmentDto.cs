namespace DeuStudentHub.Application.Departments.DTOs;

public class DepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int FacultyId { get; set; }
}