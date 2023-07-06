using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class MOVX_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }

        public PrefixStructure Third { get; set; }
        public ushort Type;
        public MOVX_Instruction(PrefixStructure second, PrefixStructure third, ushort type, int line) : base(1, line)
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
                        (byte)(0xE2+ Third.InnerToken.GetReg_Rn_index())
                    };

                case 1:
                    return new Byte[]
                    {
                       0xE0,
                    };

                case 2:
                    return new Byte[]
                    {
                        (byte)(0xF2+ Second.InnerToken.GetReg_Rn_index())
                    };
                default:
                    return new Byte[]
                    {
                       0xF0,
                    };
              

            }
        }


        public override string ToString()
        {
            return "{MOVX_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }


}
