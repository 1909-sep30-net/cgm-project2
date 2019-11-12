using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Logic.Library.Models
{
    public class Quiz
    {
        public Title            title       { get; set; }
        public List<Question>   questions   { get; set; }
        public List<Category>   category    { get; set; }
        public int              score       { get; set; }

        //constructors
        public Quiz()  {  }
        public Quiz(Title t) 
        {  
            this.title = t;
            questions = new List<Question>() { };
            category = new List<Category>() { };
        }
    }
}
