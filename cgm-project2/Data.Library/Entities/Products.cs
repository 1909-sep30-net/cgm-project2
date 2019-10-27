using System;
using System.Collections.Generic;

namespace Data.Library.Entities
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Function { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}
