using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyBBSWebApi.Common
{
    public static class Md5Helper
    {
        public static string ToMd5(this string str)
        {
            // 参数中的this是告诉编译器这是一个扩展方法，也就是一个string变量可以直接调用这个方法
            // 扩展方法要成立的话, 当前class必须要是静态的

            // MD5 md5 = new MD5CryptoServiceProvider();  // 这个实例已经过时了
            using (MD5 md5 = MD5.Create()) {
                byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(str));
                var md5Str = BitConverter.ToString(output).Replace("-","");  // 把所有破折号都去掉
                return md5Str;
            }
        }
    }
}