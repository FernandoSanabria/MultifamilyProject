using System;
using System.Collections.Generic;

namespace WSMultifamilyProperty.Models
{
    public partial class Module
    {
        public Module()
        {
            Action = new HashSet<Action>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual ICollection<Action> Action { get; set; }
    }
}
