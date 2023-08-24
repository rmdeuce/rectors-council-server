﻿using AutoMapper;
using System.Reflection;

namespace Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly)
        {
            ApplyMappingsAssembly(assembly);
        }

        private void ApplyMappingsAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                   .Where(
                        type => type.GetInterfaces()
                        .Any(type => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IMapWith<>))
                   ).ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
