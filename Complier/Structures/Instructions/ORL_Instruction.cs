using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class ORL_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }

        public PrefixStructure Third { get; set; }
        public ushort Type;

        private int bit_offset= 0;
        public ORL_Instruction(PrefixStructure second, PrefixStructure third, ushort type, int code_length, int line, int bit_offset=0) : base(code_length, line)
        {
            Second = second;
            Third = third;
            Type = type;
            this.bit_offset = bit_offset;
        }

        public override Byte[] GetHexCode()
        {
            switch (Type)
            {
                case 0:
                    return new Byte[]
                    {
                        (byte)(0x48+ Third.InnerToken.GetReg_Rn_index())
                    };

                case 1:
                    return new Byte[]
                    {
                       0x45,
                       Third.InnerToken.GetDirectByte(),
                    };


                case 2:
                    return new Byte[]
                    {
                        (byte)(0x46+ Third.InnerToken.GetReg_Rn_index())
                    };
                case 3:
                    return new Byte[]
                    {
                       0x44,
                       Third.InnerToken.GetDataByte(),
                    };
                case 4:
                    return new Byte[]
                    {
                       0x42,
                       Second.InnerToken.GetDirectByte(),
                    };
                case 5:
                    return new Byte[]
                    {
                       0x43,
                       Second.InnerToken.GetDirectByte(),
                       Third.InnerToken.GetDataByte()
                    };
                case 6:
                    return new Byte[]
                    {
                       0x72,
                       Third.InnerToken.GetBitByte()
                    };
                case 7:
                    return new Byte[]
                    {
                      0x72,
                      Third.InnerToken.GetBitByte(bit_offset,true)
                    };
                case 8:
                    return new Byte[]
                    {
                       0xA0,
                       Third.InnerToken.GetBitByte()
                    };
                default:
                    return new Byte[]
                    {
                       0xA0,
                       Third.InnerToken.GetBitByte(bit_offset,true)
                    };
            }
        }


        public override string ToString()
        {
            return "{ORL_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }
}
