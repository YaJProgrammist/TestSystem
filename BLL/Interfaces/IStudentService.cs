using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    interface IStudentService
    {
        StudentDTO GetProduct(int? id);
        IEnumerable<StudentDTO> GetProducts(Predicate<StudentDTO> predic);
        void AddProduct(StudentDTO testDTO);
        void UpdateProduct(StudentDTO testDTO);
        void DeleteProduct(int? id);
        void Dispose();
    }
}
