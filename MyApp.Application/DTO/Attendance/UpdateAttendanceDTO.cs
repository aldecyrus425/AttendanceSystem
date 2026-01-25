using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO.Attendance
{
    public class UpdateAttendanceDTO
    {
        public int StudentID { get; set; }

        public string Type { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
