using DeuStudentHub.Domain.Entities;

namespace DeuStudentHub.Application.Interfaces;

public interface IFacultyRepository
{
    Task<List<Faculty>> GetAllAsync();
}