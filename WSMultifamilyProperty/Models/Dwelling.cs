using System;
using System.Collections.Generic;

namespace WSMultifamilyProperty.Models
{
    public partial class Dwelling
    {
        public Dwelling()
        {
            ManagementFees = new HashSet<ManagementFees>();
            Pqr = new HashSet<Pqr>();
            Reserve = new HashSet<Reserve>();
            User = new HashSet<User>();
        }

        public ulong Id { get; set; }
        public string Name { get; set; }
        public ulong IdBuilding { get; set; }
        public bool? Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Building IdBuildingNavigation { get; set; }
        public virtual ICollection<ManagementFees> ManagementFees { get; set; }
        public virtual ICollection<Pqr> Pqr { get; set; }
        public virtual ICollection<Reserve> Reserve { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
