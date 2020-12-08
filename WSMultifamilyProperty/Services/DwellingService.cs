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
    public class DwellingService : IDwellingService
    {

        public void Add(DwellingRequest request)
        {

            using (MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {
                var dwelling = new Dwelling();

                try
                {
                    dwelling.IdBuilding = request.IdBuilding;
                    dwelling.Name = request.Name;

                    db.Dwelling.Add(dwelling);
                    db.SaveChanges();
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }

            }
        }


        public void Update(DwellingRequest request)
        {
            using (MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {

                var dwelling = db.Dwelling.Find(request.Id);

                try
                {

                    dwelling.Name = request.Name;
                    db.Entry(dwelling).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }

            }
        }


        public void Delete(DwellingRequest request)
        {
            using (MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {

                var dwelling = db.Dwelling.Find(request.Id);

                try
                {

                    dwelling.Active = false;
                    db.Entry(dwelling).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }

            }
        }


        public List<DwellingResponse> Get()
        {
            using (MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {
                try
                {
                    var dwelllingList = db.Dwelling.Where(x=> x.Active==true).ToList();
                    //var residentialComplexListFiltered = residentialComplexList.Select(x => new ResidentialComplexRequest(x.Id, x.Name, x.Address, x.Phonenumber)).ToList();
                    var dwelllingListFiltered = dwelllingList.ConvertAll(x => new DwellingResponse(x.Id, x.Name, x.IdBuilding));

                    return dwelllingListFiltered;

                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }

            }
        }



    }
}
