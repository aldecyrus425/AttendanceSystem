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
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.StudentsId == id);

            if (student == null)
                return false;

            student.isActive = false;
            student.UpdateAt = DateTime.Now;

            return true;
        }

        public async Task<IEnumerable<Students>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Where(s => s.isActive == true)
                .Include(s => s.Section)
                    .ThenInclude(sec => sec.GradeLevel)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Students?> GetStudentByIDAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Section)
                .ThenInclude(sec => sec.GradeLevel)
                .FirstOrDefaultAsync(s => s.StudentsId == id);
        }

        public async Task<Students?> GetStudentByQrNumber(string qrNumber)
        {
            return await _context.Students
                .Include(s => s.Section)
                .ThenInclude(s => s.GradeLevel)
                .FirstOrDefaultAsync(s => s.QrNumber == qrNumber);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
