using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class INC_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }

        public ushort Type;
        public INC_Instruction(PrefixStructure second, ushort type, int code_length, int line) : base(code_length, line)
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
                        0x04
                    };

                case 1:

                    return new byte[] { (byte)(0x08 + Second.InnerToken.GetReg_Rn_index()) };

                case 2:
                    var direct = Second.InnerToken.GetDirectByte();
                    return new Byte[]
                    {
                        0x05,
                        direct
                    };
                case 3:
                    return new byte[] { (byte)(0x06 + Second.InnerToken.GetReg_Rn_index()) };
                default:
                    return new byte[] { 0xA3};
            }
        }


        public override string ToString()
        {
            return "{INC_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }


}
