using FluentValidation;
using IveComeToBook.Communication.Requests;

namespace IveComeToBook.Application.UseCases.User.Register
{
    public class RegisterUserValidator: AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Name).NotEmpty();
            RuleFor(user => user.Email).NotEmpty();
            RuleFor(user => user.Email).EmailAddress();
            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6);
        }
    }
}
