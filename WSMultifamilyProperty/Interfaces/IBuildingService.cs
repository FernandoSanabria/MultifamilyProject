using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSMultifamilyProperty.Models;
using WSMultifamilyProperty.Models.Request;
using WSMultifamilyProperty.Models.Response;

namespace WSMultifamilyProperty.Interfaces
{
    public interface IBuildingService
    {
        public void Add(BuildingRequest request);

        public void Update(BuildingRequest request);

        public void Delete(BuildingRequest request);

        public List<BuildingResponse> Get();
    }
}
