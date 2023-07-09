using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class XRL_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }

        public PrefixStructure Third { get; set; }
        public ushort Type;
        public XRL_Instruction(PrefixStructure second, PrefixStructure third, ushort type, int code_length, int line) : base(code_length, line)
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
                        (byte)(0x68+ Third.InnerToken.GetReg_Rn_index())
                    };

                case 1:
                    return new Byte[]
                    {
                       0x65,
                       Third.InnerToken.GetDirectByte(),
                    };


                case 2:
                    return new Byte[]
                    {
                        (byte)(0x66+ Third.InnerToken.GetReg_Rn_index())
                    };
                case 3:
                    return new Byte[]
                    {
                       0x64,
                       Third.InnerToken.GetDataByte(),
                    };
                case 4:
                    return new Byte[]
                    {
                       0x62,
                       Second.InnerToken.GetDirectByte(),
                    };
                default:
                    return new Byte[]
                    {
                       0x63,
                       Second.InnerToken.GetDirectByte(),
                       Third.InnerToken.GetDataByte()
                    };
            }
        }


        public override string ToString()
        {
            return "{XRL_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }

}
