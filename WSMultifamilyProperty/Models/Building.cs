using System;
using System.Collections.Generic;

namespace WSMultifamilyProperty.Models
{
    public partial class Building
    {
        public Building()
        {
            Dwelling = new HashSet<Dwelling>();
        }

        public ulong Id { get; set; }
        public string Name { get; set; }
        public ulong IdResidentialComplex { get; set; }
        public bool? Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual ResidentialComplex IdResidentialComplexNavigation { get; set; }
        public virtual ICollection<Dwelling> Dwelling { get; set; }
    }
}
