using MyApp.Application.DTO.Section;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface ISectionServices
    {
        Task<IEnumerable<SectionDTO>> GetAllSectionsAsync();

        Task<SectionDTO> GetSectionByIDAsync(int id);

        Task<SectionDTO?> AddSectionAsync(CreateSectionDTO dto);

        Task<bool> DeleteSectionAsync(int id);

        Task<SectionDTO?> UpdateSectionAsync(int id, UpdateSectionDTO dto);

    }
}
