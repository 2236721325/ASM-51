﻿using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class POP_Instruction : Instruction
    {

        public Token Direct { get; set; }
        public POP_Instruction(Token direct, int line) : base(2, line)
        {
            Direct = direct;
        }

        public override Byte[] GetHexCode()
        {
            return new byte[]
            {
                0xD0,
                Direct.GetDirectByte()
            };
        }


        public override string ToString()
        {
            return "{POP_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }


}
