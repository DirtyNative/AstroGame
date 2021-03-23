using AspNetCore.ServiceRegistration.Dynamic;
using System.Security.Cryptography;

namespace AstroGame.Core.Services
{
    [ScopedService]
    public class PasswordService
    {
        public (byte[] PasswordBytes, byte[] SaltBytes) DeriveBytes(string password,
            int passwordBytesLength = 64, byte[] salt = null, int saltBytesLength = 32)
        {
            if (salt == null)
            {
                salt = new byte[saltBytesLength];

                using var rand = new RNGCryptoServiceProvider();
                rand.GetBytes(salt);
            }

            byte[] passwordBytes;
            using (var kdf = new Rfc2898DeriveBytes(password, salt, 2048))
            {
                passwordBytes = kdf.GetBytes(passwordBytesLength);
            }

            return (passwordBytes, salt);
        }
    }
}