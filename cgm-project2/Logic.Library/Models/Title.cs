﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Library.Models
{
    public class Title
    {
        public int    TitleId       { get; set; }
        public string TitleString   { get; set; }
        public string CreatorId     { get; set; }


        public Title()
        {

        }

        public Title(int tid, string t, string c = null)
        {
            TitleId = tid;
            TitleString = t;
            CreatorId = c;
        }
    }
}
