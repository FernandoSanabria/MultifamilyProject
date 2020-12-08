using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSMultifamilyProperty.Models.Response
{
    public class DwellingResponse
    {

        public ulong Id { get; set; }

        public string Name { get; set; }

        public ulong IdBuilding { get; set; }

        public DwellingResponse (ulong Id, string Name, ulong IdBuilding)
        {
            this.Id = Id;
            this.Name = Name;
            this.IdBuilding = IdBuilding;
        }

    }
}
