using EGIDAssessment.Core.Domain.Dtos;
using EGIDAssessment.Core.Domain.Dtos.Parameters;
using EGIDAssessment.Core.Domain.Interfaces.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Application.Commands.Orders
{
    public class OrdersQuery: IRequest<List<OrderDto>>
    {
        
    }
    public class OrdersQueryHandler : IRequestHandler<OrdersQuery, List<OrderDto>>
    {
        public IOrderRepository OrderRepository { get; set; }
        public OrdersQueryHandler(IOrderRepository orderRepository)
        {
            this.OrderRepository = orderRepository;
        }
        public async Task<List<OrderDto>> Handle(OrdersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var IsSavedSuccess = await OrderRepository.GetOrderList();
                return IsSavedSuccess.ToList();
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}
