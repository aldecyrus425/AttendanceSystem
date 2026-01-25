using MyApp.Application.DTO.Section;
using MyApp.Application.Interfaces.Repository;
using MyApp.Application.Interfaces.Services;
using MyApp.Domain.Entities;
using MyApp.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services.SectionServices
{
    public class SectionServices : ISectionServices
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IGradeLevelRepository _gradeLevelRepository;


        public SectionServices(ISectionRepository sectionRepository, IGradeLevelRepository gradeLevelRepository)
        {
            _sectionRepository = sectionRepository;
            _gradeLevelRepository = gradeLevelRepository;
        }

        public async Task<SectionDTO?> AddSectionAsync(CreateSectionDTO dto)
        {
            var checkGradeLevel = await _gradeLevelRepository.GetGradeLevelAsync(dto.GradeLevelId);

            if (checkGradeLevel == null)
            {
                throw new NotFoundException("Grade level not found");
            }

            var newSection = new Section(dto.GradeLevelId, dto.Name, dto.SchoolYear);

            await _sectionRepository.AddSectionAsync(newSection);
            await _sectionRepository.SaveChangesAsync();

            return new SectionDTO
            { 
                SectionId = newSection.SectionId,
                Name = newSection.Name,
                GradeLevelName = checkGradeLevel.Name,
                SchoolYear = newSection.SchoolYear
            };
        }

        public async Task<bool> DeleteSectionAsync(int id)
        {
            var isDeleted = await _sectionRepository.DeleteSectionAsync(id);
            if (!isDeleted)
                throw new NotFoundException("Section not found");

            await _sectionRepository.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<SectionDTO>> GetAllSectionsAsync()
        {
            var sections = await _sectionRepository.GetAllSectionsAsync();

            return sections.Select(sec => new SectionDTO
            {
                SectionId = sec.SectionId,
                Name = sec.Name,
                GradeLevelName = sec.GradeLevel.Name,
                SchoolYear = sec.SchoolYear
            });
        }

        public async Task<SectionDTO> GetSectionByIDAsync(int id)
        {
            var section = await _sectionRepository.GetSectionByIdAsync(id);
            if (section == null)
                throw new NotFoundException("Section not found.");

            return new SectionDTO
            {
                SectionId = section.SectionId,
                Name = section.Name,
                GradeLevelName = section.GradeLevel.Name,
                SchoolYear = section.SchoolYear
            };
        }

        public async Task<SectionDTO?> UpdateSectionAsync(int id, UpdateSectionDTO dto)
        {
            var section = await _sectionRepository.GetSectionByIdAsync(id);
            if (section == null)
                throw new NotFoundException("Section not found");

            section.UpdateSection(dto.GradeLevelId, dto.Name, dto.SchoolYear);

            await _sectionRepository.SaveChangesAsync();

            return new SectionDTO
            {
                SectionId = section.SectionId,
                Name = section.Name,
                GradeLevelName = section.GradeLevel.Name,
                SchoolYear = section.SchoolYear
            };
        }
    }
}
