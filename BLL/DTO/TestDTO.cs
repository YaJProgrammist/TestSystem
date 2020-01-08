using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class TestDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double MaxMark { get; set; }
        public bool IsOpen { get; set; }
        public ICollection<int> TeacherIds { get; set; }
        public ICollection<int> AnswerIds { get; set; }
        public ICollection<int> QuestionIds { get; set; }
        public ICollection<int> ResultIds { get; set; }
    }
}
