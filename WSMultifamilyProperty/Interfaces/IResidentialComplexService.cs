using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSMultifamilyProperty.Models;
using WSMultifamilyProperty.Models.Request;
using WSMultifamilyProperty.Models.Response;

namespace WSMultifamilyProperty.Interfaces
{
   public interface IResidentialComplexService
    {
        public void Add(ResidentialComplexRequest request);

        public void Update(ResidentialComplexRequest request);

        public List<ResidentialComplexResponse> Get();

        public void Delete(ResidentialComplexRequest request);

    }
}
