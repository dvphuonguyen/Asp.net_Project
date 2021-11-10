using System;
using System.Collections.Generic;

#nullable disable

namespace FrameworkProject.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
            Productattributes = new HashSet<ProductAttribute>();
            Productreviews = new HashSet<ProductReview>();
            Wishlists = new HashSet<Wishlist>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string Photo4 { get; set; }
        public int Stock { get; set; }
        public string Condition { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public long? CouponId { get; set; }
        public long? CatId { get; set; }
        public long? ChildCatId { get; set; }
        public long? BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Cat { get; set; }
        public virtual Category ChildCat { get; set; }
        public virtual Coupon Coupon { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductAttribute> Productattributes { get; set; }
        public virtual ICollection<ProductReview> Productreviews { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
