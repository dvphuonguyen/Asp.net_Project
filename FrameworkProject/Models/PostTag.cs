using System;
using System.Collections.Generic;

#nullable disable

namespace FrameworkProject.Models
{
    public partial class PostTag
    {
        public PostTag()
        {
            Postsandtags = new HashSet<PostsAndTags>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Status { get; set; }

        public virtual ICollection<PostsAndTags> Postsandtags { get; set; }
    }
}
