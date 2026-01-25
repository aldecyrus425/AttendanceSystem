using MyApp.Application.DTO.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IAttendanceServices
    {
        Task<IEnumerable<AttendanceDTO>> GetAllAttendanceAsync();

        Task<AttendanceDTO> GetAttendanceAsync(int id);

        Task<AttendanceDTO> AddAttendanceAsync(CreateAttendanceDTO dto);

        Task<bool> DeleteAttendanceAsync(int id);

        Task<AttendanceDTO> UpdateAttendanceAsync(int id, UpdateAttendanceDTO dto);
    }
}
