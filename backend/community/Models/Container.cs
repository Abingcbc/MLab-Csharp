using System;
using System.Collections.Generic;

namespace community.Models
{
    public partial class Container
    {
        public int ContainerId { get; set; }
        public string Username { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? InvalidTime { get; set; }

        public virtual User UsernameNavigation { get; set; }
    }
}
