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
    public class ResultService : IResultService
    {
        IUnitOfWork Database { get; set; }

        public ResultService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<ResultDTO> GetResults(Predicate<ResultDTO> predic)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Result, ResultDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Result>, List<ResultDTO>>(Database.Results.GetAll()).FindAll(predic);
        }

        public ResultDTO GetResult(int? id)
        {
            if (id == null)
                throw new ValidationException("Result id is not found", "");
            var result = Database.Results.Get(id.Value);
            if (result == null)
                throw new ValidationException("Result is not found", "");

            ResultDTO resResultDTO = new ResultDTO
            {
                Id = result.Id,
                Mark = result.Mark,
                Started = result.Started,
                Finished = result.Finished,
                TestId = result.Test.Id,
                StudentId = result.Student.Id
            };

            foreach (Answer ans in result.Answers)
            {
                resResultDTO.AnswerIds.Add(ans.Id);
            }

            return resResultDTO;
        }

        public void AddResult(ResultDTO resultDTO)
        {
            var existTest = Database.Tests.Get(resultDTO.TestId);
            if (existTest == null)
                throw new ValidationException("Result's test is not found", "");

            var existStudent = Database.Students.Get(resultDTO.StudentId);
            if (existStudent == null)
                throw new ValidationException("Result's student is not found", "");

            Result result = new Result
            {
                Id = resultDTO.Id,
                Mark = resultDTO.Mark,
                Started = resultDTO.Started,
                Finished = resultDTO.Finished,
                Test = existTest,
                Student = existStudent
            };

            foreach (int ansId in resultDTO.AnswerIds)
            {
                Answer ans = Database.Answers.Get(ansId);
                if (ans == null)
                    throw new ValidationException("Result's answer is not found", "");
                result.Answers.Add(ans);
            }

            Database.Results.Create(result);
            Database.Save();
        }

        public void UpdateResult(ResultDTO resultDTO)
        {
            var existResult = Database.Results.Get(resultDTO.Id);
            if (existResult == null)
                throw new ValidationException("Result is not found", "");

            var existTest = Database.Tests.Get(resultDTO.TestId);
            if (existTest == null)
                throw new ValidationException("Result's test is not found", "");

            var existStudent = Database.Students.Get(resultDTO.StudentId);
            if (existStudent == null)
                throw new ValidationException("Result's student is not found", "");

            Result result = new Result
            {
                Id = resultDTO.Id,
                Mark = resultDTO.Mark,
                Started = resultDTO.Started,
                Finished = resultDTO.Finished,
                Test = existTest,
                Student = existStudent
            };

            foreach (int ansId in resultDTO.AnswerIds)
            {
                Answer ans = Database.Answers.Get(ansId);
                if (ans == null)
                    throw new ValidationException("Result's answer is not found", "");
                result.Answers.Add(ans);
            }

            Database.Results.Update(result);
            Database.Save();
        }

        public void DeleteResult(int? id)
        {
            if (id == null)
                throw new ValidationException("Result id is not found", "");
            var result = Database.Results.Get(id.Value);
            if (result == null)
                throw new ValidationException("Result is not found", "");

            Database.Results.Delete(result.Id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
