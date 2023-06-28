using System;
using System.Collections.Generic;

namespace Xleb.Models
{
    public partial class Bakery
    {
        public Bakery()
        {
            Supplies = new HashSet<Supply>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
