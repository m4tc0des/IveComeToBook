using IveComeToBook.Communication.Requests;
using IveComeToBook.Communication.Responses;

namespace IveComeToBook.Application.UseCases.User.Register
{
    public  interface IRegisterUserUseCase
    {
        public Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request);
    }
}
