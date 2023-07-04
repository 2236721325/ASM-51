using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class RR_Instruction : Instruction
    {
        public RR_Instruction(int line) : base(line)
        {
        }
        public override Byte[] GetHexCode()
        {
            return new byte[] { 0x03 };
        }
        public override string ToString()
        {
            return "{RR_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }

}
