using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Day10ofLearning.Utilities
{
    public static class HashHelper
    {
        public static string ComputeHash<T>(T request)
        {
            var json = JsonSerializer.Serialize(request);
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(json));
            return Convert.ToHexString(bytes);
        }
    }
}
