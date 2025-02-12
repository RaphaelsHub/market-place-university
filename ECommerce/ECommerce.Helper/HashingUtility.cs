using System;
using System.Security.Cryptography;
using System.Text;

namespace ECommerce.Helper
{
    public static class HashingUtility
    {
        public static string HashPasswordSha256(string data)
        {
            using (SHA256 hasher = SHA256.Create())
            {
                byte[] hashedData = hasher.ComputeHash(Encoding.UTF8.GetBytes(data));
                
                StringBuilder builder = new StringBuilder();
                
                foreach (var elem in hashedData)
                    builder.Append(elem.ToString("x2"));
                
                return builder.ToString();
            }
        }
        
        public static bool VerifyPasswordSha256(string data, string dataHash)
        {
            string hashedData = HashPasswordSha256(data);
            return string.Equals(hashedData, dataHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}