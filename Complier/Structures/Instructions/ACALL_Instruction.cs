using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class ACALL_Instruction : Instruction
    {

        public Token Address11 { get; set; }
        public ACALL_Instruction(Token address11, int line) : base(2, line)
        {
            Address11 = address11;
        }

        public override Byte[] GetHexCode()
        {
            return Address11.Get_ACALL_Address11Bytes();
        }


        public override string ToString()
        {
            return "{ACALL_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }

}
