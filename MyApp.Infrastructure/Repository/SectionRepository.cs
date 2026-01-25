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
    public class SectionRepository : ISectionRepository
    {
        private readonly AppDbContext _context;

        public SectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddSectionAsync(Section section)
        {
            await _context.Sections.AddAsync(section);
        }

        public async Task<bool> DeleteSectionAsync(int id)
        {
            var section = await _context.Sections
                .FirstOrDefaultAsync(s => s.SectionId == id);

            if (section == null)
                return false;

            _context.Sections.Remove(section);

            return true;
        }

        public async Task<IEnumerable<Section>> GetAllSectionsAsync()
        {
            return await _context.Sections
                .Include(s => s.GradeLevel)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Section?> GetSectionByIdAsync(int id)
        {
            return await _context.Sections
                .Include(s => s.GradeLevel)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.SectionId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
