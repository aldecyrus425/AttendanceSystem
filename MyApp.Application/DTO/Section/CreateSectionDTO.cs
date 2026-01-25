using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO.Section
{
    public class CreateSectionDTO
    {
        public int GradeLevelId { get; set; }
        public string Name { get; set; }
        public string SchoolYear { get; set; }
    }
}
