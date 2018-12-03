using AutoMapper;
using Domain.Core.Idempotency;
using Domain.Interfaces;
using Infra.Data.Context;

using Microsoft.Extensions.DependencyInjection;
using User.CrossCutting_IoC.User;

namespace CrossCuttingIoC
{
    public class NativeInjector
    {

        public static void RegisterServices(IServiceCollection services)
        {
            
            services.AddSingleton<IRequestManager, InMemoryRequestManager>();
                       // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            UserInjector.RegisterServices(services);
            services.AddScoped<DatabaseContext>();

            // Infra - Data EventSourcing
      

         
        }

   
    }
}
