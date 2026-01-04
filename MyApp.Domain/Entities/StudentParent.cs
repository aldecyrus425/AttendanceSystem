using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class StudentParent
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public Students Students { get; set; }

        public int ParentID { get; set; }
        public Parents Parents { get; set; }

        public string Relationship { get; set; }

        protected StudentParent() { }
    }
}
