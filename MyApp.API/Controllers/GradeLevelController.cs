using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTO.GradeLevel;
using MyApp.Application.DTO.Response;
using MyApp.Application.DTO.Student;
using MyApp.Application.Interfaces.Services;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradeLevelController : ControllerBase
    {
        private readonly IGradeLevelServices _service;

        public GradeLevelController(IGradeLevelServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO<IEnumerable<GradeLevelDTO>>>> GetAllGradeLevelAsync()
        {
            var gradeLevels = await _service.GetAllGradeLevelAsync();

            var response = new ResponseDTO<IEnumerable<GradeLevelDTO>>
            {
                Success = true,
                Message = "Grade level lists.",
                Data = gradeLevels
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO<GradeLevelDTO>>> GetGradeLevelByIDAsync(int id)
        {
            var gradeLevel = await _service.GetGradeLevelAsync(id);
            if (gradeLevel == null)
            {
                return NotFound(new ResponseDTO<GradeLevelDTO>
                {
                    Success = false,
                    Message = "Grade level not found.",
                    Data = null
                });
            }

            return Ok(new ResponseDTO<GradeLevelDTO>
            {
                Success = true,
                Message = "Grade level fetched successfully",
                Data = gradeLevel
            });
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO<GradeLevelDTO>>> AddGradeLevelAsync(CreateGradeLevelDTO gradeLevel)
        {
            var addGradeLevel = await _service.AddGradeLevelAsync(gradeLevel);

            if (addGradeLevel == null)
            {
                return BadRequest(new ResponseDTO<GradeLevelDTO>
                {
                    Success = false,
                    Message = "Grade level failed to add.",
                    Data = null
                });
            }

            return Ok(new ResponseDTO<GradeLevelDTO>
            {
                Success = true,
                Message = "Grade level added successfully.",
                Data = addGradeLevel
            });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDTO<GradeLevelDTO>>> UpdateGradeLevelAsync(int id, UpdateGradeLevelDTO gradeLevel)
        {
            var isUpdated = await _service.UpdateGradeLevelAsync(id, gradeLevel);

            if (isUpdated == null)
            {
                return NotFound(new ResponseDTO<GradeLevelDTO>
                {
                    Success = false,
                    Message = "Grade level not found.",
                    Data = null
                });
            }

            return Ok(new ResponseDTO<GradeLevelDTO>
            {
                Success = true,
                Message = "Grade level Updated Successfully",
                Data = isUpdated
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO<GradeLevelDTO>>> DeleteGradeLevelAsync(int id)
        {
            var isDeleted = await _service.DeleteGradeLevelAsync(id);
            if(!isDeleted)
            {
                return NotFound(new ResponseDTO<GradeLevelDTO>
                {
                    Success = false,
                    Message = "Grade level not found.",
                    Data = null
                });
            }

            return Ok(new ResponseDTO<GradeLevelDTO>
            {
                Success = true,
                Message = "Grade level deleted successfully.",
                Data = null
            });
        }

    }
}
