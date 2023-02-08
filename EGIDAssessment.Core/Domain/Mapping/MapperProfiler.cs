using AutoMapper;
using EGIDAssessment.Core.Domain.Dtos;
using EGIDAssessment.Core.Domain.Dtos.Parameters;
using EGIDAssessment.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Mapping
{
    public partial class MapperProfiler : Profile
    {
        public MapperProfiler()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

            CreateMap<Stock, StokeDto>()
              .ForMember(dest => dest.StokeId, opt => opt.MapFrom(src => src.ID))
              .ForMember(dest => dest.StockName, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
              .ReverseMap();
            StokeMap();
            OrderMap();
            PersonMap();
            addOrderMapp();
            BrokerMap();

        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            dynamic types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
