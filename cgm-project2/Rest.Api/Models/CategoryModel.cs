using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Models
{
    /// <summary>
    /// Compare to Domains.Library.Models.Category
    /// </summary>
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public int TitleId { get; set; }
        public string CategoryString { get; set; }
        public string CategoryDescription { get; set; }
        public int Rank { get; set; }
    }
}
