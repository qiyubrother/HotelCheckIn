using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAPI
{
    public class API
    {
        /// <summary>
        /// 设定INI文件中的属性
        /// </summary>
        /// <param name="section">节</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="filePath">INI文件的绝对地址</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        /// <summary>
        /// 读取INI文件中的属性
        /// </summary>
        /// <param name="section">节</param>
        /// <param name="key">键</param>
        /// <param name="def">默认值</param>
        /// <param name="retVal">被存储到的StringBuilder</param>
        /// <param name="size">最大字串截取长度</param>
        /// <param name="filePath">INI文件的绝对地址</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    }
}
