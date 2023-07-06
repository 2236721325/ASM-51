using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class JZ_Instruction : Instruction
    {

        public Token Rel { get; set; }
        private int start_address;
        public JZ_Instruction(int start_address, Token rel, int line) : base(2, line)
        {
            Rel = rel;
            this.start_address = start_address;
        }

        public override Byte[] GetHexCode()
        {
            return new byte[]
            {
                0x60,
                Rel.GetRelByte(start_address+HexCodeLength)
            };
        }


        public override string ToString()
        {
            return "{JZ_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }



}
