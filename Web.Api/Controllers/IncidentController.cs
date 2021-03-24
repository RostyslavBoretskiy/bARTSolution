using bARTSolution.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bARTSolution.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            this.incidentService = incidentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(incidentService.GetIncidents());
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            return new OkObjectResult(incidentService.GetIncident(name));
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<IncidentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IncidentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
