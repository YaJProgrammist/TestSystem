using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ITeacherService
    {
        TeacherDTO GetTeacher(int? id);
        IEnumerable<TeacherDTO> GetTeachers(Predicate<TeacherDTO> predic);
        void AddTeacher(TeacherDTO testDTO);
        void UpdateTeacher(TeacherDTO testDTO);
        void DeleteTeacher(int? id);
        void Dispose();
    }
}
