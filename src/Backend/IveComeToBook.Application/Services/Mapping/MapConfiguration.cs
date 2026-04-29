using IveComeToBook.Communication.Requests;
using Mapster;

namespace IveComeToBook.Application.Services.Mapping
{
    public static class MapConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<RequestRegisterUserJson, Domain.Entities.User>
                .NewConfig()
                .Ignore(dest => dest.Password);
        }
    }
}
