namespace DeuStudentHub.Domain.Entities;

public class Comment
{
    public int Id { get; set; }

    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public int ForumPostId { get; set; }

    public ForumPost ForumPost { get; set; } = null!;
}