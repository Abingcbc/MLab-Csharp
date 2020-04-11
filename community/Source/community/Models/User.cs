using System;
using System.Collections.Generic;

namespace community.Models
{
    public class User
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            Dataset = new HashSet<Dataset>();
            History = new HashSet<History>();
            Likes = new HashSet<Likes>();
            Mlmodel = new HashSet<Mlmodel>();
            Post = new HashSet<Post>();
            Reply = new HashSet<Reply>();
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Dataset> Dataset { get; set; }
        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<Likes> Likes { get; set; }
        public virtual ICollection<Mlmodel> Mlmodel { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<Reply> Reply { get; set; }
    }
}
