using DeuStudentHub.Application.CourseSections.DTOs;
using DeuStudentHub.Application.Interfaces;
using DeuStudentHub.Application.Teachers.DTOs;

namespace DeuStudentHub.Application.CourseSections.GetCourseSections;

public class GetCourseSectionsService
{
    private readonly ICourseSectionRepository _courseSectionRepository;

    public GetCourseSectionsService(
        ICourseSectionRepository courseSectionRepository)
    {
        _courseSectionRepository = courseSectionRepository;
    }

    public async Task<List<CourseSectionDto>> ExecuteAsync(int courseId)
    {
        var sections =
            await _courseSectionRepository.GetByCourseIdAsync(courseId);

        return sections.Select(section => new CourseSectionDto
        {
            Id = section.Id,
            Semester = section.Semester,
            AcademicYear = section.AcademicYear,
            SectionNumber = section.SectionNumber,
            CourseId = section.CourseId,

            Teachers = section.CourseSectionTeachers
                .Select(cst => new TeacherDto
                {
                    Id = cst.Teacher.Id,
                    FirstName = cst.Teacher.FirstName,
                    LastName = cst.Teacher.LastName,
                    Email = cst.Teacher.Email
                })
                .ToList()
        }).ToList();
    }
}