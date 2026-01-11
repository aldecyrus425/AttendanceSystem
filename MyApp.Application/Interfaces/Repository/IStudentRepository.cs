using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Students>> GetAllStudentsAsync();

        Task<Students?> GetStudentByIDAsync(int id);

        Task AddStudentAsync(Students student);

        Task<bool> DeleteStudentAsync(int id);

        Task SaveChangesAsync();
    }
}
