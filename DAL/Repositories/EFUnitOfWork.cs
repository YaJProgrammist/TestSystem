using System;
using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly TestSystemContext _db;
        private AnswerRepository _answerRepository;
        private QuestionRepository _questionRepository;
        private ResultRepository _resultRepository;
        private StudentRepository _studentRepository;
        private TeacherRepository _teacherRepository;
        private TestRepository _testRepository;

        public EFUnitOfWork(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestSystemContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            _db = new TestSystemContext(options);
        }

        public IRepository<Answer> Answers
        {
            get
            {
                if (_answerRepository == null)
                    _answerRepository = new AnswerRepository(_db);
                return _answerRepository;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                if (_questionRepository == null)
                    _questionRepository = new QuestionRepository(_db);
                return _questionRepository;
            }
        }

        public IRepository<Result> Results
        {
            get
            {
                if (_resultRepository == null)
                    _resultRepository = new ResultRepository(_db);
                return _resultRepository;
            }
        }

        public IRepository<Student> Students
        {
            get
            {
                if (_studentRepository == null)
                    _studentRepository = new StudentRepository(_db);
                return _studentRepository;
            }
        }

        public IRepository<Teacher> Teachers
        {
            get
            {
                if (_teacherRepository == null)
                    _teacherRepository = new TeacherRepository(_db);
                return _teacherRepository;
            }
        }

        public IRepository<Test> Tests
        {
            get
            {
                if (_testRepository == null)
                    _testRepository = new TestRepository(_db);
                return _testRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
