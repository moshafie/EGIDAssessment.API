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
    public class GetAllBrokerQuery : IRequest<IEnumerable< BrokerDto>>
    {
    }
    public class GetAllBrokerHandler : IRequestHandler<GetAllBrokerQuery, IEnumerable< BrokerDto>>
    {
        public IBrokerRepository brokerRepository;
        public GetAllBrokerHandler(IBrokerRepository brokerRepository) => this.brokerRepository = brokerRepository;
        public async Task<IEnumerable<BrokerDto>> Handle(GetAllBrokerQuery request, CancellationToken cancellationToken)
        {
            return await brokerRepository.GetAll();
        }
    }
}
