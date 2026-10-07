using DeuStudentHub.Domain.Entities;

namespace DeuStudentHub.Application.Interfaces;

public interface IDepartmentRepository
{
    Task<List<Department>> GetByFacultyIdAsync(int facultyId);
}