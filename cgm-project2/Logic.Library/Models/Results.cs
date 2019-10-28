using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Library.Models
{
    class Results
    {
        public int ResultId { get; set; }
        public int Score    { get; set; }
        public int TakerId  { get; set; }
        public int TitleId  { get; set; }

        public Results()
        {

        }

        public Results(int rid, int s, int ti, int title)
        {
            ResultId = rid;
            Score = s;
            TakerId = ti;
            TitleId = title;
        }

    }
}
