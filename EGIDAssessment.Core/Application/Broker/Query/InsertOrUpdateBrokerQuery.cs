using EGIDAssessment.Core.Domain.Dtos;
using EGIDAssessment.Core.Domain.Interfaces.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Application.Broker.Query
{
    public class InsertOrUpdateBrokerQuery :IRequest<int>
    {
        public BrokerDto Broker { get; set; }
        public InsertOrUpdateBrokerQuery(BrokerDto brokerDto)
        {
            this.Broker = brokerDto;
        }
    }
    public class InsertOrUpdateBrokerHandler : IRequestHandler<InsertOrUpdateBrokerQuery, int>
    {
        public IBrokerRepository brokerRepository;
        public InsertOrUpdateBrokerHandler(IBrokerRepository brokerRepository) => this.brokerRepository = brokerRepository; 
        public async Task<int> Handle(InsertOrUpdateBrokerQuery request, CancellationToken cancellationToken)
        {
            return await brokerRepository.AddOrUpdate(request.Broker);
        }
    }
}
