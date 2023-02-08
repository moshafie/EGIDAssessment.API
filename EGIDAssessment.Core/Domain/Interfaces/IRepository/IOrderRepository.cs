using EGIDAssessment.Core.Domain.Dtos;
using EGIDAssessment.Core.Domain.Dtos.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Interfaces.IRepository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDto>> GetOrderList();
        Task<bool> AddOrder(OrderParameter order);
    }
}
