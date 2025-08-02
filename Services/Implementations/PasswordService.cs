using System.Security.Cryptography;
using System.Text;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public class PasswordService : IPasswordService
    {
        public (string Hash, string Salt) HashPassword(string password)
        {
            byte[] saltBytes = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256);
            var hash = Convert.ToBase64String(pbkdf2.GetBytes(32));

            return (hash, salt);
        }

        public bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256);
            var computedHash = Convert.ToBase64String(pbkdf2.GetBytes(32));

            return storedHash == computedHash;
        }

        public bool IsPasswordStrong(string password)
        {
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit);
        }
    }
}
