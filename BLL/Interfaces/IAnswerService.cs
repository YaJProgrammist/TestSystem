using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    interface IAnswerService
    {
        AnswerDTO GetProduct(int? id);
        IEnumerable<AnswerDTO> GetProducts(Predicate<AnswerDTO> predic);
        void AddProduct(AnswerDTO testDTO);
        void UpdateProduct(AnswerDTO testDTO);
        void DeleteProduct(int? id);
        void Dispose();
    }
}
