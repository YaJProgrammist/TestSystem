using System.Collections.Generic;

namespace BLL.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int TestId { get; set; }
        public ICollection<int> AnswerIds {get; set; } 
    }
}
