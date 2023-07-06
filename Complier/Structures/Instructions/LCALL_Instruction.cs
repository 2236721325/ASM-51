using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;
using System.Collections.Generic;

namespace Complier.Structures.Instructions
{
    public class LCALL_Instruction : Instruction
    {

        public Token Address16 { get; set; }
        public LCALL_Instruction(Token address16, int line) : base(3, line)
        {
            Address16 = address16;
        }

        public override Byte[] GetHexCode()
        {
            var bytes = new List<Byte>
            {
               0x12
            };
            bytes.AddRange(Address16.GetAddress16Byte());
            return bytes.ToArray();
        }


        public override string ToString()
        {
            return "{LCALL_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }


}
