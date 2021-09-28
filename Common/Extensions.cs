using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Extensions
    {
        /// <summary>
        /// This is extension method for service collections,
        /// the purpose of the method is to register all types
        /// </summary>
        /// <param name="param">An object representing a type in the assembly that will be returned.</param>
        /// <returns>The assembly in which the specified type is defined.</returns>
        public static IServiceCollection RegisterAllTypes(this IServiceCollection services, ServiceLifetime serviceLifetime, Type param)
        {
            var assembly = Assembly.GetAssembly(param);

            var types = assembly.GetTypes().Where(x => x.IsInterface && x.IsAbstract)
                .Select(t => new
                {
                    Service = t,
                    Implementation = assembly.GetTypes().FirstOrDefault(x => t.IsAssignableFrom(x))
                }).ToList();

            foreach (var type in types)
            {
                if (serviceLifetime == ServiceLifetime.Scoped)
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
                else if (serviceLifetime == ServiceLifetime.Singleton)
                {
                    services.AddSingleton(type.Service, type.Implementation);
                }
                else
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
            }

            return services;
        }
    }
}
