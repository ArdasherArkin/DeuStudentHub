using DeuStudentHub.Application.Interfaces;

namespace DeuStudentHub.Application.Courses.DeleteCourse;

public class DeleteCourseService
{
    private readonly ICourseRepository _courseRepository;

    public DeleteCourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<bool> ExecuteAsync(int id)
    {
        return await _courseRepository.DeleteAsync(id);
    }
}