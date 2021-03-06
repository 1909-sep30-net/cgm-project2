﻿using System.Collections.Generic;

namespace Data.Library.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int Rank { get; set; }
        public string CategoryString { get; set; }
        public string CategoryDescription { get; set; }
        public int TitleId { get; set; }
        public Title Title {get;set;}
        public ICollection<Answer> Answers { get; set; }
    }
}