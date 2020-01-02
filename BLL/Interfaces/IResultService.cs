using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    interface IResultService
    {
        ResultDTO GetProduct(int? id);
        IEnumerable<ResultDTO> GetProducts(Predicate<ResultDTO> predic);
        void AddProduct(ResultDTO testDTO);
        void UpdateProduct(ResultDTO testDTO);
        void DeleteProduct(int? id);
        void Dispose();
    }
}
