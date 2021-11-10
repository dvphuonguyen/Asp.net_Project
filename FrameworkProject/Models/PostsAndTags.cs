using System;
using System.Collections.Generic;

#nullable disable

namespace FrameworkProject.Models
{
    public partial class PostsAndTags
    {
        public long Id { get; set; }
        public long? PostId { get; set; }
        public long? TagId { get; set; }

        public virtual Post Post { get; set; }
        public virtual PostTag Tag { get; set; }
    }
}
