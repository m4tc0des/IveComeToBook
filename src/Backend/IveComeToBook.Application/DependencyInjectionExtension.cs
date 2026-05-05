using IveComeToBook.Application.Services.Cryptography;
using IveComeToBook.Application.Services.Mapping;
using IveComeToBook.Application.UseCases.User.Register;
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
            AddUseCases(services);
            AddPasswordEncripter(services);
        }

        private static void AddMapperConfigurations(IServiceCollection services)
        {

            var config = TypeAdapterConfig.GlobalSettings;

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            MapConfiguration.Configure();
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }

        private static void AddPasswordEncripter(IServiceCollection services)
        {
            services.AddScoped(options => new PasswordEncripter());
        }
    }
}