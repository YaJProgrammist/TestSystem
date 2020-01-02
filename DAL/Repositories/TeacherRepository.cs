using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class TeacherRepository : IRepository<Teacher>
    {
        private TestSystemContext db;

        public TeacherRepository(TestSystemContext context)
        {
            this.db = context;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return db.Teachers;
        }

        public Teacher Get(int id)
        {
            return db.Teachers.Find(id);
        }

        public void Create(Teacher teach)
        {
            db.Teachers.Add(teach);
        }

        public void Update(Teacher teach)
        {
            db.Entry(teach).State = EntityState.Modified;
        }

        public IEnumerable<Teacher> Find(Func<Teacher, Boolean> predicate)
        {
            return db.Teachers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Teacher teach = db.Teachers.Find(id);
            if (teach != null)
                db.Teachers.Remove(teach);
        }
    }
}
