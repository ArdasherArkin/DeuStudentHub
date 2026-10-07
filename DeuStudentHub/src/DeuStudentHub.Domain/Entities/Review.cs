namespace DeuStudentHub.Domain.Entities;

public class Review
{
    public int Id { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public int? CourseId { get; set; }

    public Course? Course { get; set; }

    public int? TeacherId { get; set; }

    public Teacher? Teacher { get; set; }
}