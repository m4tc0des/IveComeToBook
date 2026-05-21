using IveComeToBook.Communication.Requests;

namespace CommonTestUtilities.Requests;
public class RequestRegisterUserJsonBuilder
{
    public static RequestRegisterUserJson Build()
    {
        return new RequestRegisterUserJson
        {
            Name = "Mateus",
            Email = "mateus@example.com",
            Password = "password123"
        };
    }
}
