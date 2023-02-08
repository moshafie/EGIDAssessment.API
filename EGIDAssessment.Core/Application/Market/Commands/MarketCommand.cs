using EGIDAssessment.Core.Domain.Dtos;

using EGIDAssessment.Core.Domain.Interfaces;
using EGIDAssessment.Core.Domain.Interfaces.IMarketBusiness;
using EGIDAssessment.Core.Domain.Interfaces.IRepository;
using EGIDAssessment.Core.Domain.Services;
using EGIDAssessment.Core.Domain.Services.SignalR;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Application.Commands
{
    public class MarketCommand : IRequest<List<StokeDto>>
    {

    }

    public class MarketCommandHandler : IRequestHandler<MarketCommand, List<StokeDto>>
    {
        private readonly IStokeRepository stokeRepository;
        private readonly IHubContext<StockHub> hubContext;
        private readonly ITimerManager timer;
        public MarketCommandHandler(IStokeRepository stokeRepository,
            IHubContext<StockHub> hubContext, ITimerManager timer)
        {
            this.stokeRepository = stokeRepository;
            this.hubContext = hubContext;
            this.timer = timer;
        }
        public async Task<List<StokeDto>> Handle(MarketCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await getData();

                return data;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
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
    }

}
