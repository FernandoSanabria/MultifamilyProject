using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSMultifamilyProperty.Interfaces;
using WSMultifamilyProperty.Models.Request;
using WSTest.Models.Response;

namespace WSMultifamilyProperty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController (IUserService userService)
        {
            this._userService = userService;
        }


        [HttpPost]
        
        public IActionResult Add (UserRequest request)
        {
            Answer answer = new Answer();
            try
            {
                _userService.Add(request);
                answer.Successful = true;
            }
            catch (Exception err)
            {
                answer.Message = err.Message;
            }

            return Ok(answer);
        }


        [HttpPut]

        public IActionResult Update(UserRequest request)
        {
            Answer answer = new Answer();
            try
            {
                _userService.Update(request);
                answer.Successful = true;
            }
            catch (Exception err)
            {
                answer.Message = err.Message;
            }

            return Ok(answer);
        }


        [HttpDelete]

        public IActionResult Delete(UserRequest request)
        {
            Answer answer = new Answer();
            try
            {
                _userService.Delete(request);
                answer.Successful = true;
            }
            catch (Exception err)
            {
                answer.Message = err.Message;
            }

            return Ok(answer);
        }



        [HttpGet]

        public IActionResult Get()
        {
            Answer answer = new Answer();
            try
            {
                answer.Data = _userService.Get();
                answer.Successful = true;
            }
            catch (Exception err)
            {
                answer.Message = err.Message;
            }

            return Ok(answer);
        }

    }
}
