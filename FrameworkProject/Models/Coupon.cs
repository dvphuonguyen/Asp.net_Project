using System;
using System.Collections.Generic;

#nullable disable

namespace FrameworkProject.Models
{
    public partial class Coupon
    {
        public Coupon()
        {
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public string Status { get; set; }
        public bool IsVoucher { get; set; }
        public int Quantity { get; set; }
        public DateTime? StartedAt{ get; set; }
        public DateTime? EndedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
