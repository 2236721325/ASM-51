using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class ORL_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }

        public PrefixStructure Third { get; set; }
        public ushort Type;
        public ORL_Instruction(PrefixStructure second, PrefixStructure third, ushort type, int code_length, int line) : base(code_length, line)
        {
            Second = second;
            Third = third;
            Type = type;
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
                default:
                    return new Byte[]
                    {
                       0x43,
                       Second.InnerToken.GetDirectByte(),
                       Third.InnerToken.GetDataByte()
                    };
            }
        }


        public override string ToString()
        {
            return "{ORL_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }
}
