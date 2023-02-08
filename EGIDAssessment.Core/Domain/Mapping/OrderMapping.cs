using EGIDAssessment.Core.Domain.Dtos;
using EGIDAssessment.Core.Domain.Dtos.Parameters;
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
        public void OrderMap()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(des=>des.personId,opt=>opt.MapFrom(res=>res.PersoneID))
                .ForMember(des => des.StockId, opt => opt.MapFrom(res => res.StockId))
                .ForMember(des => des.BrokerId, opt => opt.MapFrom(res => res.BrokerId))
                .ForMember(des => des.Broker, opt => opt.MapFrom(res => res.Broker))
                .ForMember(des => des.Stoke, opt => opt.MapFrom(res => res.Stoke))
                .ForMember(des => des.Price, opt => opt.MapFrom(res => res.Price))
                .ForMember(des => des.Commission, opt => opt.MapFrom(res => res.Commission))
                .ForMember(des => des.Quantity, opt => opt.MapFrom(res => res.Quantity))
                .ReverseMap();
          
        }
        public void addOrderMapp()
        {
            CreateMap<OrderParameter,Order>()

                .ForMember(res=>res.StockId,opt=>opt.MapFrom(src=>src.StockId))
                .ForMember(res => res.PersoneID, opt => opt.MapFrom(src => src.personId))
                .ForMember(res => res.Person, opt => opt.Ignore())
                .ForMember(res => res.BrokerId, opt => opt.MapFrom(src => src.BrokerId))
                .ForMember(res => res.Commission, opt => opt.Ignore())
                .ReverseMap();
          
        }
    }
}
