using System;
using System.Collections.Generic;

namespace WSMultifamilyProperty.Models
{
    public partial class Reserve
    {
        public ulong Id { get; set; }
        public string Facility { get; set; }
        public DateTime Date { get; set; }
        public ulong? IdDwelling { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Dwelling IdDwellingNavigation { get; set; }
    }
}
