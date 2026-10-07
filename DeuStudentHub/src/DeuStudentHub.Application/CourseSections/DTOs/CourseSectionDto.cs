using DeuStudentHub.Application.Teachers.DTOs;

namespace DeuStudentHub.Application.CourseSections.DTOs;

public class CourseSectionDto
{
    public int Id { get; set; }

    public string Semester { get; set; } = string.Empty;

    public string AcademicYear { get; set; } = string.Empty;

    public string SectionNumber { get; set; } = string.Empty;

    public int CourseId { get; set; }

    public List<TeacherDto> Teachers { get; set; } = new();
}