using MyApp.Application.DTO.Attendance;
using MyApp.Application.Interfaces.Repository;
using MyApp.Application.Interfaces.Services;
using MyApp.Domain.Entities;
using MyApp.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services.AttendanceServices
{
    public class AttendanceServices : IAttendanceServices
    {
        private readonly IAttendanceRecordRepository _recordRepository;
        private readonly IStudentRepository _studentRepository;

        public AttendanceServices(IAttendanceRecordRepository recordRepository, IStudentRepository studentRepository)
        {
            _recordRepository = recordRepository;
            _studentRepository = studentRepository;
        }

        public async Task<AttendanceDTO> AddAttendanceAsync(CreateAttendanceDTO dto)
        {
            var student = await _studentRepository.GetStudentByQrNumber(dto.QrNumber);
            if (student == null)
            {
                throw new NotFoundException("Students data not found.");
            }

            var attendanceRecord = new AttendanceRecords(dto.QrNumber, dto.Type);

            await _recordRepository.AddAttendanceRecordAsync(attendanceRecord);
            await _recordRepository.SaveChangesAsync();

            return new AttendanceDTO 
            {
                AttendanceRecordsId = attendanceRecord.AttendanceRecordsId,
                StudentID = student.StudentsId,
                QrNumber = student.QrNumber,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                Gender = student.Gender,
                Section = student.Section.Name,
                GradeLevel = student.Section.GradeLevel.Name,
                Type = attendanceRecord.Type,
                CreatedAt = attendanceRecord.CreatedAt
               
            };
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var isDeleted = await _recordRepository.DeleteAttendanceRecordAsync(id);
            if(!isDeleted)
            {
                throw new NotFoundException("Attendance record not found!");
            }

            await _recordRepository.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAllAttendanceAsync()
        {
            var attendanceRecords = await _recordRepository.GetAllAttendanceRecordsAsync();

            return attendanceRecords.Select(a => new AttendanceDTO
            {
                AttendanceRecordsId = a.AttendanceRecordsId,
                StudentID = a.Students.StudentsId,
                QrNumber = a.Students.QrNumber,
                FirstName = a.Students.FirstName,
                MiddleName = a.Students.MiddleName,
                LastName = a.Students.LastName,
                Gender = a.Students.Gender,
                Section = a.Students.Section.Name,
                GradeLevel = a.Students.Section.GradeLevel.Name,
                Type = a.Type,
                CreatedAt = a.CreatedAt
            });
        }

        public async Task<AttendanceDTO> GetAttendanceAsync(int id)
        {
            var attendanceRecord = await _recordRepository.GetAttendanceRecordByIDAsync(id);
            if(attendanceRecord == null)
                throw new NotFoundException("Attendance record not found.");

            return new AttendanceDTO 
            {
                AttendanceRecordsId = attendanceRecord.AttendanceRecordsId,
                StudentID = attendanceRecord.Students.StudentsId,
                QrNumber = attendanceRecord.Students.QrNumber,
                FirstName = attendanceRecord.Students.FirstName,
                MiddleName = attendanceRecord.Students.MiddleName,
                LastName = attendanceRecord.Students.LastName,
                Gender = attendanceRecord.Students.Gender,
                Section = attendanceRecord.Students.Section.Name,
                GradeLevel = attendanceRecord.Students.Section.GradeLevel.Name,
                Type = attendanceRecord.Type,
                CreatedAt = attendanceRecord.CreatedAt
            };
        }

        public async Task<AttendanceDTO> UpdateAttendanceAsync(int id, UpdateAttendanceDTO dto)
        {
            var attendanceRecord = await _recordRepository.GetAttendanceRecordByIDAsync(id);
            if (attendanceRecord == null)
                throw new NotFoundException("Attendance record not found.");

            attendanceRecord.UpdateAttendanceRecord(dto.QrNumber, dto.Type);

            await _recordRepository.SaveChangesAsync();

            return new AttendanceDTO
            {
                AttendanceRecordsId = attendanceRecord.AttendanceRecordsId,
                StudentID = attendanceRecord.Students.StudentsId,
                QrNumber = attendanceRecord.Students.QrNumber,
                FirstName = attendanceRecord.Students.FirstName,
                MiddleName = attendanceRecord.Students.MiddleName,
                LastName = attendanceRecord.Students.LastName,
                Gender = attendanceRecord.Students.Gender,
                Section = attendanceRecord.Students.Section.Name,
                GradeLevel = attendanceRecord.Students.Section.GradeLevel.Name,
                Type = attendanceRecord.Type,
                CreatedAt = attendanceRecord.CreatedAt
            };
        }
    }
}
