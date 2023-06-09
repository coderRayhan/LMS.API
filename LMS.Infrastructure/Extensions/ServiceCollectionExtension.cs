using LMS.Application.Interfaces.Repositories;
using LMS.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ILookupRepository, LookupRepository>();
            services.AddTransient<ILookupDetailsRepository, LookupDetailsRepository>();
        }
    }
}
