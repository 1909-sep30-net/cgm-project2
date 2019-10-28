using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Library.Models
{
    public class Question
    {
        public int      QuestionId      { get; set; }
        public int      TitleId         { get; set; }
        public string   QuestionString  { get; set; }

        public Question()
        {

        }

        public Question(int qid, int t, string s)
        {
            QuestionId = qid;
            TitleId = t;
            QuestionString = s;
        }

    }
}
