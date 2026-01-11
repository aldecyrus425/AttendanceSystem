using MyApp.Application.DTO.GradeLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IGradeLevelServices
    {
        //                 Return Type
        Task<IEnumerable<GradeLevelDTO>> GetAllGradeLevelAsync();

        Task<GradeLevelDTO?> GetGradeLevelAsync(int gradeLevelID);

        //    Return Type                                  Payload
        Task<GradeLevelDTO> AddGradeLevelAsync(CreateGradeLevelDTO gradeLevel);

        Task<GradeLevelDTO?> UpdateGradeLevelAsync(int gradeLevelID, UpdateGradeLevelDTO dto);

        Task<bool> DeleteGradeLevelAsync(int gradeLevelID);
    }
}
