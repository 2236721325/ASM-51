using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class XCHD_Instruction : Instruction
    {

        public Token Ri_Token { get; set; }
        public XCHD_Instruction(Token ri_token, int line) : base(1, line)
        {
            Ri_Token = ri_token;
        }

        public override Byte[] GetHexCode()
        {
            return new byte[]
            {
                (byte)(0xD6+Ri_Token.GetReg_Rn_index())
            };
        }


        public override string ToString()
        {
            return "{XCHD_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }



}
