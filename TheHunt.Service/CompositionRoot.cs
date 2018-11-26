using System;
using Microsoft.Extensions.DependencyInjection;

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
        }
    }
}