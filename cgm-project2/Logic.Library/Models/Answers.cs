using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Library.Models
{
    class Answers
    {
        public int      AnswerId    { get; set; }
        public string   AnswerString { get; set; }
        public int      Weight      { get; set; }
        public int      CategoryId  { get; set; }
        public int      QuestionId  { get; set; }

        public Answers()
        {

        }

        public Answers(int a, string ans, int w, int c, int q)
        {
            AnswerId = a;
            AnswerString = ans;
            Weight = w;
            CategoryId = c;
            QuestionId = q;
        }
    }
}
