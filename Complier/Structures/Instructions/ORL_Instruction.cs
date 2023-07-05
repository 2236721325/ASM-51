using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class ORL_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }

        public PrefixStructure Third { get; set; }
        public ushort Type;
        public ORL_Instruction(PrefixStructure second, PrefixStructure third, ushort type, int line) : base(line)
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
                       Third.InnerToken.NumberTokenToBytes()[0],
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
                       Third.InnerToken.NumberTokenToBytes()[0],
                    };
                case 4:
                    return new Byte[]
                    {
                       0x42,
                       Second.InnerToken.NumberTokenToBytes()[0],
                    };
                default:
                    return new Byte[]
                    {
                       0x43,
                       Second.InnerToken.NumberTokenToBytes()[0],
                       Third.InnerToken.NumberTokenToBytes()[0],
                    };
            }
        }


        public override string ToString()
        {
            return "{ORL_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }
}
