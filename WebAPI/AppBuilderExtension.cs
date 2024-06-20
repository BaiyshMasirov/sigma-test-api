using Microsoft.OpenApi.Models;
using System.Reflection;

namespace WebAPI
{
    internal static class AppBuilderExtension
    {
        internal static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var currentAssembly = Assembly.GetExecutingAssembly();
                var xmlDocs = currentAssembly.GetReferencedAssemblies()
                .Union(new AssemblyName[] { currentAssembly.GetName() })
                .Select(a => Path.Combine(Path.GetDirectoryName(currentAssembly.Location), $"{a.Name}.xml"))
                .Where(f => File.Exists(f)).ToArray();
                Array.ForEach(xmlDocs, (d) =>
                {
                    options.IncludeXmlComments(d);
                });

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "sigma API v1",
                    Version = "v1",
                    Description = "sigma REST API v1",
                });
                options.DescribeAllParametersInCamelCase();
            });

            return services;
        }
    }
}