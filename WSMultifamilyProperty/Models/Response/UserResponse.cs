using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSMultifamilyProperty.Models.Response
{
    public class UserResponse
    {
        public ulong Id { get; set; }
        public string Username { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public ulong Phonenumber { get; set; }
        public string Email { get; set; }
        public uint IdRole { get; set; }
        public uint? IdOptionalRole { get; set; }
        public string Tenure { get; set; }
        public ulong IdResidentialComplex { get; set; }
        public ulong? IdDwelling { get; set; }

        public UserResponse(ulong Id, string Username, string Lastname, string Firstname,
                            ulong Phonenumber, string Email, uint IdRole, string Tenure, ulong IdResidentialComplex, uint? IdOptionalRole = null, ulong? IdDwelling=null)
        {
            this.Id = Id;
            this.Username = Username;
            this.Lastname = Lastname;
            this.Firstname = Firstname;
            this.Phonenumber = Phonenumber;
            this.Email = Email;
            this.IdRole = IdRole;
            this.Tenure = Tenure;
            this.IdResidentialComplex = IdResidentialComplex;
            this.IdDwelling = IdDwelling;
            this.IdOptionalRole = IdOptionalRole;
        }


    }
}
