using AutoMapper;
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
        public void StokeMap()
        {
            CreateMap<Stock, StokeDto>()
                 .ForMember(dest => dest.StokeId, opt => opt.MapFrom(src => src.ID))
                 .ForMember(dest => dest.StockName, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                 .ReverseMap();
        }
    }
}
