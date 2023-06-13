using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HashCrypto
    {
        public string GenerarMD5(string Cadena)
        {
            try
            {
                UnicodeEncoding UeCod = new UnicodeEncoding();

                byte[] ByteSourceText = UeCod.GetBytes(Cadena);
                MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
                byte[] ByteHash = Md5.ComputeHash(ByteSourceText);
                return Convert.ToBase64String(ByteHash);
            }
            catch (CryptographicException ex)
            { throw (ex); }
            catch (Exception ex)
            { throw (ex); }
        }
    }
}
