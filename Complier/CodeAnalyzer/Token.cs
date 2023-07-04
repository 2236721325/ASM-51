using Complier.Exceptions;
using Complier.Helpers;
using Complier.Structures;
using System;

namespace Complier.CodeAnalyzer
{
    
    public class Token
    {
        public TokenKind Kind { get; set; }

        public string Value { get; set; }

        public int Line { get; set; }

        public Token(TokenKind kind, string value, int line)
        {
            Kind = kind;
            Value = value;
            Line = line;
        }

        public PrefixStructure ToPrefixStructure()
        {
            return new PrefixStructure(this);
        }

        public PrefixStructure ToPrefixStructure(Token prefix_token)
        {
            return new PrefixStructure(prefix_token,this);
        }


        public  bool IsReg_Rn()
        {
            var num = (int)this.Kind;
            return num >= 48 && num <= 55;
        }
        public  bool IsReg_Ri()
        {
            return this.Kind == TokenKind.REG_R0 || this.Kind == TokenKind.REG_R1;
        }

        public  Byte GetReg_Rn_index()
        {
            return (byte)((int)this.Kind - 48);
        }

        public Byte[] NumberTokenToBytes(int count=1)
        {
            if(this.Kind !=TokenKind.Number)
            {
                throw ThrowHelper.UnexpectedToken(this);
            }
            var bytes= ByteHelper.NumberTokenToBytes(this);
            if(bytes.Length!=count)
            {
                throw ThrowHelper.UnexpectedToken(this, $"this token must {count} byte length!");
            }
            return bytes;
        }
        //public override string ToString()
        //{
        //    return "{Token:{ " + $"TokenKind={Enum.GetName(typeof(TokenKind), Kind)}, Value={Value} , Line={Line} " + " }}";
        //}
    }
}
