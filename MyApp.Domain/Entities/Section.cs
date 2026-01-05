using MyApp.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Section
    {
        public int SectionID { get; internal set; }
        public int GradeLevelID { get; internal set; }
        public GradeLevel GradeLevel { get; internal set; }
        public string Name { get; internal set; }
        public string SchoolYear { get; internal set; }

        protected Section() { }

        public Section(int gradelevelID, string name, string schoolYear)
        {
            if (gradelevelID <= 0)
                throw new DomainException("Grade level is not valid.");

            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("There is something wrong with section name.");

            if (string.IsNullOrWhiteSpace(schoolYear))
                throw new DomainException("There is something wrong with school year details.");

            GradeLevelID = gradelevelID;
            Name = name.Trim();
            SchoolYear = schoolYear.Trim();
        }

        public void UpdateSection(int gradelevelID, string name, string schoolYear)
        {
            if (gradelevelID <= 0)
                throw new DomainException("Grade level is not valid.");

            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("There is something wrong with section name.");

            if (string.IsNullOrWhiteSpace(schoolYear))
                throw new DomainException("There is something wrong with school year details.");

            GradeLevelID = gradelevelID;
            Name = name.Trim();
            SchoolYear = schoolYear.Trim();
        }
    }
    }
