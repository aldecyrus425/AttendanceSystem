using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IGradeLevelRepository
    {
        Task<IEnumerable<GradeLevel>> GetAllGradeLevelAsync();

        Task<GradeLevel?> GetGradeLevelAsync(int gradeLevelID);

        Task AddGradeLevelAsync(GradeLevel gradeLevel);

        Task SaveChangesAsync();

        Task<bool> DeleteGradeLevelAsync(int gradeLevelID);
    }
}
