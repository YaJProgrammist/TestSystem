using System;

namespace DAL
{
    public class Answer
    {
        public int Id { get; set; }
        public int AnswerText { get; set; }
        public bool IsRight { get; set; }

        public Question Question { get; set; }
    }
}
