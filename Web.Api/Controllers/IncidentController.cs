using bARTSolution.Domain.Infrastructure.Models;
using bARTSolution.Domain.Services;
using bARTSolutionWeb.Domain.Services.Models;
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

        /// <summary>
        /// Returns all incidents.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(incidentService.GetIncidentsAsync());
        }

        /// <summary>
        /// Returns incident by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            return new OkObjectResult(incidentService.GetIncidentAsync(name));
        }

        /// <summary>
        /// Create incident.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIncidentModel model)
        {
            if (!ModelState.IsValid)
                return new BadRequestObjectResult(ModelState.Values);

            var result = await incidentService.CreateIncidentAsync(model);

            if (result != null)
                return new OkObjectResult(result);

            return new BadRequestResult();
        }

        /// <summary>
        /// Update incident.
        /// </summary>
        /// <param name="model"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] IncidentModel model)
        {
            return new OkObjectResult(await incidentService.UpdateIncidentAsync(model));
        }

        /// <summary>
        /// Delete incident by name.
        /// </summary>
        /// <param name="name"></param>
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            return new OkObjectResult(await incidentService.DeleteIncidentAsync(name));
        }
    }
}
