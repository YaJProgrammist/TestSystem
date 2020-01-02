using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class QuestionRepository : IRepository<Question>
    {
        private TestSystemContext db;

        public QuestionRepository(TestSystemContext context)
        {
            this.db = context;
        }

        public IEnumerable<Question> GetAll()
        {
            return db.Questions;
        }

        public Question Get(int id)
        {
            return db.Questions.Find(id);
        }

        public void Create(Question quest)
        {
            db.Questions.Add(quest);
        }

        public void Update(Question quest)
        {
            db.Entry(quest).State = EntityState.Modified;
        }

        public IEnumerable<Question> Find(Func<Question, Boolean> predicate)
        {
            return db.Questions.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Question quest = db.Questions.Find(id);
            if (quest != null)
                db.Questions.Remove(quest);
        }
    }
}
