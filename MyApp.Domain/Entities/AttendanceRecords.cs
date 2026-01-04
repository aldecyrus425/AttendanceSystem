using MyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class AttendanceRecords
    {
        public int AttendanceRecordID { get; set; }
        public int StudentID { get; set; }
        public Students Students { get; set; }

        public AttendanceType Type { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        
        protected AttendanceRecords() {}

    }
}
