using EGIDAssessment.Core.Domain.BaseBusiness;
using EGIDAssessment.Core.Domain.Dtos;
using EGIDAssessment.Core.Domain.Dtos.Base;
using EGIDAssessment.Core.Domain.Entity;
using EGIDAssessment.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Infrastructure.Repository
{
    public class StokeRepository :BusinessBase<Stock>, IStokeRepository
    {
        public StokeRepository(IBusinessBaseParameter<Stock> businessBaseParameter):
            base(businessBaseParameter)
        {
        }
        public async Task<List<StokeDto>> GetAllStokes()
        {
            try
            {
                var AllStokes = await UnitOfWork.Repository.GetAll();
                var stokesDto = _Mapper.Map<List<Stock>, List<StokeDto>>(AllStokes.ToList());
                return stokesDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
