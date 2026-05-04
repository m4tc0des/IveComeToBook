using IveComeToBook.Application.Services.Mapping;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace IveComeToBook.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddMapperConfigurations(services);
        }

        private static void AddMapperConfigurations(IServiceCollection services)
        {

            var config = TypeAdapterConfig.GlobalSettings;

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            MapConfiguration.Configure();
        }
    }
}