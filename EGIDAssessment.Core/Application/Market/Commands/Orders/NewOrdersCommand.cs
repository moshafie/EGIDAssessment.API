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
    public class NewOrdersCommand:IRequest<bool>
    {
        public OrderParameter NewOrder { get; set; }
        public NewOrdersCommand(OrderParameter NewOrder)
        {
            this.NewOrder = NewOrder;
        }
    }
    public class NewOrdersCommandHandler : IRequestHandler<NewOrdersCommand, bool>
    {
        public IOrderRepository OrderRepository { get; set; }
        public NewOrdersCommandHandler(IOrderRepository orderRepository)
        {
            this.OrderRepository = orderRepository;
        }
        public Task<bool> Handle(NewOrdersCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var IsSavedSuccess = OrderRepository.AddOrder(request.NewOrder);
                return IsSavedSuccess;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
