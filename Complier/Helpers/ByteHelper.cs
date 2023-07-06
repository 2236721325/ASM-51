using Complier.CodeAnalyzer;
using Complier.Exceptions;
using Complier.Symbols;
using System;
using System.Collections.Generic;
using System.Drawing;
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
           
            var list = new List<byte>();
          
            for (int i = bytes.Length-1; i>=0; i--)
            {
                if (bytes[i]!=0)
                {
                    list.Add(bytes[i]);
                }
            }
            return list.ToArray();
        }

      
        public static Byte[] NumberTokenToBytes(Token number_token)
        {
            var value_str = number_token.Value;
            if (Char.ToLower( value_str[value_str.Length-1])=='b')
            {
                value_str = value_str.Substring(0, value_str.Length - 1);

                // 将二进制字符串转换为字节数组
                int num = Convert.ToInt32(value_str, 2);
                return Zip(BitConverter.GetBytes(num));
            }
            if (Char.ToLower(value_str[value_str.Length - 1]) == 'h')
            {
                value_str = value_str.Substring(0, value_str.Length - 1);
                int num = int.Parse(value_str, System.Globalization.NumberStyles.AllowHexSpecifier);
                return Zip(BitConverter.GetBytes(num));
                // 消除多余的字节
            }
            var num_end = int.Parse(value_str);
            return Zip(BitConverter.GetBytes(num_end));
        }

        public static int NumberTokenToInt(Token number_token)
        {
            var value_str = number_token.Value;
            if (Char.ToLower(value_str[value_str.Length - 1]) == 'b')
            {
                value_str = value_str.Substring(0, value_str.Length - 1);

                // 将二进制字符串转换为字节数组
               return Convert.ToInt32(value_str, 2);
                
            }
            if (Char.ToLower(value_str[value_str.Length - 1]) == 'h')
            {
                value_str = value_str.Substring(0, value_str.Length - 1);
                return int.Parse(value_str, System.Globalization.NumberStyles.AllowHexSpecifier);
                // 消除多余的字节
            }
            var num_end = int.Parse(value_str);
            return num_end;
        }



        public static byte GetDirectByte(Token token)
        {
            if (token.Kind == TokenKind.Number)
            {
                return token.NumberTokenToBytes()[0];
            }
            if (token.Kind == TokenKind.TOKEN_Symbol)
            {
                var symbol = SymbolTableFactory.Current.FindSymbolOfKind(token, e => e.Type==SymbolType.CONST|| e.Type==SymbolType.DATA);
                var bytes= Zip(BitConverter.GetBytes(symbol.Value));
                if(bytes.Length!=1)
                {
                    throw ThrowHelper.UnexpectedToken(token, "Direct Value Must 1 byte");
                }
                return bytes[0];
            }
            throw ThrowHelper.UnexpectedToken(token);

        }

        public static byte GetDataByte(Token token)
        {
            if (token.Kind == TokenKind.Number)
            {
                return token.NumberTokenToBytes()[0];
            }
            if (token.Kind == TokenKind.TOKEN_Symbol)
            {
                var symbol = SymbolTableFactory.Current.FindSymbolOfKind(token, e => e.Type== SymbolType.CONST || e .Type== SymbolType.LABEL);
                var bytes = Zip(BitConverter.GetBytes(symbol.Value));
                if (bytes.Length > 1)
                {
                    throw ThrowHelper.UnexpectedToken(token, "Data Value Must 1 byte");
                }
                if(bytes.Length==0)
                {
                    return 0x00;
                }
                return bytes[0];
            }
            throw ThrowHelper.UnexpectedToken(token);
        }

        public static byte[] GetData16Byte(Token token)
        {
            if (token.Kind == TokenKind.Number)
            {
                return token.NumberTokenToBytes(2);
            }
            if (token.Kind == TokenKind.TOKEN_Symbol)
            {
                var symbol = SymbolTableFactory.Current.FindSymbolOfKind(token, e => e.Type == SymbolType.CONST || e.Type == SymbolType.LABEL);
                var bytes = Zip(BitConverter.GetBytes(symbol.Value));
                if (bytes.Length > 2)
                {
                    throw ThrowHelper.UnexpectedToken(token, "Data16 Value Must 2 byte");
                }
                var list = bytes.ToList();

                if (bytes.Length<2)
                {
                    for (int i = 0; i <2- bytes.Length; i++)
                    {
                        list.Insert(0, 0x00);
                    }
                }
                
                return list.ToArray();
            }
            throw ThrowHelper.UnexpectedToken(token);
        }

        public static byte[] GetAdrress16Byte(Token token)
        {
            if (token.Kind == TokenKind.Number)
            {
                return token.NumberTokenToBytes(2);
            }
            if (token.Kind == TokenKind.TOKEN_Symbol)
            {
                var symbol = SymbolTableFactory.Current.FindSymbolOfKind(token, e => e.Type == SymbolType.CONST || e.Type == SymbolType.LABEL);
                var bytes = Zip(BitConverter.GetBytes(symbol.Value));
                if (bytes.Length > 2)
                {
                    throw ThrowHelper.UnexpectedToken(token, "Address16 Value Must 2 byte");
                }
                var list = bytes.ToList();

                if (bytes.Length < 2)
                {
                    for (int i = 0; i < 2 - bytes.Length; i++)
                    {
                        list.Insert(0, 0x00);
                    }
                }

                return list.ToArray();
            }
            throw ThrowHelper.UnexpectedToken(token);
        }


        public static byte[] Get_ACALL_Address11Bytes(Token token)
        {
            var byte_array = new byte[2];
            int address11 = 0;
            if(token.Kind==TokenKind.Number)
            {
                address11= NumberTokenToInt(token);
            }
            var symbol = SymbolTableFactory.Current.FindSymbolOfKind(token, e => e.Type == SymbolType.CONST || e.Type == SymbolType.LABEL);


            address11 = symbol.Value;



            byte_array[0] = (byte)(
                    ((address11 >> 3) & 0b_1110_0000) | 0b0001_0001
                );
            byte_array[1]=(byte)(
                    address11 & 0b_1111_1111
                );
            return byte_array;
        }
        public static byte GetBitByte(Token token,int offset=0,bool has_dot_bit=false)
        {
            if (token.Kind == TokenKind.Number)
            {
                return (byte)(token.NumberTokenToBytes()[0] + offset);
            }
            if (token.Kind == TokenKind.TOKEN_Symbol)
            {
                var symbol = SymbolTableFactory.Current.FindSymbol(token);
                if (symbol.Type == SymbolType.CONST || symbol.Type == SymbolType.BIT)
                {
                    var bytes = Zip(BitConverter.GetBytes(symbol.Value));
                    if (bytes.Length > 1)
                    {
                        throw ThrowHelper.UnexpectedToken(token, "Data Value Must 1 byte");
                    }
                    if (bytes.Length == 0)
                    {
                        return 0x00;
                    }
                    return bytes[0];
                }
                if(symbol.Type==SymbolType.DATA &&symbol.canDotBit && has_dot_bit)
                {
                    var bytes = Zip(BitConverter.GetBytes(symbol.Value));
                    if (bytes.Length > 1)
                    {
                        throw ThrowHelper.UnexpectedToken(token, "Data Value Must 1 byte");
                    }
                    if (bytes.Length == 0)
                    {
                        return 0x00;
                    }
                    return (byte)(bytes[0]+offset);
                }
                throw ThrowHelper.UnexpectedToken(token);
            }
            
            throw ThrowHelper.UnexpectedToken(token);
        }

        public static byte[] Get_AJMP_Address11Bytes(Token token)
        {
            var byte_array = new byte[2];
            int address11 = 0;
            if (token.Kind == TokenKind.Number)
            {
                address11 = NumberTokenToInt(token);
            }
            var symbol = SymbolTableFactory.Current.FindSymbolOfKind(token, e => e.Type == SymbolType.CONST || e.Type == SymbolType.LABEL);


            address11 = symbol.Value;



            byte_array[0] = (byte)(
                    ((address11 >> 3) & 0b_1110_0000) | 0b0000_0001
                );
            byte_array[1] = (byte)(
                    address11 & 0b_1111_1111
                );
            return byte_array;
        }


        public static byte GetRelByte(Token token,int current_address)
        {
            if (token.Kind == TokenKind.Number)
            {
                return (byte)(token.NumberTokenToBytes()[0] - current_address);
            }
            if (token.Kind == TokenKind.TOKEN_Symbol)
            {
                var symbol = SymbolTableFactory.Current.FindSymbolOfKind(token, e => e.Type == SymbolType.CONST || e.Type == SymbolType.LABEL);
                var bytes = Zip(BitConverter.GetBytes(symbol.Value));
                if (bytes.Length != 1)
                {
                    throw ThrowHelper.UnexpectedToken(token, "Rel Value Must 1 byte");
                }
                return (byte)(bytes[0] - current_address);
            }
            throw ThrowHelper.UnexpectedToken(token);
        }
    }
}
