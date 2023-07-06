using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class MOVC_Instruction : Instruction
    {

        public Token Second { get; set; }

        public PrefixStructure Third { get; set; }
        public ushort Type;
        public MOVC_Instruction(Token second, PrefixStructure third, ushort type, int line) : base(1, line)
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
                        0x93
                    };

                default:
                    return new Byte[]
                    {
                       0x83,
                    };

           

            }
        }


        public override string ToString()
        {
            return "{MOVC_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }



}
