using IveComeToBook.Communication.Requests;
using IveComeToBook.Communication.Responses;
using IveComeToBook.Exceptions.ExceptionsBase;
using Mapster;

namespace IveComeToBook.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisterUserJson Execute(RequestRegisterUserJson request)
        {
            Validate(request);

            var user = request.Adapt<Domain.Entities.User>();

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
