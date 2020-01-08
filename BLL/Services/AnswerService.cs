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
    public class AnswerService : IAnswerService
    {
        IUnitOfWork Database { get; set; }

        public AnswerService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<AnswerDTO> GetAnswers(Predicate<AnswerDTO> predic)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Answer, AnswerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Answer>, List<AnswerDTO>>(Database.Answers.GetAll()).FindAll(predic);
        }

        public AnswerDTO GetAnswer(int? id)
        {
            if (id == null)
                throw new ValidationException("Answer id is not found", "");
            var answer = Database.Answers.Get(id.Value);
            if (answer == null)
                throw new ValidationException("Answer is not found", "");

            AnswerDTO resAnswerDTO = new AnswerDTO
            {
                Id = answer.Id,
                AnswerText = answer.AnswerText,
                IsRight = answer.IsRight,
                QuestionId = answer.Question.Id
            };

            return resAnswerDTO;
        }

        public void AddAnswer(AnswerDTO answerDTO)
        {
            var existQuestion = Database.Questions.Get(answerDTO.QuestionId);
            if (existQuestion == null)
                throw new ValidationException("Answer's question is not found", "");

            Answer answer = new Answer
            {
                Id = answerDTO.Id,
                AnswerText = answerDTO.AnswerText,
                IsRight = answerDTO.IsRight,
                Question = existQuestion
            };

            Database.Answers.Create(answer);
            Database.Save();
        }

        public void UpdateAnswer(AnswerDTO answerDTO)
        {
            var existAnswer = Database.Answers.Get(answerDTO.Id);
            if (existAnswer == null)
                throw new ValidationException("Answer is not found", "");

            var existQuestion = Database.Questions.Get(answerDTO.QuestionId);
            if (existQuestion == null)
                throw new ValidationException("Answer's question is not found", "");

            Answer answer = new Answer
            {
                Id = answerDTO.Id,
                AnswerText = answerDTO.AnswerText,
                IsRight = answerDTO.IsRight,
                Question = existQuestion
            };

            Database.Answers.Update(answer);
            Database.Save();
        }

        public void DeleteAnswer(int? id)
        {
            if (id == null)
                throw new ValidationException("Answer id is not found", "");
            var answer = Database.Answers.Get(id.Value);
            if (answer == null)
                throw new ValidationException("Answer is not found", "");

            Database.Answers.Delete(answer.Id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
