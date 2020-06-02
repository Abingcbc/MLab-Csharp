using System;
using System.Collections.Generic;

namespace community.Models
{
    public partial class Post
    {
        public Post()
        {
            Comment = new HashSet<Comment>();
        }

        public int PostId { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public int? ModelId { get; set; }
        public string Content { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? LikeNum { get; set; }
        public int? ReplyNum { get; set; }
        public int? CommentNum { get; set; }
        public int? Status { get; set; }

        public virtual Mlmodel Model { get; set; }
        public virtual User UsernameNavigation { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
