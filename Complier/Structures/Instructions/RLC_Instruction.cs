using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class RLC_Instruction : Instruction
    {
        public RLC_Instruction(int line) : base(line)
        {
        }
        public override Byte[] GetHexCode()
        {
            return new byte[] { 0x33 };
        }
        public override string ToString()
        {
            return "{RLC_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }

}
