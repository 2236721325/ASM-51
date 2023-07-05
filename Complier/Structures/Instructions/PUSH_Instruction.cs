using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class PUSH_Instruction : Instruction
    {

        public Token Direct { get; set; }
        public PUSH_Instruction(Token direct,int line) : base(line)
        {
            Direct = direct;
        }

        public override Byte[] GetHexCode()
        {
            return new byte[]
            {
                0xC0,
                Direct.NumberTokenToBytes()[0],
            };
        }


        public override string ToString()
        {
            return "{PUSH_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }


}
