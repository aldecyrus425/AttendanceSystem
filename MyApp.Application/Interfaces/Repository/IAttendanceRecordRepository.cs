using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IAttendanceRecordRepository
    {
        Task<IEnumerable<AttendanceRecords>> GetAllAttendanceRecordsAsync();

        Task<AttendanceRecords?> GetAttendanceRecordByIDAsync(int id);

        Task AddAttendanceRecordAsync(AttendanceRecords attendanceRecord);

        Task<bool> DeleteAttendanceRecordAsync(int id);

        Task SaveChangesAsync();
    }
}
