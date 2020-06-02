using System;
using System.Collections.Generic;

namespace community.Models
{
    public partial class Reply
    {
        public int ReplyId { get; set; }
        public string Username { get; set; }
        public int? CommentId { get; set; }
        public string Content { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? Status { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual User UsernameNavigation { get; set; }
    }
}
