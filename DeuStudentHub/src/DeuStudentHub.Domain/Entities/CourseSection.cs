namespace DeuStudentHub.Domain.Entities;

public class CourseSection
{
    public int Id { get; set; }

    public string Semester { get; set; } = string.Empty;

    public string AcademicYear { get; set; } = string.Empty;

    public string SectionNumber { get; set; } = string.Empty;

    public int CourseId { get; set; }

    public Course Course { get; set; } = null!;

    public ICollection<CourseSectionTeacher> CourseSectionTeachers { get; set; } = new List<CourseSectionTeacher>();
}