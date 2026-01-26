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
        public string QrNumber { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Section { get; set; }
        public string GradeLevel { get; set; }

        public AttendanceType Type { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
