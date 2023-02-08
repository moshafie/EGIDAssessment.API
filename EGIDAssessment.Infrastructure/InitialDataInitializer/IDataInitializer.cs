using EGIDAssessment.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Infrastructure.InitialDataInitializer
{
    public interface IDataInitializer
    {
        List<Stock> GetInitialStoks();

    }
}
