using DeuStudentHub.Application.Interfaces;
using DeuStudentHub.Application.Teachers.DTOs;

namespace DeuStudentHub.Application.Teachers.GetTeacherDetails;

public class GetTeacherDetailsService
{
    private readonly ITeacherRepository _teacherRepository;

    public GetTeacherDetailsService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<TeacherDetailsDto?> ExecuteAsync(int id)
    {
        var teacher = await _teacherRepository.GetDetailsByIdAsync(id);

        if (teacher is null)
        {
            return null;
        }

        return new TeacherDetailsDto
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Email = teacher.Email,

            Sections = teacher.CourseSectionTeachers
                .Select(cst => new TeacherSectionDto
                {
                    SectionId = cst.CourseSection.Id,
                    Semester = cst.CourseSection.Semester,
                    AcademicYear = cst.CourseSection.AcademicYear,
                    SectionNumber = cst.CourseSection.SectionNumber,

                    CourseId = cst.CourseSection.Course.Id,
                    CourseCode = cst.CourseSection.Course.Code,
                    CourseName = cst.CourseSection.Course.Name
                })
                .ToList()
        };
    }
}