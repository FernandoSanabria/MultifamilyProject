using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSMultifamilyProperty.Models.Request;

namespace WSMultifamilyProperty.Interfaces
{
   public interface IResidentialComplexService
    {
        public void Add(ResidentialComplexRequest request);

    }
}
