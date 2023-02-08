using EGIDAssessment.Core.Domain.BaseBusiness;
using EGIDAssessment.Core.Domain.Dtos;
using EGIDAssessment.Core.Domain.Dtos.Base;
using EGIDAssessment.Core.Domain.Dtos.Parameters;
using EGIDAssessment.Core.Domain.Entity;
using EGIDAssessment.Core.Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Infrastructure.Repository
{
    public class BrokerRepository : BusinessBase<Broker>, IBrokerRepository
    {
        public BrokerRepository(IBusinessBaseParameter<Broker> businessBase)
            :base(businessBase)
        {

        }

        public async Task<int> AddOrUpdate(BrokerDto broker)
        {
            var IsBroker =await GetById(broker.ID);
            if (IsBroker != null)
                return await Update(broker);
            else
              return  await Add(broker);
        }
        public async Task<int> Add(BrokerDto broker)
        {
            var parameter = _Mapper.Map<BrokerDto, Broker>(broker);
            UnitOfWork.Repository.Add(parameter);
            var UpdateRestult = await UnitOfWork.SaveChanges();
            return UpdateRestult;
        }
        public async Task<int> Delete(int id)
        {
             UnitOfWork.Repository.Remove(w => w.ID == id);
          return  await UnitOfWork.SaveChanges();

        }

        public async Task<IEnumerable<BrokerDto>> GetAll()
        {
            var result =await UnitOfWork.Repository.GetAll(p=>p.person);
            var resultDto = _Mapper.Map<IEnumerable < Broker > ,IEnumerable < BrokerDto > >(result);
            return resultDto;
        }

        public async Task<BrokerDto> GetById(int id)
        {
            var result = await UnitOfWork.Repository.FirstOrDefault(w=>w.ID==id);
            var resultDto = _Mapper.Map<Broker,BrokerDto>(result);
            return resultDto;
        }

        public async Task<int> Update(BrokerDto broker)
        {
            var parameter = _Mapper.Map<BrokerDto, Broker>(broker);
             UnitOfWork.Repository.Update(parameter);
            var UpdateRestult = await UnitOfWork.SaveChanges();
            return UpdateRestult  ;
        }
    }
}
