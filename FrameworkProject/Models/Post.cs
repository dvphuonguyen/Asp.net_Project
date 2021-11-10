using System;
using System.Collections.Generic;

#nullable disable

namespace FrameworkProject.Models
{
    public partial class Post
    {
        public Post()
        {
            Postcomments = new HashSet<PostComment>();
            Postsandtags = new HashSet<PostsAndTags>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Quote { get; set; }
        public string Photo { get; set; }
        public long? PostCatId { get; set; }
        public long? AddedBy { get; set; }
        public string Status { get; set; }

        public virtual User AddedByNavigation { get; set; }
        public virtual PostCategory PostCat { get; set; }
        public virtual ICollection<PostComment> Postcomments { get; set; }
        public virtual ICollection<PostsAndTags> Postsandtags { get; set; }
    }
}
