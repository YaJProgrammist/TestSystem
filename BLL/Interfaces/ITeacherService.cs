using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    interface ITeacherService
    {
        TeacherDTO GetProduct(int? id);
        IEnumerable<TeacherDTO> GetProducts(Predicate<TeacherDTO> predic);
        void AddProduct(TeacherDTO testDTO);
        void UpdateProduct(TeacherDTO testDTO);
        void DeleteProduct(int? id);
        void Dispose();
    }
}
