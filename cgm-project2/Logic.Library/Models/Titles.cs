using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Library.Models
{
    class Titles
    {
        public int    TitleId       { get; set; }
        public string TitleString   { get; set; }
        public string CreatorID     { get; set; }


        public Titles()
        {

        }

        public Titles(int tid, string t, string c = null)
        {
            TitleId = tid;
            TitleString = t;
            CreatorID = c;
        }
    }
}
