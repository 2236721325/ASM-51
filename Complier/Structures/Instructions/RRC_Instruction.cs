using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class RRC_Instruction : Instruction
    {
        public RRC_Instruction(int line) : base(line)
        {
        }
        public override Byte[] GetHexCode()
        {
            return new byte[] { 0x13 };
        }
        public override string ToString()
        {
            return "{RRC_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }

}
