using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSMultifamilyProperty.Interfaces;
using WSMultifamilyProperty.Models;
using WSMultifamilyProperty.Models.Request;

namespace WSMultifamilyProperty.Services
{
    public class ResidentialComplexService : IResidentialComplexService
    {
        public void Add(ResidentialComplexRequest request)
        {
            using (MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {
                var residentialComplex = new ResidentialComplex();

                try
                {
                    residentialComplex.Address = request.Address;
                    residentialComplex.Name = request.Name;
                    residentialComplex.Phonenumber = request.Phonenumber;

                    db.ResidentialComplex.Add(residentialComplex);
                    db.SaveChanges();
                }
                catch (Exception err)
                {
                    throw new Exception( err.Message);
                }

            }
        }
    }
}
