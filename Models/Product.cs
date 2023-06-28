using System;
using System.Collections.Generic;

namespace Xleb.Models
{
    public partial class Product
    {
        public Product()
        {
            Supplies = new HashSet<Supply>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;

        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
