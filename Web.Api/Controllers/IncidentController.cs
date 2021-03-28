using bARTSolution.Domain.Services;
using bARTSolutionWeb.Domain.Services.Models;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace bARTSolution.Web.Api.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public async Task<IActionResult> Get()
        {
            return Ok(await incidentService.GetIncidentsAsync());
        }

        /// <summary>
        /// Returns incident by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            if (string.IsNullOrEmpty(name))
                BadRequest($"Name can`t be null or empty.");

            return Ok(await incidentService.GetIncidentAsync(name));
        }

        /// <summary>
        /// Create incident.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IncidentViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var result = await incidentService.CreateIncidentAsync(model);

            if (result != null)
                return Ok(result);

            return BadRequest();
        }

        /// <summary>
        /// Delete incident by name.
        /// </summary>
        /// <param name="name"></param>
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            return Ok(await incidentService.DeleteIncidentAsync(name));
        }
    }
}
