namespace Data.Library.Entities
{
    public class Result
    {
        public int ResultId { get; set; }
        public int Score { get; set; }
        public int TakerId { get; set; }
        public int TitleId { get; set; }
        public User User { get; set; }
        public Title Title { get; set; }
    }
}