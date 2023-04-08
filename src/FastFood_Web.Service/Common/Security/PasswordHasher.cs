namespace FastFood_Web.Service.Common.Security
{
    public class PasswordHasher
    {
        public static (string PasswordHash, string Salt) Hash(string password)
        {
            string salt = Guid.NewGuid().ToString();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(salt + password);
            return (passwordHash, salt);
        }

        public static bool Verify(string password, string salt, string passwordHash)
        {
            var result = BCrypt.Net.BCrypt.Verify(salt + password, passwordHash);
            return result;
        }
    }
}