using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class AJMP_Instruction : Instruction
    {

        public Token Address11 { get; set; }
        public AJMP_Instruction(Token address11, int line) : base(2, line)
        {
            Address11 = address11;
        }

        public override Byte[] GetHexCode()
        {
            return Address11.Get_AJMP_Address11Bytes();
        }


        public override string ToString()
        {
            return "{AJMP_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }

}
