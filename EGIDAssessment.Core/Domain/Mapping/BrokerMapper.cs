using EGIDAssessment.Core.Domain.Dtos;
using EGIDAssessment.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Mapping
{
    public partial class MapperProfiler
    {
        public void BrokerMap()
        {
            CreateMap<Broker, BrokerDto>()
                .ForMember(des=>des.person,opt=>opt.MapFrom(res=>res.person))
                //.ForMember(des => des.Orders, opt => opt.MapFrom(res => res.Orders))
                .ForMember(des => des.Name, opt => opt.MapFrom(res => res.Name))
                .ForMember(des => des.ID, opt => opt.MapFrom(res => res.ID))
                .ReverseMap(); ;
        }
    }
}
