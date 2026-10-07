using DeuStudentHub.Domain.Entities;

namespace DeuStudentHub.Application.Interfaces;

public interface ITeacherRepository
{
    Task<List<Teacher>> GetAllAsync();
    Task<Teacher?> GetByIdAsync(int id);
    Task<Teacher?> GetDetailsByIdAsync(int id);
}