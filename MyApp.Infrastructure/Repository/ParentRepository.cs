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
    public class ParentRepository : IParentRepository
    {
        private readonly AppDbContext _context;

        public ParentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddParentAsync(Parents parent)
        {
            await _context.Parents.AddAsync(parent);
        }

        public async Task<bool> DeleteParentAsync(int id)
        {
            var parent = await _context.Parents.FirstOrDefaultAsync(p => p.ParentID == id);
            if(parent == null) 
                return false;

            _context.Parents.Remove(parent);

            return true;
        }

        public async Task<IEnumerable<Parents>> GetAllParentsAsync()
        {
            return await _context.Parents.AsNoTracking().ToListAsync();
        }

        public async Task<Parents?> GetParentByIdAsync(int id)
        {
            return await _context.Parents.AsNoTracking().FirstOrDefaultAsync(p => p.ParentID == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
