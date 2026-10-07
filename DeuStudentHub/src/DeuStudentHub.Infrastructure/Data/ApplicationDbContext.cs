using DeuStudentHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeuStudentHub.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Faculty> Faculties => Set<Faculty>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<CourseSection> CourseSections => Set<CourseSection>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<CourseSectionTeacher> CourseSectionTeachers => Set<CourseSectionTeacher>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<ForumPost> ForumPosts => Set<ForumPost>();
    public DbSet<Comment> Comments => Set<Comment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // User
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(u => u.Name)
                .HasMaxLength(100);

            entity.Property(u => u.Email)
                .HasMaxLength(255);

            entity.Property(u => u.PasswordHash)
                .HasMaxLength(500);

            entity.HasIndex(u => u.Email)
                .IsUnique();
        });

        // Faculty
        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.Property(f => f.Name)
                .HasMaxLength(200);
        });

        // Department
        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(d => d.Name)
                .HasMaxLength(200);
        });

        // Course
        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(c => c.Code)
                .HasMaxLength(20);

            entity.Property(c => c.Name)
                .HasMaxLength(200);

            entity.Property(c => c.Description)
                .HasMaxLength(2000);

            entity.HasIndex(c => c.Code)
                .IsUnique();
        });

        // CourseSection
        modelBuilder.Entity<CourseSection>(entity =>
        {
            entity.Property(cs => cs.Semester)
                .HasMaxLength(20);

            entity.Property(cs => cs.AcademicYear)
                .HasMaxLength(20);

            entity.Property(cs => cs.SectionNumber)
                .HasMaxLength(20);
        });

        // Teacher
        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.Property(t => t.FirstName)
                .HasMaxLength(100);

            entity.Property(t => t.LastName)
                .HasMaxLength(100);

            entity.Property(t => t.Email)
                .HasMaxLength(255);
        });

        // Review
        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(r => r.Comment)
                .HasMaxLength(2000);

            entity.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Reviews_Target",
                    "([CourseId] IS NOT NULL AND [TeacherId] IS NULL) OR " +
                    "([CourseId] IS NULL AND [TeacherId] IS NOT NULL)");

                t.HasCheckConstraint(
                    "CK_Reviews_Rating",
                    "[Rating] >= 1 AND [Rating] <= 5");
            });
        });

        // ForumPost
        modelBuilder.Entity<ForumPost>(entity =>
        {
            entity.Property(fp => fp.Title)
                .HasMaxLength(200);

            entity.Property(fp => fp.Content)
                .HasMaxLength(10000);
        });

        // Comment
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(c => c.Content)
                .HasMaxLength(5000);
        });
                
        // Faculty -> Departments
        modelBuilder.Entity<Department>()
            .HasOne(d => d.Faculty)
            .WithMany(f => f.Departments)
            .HasForeignKey(d => d.FacultyId);

        // Department -> Courses
        modelBuilder.Entity<Course>()
            .HasOne(c => c.Department)
            .WithMany(d => d.Courses)
            .HasForeignKey(c => c.DepartmentId);

        // Course -> CourseSections
        modelBuilder.Entity<CourseSection>()
            .HasOne(cs => cs.Course)
            .WithMany(c => c.CourseSections)
            .HasForeignKey(cs => cs.CourseId);

        // CourseSection <-> Teacher
        modelBuilder.Entity<CourseSectionTeacher>()
            .HasKey(cst => new
            {
                cst.CourseSectionId,
                cst.TeacherId
            });

        modelBuilder.Entity<CourseSectionTeacher>()
            .HasOne(cst => cst.CourseSection)
            .WithMany(cs => cs.CourseSectionTeachers)
            .HasForeignKey(cst => cst.CourseSectionId);

        modelBuilder.Entity<CourseSectionTeacher>()
            .HasOne(cst => cst.Teacher)
            .WithMany(t => t.CourseSectionTeachers)
            .HasForeignKey(cst => cst.TeacherId);

        // User -> Reviews
        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId);

        // Course -> Reviews
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Course)
            .WithMany(c => c.Reviews)
            .HasForeignKey(r => r.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Teacher -> Reviews
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Teacher)
            .WithMany(t => t.Reviews)
            .HasForeignKey(r => r.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

     

        // User -> ForumPosts
        modelBuilder.Entity<ForumPost>()
            .HasOne(fp => fp.User)
            .WithMany(u => u.ForumPosts)
            .HasForeignKey(fp => fp.UserId);

        // User -> Comments
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // ForumPost -> Comments
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.ForumPost)
            .WithMany(fp => fp.Comments)
            .HasForeignKey(c => c.ForumPostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}