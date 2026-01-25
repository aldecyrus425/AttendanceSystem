using MyApp.Application.DTO.Student;
using MyApp.Application.Interfaces.Repository;
using MyApp.Application.Interfaces.Services;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Domain.Exceptions;

namespace MyApp.Application.Services.Student
{
    public class StudentsServices : IStudentServices
    {
        private readonly IStudentRepository _repository;
        private readonly ISectionRepository _sectionRepository;

        public StudentsServices(IStudentRepository repository, ISectionRepository sectionRepository)
        {
            _repository = repository;
            _sectionRepository = sectionRepository;
        }

        public async Task<StudentDTO?> AddStudentAsync(CreateStudentDTO student)
        {
            var checkSection = await _sectionRepository.GetSectionByIdAsync(student.SectionID);

            if (checkSection == null)
                throw new NotFoundException("Section not found.");

            var addStudent = new Students(
                studentNumber: student.StudentNumber,
                qrNumber: student.QrNumber,
                firstName: student.FirstName,
                middleName: student.MiddleName,
                lastName: student.LastName,
                dateOfBirth: student.DateOfBirth,
                gender: student.Gender,
                sectionID: student.SectionID
            );

            await _repository.AddStudentAsync(addStudent);

            await _repository.SaveChangesAsync();

            return new StudentDTO
            {
                StudentID = addStudent.StudentsId,
                StudentNumber = addStudent.StudentNumber,
                QrNumber = addStudent.QrNumber,
                FirstName = addStudent.FirstName,
                MiddleName = addStudent.MiddleName,
                LastName = addStudent.LastName,
                DateOfBirth = addStudent.DateOfBirth,
                Gender = addStudent.Gender,
                isActive = addStudent.isActive,
                SectionName = checkSection.Name,
                GradeLevelName = checkSection.GradeLevel.Name
                
            };


        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var isDeleted = await _repository.DeleteStudentAsync(id);
            if (!isDeleted)
                return false;

            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            var studentsList = await _repository.GetAllStudentsAsync();

            return studentsList.Select(student => new StudentDTO
            {
                StudentID = student.StudentsId,
                StudentNumber = student.StudentNumber,
                QrNumber = student.QrNumber,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Gender = student.Gender,
                SectionName = student.Section.Name,
                GradeLevelName = student.Section.GradeLevel.Name,
                isActive = student.isActive
            });
        }

        public async Task<StudentDTO?> GetStudentsByIDAsync(int id)
        {
            var student = await _repository.GetStudentByIDAsync(id);
            if(student == null)
                return null;

            return new StudentDTO
            {
                StudentID = student.StudentsId,
                StudentNumber = student.StudentNumber,
                QrNumber = student.QrNumber,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Gender = student.Gender,
                SectionName = student.Section.Name,
                GradeLevelName = student.Section.GradeLevel.Name,
                isActive = student.isActive
            };
        }

        public async Task<StudentDTO?> UpdateStudentAsync(int id, UpdateStudentDTO student)
        {
            var existingStudent = await _repository.GetStudentByIDAsync(id);
            if (existingStudent == null)
                return null;

            existingStudent.Update(
                studentNumber: student.StudentNumber,
                qrNumber: student.QrNumber,
                firstName: student.FirstName,
                lastName: student.LastName,
                dateOfBirth: student.DateOfBirth,
                gender: student.Gender,
                sectionID: student.SectionID 
            );

            await _repository.SaveChangesAsync();

            return new StudentDTO
            {
                StudentID = existingStudent.StudentsId,
                StudentNumber = existingStudent.StudentNumber,
                QrNumber = existingStudent.QrNumber,
                FirstName = existingStudent.FirstName,
                LastName = existingStudent.LastName,
                DateOfBirth = existingStudent.DateOfBirth,
                Gender = existingStudent.Gender,
                SectionName = existingStudent.Section.Name,
                GradeLevelName = existingStudent.Section.GradeLevel.Name,
                isActive = student.isActive
            };

        }
    }
}
