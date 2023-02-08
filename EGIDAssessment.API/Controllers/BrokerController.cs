using EGIDAssessment.Core.Application.Broker.Query;
using EGIDAssessment.Core.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EGIDAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokerController : ControllerBase
    {

        private readonly IMediator mediator;
        public BrokerController(IMediator mediator) => this.mediator = mediator;
        // GET: api/<BrokerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await mediator.Send(new GetAllBrokerQuery()));
        }

        // GET api/<BrokerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BrokerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BrokerDto value)
        {
            return Ok(await mediator.Send(value));

        }

        // PUT api/<BrokerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BrokerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
