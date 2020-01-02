using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    interface ITestService
    {
        TestDTO GetProduct(int? id);
        IEnumerable<TestDTO> GetProducts(Predicate<TestDTO> predic);
        void AddProduct(TestDTO testDTO);
        void UpdateProduct(TestDTO testDTO);
        void DeleteProduct(int? id);
        void Dispose();
    }
}
