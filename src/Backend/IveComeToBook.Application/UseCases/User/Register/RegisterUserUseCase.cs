using IveComeToBook.Application.Services.Cryptography;
using IveComeToBook.Communication.Requests;
using IveComeToBook.Communication.Responses;
using IveComeToBook.Domain.Repositories.User;
using IveComeToBook.Exceptions.ExceptionsBase;
using Mapster;
using MapsterMapper;

namespace IveComeToBook.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IMapper _mapper;

        public RegisterUserUseCase(IUserReadOnlyRepository userReadOnlyRepository, IUserWriteOnlyRepository userWriteOnlyRepository, IMapper mapper)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _mapper = mapper;
        }
        public async Task <ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
        {
            Validate(request);

            var encryptedPassword = new PasswordEncripter();

            var user = _mapper.Map<Domain.Entities.User>(request);

            user.Password = encryptedPassword.Encrypt(request.Password);

            await _userWriteOnlyRepository.Add(user);

            return _mapper.Map<ResponseRegisterUserJson>(user);
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
