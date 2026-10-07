namespace DeuStudentHub.Domain.Entities;

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int FacultyId { get; set; }

    public Faculty Faculty { get; set; } = null!;

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}