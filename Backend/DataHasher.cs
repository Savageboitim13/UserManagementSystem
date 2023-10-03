using System.Security.Cryptography;
using System.Text;

namespace UMS.Backend {
    internal class DataHasher {
        public static string HashData(string rawData) {
            // ComputeHash - returns a 256 byte array
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(rawData));

            StringBuilder builder = new StringBuilder();

            // Convert byte array to string
            for (int i = 0; i < bytes.Length; i++) {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
