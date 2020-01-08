using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IStudentService
    {
        StudentDTO GetStudent(int? id);
        IEnumerable<StudentDTO> GetStudents(Predicate<StudentDTO> predic);
        void AddStudent(StudentDTO testDTO);
        void UpdateStudent(StudentDTO testDTO);
        void DeleteStudent(int? id);
        void Dispose();
    }
}
