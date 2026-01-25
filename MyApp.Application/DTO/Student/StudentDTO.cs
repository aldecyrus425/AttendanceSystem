using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO.Student
{
    public class StudentDTO
    {
        public int StudentID { get; set; }
        public string StudentNumber { get; set; }
        public string QrNumber { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string? SectionName { get; set; }
        public string? GradeLevelName { get; set; }
        public bool isActive { get; set; } = false;
    }
}
