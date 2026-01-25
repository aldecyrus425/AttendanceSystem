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
    public class AttendanceRecordsRepository : IAttendanceRecordRepository
    {
        private readonly AppDbContext _context;

        public AttendanceRecordsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAttendanceRecordAsync(AttendanceRecords attendanceRecord)
        {
            await _context.AttendanceRecords.AddAsync(attendanceRecord);
        }

        public async Task<bool> DeleteAttendanceRecordAsync(int id)
        {
            var attendance = await _context.AttendanceRecords.FirstOrDefaultAsync(a => a.AttendanceRecordsId == id);
            if (attendance == null)
                return false;

            _context.AttendanceRecords.Remove(attendance);

            return true;
        }

        public async Task<IEnumerable<AttendanceRecords>> GetAllAttendanceRecordsAsync()
        {
            return await _context.AttendanceRecords
                .Include(a => a.Students)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AttendanceRecords?> GetAttendanceRecordByIDAsync(int id)
        {
            return await _context.AttendanceRecords.AsNoTracking().FirstOrDefaultAsync(a => a.AttendanceRecordsId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
