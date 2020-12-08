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
    public class BuildingController : ControllerBase
    {
        private IBuildingService _buildingService;

        public BuildingController (IBuildingService buildingService)
        {
            this._buildingService = buildingService;
        }


        [HttpPost]
        public IActionResult Add(BuildingRequest request)
        {
            Answer answer = new Answer();

            try
            {
                _buildingService.Add(request);
                answer.Successful = true;
            }
            catch (Exception err)
            {
                answer.Message = err.Message;
            }

            return Ok(answer);
        }

        [HttpPut]
        public IActionResult Update(BuildingRequest request)
        {
            Answer answer = new Answer();

            try
            {
                _buildingService.Update(request);
                answer.Successful = true;
            }
            catch (Exception err)
            {
                answer.Message = err.Message;
            }

            return Ok(answer);
        }

        [HttpDelete]
        public IActionResult Delete(BuildingRequest request)
        {
            Answer answer = new Answer();

            try
            {
                _buildingService.Delete(request);
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
                answer.Data = _buildingService.Get();
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
