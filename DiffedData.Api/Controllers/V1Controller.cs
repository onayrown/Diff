using DiffedData.Api.DTOs;
using DiffedData.Domain.Entities;
using DiffedData.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DiffedData.Api.Controllers
{
    [Route("[controller]/diff")]
    [ApiController]
    public class V1Controller : ControllerBase
    {
        private readonly IDataServices _dataService;
        public V1Controller(IDataServices dataServices)
        {
            _dataService = dataServices;
        }
             
        // POST: V1/diff
        [Route("{id}/Left")]
        [HttpPost]
        public async Task<IActionResult> Left([FromBody] DiffDto bodyData, string id) =>
             await Handle(bodyData.ToLeftCommand(id));

        // POST: V1/diff
        [Route("{id}/right")]
        [HttpPost]
        public async Task<IActionResult> Right([FromBody] DiffDto bodyData, string id) =>
             await Handle(bodyData.ToRightCommand(id));

        // POST: V1/diff
        [Route("{id}")]
        [HttpPost]
        public async Task<IActionResult> Compare(string id)
        {
            var response = await _dataService.Compare(id);
            if (response.IsValid)
                return Ok(response);
            else
                return BadRequest(response);     
        }  
        
        protected async Task<IActionResult> Handle(DataCommand command)
        {
            try
            {
                var response = await _dataService.AddData(command);

                if (response.IsValid)
                    return Ok(response.Value);
                else
                    return BadRequest(response.Message);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex); ;
            }
        }     
    }
}
