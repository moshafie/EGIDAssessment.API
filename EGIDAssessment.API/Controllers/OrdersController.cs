using EGIDAssessment.Core.Application.Commands.Orders;
using EGIDAssessment.Core.Domain.Dtos.Parameters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EGIDAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController (IMediator mediator) => this._mediator = mediator;
        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _mediator.Send(new OrdersQuery());
                var x = JsonSerializer.Serialize(result);
                return Ok(x);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderParameter orderParameter)
        {
            try
            {
                return Ok(await _mediator.Send(new NewOrdersCommand(orderParameter)));

            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
