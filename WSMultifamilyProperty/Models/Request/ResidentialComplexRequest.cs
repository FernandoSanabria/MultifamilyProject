using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSMultifamilyProperty.Models.Request
{
    public class ResidentialComplexRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public ulong Phonenumber { get; set; }

    }
}
