using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Application.Helpers
{
    public static class SHA1Helper
    {
        public static string Encrypt(string password)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha1.ComputeHash(passwordBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString());
                }

                return sb.ToString();
            }
        }
    }
}
