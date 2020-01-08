namespace BLL.DTO
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public int AnswerText { get; set; }
        public bool IsRight { get; set; }
        public int QuestionId { get; set; }
    }
}
