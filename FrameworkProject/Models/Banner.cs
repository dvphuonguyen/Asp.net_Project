using System;
using System.Collections.Generic;

#nullable disable

namespace FrameworkProject.Models
{
    public partial class Banner
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Condition { get; set; }
    }
}
