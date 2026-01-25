using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Domain.Exceptions;

namespace MyApp.Domain.Entities
{
    public class StudentParent
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Students Students { get; set; }

        public int ParentId { get; set; }
        public Parents Parents { get; set; }

        public string Relationship { get; set; }

        protected StudentParent() { }

        public StudentParent(int studentID, int parentID, string relationship) 
        {
            if (studentID <= 0)
                throw new DomainException("Something wrong with student ID.");

            if (parentID <= 0)
                throw new DomainException("Something wrong with parent ID.");

            if (string.IsNullOrWhiteSpace(relationship))
                throw new DomainException("Something wrong with relationship of parent and student.");

            StudentId = studentID;
            ParentId = parentID;
            Relationship = relationship.Trim();
        }

        public void Update(int studentID, int parentID, string relationship)
        {
            if (studentID <= 0)
                throw new DomainException("Something wrong with student ID.");

            if (parentID <= 0)
                throw new DomainException("Something wrong with parent ID.");

            if (string.IsNullOrWhiteSpace(relationship))
                throw new DomainException("Something wrong with relationship of parent and student.");

            StudentId = studentID;
            ParentId = parentID;
            Relationship = relationship.Trim();
        }
    }
}
