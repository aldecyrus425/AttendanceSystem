using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO.Attendance
{
    public class CreateAttendanceDTO
    {
        public int StudentID { get; set; }

        public AttendanceType Type { get; set; }

    }
}
