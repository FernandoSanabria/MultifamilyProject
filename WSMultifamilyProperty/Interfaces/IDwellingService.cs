using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSMultifamilyProperty.Models;
using WSMultifamilyProperty.Models.Request;
using WSMultifamilyProperty.Models.Response;

namespace WSMultifamilyProperty.Interfaces
{
    public interface IDwellingService
    {
        public void Add(DwellingRequest request);
        public void Delete(DwellingRequest request);

        public void Update(DwellingRequest request);

        public List<DwellingResponse> Get();

    }
}
