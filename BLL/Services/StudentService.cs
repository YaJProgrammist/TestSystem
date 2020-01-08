using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure;
using DAL;
using DAL.Interfaces;

namespace BLL.Services
{
    public class StudentService : IStudentService
    {
        IUnitOfWork Database { get; set; }

        public StudentService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<StudentDTO> GetStudents(Predicate<StudentDTO> predic)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Student>, List<StudentDTO>>(Database.Students.GetAll()).FindAll(predic);
        }

        public StudentDTO GetStudent(int? id)
        {
            if (id == null)
                throw new ValidationException("Student id is not found", "");
            var student = Database.Students.Get(id.Value);
            if (student == null)
                throw new ValidationException("Student is not found", "");

            StudentDTO resStudentDTO = new StudentDTO
            {
                Id = student.Id,
                Name = student.Name
            };

            foreach (Result res in student.Results)
            {
                resStudentDTO.ResultIds.Add(res.Id);
            }

            return resStudentDTO;
        }

        public void AddStudent(StudentDTO studentDTO)
        {
            Student student = new Student
            {
                Id = studentDTO.Id,
                Name = studentDTO.Name
            };

            foreach (int resId in studentDTO.ResultIds)
            {
                Result res = Database.Results.Get(resId);
                if (res == null)
                    throw new ValidationException("Student's result is not found", "");
                student.Results.Add(res);
            }

            Database.Students.Create(student);
            Database.Save();
        }

        public void UpdateStudent(StudentDTO studentDTO)
        {
            var existStudent = Database.Students.Get(studentDTO.Id);
            if (existStudent == null)
                throw new ValidationException("Student is not found", "");

            Student student = new Student
            {
                Id = studentDTO.Id,
                Name = studentDTO.Name
            };

            foreach (int resId in studentDTO.ResultIds)
            {
                Result res = Database.Results.Get(resId);
                if (res == null)
                    throw new ValidationException("Student's result is not found", "");
                student.Results.Add(res);
            }

            Database.Students.Update(student);
            Database.Save();
        }

        public void DeleteStudent(int? id)
        {
            if (id == null)
                throw new ValidationException("Student id is not found", "");
            var student = Database.Students.Get(id.Value);
            if (student == null)
                throw new ValidationException("Student is not found", "");

            Database.Students.Delete(student.Id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
