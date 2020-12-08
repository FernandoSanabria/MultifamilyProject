using System;
using System.Collections.Generic;

namespace WSMultifamilyProperty.Models
{
    public partial class User
    {
        public ulong Id { get; set; }
        public string Username { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public ulong Phonenumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool? Active { get; set; }
        public uint IdRole { get; set; }
        public uint? IdOptionalRole { get; set; }
        public string Tenure { get; set; }
        public ulong IdResidentialComplex { get; set; }
        public ulong? IdDwelling { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Dwelling IdDwellingNavigation { get; set; }
        public virtual Role IdOptionalRoleNavigation { get; set; }
        public virtual ResidentialComplex IdResidentialComplexNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
    }
}
