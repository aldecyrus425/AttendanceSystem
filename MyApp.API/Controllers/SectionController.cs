using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTO.Response;
using MyApp.Application.DTO.Section;
using MyApp.Application.DTO.Student;
using MyApp.Application.Interfaces.Services;
using MyApp.Domain.Exceptions;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionServices _sectionServices;

        public SectionController(ISectionServices sectionServices)
        {
            _sectionServices = sectionServices;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO<IEnumerable<SectionDTO>>>> GetAllSectionAsync()
        {
            var sections = await _sectionServices.GetAllSectionsAsync();

            var response = new ResponseDTO<IEnumerable<SectionDTO>>
            {
                Success = true,
                Message = "Section Lists.",
                Data = sections
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO<SectionDTO>>> GetSectionAsync(int id)
        {
            try
            {
                var section = await _sectionServices.GetSectionByIDAsync(id);

                return Ok(new ResponseDTO<SectionDTO>
                {
                    Success = true,
                    Message = "Section data.",
                    Data = section
                });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseDTO<SectionDTO>
                {
                    Message = ex.Message,
                    Success = false
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO<StudentDTO>>> AddSectionAsync(CreateSectionDTO dto)
        {
            try
            {
                var addSection = await _sectionServices.AddSectionAsync(dto);

                return Ok(new ResponseDTO<SectionDTO>
                {
                    Success = true,
                    Message = "Section added successfully.",
                    Data = addSection
                });
            } 
            catch(NotFoundException ex) 
            {
                return NotFound(new ResponseDTO<SectionDTO>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDTO<SectionDTO>>> UpdateSectionAsync(int id, UpdateSectionDTO dto)
        {
            try
            {
                var updateSection = await _sectionServices.UpdateSectionAsync(id, dto);

                return Ok(new ResponseDTO<SectionDTO>
                {
                    Success = true,
                    Message = "Section updated successfully.",
                    Data = updateSection
                });

            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseDTO<SectionDTO>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO<SectionDTO>>> DeleteSectionAsync(int id)
        {
            try
            {
                var isDeleted = await _sectionServices.DeleteSectionAsync(id);

                return Ok(new ResponseDTO<SectionDTO>
                {
                    Success = true,
                    Message = "Section deleted successfully."
                });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseDTO<SectionDTO>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }
    }
}
