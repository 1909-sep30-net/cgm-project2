namespace Data.Library.Entities
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerString { get; set; }
        public int Weight { get; set; }
        public int CategoryId { get; set; }
        public int QuestionId { get; set; }
        public Category Category { get; set; }
        public Question Question { get; set; }
    }
}