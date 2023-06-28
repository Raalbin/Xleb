using System;
using System.Collections.Generic;

namespace Xleb.Models
{
    public partial class Supply
    {
        public int Id { get; set; }
        public int BakeriesId { get; set; }
        public int ProductsId { get; set; }
        public int SuppliersId { get; set; }

        public virtual Bakery Bakeries { get; set; } = null!;
        public virtual Product Products { get; set; } = null!;
        public virtual Supplier Suppliers { get; set; } = null!;
    }
}
