using System;
using System.Collections.Generic;

namespace WSMultifamilyProperty.Models
{
    public partial class Pqr
    {
        public ulong Id { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public ulong? IdDwelling { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Dwelling IdDwellingNavigation { get; set; }
    }
}
