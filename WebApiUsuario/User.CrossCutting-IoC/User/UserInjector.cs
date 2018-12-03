using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.User.Repository;
using User.Infra.Data.User.Repository;

namespace User.CrossCutting_IoC.User
{
   public  class UserInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
           
            RegisterAppRepository(services);
           
        }
        private static void RegisterAppRepository(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            
        }
    }
}
