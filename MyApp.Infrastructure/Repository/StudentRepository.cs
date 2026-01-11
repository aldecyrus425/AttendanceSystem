using Microsoft.EntityFrameworkCore;
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
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddStudentAsync(Students student)
        {

            await _context.Students.AddAsync(student);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.StudentID == id);

            if (student == null)
                return false;

            _context.Students.Remove(student);

            return true;
        }

        public async Task<IEnumerable<Students>> GetAllStudentsAsync()
        {
            return await _context.Students.AsNoTracking().ToListAsync();
        }

        public async Task<Students?> GetStudentByIDAsync(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.StudentID == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
