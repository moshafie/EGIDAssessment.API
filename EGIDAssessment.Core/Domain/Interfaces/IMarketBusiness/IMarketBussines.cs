using EGIDAssessment.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Interfaces.IMarketBusiness
{
    public interface IMarketBussines
    {
        Task<IEnumerable<StokeDto>> GetStokeList();
    }
}
