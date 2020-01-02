using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories
{
    class AnswerRepository : IRepository<Answer>
    {
        private TestSystemContext db;

        public AnswerRepository(TestSystemContext context)
        {
            this.db = context;
        }

        public IEnumerable<Answer> GetAll()
        {
            return db.Answers;
        }

        public Answer Get(int id)
        {
            return db.Answers.Find(id);
        }

        public void Create(Answer ans)
        {
            db.Answers.Add(ans);
        }

        public void Update(Answer ans)
        {
            db.Entry(ans).State = EntityState.Modified;
        }

        public IEnumerable<Answer> Find(Func<Answer, Boolean> predicate)
        {
            return db.Answers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Answer ans = db.Answers.Find(id);
            if (ans != null)
                db.Answers.Remove(ans);
        }
    }
}
