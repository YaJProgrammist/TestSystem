using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure;
using DAL;
using DAL.Interfaces;

namespace BLL.Services
{
    public class QuestionService : IQuestionService
    {
        IUnitOfWork Database { get; set; }

        public QuestionService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<QuestionDTO> GetQuestions(Predicate<QuestionDTO> predic)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Question, QuestionDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Question>, List<QuestionDTO>>(Database.Questions.GetAll()).FindAll(predic);
        }

        public QuestionDTO GetQuestion(int? id)
        {
            if (id == null)
                throw new ValidationException("Question id is not found", "");
            var question = Database.Questions.Get(id.Value);
            if (question == null)
                throw new ValidationException("Question is not found", "");

            QuestionDTO resQuestionDTO = new QuestionDTO
            {
                Id = question.Id,
                QuestionText = question.QuestionText,
                TestId = question.Test.Id
            };

            foreach (Answer ans in question.Answers)
            {
                resQuestionDTO.AnswerIds.Add(ans.Id);
            }

            return resQuestionDTO;
        }

        public void AddQuestion(QuestionDTO questionDTO)
        {
            var existTest = Database.Tests.Get(questionDTO.TestId);
            if (existTest == null)
                throw new ValidationException("Question's test is not found", "");

            Question question = new Question
            {
                Id = questionDTO.Id,
                QuestionText = questionDTO.QuestionText,
                Test = existTest
            };

            foreach (int ansId in questionDTO.AnswerIds)
            {
                Answer ans = Database.Answers.Get(ansId);
                if (ans == null)
                    throw new ValidationException("Question's answer is not found", "");
                question.Answers.Add(ans);
            }

            Database.Questions.Create(question);
            Database.Save();
        }

        public void UpdateQuestion(QuestionDTO questionDTO)
        {
            var existQuestion = Database.Questions.Get(questionDTO.Id);
            if (existQuestion == null)
                throw new ValidationException("Question is not found", "");

            var existTest = Database.Tests.Get(questionDTO.TestId);
            if (existTest == null)
                throw new ValidationException("Question's test is not found", "");

            Question question = new Question
            {
                Id = questionDTO.Id,
                QuestionText = questionDTO.QuestionText,
                Test = existTest
            };

            foreach (int ansId in questionDTO.AnswerIds)
            {
                Answer ans = Database.Answers.Get(ansId);
                if (ans == null)
                    throw new ValidationException("Question's answer is not found", "");
                question.Answers.Add(ans);
            }

            Database.Questions.Update(question);
            Database.Save();
        }

        public void DeleteQuestion(int? id)
        {
            if (id == null)
                throw new ValidationException("Question id is not found", "");
            var question = Database.Questions.Get(id.Value);
            if (question == null)
                throw new ValidationException("Question is not found", "");

            Database.Questions.Delete(question.Id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
