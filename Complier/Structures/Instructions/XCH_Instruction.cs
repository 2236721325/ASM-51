using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class XCH_Instruction : Instruction
    {

        public Token Second { get; set; }
        public PrefixStructure Third { get; set; }

        public ushort Type { get; set; }

        public XCH_Instruction(Token second, PrefixStructure third, ushort type, int line) : base(line)
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

                    return new byte[]
                    {
                        (byte)(0xC8+Third.InnerToken.GetReg_Rn_index())
                    };


                case 1:

                    return new byte[]
                    {
                        0xC5,
                        Third.InnerToken.NumberTokenToBytes()[0],
                    };
             
                default:
                    return new byte[]
                    {
                        (byte)(0xC6+Third.InnerToken.GetReg_Rn_index())
                    };
            }
        }


        public override string ToString()
        {
            return "{XCH_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line},Type={Type}" + "} }";
        }
    }



}
