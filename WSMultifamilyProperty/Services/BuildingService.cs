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
    public class BuildingService : IBuildingService
    {

        public void Add (BuildingRequest request ) {

            using (MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {
                var building = new Building();

                try
                {
                    building.IdResidentialComplex = request.IdResidentialComplex;
                    building.Name = request.Name;

                    db.Building.Add(building);
                    db.SaveChanges();
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }

            }
        }


        public void Update(BuildingRequest request)
        {
            using (MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {

                var building = db.Building.Find(request.Id);

                try
                {

                    building.Name = request.Name;
                    db.Entry(building).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }

            }
        }

        public void Delete(BuildingRequest request)
        {
            using (MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {

                var building = db.Building.Find(request.Id);

                try
                {

                    building.Active = false;
                    db.Entry(building).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }

            }
        }

        public List<BuildingResponse> Get()
        {
            using (MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {
                try
                {
                    var buildingList = db.Building.Where( x => x.Active == true).ToList();
                    //var residentialComplexListFiltered = residentialComplexList.Select(x => new ResidentialComplexRequest(x.Id, x.Name, x.Address, x.Phonenumber)).ToList();
                    var buildingListFiltered = buildingList.ConvertAll(x => new BuildingResponse(x.Id, x.Name, x.IdResidentialComplex));

                    return buildingListFiltered;

                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }

            }
        }


    }
}
