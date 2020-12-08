using System;
using System.Collections.Generic;

namespace WSMultifamilyProperty.Models
{
    public partial class Role
    {
        public Role()
        {
            RolAction = new HashSet<RolAction>();
            UserIdOptionalRoleNavigation = new HashSet<User>();
            UserIdRoleNavigation = new HashSet<User>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual ICollection<RolAction> RolAction { get; set; }
        public virtual ICollection<User> UserIdOptionalRoleNavigation { get; set; }
        public virtual ICollection<User> UserIdRoleNavigation { get; set; }
    }
}
