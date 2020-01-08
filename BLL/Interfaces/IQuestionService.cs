using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IQuestionService
    {
        QuestionDTO GetQuestion(int? id);
        IEnumerable<QuestionDTO> GetQuestions(Predicate<QuestionDTO> predic);
        void AddQuestion(QuestionDTO testDTO);
        void UpdateQuestion(QuestionDTO testDTO);
        void DeleteQuestion(int? id);
        void Dispose();
    }
}
