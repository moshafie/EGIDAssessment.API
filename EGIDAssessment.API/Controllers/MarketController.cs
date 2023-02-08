using EGIDAssessment.Core.Application;
using EGIDAssessment.Core.Application.Commands;
using EGIDAssessment.Core.Domain.Dtos;
using EGIDAssessment.Core.Domain.Entity;
using EGIDAssessment.Core.Domain.Interfaces;
using EGIDAssessment.Core.Domain.Interfaces.IRepository;
using EGIDAssessment.Core.Domain.Services.SignalR;
using EGIDAssessment.Infrastructure.DataContext;
using EGIDAssessment.Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EGIDAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHubContext<StockHub> hubContext;
        private readonly ITimerManager timer;
        private readonly IStokeRepository stokeRepository;
        private readonly EGIDAssessmentDbContext context;
        List<StokeDto> stocks = new List<StokeDto>();
       
        public MarketController(IMediator mediator, IHubContext<StockHub> hubContext, ITimerManager timer, IStokeRepository stokeRepository)
        {
            this._mediator = mediator;
            this.hubContext = hubContext;
            this.timer = timer;
            this.stokeRepository = stokeRepository;
            
        }
        [NonAction]
        public async Task<List<StokeDto>> ChangePrice(List<StokeDto> stokeDtos)
        {
            var r = new Random();
            foreach (var item in stokeDtos)
            {
                item.Price = r.Next(1, 100);
            }
          
            return stokeDtos;
        }
        [NonAction]
        public async Task<List<StokeDto>> getData()
        {
            var r = new Random();

            var data = await stokeRepository.GetAllStokes();
            foreach (var item in data)
            {
                item.Price = r.Next(1, 100);
            }
            return data.ToList();
        }
        [HttpGet]    
        public async Task<IActionResult> Get()
        {
            try
            {
                if (stocks.Count == 0)
                {
                    stocks.AddRange(await getData());
                }
                if (!timer.IsTimerStarted)
                    timer.PrepareTimer(async () => await hubContext.Clients.All.SendAsync("ReceiveNewPrice", await ChangePrice(stocks)));

                return Ok(new { message = "Connection Done" });
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        // GET: api/<Market>
        [HttpGet("GetAllStocks")]
        public async Task<IActionResult> GetAllStocks()
        {
            try
            {
                stocks.AddRange(await getData());
                return Ok(await _mediator.Send(new MarketCommand()));

            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
          
        }

        // GET api/<Market>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Market>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Market>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Market>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
