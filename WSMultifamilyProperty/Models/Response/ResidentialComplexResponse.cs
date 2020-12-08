using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSMultifamilyProperty.Models.Response
{
    public class ResidentialComplexResponse
    {

        public ulong Id { get; set; }

    
        public string Name { get; set; }

        public string Address { get; set; }

        public ulong Phonenumber { get; set; }

        public ResidentialComplexResponse(ulong Id, string Name, string Address, ulong Phonenumber)
        {
            this.Name = Name;
            this.Id = Id;
            this.Address = Address;
            this.Phonenumber = Phonenumber;
        }

    }
}
