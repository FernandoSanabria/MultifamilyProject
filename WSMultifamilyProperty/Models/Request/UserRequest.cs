using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSMultifamilyProperty.Models.Request
{
    public class UserRequest
    {
        public ulong Id { get; set; }


        [Required]
        public string Username { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Firstname { get; set; }


        [Required]
        public ulong Phonenumber { get; set; }

    
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public uint IdRole { get; set; }

        public uint IdOptinalRole { get; set; }

        public string Tenure { get; set; }

        [Required]
        public ulong IdResidentialComplex { get; set; }

        public ulong IdDwelling { get; set; }


    }
}
