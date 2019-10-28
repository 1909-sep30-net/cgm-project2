using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Library.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public int Score    { get; set; }
        public int TakerId  { get; set; }
        public int TitleId  { get; set; }

        public Result()
        {

        }

        public Result(int rid, int s, int ti, int title)
        {
            ResultId = rid;
            Score = s;
            TakerId = ti;
            TitleId = title;
        }

    }
}
