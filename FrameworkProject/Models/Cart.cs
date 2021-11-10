using System;
using System.Collections.Generic;

#nullable disable

namespace FrameworkProject.Models
{
    public partial class Cart
    {
        public Cart()
        {
            Wishlists = new HashSet<Wishlist>();
        }

        public long Id { get; set; }
        public long ProductId { get; set; }
        public long? OrderId { get; set; }
        public long? UserId { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
