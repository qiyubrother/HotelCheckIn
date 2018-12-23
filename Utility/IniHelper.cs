using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class IniHelper
    {
        /// <summary>
        /// INI文件的绝对路径
        /// </summary>
        public string Path;

        /// <summary>
        /// 读取的默认值
        /// </summary>
        public string DefValue;

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

        /// <summary>
        /// INI读写工具类
        /// </summary>
        /// <param name="path">INI文件绝对地址</param>
        /// <param name="def">读取值的默认值</param>
        public IniHelper(string path, string def = "")
        {
            FileInfo fi = new FileInfo(path);
            Path = fi.FullName;
            DefValue = def;
        }

        /// <summary>
        /// 设置INI文件的一个值
        /// </summary>
        /// <param name="section">节</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void SetValue(string section, string key, object value)
        {
            if (File.Exists(Path))
            {
                WritePrivateProfileString(section, key, value.ToString(), Path);
            }
        }

        /// <summary>
        /// 获取INI文件的一个值
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string section, string key, string defaultValue = "")
        {
            if (!File.Exists(Path))
            {
                return defaultValue;
            }
            StringBuilder sb = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, DefValue, sb, 255, Path);
            return sb.ToString();
        }
    }

}
