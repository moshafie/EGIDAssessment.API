using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using EGIDAssessment.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using EGIDAssessment.Infrastructure.InitialDataInitializer;
using EGIDAssessment.Core.Domain.Interfaces;
using EGIDAssessment.Infrastructure.Repository;
using EGIDAssessment.Core.Domain.Interfaces.IRepository;
using EGIDAssessment.Core.Domain.Interfaces.IUnityOfWork;
using EGIDAssessment.Infrastructure.Repository.UnitofWork;
using EGIDAssessment.Infrastructure.Repository.GenaricRepository;
using EGIDAssessment.Core.Domain.BaseBusiness;
using EGIDAssessment.Core.Domain.Dtos.Base;
using AutoMapper;

namespace EGIDAssessment.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDataInitializer, DataInitializer>();
            services.AddTransient<IStokeRepository, StokeRepository>();
            services.AddTransient<IBrokerRepository, BrokerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IBusinessBaseParameter<>), typeof(BusinessBaseParameter<>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSignalRCore();
            return services;
        }
      
    }
}
