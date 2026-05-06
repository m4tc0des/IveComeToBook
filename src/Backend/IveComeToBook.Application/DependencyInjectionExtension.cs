using IveComeToBook.Application.Services.Cryptography;
using IveComeToBook.Application.Services.Mapping;
using IveComeToBook.Application.UseCases.User.Register;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IveComeToBook.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddMapperConfigurations(services);
            AddUseCases(services);
            AddPasswordEncripter(services, configuration);
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

        private static void AddPasswordEncripter(IServiceCollection services, IConfiguration configuration)
        {
            var additionalKey = configuration.GetValue<string>("Settings:Password:AdditionalKey");
            services.AddScoped(options => new PasswordEncripter(additionalKey!));
        }
    }
}