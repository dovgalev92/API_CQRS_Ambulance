using AutoMapper;
using System.Reflection;


namespace Ambulance_API_CQRS.Application.Common.Interfaces.IMapp
{
    public class AssemblyMappingProfiles : Profile
    {
        public AssemblyMappingProfiles(Assembly assembly)
        {
            ApplyMappingAssembly(assembly);
        }
        private void ApplyMappingAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()  
                .Where(type => type.GetInterfaces() 
                .Any(i => i.IsGenericType && 
                i.GetGenericTypeDefinition() == typeof(IMapping<>)))
                .ToList();
            foreach (var type in types)
            {
                var intanse = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(intanse, new object[] {this });
            }
        }
    }
}
