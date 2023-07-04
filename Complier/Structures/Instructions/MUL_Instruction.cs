using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class MUL_Instruction : Instruction
    {
        public MUL_Instruction(int line) : base(line)
        {
        }
        public override Byte[] GetHexCode()
        {
            return new byte[] { 0xA4 };
        }
        public override string ToString()
        {
            return "{MUL_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }


}
