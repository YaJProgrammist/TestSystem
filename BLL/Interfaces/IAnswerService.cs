using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IAnswerService
    {
        AnswerDTO GetAnswer(int? id);
        IEnumerable<AnswerDTO> GetAnswers(Predicate<AnswerDTO> predic);
        void AddAnswer(AnswerDTO testDTO);
        void UpdateAnswer(AnswerDTO testDTO);
        void DeleteAnswer(int? id);
        void Dispose();
    }
}
