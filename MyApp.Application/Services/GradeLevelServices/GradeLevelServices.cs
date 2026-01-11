using MyApp.Application.DTO.GradeLevel;
using MyApp.Application.Interfaces.Repository;
using MyApp.Application.Interfaces.Services;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services.GradeLevelServices
{
    public class GradeLevelServices : IGradeLevelServices
    {
        private IGradeLevelRepository _repository;
        public GradeLevelServices(IGradeLevelRepository repository) 
        {
            _repository = repository;
        }


        public async Task<GradeLevelDTO> AddGradeLevelAsync(CreateGradeLevelDTO request)
        {
            var gradeLevel = new GradeLevel(
                request.Name,
                request.Description
            );

            await _repository.AddGradeLevelAsync(gradeLevel);

            await _repository.SaveChangesAsync();

            return new GradeLevelDTO
            {
                GradeLevelId = gradeLevel.GradeLevelId,
                Name = gradeLevel.Name,
                Description = gradeLevel.Description
            };
        }

        public async Task<bool> DeleteGradeLevelAsync(int gradeLevelID)
        {
            var isDeleted = await _repository.DeleteGradeLevelAsync(gradeLevelID);

            if (!isDeleted)
                return false;

            await _repository.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<GradeLevelDTO>> GetAllGradeLevelAsync()
        {
            var gradeLevels =  await _repository.GetAllGradeLevelAsync();

            return gradeLevels.Select(gradeLevels => new GradeLevelDTO
            {
                GradeLevelId = gradeLevels.GradeLevelId,
                Name = gradeLevels.Name,
                Description = gradeLevels.Description
            });
        }

        public async Task<GradeLevelDTO?> GetGradeLevelAsync(int gradeLevelID)
        {
            var gradeLevel = await _repository.GetGradeLevelAsync(gradeLevelID);

            return new GradeLevelDTO
            {
                GradeLevelId = gradeLevel.GradeLevelId,
                Name= gradeLevel.Name,
                Description = gradeLevel.Description
            };

        }

        public async Task<GradeLevelDTO?> UpdateGradeLevelAsync(int gradeLevelID, UpdateGradeLevelDTO dto)
        {
            var existingGradeLevel = await _repository.GetGradeLevelAsync(gradeLevelID);

            if (existingGradeLevel == null) 
                return null;

            //Mapping
            existingGradeLevel.Update(dto.Name, dto.Description);

            await _repository.SaveChangesAsync();

            return new GradeLevelDTO
            {
                GradeLevelId = existingGradeLevel.GradeLevelId,
                Name = existingGradeLevel.Name,
                Description = existingGradeLevel.Description
            };
        }
    }
}
