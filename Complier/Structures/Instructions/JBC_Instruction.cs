using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class JBC_Instruction : Instruction
    {

        public Token BitToken { get; set; }
        public Token Rel { get; set; }
        private int start_address;
        private int bit_offset;
        public ushort Type { get; set; }
        public JBC_Instruction(int start_address, Token bit_token, Token rel, ushort type, int line, int bit_offset = 0) : base(3, line)
        {
            Rel = rel;
            this.start_address = start_address;
            this.bit_offset = bit_offset;
            Type = type;
            BitToken = bit_token;
        }

        public override Byte[] GetHexCode()
        {
            switch (Type)
            {
                case 0:
                    return new byte[]
                    {
                        0x10,
                        BitToken.GetBitByte(),
                        Rel.GetRelByte(start_address+HexCodeLength)
                    };
                default:
                    return new byte[]
                   {
                        0x10,
                        BitToken.GetBitByte(bit_offset,true),
                        Rel.GetRelByte(start_address+HexCodeLength)
                   };

            }

        }



        public override string ToString()
        {
            return "{JBC_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }

}
