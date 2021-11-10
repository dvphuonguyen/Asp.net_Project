using System;
using System.Collections.Generic;

#nullable disable

namespace FrameworkProject.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
