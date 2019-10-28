using System.Collections.Generic;

namespace Data.Library.Entities
{
    public class Title
    {
        public int TitleId { get; set; }
        public string Titletring { get; set; } //the name of the title
        public int CreatorId { get; set; }
        public User User { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}