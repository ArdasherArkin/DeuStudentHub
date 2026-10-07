namespace DeuStudentHub.Domain.Entities;

public class Faculty
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<Department> Departments { get; set; } = new List<Department>();
}