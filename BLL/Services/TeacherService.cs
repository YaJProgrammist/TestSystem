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
    public class TeacherService : ITeacherService
    {
        IUnitOfWork Database { get; set; }

        public TeacherService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<TeacherDTO> GetTeachers(Predicate<TeacherDTO> predic)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Teacher, TeacherDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Teacher>, List<TeacherDTO>>(Database.Teachers.GetAll()).FindAll(predic);
        }

        public TeacherDTO GetTeacher(int? id)
        {
            if (id == null)
                throw new ValidationException("Teacher id is not found", "");
            var teacher = Database.Teachers.Get(id.Value);
            if (teacher == null)
                throw new ValidationException("Teacher is not found", "");

            TeacherDTO resTeacherDTO = new TeacherDTO
            {
                Id = teacher.Id,
                Name = teacher.Name
            };

            foreach (Test test in teacher.Tests)
            {
                resTeacherDTO.TestIds.Add(test.Id);
            }

            return resTeacherDTO;
        }

        public void AddTeacher(TeacherDTO teacherDTO)
        {
            Teacher teacher = new Teacher
            {
                Id = teacherDTO.Id,
                Name = teacherDTO.Name
            };

            foreach (int testId in teacherDTO.TestIds)
            {
                Test test = Database.Tests.Get(testId);
                if (test == null)
                    throw new ValidationException("Teacher's test is not found", "");
                teacher.Tests.Add(test);
            }

            Database.Teachers.Create(teacher);
            Database.Save();
        }

        public void UpdateTeacher(TeacherDTO teacherDTO)
        {
            var existTeacher = Database.Teachers.Get(teacherDTO.Id);
            if (existTeacher == null)
                throw new ValidationException("Teacher is not found", "");

            Teacher teacher = new Teacher
            {
                Id = teacherDTO.Id,
                Name = teacherDTO.Name
            };

            foreach (int testId in teacherDTO.TestIds)
            {
                Test test = Database.Tests.Get(testId);
                if (test == null)
                    throw new ValidationException("Teacher's test is not found", "");
                teacher.Tests.Add(test);
            }

            Database.Teachers.Update(teacher);
            Database.Save();
        }

        public void DeleteTeacher(int? id)
        {
            if (id == null)
                throw new ValidationException("Teacher id is not found", "");
            var teacher = Database.Teachers.Get(id.Value);
            if (teacher == null)
                throw new ValidationException("Teacher is not found", "");

            Database.Teachers.Delete(teacher.Id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
