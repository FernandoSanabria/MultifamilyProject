using System;
using System.Collections.Generic;

namespace WSMultifamilyProperty.Models
{
    public partial class PropertyRevenue
    {
        public ulong Id { get; set; }
        public string Concept { get; set; }
        public decimal Revenue { get; set; }
        public string Type { get; set; }
        public ulong IdResidentialComplex { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual ResidentialComplex IdResidentialComplexNavigation { get; set; }
    }
}
