using System;
using System.Collections.Generic;

namespace WSMultifamilyProperty.Models
{
    public partial class RolAction
    {
        public uint Id { get; set; }
        public uint IdRole { get; set; }
        public uint IdAction { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Action IdActionNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
    }
}
