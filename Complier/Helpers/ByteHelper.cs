using Complier.CodeAnalyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Complier.Helpers
{
    public static class ByteHelper
    {

        public static string GetString(this Byte[] bytes)
        {
            return "[" + string.Join(" , ", bytes.Select(b => b.ToString("X2"))) + "]";
        }
        public static Byte[] Zip(Byte[] bytes)
        {
            var list = new List<byte>
            {
                bytes[0]
            };
            for (int i = 1; i < bytes.Length; i++)
            {
                if (bytes[i]!=0)
                {
                    list.Add(bytes[i]);
                }
            }
            return list.ToArray();
        }
        public static Byte[]  NumberTokenToBytes(Token number_token)
        {
            var value_str = number_token.Value;
            if (value_str.EndsWith('b'))
            {
                value_str = value_str.Substring(0, value_str.Length - 1);

                // 将二进制字符串转换为字节数组
                int num = Convert.ToInt32(value_str, 2);
                return Zip(BitConverter.GetBytes(num));
            }
            if (value_str.EndsWith('h'))
            {
                value_str = value_str.Substring(0, value_str.Length - 1);
                int num = int.Parse(value_str, System.Globalization.NumberStyles.AllowHexSpecifier);
                return Zip(BitConverter.GetBytes(num));
                // 消除多余的字节

            }
            var num_end = int.Parse(value_str);
            return Zip(BitConverter.GetBytes(num_end));
        }
    }
}
