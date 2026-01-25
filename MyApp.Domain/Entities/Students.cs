using MyApp.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Students
    {
        public int StudentsId { get; set; }
        public string StudentNumber { get; set; }
        public string QrNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int SectionID { get; set; }
        public Section Section { get; set; }

        public bool isActive { get; set; } = false;

        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }

        protected Students() { } //Navigation

        public Students(string studentNumber, string qrNumber, string firstName, string middleName, string lastName, DateOnly dateOfBirth, string gender, int sectionID)
        {

            if (string.IsNullOrWhiteSpace(studentNumber))
                throw new DomainException("Something wrong with student number.");

            if (string.IsNullOrWhiteSpace(qrNumber))
                throw new DomainException("Something wrong with qr number.");

            if (string.IsNullOrWhiteSpace(firstName))
                throw new DomainException("Something wrong with first name.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainException("Something wrong with last name.");

            if (dateOfBirth == default)
                throw new DomainException("Something wrong with the date of birth.");

            if (string.IsNullOrWhiteSpace(gender))
                throw new DomainException("Something wrong with the gender.");

            if (sectionID <= 0)
                throw new DomainException("Something wrong with the student ID.");

            StudentNumber = studentNumber;
            QrNumber = qrNumber;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            SectionID = sectionID;
        }

        public void Update(string studentNumber, string qrNumber, string firstName, string lastName, DateOnly dateOfBirth, string gender, int sectionID)
        {
            

            if (string.IsNullOrWhiteSpace(studentNumber))
                throw new DomainException("Something wrong with student number.");

            if (string.IsNullOrWhiteSpace(qrNumber))
                throw new DomainException("Something wrong with qr number.");

            if (string.IsNullOrWhiteSpace(firstName))
                throw new DomainException("Something wrong with first name.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainException("Something wrong with last name.");

            if (dateOfBirth == default)
                throw new DomainException("Something wrong with the date of birth.");

            if (string.IsNullOrWhiteSpace(gender))
                throw new DomainException("Something wrong with the gender.");

            if (sectionID <= 0)
                throw new DomainException("Something wrong with the student ID.");

            StudentNumber = studentNumber;
            QrNumber = qrNumber;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            SectionID = sectionID;
        }

    }
}
