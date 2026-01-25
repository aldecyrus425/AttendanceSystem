using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO.Student
{
    public class UpdateStudentDTO
    {
        public string StudentNumber { get; set; }
        public string QrNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int SectionID { get; set; }
        public bool isActive { get; set; } = false;

    }
}
