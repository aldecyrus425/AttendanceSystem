using MyApp.Application.DTO.Response;
using MyApp.Application.DTO.Student;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IStudentServices
    {
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();

        Task<StudentDTO?> GetStudentsByIDAsync(int id);

        Task<StudentDTO?> AddStudentAsync(CreateStudentDTO student);

        Task<bool> DeleteStudentAsync(int id);

        Task<StudentDTO?> UpdateStudentAsync(int id, UpdateStudentDTO student);
    }
}
