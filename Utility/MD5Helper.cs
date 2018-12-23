using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Utility
{
    public class MD5Helper
    {
        /// <summary>
        /// 获取字符串的MD5结果
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <returns></returns>
        public static string CalculateMD5(string str)
        {
            string result = string.Empty;
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] s1 = Encoding.UTF8.GetBytes(str);
                byte[] s2 = md5.ComputeHash(s1, 0, s1.Length);
                md5.Clear();
                result = string.Join(string.Empty, from o in s2 select o.ToString("X2"));
            }
            return result;
        }
    }
}
