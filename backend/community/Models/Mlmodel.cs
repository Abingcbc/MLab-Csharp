using System;
using System.Collections.Generic;

namespace community.Models
{
    public partial class Mlmodel
    {
        public Mlmodel()
        {
            Post = new HashSet<Post>();
        }

        public int ModelId { get; set; }
        public string Username { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? Status { get; set; }

        public virtual User UsernameNavigation { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
