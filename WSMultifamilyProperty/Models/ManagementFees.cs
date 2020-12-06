using System;
using System.Collections.Generic;

namespace WSMultifamilyProperty.Models
{
    public partial class ManagementFees
    {
        public ulong Id { get; set; }
        public ulong IdDwelling { get; set; }
        public ulong IdResidentialComplex { get; set; }
        public decimal Fee { get; set; }
        public short Year { get; set; }
        public string Month { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Dwelling IdDwellingNavigation { get; set; }
        public virtual ResidentialComplex IdResidentialComplexNavigation { get; set; }
    }
}
