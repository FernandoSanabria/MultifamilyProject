using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSMultifamilyProperty.Models.Request
{
    public class DwellingRequest
    {

        public ulong Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ulong IdBuilding { get; set; }

    }
}
