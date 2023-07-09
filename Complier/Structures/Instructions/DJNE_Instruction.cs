using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class DJNE_Instruction : Instruction
    {

        public Token First { get; set; }
        public Token Rel { get; set; }
        private int start_address;
        public ushort Type { get; set; }
        public DJNE_Instruction(int start_address, Token first, Token rel, ushort type, int line,int code_length) : base(code_length, line)
        {
            Rel = rel;
            this.start_address = start_address;
            Type = type;
            First = first;
        }

        public override Byte[] GetHexCode()
        {
            switch (Type)
            {
                case 0:
                    return new byte[]
                    {
                        (byte)(0xD8+First.GetReg_Rn_index()),
                        Rel.GetRelByte(start_address+HexCodeLength)
                    };
                default:
                    return new byte[]
                    {
                        0xD5,
                        First.GetDirectByte(),
                        Rel.GetRelByte(start_address+HexCodeLength)
                    };

            }

        }



        public override string ToString()
        {
            return "{DJNE_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }

}
