using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class SWAP_Instruction : Instruction
    {
        public SWAP_Instruction(int line) : base(1, line)
        {
        }
        public override Byte[] GetHexCode()
        {
            return new byte[] { 0xC4 };
        }
        public override string ToString()
        {
            return "{SWAP_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }

}
