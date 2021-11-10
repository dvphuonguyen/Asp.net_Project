using System;
using System.Collections.Generic;

#nullable disable

namespace FrameworkProject.Models
{
    public partial class Wishlist
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long? CartId { get; set; }
        public long? UserId { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
