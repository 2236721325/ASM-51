using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class Nop_Instruction : Instruction
    {
        public Nop_Instruction(int line) : base(1, line)
        {
        }
        public override Byte[] GetHexCode()
        {
            return new byte[] { 0x00 };
        }
        public override string ToString()
        {
            return "{Nop_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }


}
