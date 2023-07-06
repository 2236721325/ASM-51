using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class JMP_Instruction : Instruction
    {

        public JMP_Instruction( int line) : base(1, line)
        {

        }

        public override Byte[] GetHexCode()
        {
            return new byte[]
            {
                0x73,
            };
        }


        public override string ToString()
        {
            return "{JMP_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }



}
