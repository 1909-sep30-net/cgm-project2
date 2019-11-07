using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Library.Models
{
    public class Category
    {
        public int      CategoryId          { get; set; }
        public int      TitleId             { get; set; }
        public int      Rank                { get; set; }
        public string   CategoryString      { get; set; }
        public string   CategoryDescription { get; set; }
    


        public Category() {   }

        //this is for converting from the DB entity to class.
        public Category(int cid, int t, int r, string cs, string cd)
        {
            CategoryId = cid;
            TitleId = t;
            Rank = r;
            CategoryString = cs;
            CategoryDescription = cd;
        }
    

    
    
    }
}
