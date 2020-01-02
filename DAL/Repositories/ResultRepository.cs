using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class ResultRepository : IRepository<Result>
    {
        private TestSystemContext db;

        public ResultRepository(TestSystemContext context)
        {
            this.db = context;
        }

        public IEnumerable<Result> GetAll()
        {
            return db.Results;
        }

        public Result Get(int id)
        {
            return db.Results.Find(id);
        }

        public void Create(Result res)
        {
            db.Results.Add(res);
        }

        public void Update(Result res)
        {
            db.Entry(res).State = EntityState.Modified;
        }

        public IEnumerable<Result> Find(Func<Result, Boolean> predicate)
        {
            return db.Results.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Result res = db.Results.Find(id);
            if (res != null)
                db.Results.Remove(res);
        }
    }
}
