using AutoMapper;
using EGIDAssessment.Core.Domain.Interfaces.IUnityOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Dtos.Base
{
    public interface IBusinessBaseParameter<T> where T : class
    {
        IMapper Mapper { get; set; }
        IUnitOfWork<T> UnitOfWork { get; set; }
    }
}
