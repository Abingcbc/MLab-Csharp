using System;
using System.Collections.Generic;

namespace community.Models
{
    public class Mlmodel
    {
        public Mlmodel()
        {
            this.History = new HashSet<History>();
            this.Post = new HashSet<Post>();
        }

        public int ModelId { get; set; }
        public string Username { get; set; }
        public string ModelName { get; set; }
        public byte[] Detail { get; set; }
        public string Description { get; set; }
        public DateTime? CreateTime { get; set; }

        public virtual User UsernameNavigation { get; set; }
        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
