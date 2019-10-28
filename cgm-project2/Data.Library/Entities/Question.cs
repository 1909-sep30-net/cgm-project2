using System.Collections.Generic;

namespace Data.Library.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionString { get; set; }
        public int TitleId { get; set; }
        public Title Title { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}