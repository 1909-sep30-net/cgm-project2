using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Library.Models
{
    class Categories
    {
        public int      CategoryId          { get; set; }
        public int      TitleId             { get; set; }
        public int      Rank                { get; set; }
        public string   CategoryString      { get; set; }
        public string   CategoryDescription { get; set; }
    
        public Categories()
        {

        }


        //this is for converting from the DB entity to class.
        public Categories(int cid, int t, int r, string cs, string cd)
        {
            CategoryId = cid;
            TitleId = t;
            Rank = r;
            CategoryString = cs;
            CategoryDescription = cd;
        }
    

    
    
    }
}
