using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    interface IQuestionService
    {
        QuestionDTO GetProduct(int? id);
        IEnumerable<QuestionDTO> GetProducts(Predicate<QuestionDTO> predic);
        void AddProduct(QuestionDTO testDTO);
        void UpdateProduct(QuestionDTO testDTO);
        void DeleteProduct(int? id);
        void Dispose();
    }
}
