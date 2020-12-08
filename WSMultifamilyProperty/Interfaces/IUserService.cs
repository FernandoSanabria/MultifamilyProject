using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSMultifamilyProperty.Models.Request;
using WSMultifamilyProperty.Models.Response;

namespace WSMultifamilyProperty.Interfaces
{
    public interface IUserService
    {

        public void Add(UserRequest request);

        public void Update(UserRequest request);

        public void Delete(UserRequest request);


        public List<UserResponse> Get();

    }
}
