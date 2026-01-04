using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddDomainDI(this IServiceCollection services)
        {
            return services;
        }
    }
}
