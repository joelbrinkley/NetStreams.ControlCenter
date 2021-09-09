using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetStreams.ControlCenter.Models;
using NetStreams.ControlCenter.WebApi.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StreamProcessorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StreamProcessorsController> _logger;

        public StreamProcessorsController(IMediator mediator, ILogger<StreamProcessorsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [ProducesResponseType(typeof(List<StreamProcessor>), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var streamProcessors = await _mediator.Send(new GetAllStreamProcessorsQuery());
            return Ok(streamProcessors);
        }
    }
}
