namespace DeuStudentHub.Domain.Entities;

public class CourseSectionTeacher
{
    public int CourseSectionId { get; set; }

    public CourseSection CourseSection { get; set; } = null!;

    public int TeacherId { get; set; }

    public Teacher Teacher { get; set; } = null!;
}