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
    public class GradeLevelRepository : IGradeLevelRepository
    {
        private AppDbContext _context;
        public GradeLevelRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task AddGradeLevelAsync(GradeLevel gradeLevel)
        {
            await _context.GradeLevels.AddAsync(gradeLevel);
        }

        public async Task<bool> DeleteGradeLevelAsync(int gradeLevelID)
        {

            var gradeLevel = await _context.GradeLevels.FirstOrDefaultAsync(g => gradeLevelID == gradeLevelID);
            if (gradeLevel == null)
                return false;

            _context.GradeLevels.Remove(gradeLevel);

            return true;
        }

        public async Task<IEnumerable<GradeLevel>> GetAllGradeLevelAsync()
        {
            return await _context.GradeLevels.AsNoTracking().ToListAsync();
        }

        public async Task<GradeLevel?> GetGradeLevelAsync(int gradeLevelID)
        {
            return await _context.GradeLevels.AsNoTracking().FirstOrDefaultAsync(g => g.GradeLevelId == gradeLevelID);

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
