using System.Security.Cryptography;
using System.Text;

namespace IveComeToBook.Application.Services.Cryptography
{
    public class PasswordEncripter
    {
        public string Encrypt(string password)
        {
            var adicionalKey = "7ef72c2a6a307c535152f99b0b2df36e";

            var newPassword = $"{password}{adicionalKey}";

            var bytes = Encoding.UTF8.GetBytes(newPassword);
            
            var hashBytes = SHA512.HashData(bytes);

            return StringBytes(hashBytes);
        }


        private static string StringBytes(byte[] bytes)
        {
            var stringBuilder = new StringBuilder();
            foreach (var x in bytes)
            {
                stringBuilder.Append(x.ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
