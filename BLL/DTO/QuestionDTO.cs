using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int TestId { get; set; }
        public int[] AnswerIds {get; set; } 
    }
}
