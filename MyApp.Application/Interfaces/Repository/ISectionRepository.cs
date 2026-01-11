using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface ISectionRepository
    {
        Task<IEnumerable<Section>> GetAllSectionsAsync();

        Task<Section?> GetSectionByIdAsync(int id);

        Task AddSectionAsync(Section section);

        Task<bool> DeleteSectionAsync(int id);

        Task SaveChangesAsync();


    }
}
