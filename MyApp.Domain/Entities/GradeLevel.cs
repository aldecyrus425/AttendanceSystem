using MyApp.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class GradeLevel
    {
        public int GradeLevelId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        protected GradeLevel() { } //For ORM

        public GradeLevel(string name, string? description)
        {
            if (!string.IsNullOrWhiteSpace(name))
                throw new DomainException("Grade level name is required");

            if (name.Length > 100)
                throw new DomainException("Grade level name must not exceed 100 characters");

            Name = name;
            Description = description;
        }


        public void Update(string name, string? description)
        {
            if (!string.IsNullOrWhiteSpace(name))
                throw new DomainException("Grade level name is required");

            if (name.Length > 100)
                throw new DomainException("Grade level name must not exceed 100 characters");

            Name = name;
            Description = description;
        }
    }
}
