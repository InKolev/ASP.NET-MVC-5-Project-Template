namespace MvcTemplate.Web.Infrastructure.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    public class AutoMapperConfig
    {
        public static MapperConfiguration Configuration { get; private set; }

        public void RegisterMappings(Assembly assembly)
        {
            Configuration = new MapperConfiguration(
                config =>
                {
                    // TODO: Check from which assembly the types are loaded and change it if there are performance issues
                    var types = assembly.GetExportedTypes();
                    RegisterStandardMappings(types, config);
                    RegisterReverseMappings(types, config);
                    RegisterCustomMappings(types, config);
                });
        }

        private static void RegisterStandardMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapperConfiguration)
        {
            var maps = from t in types
                       from i in t.GetInterfaces()
                       where i.IsGenericType &&
                             i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                             !t.IsAbstract &&
                             !t.IsInterface
                       select new
                       {
                           Source = i.GetGenericArguments()[0],
                           Destination = t
                       };

            foreach (var map in maps)
            {
                mapperConfiguration.CreateMap(map.Source, map.Destination);
            }
        }

        private static void RegisterReverseMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapperConfiguration)
        {
            var maps = from t in types
                       from i in t.GetInterfaces()
                       where i.IsGenericType &&
                             i.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                             !t.IsAbstract &&
                             !t.IsInterface
                       select new
                       {
                           Destination = i.GetGenericArguments()[0],
                           Source = t
                       };

            foreach (var map in maps)
            {
                mapperConfiguration.CreateMap(map.Source, map.Destination);
            }
        }

        private static void RegisterCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapperConfiguration)
        {
            var maps = from t in types
                       from i in t.GetInterfaces()
                       where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                             !t.IsAbstract &&
                             !t.IsInterface
                       select (IHaveCustomMappings)Activator.CreateInstance(t);

            foreach (var map in maps)
            {
                map.CreateMappings(mapperConfiguration);
            }
        }
    }
}
