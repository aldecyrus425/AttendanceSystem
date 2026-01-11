using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repository
{
    public class StudentParentRepository : IStudentParentRepository
    {
        private readonly AppDbContext _context;

        public StudentParentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddStudentPrentAsync(StudentParent studentParent)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudentPrentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentParent>> GetAllStudentParentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StudentParent?> GetStudentParentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
