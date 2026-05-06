using System.Security.Cryptography;
using System.Text;

namespace IveComeToBook.Application.Services.Cryptography
{
    public class PasswordEncripter
    {
        private readonly string _additionalKey;
        public PasswordEncripter(string additionalKey)
        {
            _additionalKey = additionalKey;
        }
        public string Encrypt(string password)
        {

            var newPassword = $"{password}{_additionalKey}";

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
