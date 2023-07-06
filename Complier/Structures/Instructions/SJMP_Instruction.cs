using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class SJMP_Instruction : Instruction
    {

        public Token Rel { get; set; }
        private int start_address;
        public SJMP_Instruction(int start_address,Token rel, int line) : base(2, line)
        {
            Rel = rel;
            this.start_address = start_address;
        }

        public override Byte[] GetHexCode()
        {
            return new byte[]
            {
                0x80,
                Rel.GetRelByte(start_address+HexCodeLength)
            };
        }


        public override string ToString()
        {
            return "{SJMP_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }



}
