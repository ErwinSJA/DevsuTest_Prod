using System.Security.Cryptography;
using System.Text;

namespace WebAPI.DevsuTest.Util.Class
{
    public class clsEncrypt
    {
        const int keySize = 16; //64;

        private static readonly Dictionary<string, byte[]> keyCache = new ();

        public static string fstrGenerarPasswordHashSHA512(string pstrPassword, out string pstrSalt)
        {
            byte[] arrbyteSalt = RandomNumberGenerator.GetBytes(keySize);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(pstrPassword);

            using var sha512 = SHA512.Create();
            byte[] hashBytes = sha512.ComputeHash(arrbyteSalt.Concat(passwordBytes).ToArray());
            string passwordHash = Convert.ToHexString(hashBytes);
            pstrSalt = Convert.ToHexString(arrbyteSalt);
            return passwordHash;
        }
        public static bool fblnVerificarPasswordSHA512(string pstrPassword, string pstrPaswwordSalt, string pstrPasswordHash)
        {
            string cacheKey = pstrPaswwordSalt + pstrPassword;

            if (!keyCache.TryGetValue(cacheKey, out byte[]? hashToCompare))
            {
                byte[] passwordSaltBytes = StringToByteArray(pstrPaswwordSalt);
                byte[] passwordBytes = Encoding.UTF8.GetBytes(pstrPassword);

                using (var sha512 = SHA512.Create())
                {
                    byte[] computedHash = sha512.ComputeHash(passwordSaltBytes.Concat(passwordBytes).ToArray());
                    hashToCompare = computedHash;
                }

                keyCache.Add(cacheKey, hashToCompare);
            }

            return hashToCompare.SequenceEqual(Convert.FromHexString(pstrPasswordHash));
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}
