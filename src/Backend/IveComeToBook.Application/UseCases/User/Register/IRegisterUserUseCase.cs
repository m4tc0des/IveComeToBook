using IveComeToBook.Communication.Requests;
using IveComeToBook.Communication.Responses;
using IveComeToBook.Domain.Repositories.User;
using MapsterMapper;

namespace IveComeToBook.Application.UseCases.User.Register
{
    public  interface IRegisterUserUseCase
    {
        public Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request);
    }
}
