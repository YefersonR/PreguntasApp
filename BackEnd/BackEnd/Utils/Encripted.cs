using System.Security.Cryptography;
using System.Text;

namespace BackEnd.Utils
{
    public static class Encripted
    {
        public static string EncriptedPassword(string password)
        {
            MD5 md5Hash = MD5.Create();

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sBuilder = new StringBuilder();
            for(int i = 0; i< data.Length; i++) 
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
