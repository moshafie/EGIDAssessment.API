using EGIDAssessment.Core.Domain.Dtos;
using EGIDAssessment.Core.Domain.Interfaces;
using EGIDAssessment.Core.Domain.Interfaces.IRepository;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Services.SignalR
{
    public class StockHub : Hub
    {
        private readonly ITimerManager timer;
        public StockHub(ITimerManager timer)
        {
            this.timer = timer;
        }
       public async Task NotifyPrice(List<StokeDto>stokeDtos)
        {
            timer.PrepareTimer(async () => await Clients.All.SendAsync("ReceiveNewPrice", stokeDtos));
        }
    }
}
