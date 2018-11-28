using System;
using Microsoft.Extensions.DependencyInjection;
using TheHunt.Data.Internal;

namespace TheHunt.Data
{
    public static class CompositionRoot
    {
        public static void AddTheHuntData(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IJobPostRepository, JobPostRepository>();

            services.AddTransient<ICompanyRepository, CompanyRepository>();
        }
    }
}