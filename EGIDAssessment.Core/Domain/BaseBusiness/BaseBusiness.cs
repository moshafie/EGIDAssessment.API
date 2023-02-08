using AutoMapper;
using EGIDAssessment.Core.Domain.Dtos.Base;
using EGIDAssessment.Core.Domain.Interfaces.IUnityOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.BaseBusiness
{
    public class BusinessBase<T> where T : class
    {
        protected readonly IUnitOfWork<T> UnitOfWork;
        protected readonly IMapper _Mapper;
        protected internal BusinessBase(IBusinessBaseParameter<T> businessBaseParameter)
        {
            UnitOfWork = businessBaseParameter.UnitOfWork;
            _Mapper = businessBaseParameter.Mapper;
        }
    }
}
