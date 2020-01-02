using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    class TestSystemContext : DbContext
    {
        public TestSystemContext(DbContextOptions<TestSystemContext> options) : base(options)
        {
            Database.EnsureCreated();
        } 
        
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
