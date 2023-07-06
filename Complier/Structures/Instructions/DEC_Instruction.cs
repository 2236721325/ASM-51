using Complier.CodeAnalyzer;
using Complier.Exceptions;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class DEC_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }


        public ushort Type;
        public DEC_Instruction(PrefixStructure second, ushort type, int code_length, int line) : base(code_length, line)
        {
            Second = second;
            Type = type;
        }

        public override Byte[] GetHexCode()
        {
            switch (Type)
            {
                case 0:
                    return new Byte[]
                    {
                        0x14
                    };

                case 1:

                    return new byte[] { (byte)(0x18 + Second.InnerToken.GetReg_Rn_index()) };

                case 2:
                    var direct = Second.InnerToken.GetDirectByte();
                    return new Byte[]
                    {
                        0x15,
                        direct
                    };
                default:
                    return new byte[] { (byte)(0x16 + Second.InnerToken.GetReg_Rn_index()) };
             
            }
        }


        public override string ToString()
        {
            return "{DEC_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }

}
