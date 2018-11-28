using System;
using Microsoft.Extensions.DependencyInjection;
using TheHunt.Service.Internal;

namespace TheHunt.Service
{
    public static class CompositionRoot
    {
        public static void AddTheHuntService(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddTransient<IUserService, UserService>();
        }
    }
}