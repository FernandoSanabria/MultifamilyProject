using System;
using System.Collections.Generic;

namespace WSMultifamilyProperty.Models
{
    public partial class Action
    {
        public Action()
        {
            RolAction = new HashSet<RolAction>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public uint IdModule { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Module IdModuleNavigation { get; set; }
        public virtual ICollection<RolAction> RolAction { get; set; }
    }
}
