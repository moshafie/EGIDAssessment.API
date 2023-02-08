using EGIDAssessment.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Interfaces.IRepository
{
    public interface IBrokerRepository
    {
        Task<IEnumerable<BrokerDto>> GetAll();
        Task<BrokerDto> GetById(int id);
        Task<int> Add(BrokerDto broker);
        Task<int> Update(BrokerDto broker);
        Task<int> Delete(int id);
        Task<int> AddOrUpdate(BrokerDto broker);
    }
}
