using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO.Attendance
{
    public class AttendanceDTO
    {
        public int AttendanceRecordsId { get; set; }
        public int StudentID { get; set; }
        public Students Students { get; set; }

        public AttendanceType Type { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
