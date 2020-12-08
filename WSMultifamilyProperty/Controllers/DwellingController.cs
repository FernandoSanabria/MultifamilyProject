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
    public class DwellingController : ControllerBase
    {
        private IDwellingService _dwellingService;

        public DwellingController(IDwellingService dwellingService)
        {
            this._dwellingService = dwellingService;
        }


        [HttpPost]
        public IActionResult Add(DwellingRequest request)
        {
            Answer answer = new Answer();

            try
            {
                _dwellingService.Add(request);
                answer.Successful = true;
            }
            catch (Exception err)
            {
                answer.Message = err.Message;
            }

            return Ok(answer);
        }



        [HttpPut]
        public IActionResult Update(DwellingRequest request)
        {
            Answer answer = new Answer();

            try
            {
                _dwellingService.Update(request);
                answer.Successful = true;
            }
            catch (Exception err)
            {
                answer.Message = err.Message;
            }

            return Ok(answer);
        }


        [HttpDelete]
        public IActionResult Delete(DwellingRequest request)
        {
            Answer answer = new Answer();

            try
            {
                _dwellingService.Delete(request);
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
                answer.Data = _dwellingService.Get();
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
