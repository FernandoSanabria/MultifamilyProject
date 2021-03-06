﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSMultifamilyProperty.Interfaces;
using WSMultifamilyProperty.Models;
using WSMultifamilyProperty.Models.Request;
using WSTest.Models.Response;

namespace WSMultifamilyProperty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentialComplexController : ControllerBase
    {

        private IResidentialComplexService _residentialComplexService;

        public ResidentialComplexController (IResidentialComplexService residentialComplexService)
        {
            this._residentialComplexService = residentialComplexService;
        }

        [HttpPost]
        public IActionResult Add(ResidentialComplexRequest request)
        {
            Answer answer = new Answer();

            try
            {
                _residentialComplexService.Add(request);
                answer.Successful = true;
            }
            catch (Exception err)
            {
                answer.Message = err.Message;
            }

            return Ok(answer);
        }


        [HttpPut]
        public IActionResult Update(ResidentialComplexRequest request)
        {
            Answer answer = new Answer();

            try
            {
                _residentialComplexService.Update(request);
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
                answer.Data = _residentialComplexService.Get();
                answer.Successful = true;
            }
            catch (Exception err)
            {
                answer.Message = err.Message;
            }

            return Ok(answer);
        }


        [HttpDelete]
        public IActionResult Delete(ResidentialComplexRequest request)
        {
            Answer answer = new Answer();

            try
            {
                _residentialComplexService.Delete(request);
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
