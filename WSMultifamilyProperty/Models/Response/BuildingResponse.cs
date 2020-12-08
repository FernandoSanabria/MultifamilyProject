using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSMultifamilyProperty.Models.Response
{
    public class BuildingResponse
    {

        public ulong Id { get; set; }
        public string Name { get; set; }
        public ulong IdResidentialComplex { get; set; }


        public BuildingResponse(ulong Id, string Name, ulong IdResidentialComplex)
        {
            this.Id = Id;
            this.Name = Name;
            this.IdResidentialComplex = IdResidentialComplex;
        }

    }
}
