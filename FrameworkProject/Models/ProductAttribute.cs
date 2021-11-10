using System;
using System.Collections.Generic;

#nullable disable

namespace FrameworkProject.Models
{
    public partial class ProductAttribute
    {
        public long Id { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public long? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
