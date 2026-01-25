using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO.Student
{
    public class CreateStudentDTO
    {
        public string StudentNumber { get; set; }
        public string QrNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int SectionID { get; set; }
    }
}
