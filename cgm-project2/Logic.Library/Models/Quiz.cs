using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Library.Models
{
    public class Quiz
    {
        public Title title;
        public List<Question> questions;
        public List<Category> category;

        public Quiz()
        {

        }

        public Quiz(Title t)
        {
            this.title = t;
        }
    }
}
