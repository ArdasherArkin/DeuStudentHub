namespace DeuStudentHub.Application.Teachers.DTOs;

public class TeacherSectionDto
{
    public int SectionId { get; set; }

    public string Semester { get; set; } = string.Empty;

    public string AcademicYear { get; set; } = string.Empty;

    public string SectionNumber { get; set; } = string.Empty;

    public int CourseId { get; set; }

    public string CourseCode { get; set; } = string.Empty;

    public string CourseName { get; set; } = string.Empty;
}