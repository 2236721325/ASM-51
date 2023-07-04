using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class DA_Instruction : Instruction
    {
        public DA_Instruction(int line) : base(line)
        {
        }
        public override Byte[] GetHexCode()
        {
            return new byte[] { 0xD4 };
        }
        public override string ToString()
        {
            return "{DA_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }

}
