using System;
using System.Collections.Generic;

namespace DAL
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double MaxMark { get; set; }
        public bool IsOpen { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
