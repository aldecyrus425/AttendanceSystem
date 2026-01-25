using Azure;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTO.Response;
using MyApp.Application.DTO.Student;
using MyApp.Application.Interfaces.Services;
using MyApp.Domain.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _service;

        public StudentController(IStudentServices service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO<StudentDTO>>> AddStudentAsync(CreateStudentDTO student)
        {
            
            try
            {
                var addedStudent = await _service.AddStudentAsync(student);

                return Ok(new ResponseDTO<StudentDTO>
                {
                    Success = true,
                    Message = "Student added successfully.",
                    Data = addedStudent
                });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseDTO<StudentDTO>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDTO<StudentDTO>>> UpdateStudentAsync(int id, UpdateStudentDTO student)
        {
            var updateStudent = await _service.UpdateStudentAsync(id, student);
            if(updateStudent == null)
            {
                return BadRequest(new ResponseDTO<StudentDTO>
                {
                    Success = false,
                    Message = "Student update failed.",
                    Data = null
                });
            }

            return Ok(new ResponseDTO<StudentDTO>
            {
                Success = true,
                Message = "Student updated successfully!",
                Data = updateStudent
            });
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO<IEnumerable<StudentDTO>>>> GetAllStudentsAsync()
        {
            var students = await _service.GetAllStudentsAsync();

            var response = new ResponseDTO<IEnumerable<StudentDTO>> 
            {
                Success = true,
                Message = "Students List",
                Data = students
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO<StudentDTO>>> GetStudentByIDAsync(int id)
        {
            var student = await _service.GetStudentsByIDAsync(id);

            if(student == null)
            {
                return NotFound(new ResponseDTO<StudentDTO>
                {
                    Success = false,
                    Message = "Student Not Found.",
                    Data = null
                });
            }

            var response = new ResponseDTO<StudentDTO>
            {
                Success = true,
                Message = "Student Data Fetched Successfully.",
                Data = student

            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO<StudentDTO>>> DeleteStudentAsync(int id)
        {
            var isDeleted = await _service.DeleteStudentAsync(id);
            if(!isDeleted)
            {
                return NotFound(new ResponseDTO<StudentDTO>
                {
                    Success = false,
                    Message = "Student not found for deletion.",
                    Data = null
                });
            }

            return Ok(new ResponseDTO<StudentDTO>
            {
                Success = true,
                Message = "Student deleted successfully.",
                Data = null
            });
        }
    }
}
