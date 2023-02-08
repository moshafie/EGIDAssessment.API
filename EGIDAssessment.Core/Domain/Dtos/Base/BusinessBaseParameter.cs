using AutoMapper;
using EGIDAssessment.Core.Domain.Interfaces.IUnityOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Dtos.Base
{
    public class BusinessBaseParameter<T> : IBusinessBaseParameter<T> where T : class
    {

        public BusinessBaseParameter(IMapper mapper, IUnitOfWork<T> unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public IMapper Mapper { get; set; }
        public IUnitOfWork<T> UnitOfWork { get; set; }
    }
}
