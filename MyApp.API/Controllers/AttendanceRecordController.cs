using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTO.Attendance;
using MyApp.Application.DTO.Response;
using MyApp.Application.Interfaces.Services;
using MyApp.Domain.Exceptions;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class AttendanceRecordController : ControllerBase
    {
        private readonly IAttendanceServices _attendanceServices;

        public AttendanceRecordController(IAttendanceServices attendanceServices)
        {
            _attendanceServices = attendanceServices;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO<IEnumerable<AttendanceDTO>>>> GetAllAttendanceRecordAsync()
        {
            var records = await _attendanceServices.GetAllAttendanceAsync();

            return Ok(new ResponseDTO<IEnumerable<AttendanceDTO>>
            {
                Success = true,
                Message = "Attendance record list.",
                Data = records
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO<AttendanceDTO>>> GetAttendanceRecordAsync(int id)
        {
            try
            {
                var record = await _attendanceServices.GetAttendanceAsync(id);

                return Ok(new ResponseDTO<AttendanceDTO>
                {
                    Success = true,
                    Message = "Attendance record Data.",
                    Data = record
                });
            }
            catch(NotFoundException ex)
            {
                return NotFound(new ResponseDTO<AttendanceDTO>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO<AttendanceDTO>>> AddAttendanceRecord(CreateAttendanceDTO dto)
        {
            try
            {
                var attendance = await _attendanceServices.AddAttendanceAsync(dto);

                return Ok(new ResponseDTO<AttendanceDTO>
                {
                    Success = true,
                    Message = "Attendance record added successfully.",
                    Data = attendance
                });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseDTO<AttendanceDTO>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO<AttendanceDTO>>> DeleteAttendanceRecord(int id)
        {
            try
            {
                var recordDeleted = await _attendanceServices.DeleteAttendanceAsync(id);

                return Ok(new ResponseDTO<AttendanceDTO>
                {
                    Success = true,
                    Message = "Attendance record deleted successfully."
                });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseDTO<AttendanceDTO>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDTO<AttendanceDTO>>> UpdateAttendanceRecordAsync(int id, UpdateAttendanceDTO dto)
        {
            try
            {
                var updateRecord = await _attendanceServices.UpdateAttendanceAsync(id, dto);

                return Ok(new ResponseDTO<AttendanceDTO>
                {
                    Success = true,
                    Message = "Record updated successfully.",
                    Data = updateRecord
                });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseDTO<AttendanceDTO>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}
