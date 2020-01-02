using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    class TestDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double MaxMark { get; set; }
        public bool IsOpen { get; set; }
        public int[] TeacherIds { get; set; }
        public int[] AnswerIds { get; set; }
        public int[] QuestionIds { get; set; }
    }
}
