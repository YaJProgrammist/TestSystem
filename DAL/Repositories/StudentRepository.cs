using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class StudentRepository : IRepository<Student>
    {
        private TestSystemContext db;

        public StudentRepository(TestSystemContext context)
        {
            this.db = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return db.Students;
        }

        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public void Create(Student stud)
        {
            db.Students.Add(stud);
        }

        public void Update(Student stud)
        {
            db.Entry(stud).State = EntityState.Modified;
        }

        public IEnumerable<Student> Find(Func<Student, Boolean> predicate)
        {
            return db.Students.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Student stud = db.Students.Find(id);
            if (stud != null)
                db.Students.Remove(stud);
        }
    }
}
