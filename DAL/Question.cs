using System;
using System.Collections.Generic;

namespace DAL
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }

        public Test Test { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
