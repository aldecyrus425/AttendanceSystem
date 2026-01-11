using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IParentRepository
    {
        Task<IEnumerable<Parents>> GetAllParentsAsync();

        Task<Parents?> GetParentByIdAsync(int id);

        Task AddParentAsync(Parents parent);

        Task<bool> DeleteParentAsync(int id);

        Task SaveChangesAsync();
    }
}
