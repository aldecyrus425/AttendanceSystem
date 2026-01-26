using MyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Domain.Exceptions;

namespace MyApp.Domain.Entities
{
    public class AttendanceRecords
    {
        public int AttendanceRecordsId { get; set; }
        public string QrNumber { get; set; }
        public Students Students { get; set; }

        public AttendanceType Type { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        
        protected AttendanceRecords() {}

        public AttendanceRecords(string qrNumber, AttendanceType type)
        {
            if (qrNumber == "" || qrNumber == null)
                throw new DomainException("Something wrong with Qr number.");

            if (!Enum.IsDefined(typeof(AttendanceType), type))
                throw new DomainException("Invalid attendance type.");

            QrNumber = qrNumber;
            Type = Type;
        }

        public void UpdateAttendanceRecord(string qrNumber, string type)
        {
            if (qrNumber == "" || qrNumber == null)
                throw new DomainException("Something wrong with student ID.");

            if (type == null)
                throw new DomainException("Something wrong with attendance type.");

            QrNumber = qrNumber;
            Type = Type;
            UpdatedAt = DateTime.Now;
        }

    }
}
