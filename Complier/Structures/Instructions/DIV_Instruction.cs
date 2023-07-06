using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class DIV_Instruction : Instruction
    {
        public DIV_Instruction(int line) : base(1, line)
        {
        }
        public override Byte[] GetHexCode()
        {
            return new byte[] { 0x84 };
        }
        public override string ToString()
        {
            return "{DIV_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }


}
