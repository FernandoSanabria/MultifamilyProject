using System;
using System.Collections.Generic;

namespace WSMultifamilyProperty.Models
{
    public partial class ResidentialComplex
    {
        public ResidentialComplex()
        {
            Building = new HashSet<Building>();
            ManagementFees = new HashSet<ManagementFees>();
            PropertyMaintenance = new HashSet<PropertyMaintenance>();
            PropertyRevenue = new HashSet<PropertyRevenue>();
            User = new HashSet<User>();
        }

        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ulong Phonenumber { get; set; }
        public bool? Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual ICollection<Building> Building { get; set; }
        public virtual ICollection<ManagementFees> ManagementFees { get; set; }
        public virtual ICollection<PropertyMaintenance> PropertyMaintenance { get; set; }
        public virtual ICollection<PropertyRevenue> PropertyRevenue { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
