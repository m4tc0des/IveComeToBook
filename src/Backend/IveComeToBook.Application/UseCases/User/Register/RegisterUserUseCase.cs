using IveComeToBook.Application.Services.Cryptography;
using IveComeToBook.Communication.Requests;
using IveComeToBook.Communication.Responses;
using IveComeToBook.Domain.Repositories.User;
using IveComeToBook.Exceptions.ExceptionsBase;
using Mapster;

namespace IveComeToBook.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;

        public async Task <ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
        {
            Validate(request);

            var encryptedPassword = new PasswordEncripter();

            var user = request.Adapt<Domain.Entities.User>();

            user.Password = encryptedPassword.Encrypt(request.Password);

            await _userWriteOnlyRepository.Add(user);

            return new ResponseRegisterUserJson
            {
                Name = request.Name
            };
        }

        private void Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
