using System;
using System.Collections.Generic;

namespace community.Models
{
    public class Likes
    {
        public int LikeId { get; set; }
        public int? TypeId { get; set; }
        public int? Type { get; set; }
        public string Username { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateTime { get; set; }

        public virtual User UsernameNavigation { get; set; }
    }
}
