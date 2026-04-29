namespace IveComeToBook.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException: IveComeTooBookException
    {
        public IList<string> ErrorMessages { get; set; }

        public ErrorOnValidationException(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
