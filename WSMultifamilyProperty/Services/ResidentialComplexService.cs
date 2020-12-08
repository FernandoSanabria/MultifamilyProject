using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSMultifamilyProperty.Interfaces;
using WSMultifamilyProperty.Models;
using WSMultifamilyProperty.Models.Request;
using WSMultifamilyProperty.Models.Response;

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
                    throw new Exception(err.Message);
                }

            }
        }

        public void Update(ResidentialComplexRequest request)
        {
            using (MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {

                var residentialComplex = db.ResidentialComplex.Find(request.Id);

                try
                {

                    residentialComplex.Address = request.Address;
                    residentialComplex.Name = request.Name;
                    residentialComplex.Phonenumber = request.Phonenumber;

                    db.Entry(residentialComplex).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }

            }
        }

        public List<ResidentialComplexResponse> Get()
        {
            using (MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {
                try
                {
                    var residentialComplexList = db.ResidentialComplex.ToList();
                    //var residentialComplexListFiltered = residentialComplexList.Select(x => new ResidentialComplexRequest(x.Id, x.Name, x.Address, x.Phonenumber)).ToList();
                    var residentialComplexListFiltered = residentialComplexList.ConvertAll(x => new ResidentialComplexResponse(x.Id, x.Name, x.Address, x.Phonenumber));

                    return residentialComplexListFiltered;

                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }

            }
        }


        public void Delete(ResidentialComplexRequest request)
        {
            using (MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {

                var residentialComplex = db.ResidentialComplex.Find(request.Id);

                try
                {

                    residentialComplex.Active = false;
                    db.Entry(residentialComplex).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }

            }
        }

    }
}
