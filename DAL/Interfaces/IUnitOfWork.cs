using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Teacher> Teachers { get; }
        IRepository<Student> Students { get; }
        IRepository<Test> Tests { get; }
        IRepository<Answer> Answers { get; }
        IRepository<Question> Questions { get; }
        IRepository<Result> Results { get; }
        
        void Save();
    }
}
