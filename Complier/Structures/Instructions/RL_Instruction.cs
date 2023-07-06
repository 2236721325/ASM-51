using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class RL_Instruction : Instruction
    {
        public RL_Instruction(int line) : base(1, line)
        {
        }
        public override Byte[] GetHexCode()
        {
            return new byte[] { 0x23 };
        }
        public override string ToString()
        {
            return "{RL_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }

}
