namespace DeuStudentHub.Domain.Entities;

public class Teacher
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public ICollection<CourseSectionTeacher> CourseSectionTeachers { get; set; } = new List<CourseSectionTeacher>();

    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}