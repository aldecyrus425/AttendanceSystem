using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Domain.Exceptions;

namespace MyApp.Domain.Entities
{
    public class Parents
    {
        public int ParentsId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }

        public Parents() { } //For ORM

        public Parents(string firstName, string lastName, string phoneNumber)
        {
            
            if (string.IsNullOrWhiteSpace(firstName))
                throw new DomainException("Something wrong with first name.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainException("Something wrong with last name.");

            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new DomainException("Something wrong with phone number.");

            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        public void Update(string firstName, string lastName, string phoneNumber)
        {
            

            if (string.IsNullOrWhiteSpace(firstName))
                throw new DomainException("Something wrong with first name.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainException("Something wrong with last name.");

            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new DomainException("Something wrong with phone number.");

           
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }


    }
}
