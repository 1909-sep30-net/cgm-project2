using System.Collections.Generic;

namespace Data.Library.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool Admin { get; set; }
        public ICollection<Title> Titles { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}