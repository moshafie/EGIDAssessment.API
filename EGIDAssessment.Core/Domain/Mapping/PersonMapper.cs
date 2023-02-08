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
        public void PersonMap()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(des => des.BrokerId, opt => opt.MapFrom(res => res.BrokerId))
                .ForMember(des => des.Name, opt => opt.MapFrom(res => res.Name))

                .ReverseMap(); ;
        }
    }
}
