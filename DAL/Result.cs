using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Result
    {
        public int Id { get; set; }
        public double Mark { get; set; }
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }

        public Test Test { get; set; }
        public Student Student { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
