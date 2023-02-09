using EGIDAssessment.Core.Domain.BaseBusiness;
using EGIDAssessment.Core.Domain.Dtos;
using EGIDAssessment.Core.Domain.Dtos.Base;
using EGIDAssessment.Core.Domain.Dtos.Parameters;
using EGIDAssessment.Core.Domain.Entity;
using EGIDAssessment.Core.Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Infrastructure.Repository
{
    public class OrderRepository :BusinessBase<Order>, IOrderRepository
    {
        
        public OrderRepository(IBusinessBaseParameter<Order> businessBaseParameter)
            : base(businessBaseParameter)
        {
           
        }
        public async Task<bool> AddOrder(OrderParameter order)
        {
            try
            {
                var newOrder = _Mapper.Map<OrderParameter, Order>(order);
                var com =await CalcCommission(order.Price,double.Parse( order.Quantity));
                newOrder.Commission =(double) com;
                var newBrokerOrder = UnitOfWork.Repository.Add(newOrder);
                return await UnitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<OrderDto>> GetOrderList()
        {
            try
            {
                var allBroker = await UnitOfWork.Repository.GetAll(o => o.Stoke,b=>b.Broker ,p=>p.Broker.person);
                var allBrokerList = allBroker.ToList();
                var allBrokerDto = _Mapper.Map< List< Order >,List < OrderDto>>(allBrokerList);
               

                return allBrokerDto;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<double> CalcCommission(double price,double Quantity)
        {
            double totalPrice = price * Quantity;
            double percentComplete = Math.Round((totalPrice *0.02),2);
            return percentComplete;

        }
    }
}
