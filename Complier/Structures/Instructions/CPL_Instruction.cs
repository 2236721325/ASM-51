using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class CPL_Instruction : Instruction
    {
        public ushort Type { get; set; }
        public Token EndToken { get; set; }

        private int bit_offset = 0;
        public CPL_Instruction(Token end_token, ushort type, int code_length, int line, int bit_offset = 0) : base(code_length, line)
        {
            Type = type;
            EndToken = end_token;
            this.bit_offset = bit_offset;
        }
        public override Byte[] GetHexCode()
        {
            switch (Type)
            {
                case 0:
                    return new byte[] { 0xF4 };

                case 1:
                    return new byte[] { 0xB3 };
                case 2:
                    return new byte[]
                    {
                        0xB2,
                        EndToken.GetBitByte(0,false)
                    };
                default:
                    return new byte[]
                    {
                        0xB2,
                        EndToken.GetBitByte(bit_offset,true)
                    };

            }
        }
        public override string ToString()
        {
            return "{CLR_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }

}
