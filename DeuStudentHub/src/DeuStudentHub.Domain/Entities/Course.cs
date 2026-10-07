namespace DeuStudentHub.Domain.Entities;

public class Course
{
    public int Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public Department Department { get; set; } = null!;

    public ICollection<CourseSection> CourseSections { get; set; } = new List<CourseSection>();

    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}