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

        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}
