using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ZonyLrcToolsX.Infrastructure.Extensions;

namespace ZonyLrcToolsX.Infrastructure.DependencyInject
{
    public static class AutoDependencyInjectExtensions
    {
        public static IServiceCollection BeginAutoDependencyInject<TAssemblyType>(this IServiceCollection services)
        {
            var allTypes = typeof(TAssemblyType).Assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && !t.IsGenericType)
                .ToArray();

            var transientTypes = allTypes.Where(t => typeof(ITransientDependency).IsAssignableFrom(t));
            var singletonTypes = allTypes.Where(t => typeof(ISingletonDependency).IsAssignableFrom(t));

            transientTypes.Foreach(t =>
            {
                foreach (var exposedService in GetDefaultExposedTypes(t))
                {
                    services.Add(CreateServiceDescriptor(t, exposedService, ServiceLifetime.Transient));
                }
            });

            singletonTypes.Foreach(t =>
            {
                foreach (var exposedService in GetDefaultExposedTypes(t))
                {
                    services.Add(CreateServiceDescriptor(t, exposedService, ServiceLifetime.Singleton));
                }
            });

            return services;
        }

        public static List<Type> GetDefaultExposedTypes(Type type)
        {
            var serviceTypes = new List<Type>();

            foreach (var interfaceType in type.GetTypeInfo().GetInterfaces())
            {
                var interfaceName = interfaceType.Name;

                if (interfaceName.StartsWith("I"))
                {
                    interfaceName = interfaceName.Substring(1, interfaceName.Length - 1);
                }

                if (type.Name.EndsWith(interfaceName))
                {
                    serviceTypes.Add(interfaceType);
                }
            }

            return serviceTypes;
        }

        public static ServiceDescriptor CreateServiceDescriptor(Type implementationType,
            Type exposingServiceType,
            ServiceLifetime lifetime)
        {
            return new ServiceDescriptor(exposingServiceType, implementationType, lifetime);
        }
    }
}