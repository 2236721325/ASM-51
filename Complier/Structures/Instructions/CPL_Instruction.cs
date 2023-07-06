using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class CPL_Instruction : Instruction
    {
        public CPL_Instruction( int line) : base(1, line)
        {
        }
        public override Byte[] GetHexCode()
        {
            return new byte[] { 0xF4 };
        }
        public override string ToString()
        {
            return "{CPL_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }

}
