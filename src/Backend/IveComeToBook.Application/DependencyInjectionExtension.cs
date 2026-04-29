using IveComeToBook.Application.Services.Mapping;
using Microsoft.Extensions.DependencyInjection;
namespace IveComeToBook.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddMapperConfigurations();
        }

        private static void AddMapperConfigurations()
        {
            MapConfiguration.Configure();
        }
    }
}