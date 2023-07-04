using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class CLR_Instruction : Instruction
    {
        public CLR_Instruction(int line) : base(line)
        {
        }
        public override Byte[] GetHexCode()
        {
            return new byte[] { 0xE4 };
        }
        public override string ToString()
        {
            return "{CLR_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }

}
