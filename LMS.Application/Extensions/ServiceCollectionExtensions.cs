using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationPackages(this IServiceCollection services)
        {
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddMediatR(r => r.RegisterServicesFromAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
