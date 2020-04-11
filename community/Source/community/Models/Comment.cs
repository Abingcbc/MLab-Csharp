using System;
using System.Collections.Generic;

namespace community.Models
{
    public class Comment
    {
        public Comment() => this.Reply = new HashSet<Reply>();

        public int CommentId { get; set; }
        public int? PostId { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? Status { get; set; }

        public virtual Post Post { get; set; }
        public virtual User UsernameNavigation { get; set; }
        public virtual ICollection<Reply> Reply { get; set; }
    }
}
