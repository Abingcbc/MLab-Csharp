using System;
using System.Collections.Generic;

namespace community.Models
{
    public partial class User
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            Container = new HashSet<Container>();
            Dataset = new HashSet<Dataset>();
            Likes = new HashSet<Likes>();
            Mlmodel = new HashSet<Mlmodel>();
            Post = new HashSet<Post>();
            Reply = new HashSet<Reply>();
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Container> Container { get; set; }
        public virtual ICollection<Dataset> Dataset { get; set; }
        public virtual ICollection<Likes> Likes { get; set; }
        public virtual ICollection<Mlmodel> Mlmodel { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<Reply> Reply { get; set; }
    }
}
