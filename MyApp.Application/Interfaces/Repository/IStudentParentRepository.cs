using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IStudentParentRepository
    {
        Task<IEnumerable<StudentParent>> GetAllStudentParentAsync();

        Task<StudentParent?> GetStudentParentAsync(int id);

        Task AddStudentPrentAsync(StudentParent studentParent);

        Task<bool> DeleteStudentPrentAsync(int id);

        Task SaveChangesAsync();
    }
}
