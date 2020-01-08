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
    public class TestService : ITestService
    {
        IUnitOfWork Database { get; set; }

        public TestService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<TestDTO> GetTests(Predicate<TestDTO> predic)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Test, TestDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Test>, List<TestDTO>>(Database.Tests.GetAll()).FindAll(predic);
        }

        public TestDTO GetTest(int? id)
        {
            if (id == null)
                throw new ValidationException("Test id is not found", "");
            var test = Database.Tests.Get(id.Value);
            if (test == null)
                throw new ValidationException("Test is not found", "");

            TestDTO resTestDTO = new TestDTO
            {
                Id = test.Id, 
                Title = test.Title, 
                MaxMark = test.MaxMark, 
                IsOpen = test.IsOpen
            };

            foreach (Teacher teach in test.Teachers)
            {
                resTestDTO.TeacherIds.Add(teach.Id);
            }
            foreach (Answer ans in test.Answers)
            {
                resTestDTO.AnswerIds.Add(ans.Id);
            }
            foreach (Question quest in test.Questions)
            {
                resTestDTO.QuestionIds.Add(quest.Id);
            }
            foreach (Result res in test.Results)
            {
                resTestDTO.ResultIds.Add(res.Id);
            }

            return resTestDTO;
        }

        public void AddTest(TestDTO testDTO)
        {
            Test test = new Test
            {
                Id = testDTO.Id,
                Title = testDTO.Title,
                MaxMark = testDTO.MaxMark,
                IsOpen = testDTO.IsOpen
            };

            foreach (int teachId in testDTO.TeacherIds)
            {
                Teacher teach = Database.Teachers.Get(teachId);
                if (teach == null)
                    throw new ValidationException("Test's teacher is not found", "");
                test.Teachers.Add(teach);
            }
            foreach (int ansId in testDTO.AnswerIds)
            {
                Answer ans = Database.Answers.Get(ansId);
                if (ans == null)
                    throw new ValidationException("Test's answer is not found", "");
                test.Answers.Add(ans);
            }
            foreach (int questId in testDTO.QuestionIds)
            {
                Question quest = Database.Questions.Get(questId);
                if (quest == null)
                    throw new ValidationException("Test's question is not found", "");
                test.Questions.Add(quest);
            }
            foreach (int resId in testDTO.ResultIds)
            {
                Result res = Database.Results.Get(resId);
                if (res == null)
                    throw new ValidationException("Test's result is not found", "");
                test.Results.Add(res);
            }
            
            Database.Tests.Create(test);
            Database.Save();
        }

        public void UpdateTest(TestDTO testDTO)
        {
            var existTest = Database.Tests.Get(testDTO.Id);
            if (existTest == null)
                throw new ValidationException("Test is not found", "");

            Test test = new Test
            {
                Id = testDTO.Id,
                Title = testDTO.Title,
                MaxMark = testDTO.MaxMark,
                IsOpen = testDTO.IsOpen
            };

            foreach (int teachId in testDTO.TeacherIds)
            {
                Teacher teach = Database.Teachers.Get(teachId);
                if (teach == null)
                    throw new ValidationException("Test's teacher is not found", "");
                test.Teachers.Add(teach);
            }
            foreach (int ansId in testDTO.AnswerIds)
            {
                Answer ans = Database.Answers.Get(ansId);
                if (ans == null)
                    throw new ValidationException("Test's answer is not found", "");
                test.Answers.Add(ans);
            }
            foreach (int questId in testDTO.QuestionIds)
            {
                Question quest = Database.Questions.Get(questId);
                if (quest == null)
                    throw new ValidationException("Test's question is not found", "");
                test.Questions.Add(quest);
            }
            foreach (int resId in testDTO.ResultIds)
            {
                Result res = Database.Results.Get(resId);
                if (res == null)
                    throw new ValidationException("Test's result is not found", "");
                test.Results.Add(res);
            }

            Database.Tests.Update(test);
            Database.Save();
        }

        public void DeleteTest(int? id)
        {
            if (id == null)
                throw new ValidationException("Test id is not found", "");
            var test = Database.Tests.Get(id.Value);
            if (test == null)
                throw new ValidationException("Test is not found", "");

            Database.Tests.Delete(test.Id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
