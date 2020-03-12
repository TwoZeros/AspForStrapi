using AspforStrapi.Services.Contract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspforStrapi.Services.infrasturture
{
    public class ContainerConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
        
            services.AddTransient<IAuthService, AuthorizationService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
