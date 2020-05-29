using System;
using System.Collections.Generic;

namespace community.Models
{

    public class History
    {
        public int TrainId { get; set; }
        public string Username { get; set; }
        public int? ModelId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual Mlmodel Model { get; set; }
        public virtual User UsernameNavigation { get; set; }
    }
}
