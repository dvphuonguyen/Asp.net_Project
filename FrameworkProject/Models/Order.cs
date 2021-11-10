using System;
using System.Collections.Generic;

#nullable disable

namespace FrameworkProject.Models
{
    public partial class Order
    {
        public Order()
        {
            Carts = new HashSet<Cart>();
        }

        public long Id { get; set; }
        public string OrderNumber { get; set; }
        public long? ProductId { get; set; }
        public long? UserId { get; set; }
        public decimal SubTotal { get; set; }
        public long? ShippingId { get; set; }
        public long? CouponId { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual Coupon Coupon { get; set; }
        public virtual Product Product { get; set; }
        public virtual Shipping Shipping { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
