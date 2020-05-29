using System;
using System.Collections.Generic;

namespace community.Models
{
    public class Dataset
    {
        public int DatasetId { get; set; }
        public string Username { get; set; }
        public string DatasetName { get; set; }
        public string Format { get; set; }
        public double? Size { get; set; }
        public DateTime? CreateTime { get; set; }

        public virtual User UsernameNavigation { get; set; }
    }
}
