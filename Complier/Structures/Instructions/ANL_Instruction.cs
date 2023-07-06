﻿using Complier.CodeAnalyzer;
using Complier.Exceptions;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class ANL_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }

        public PrefixStructure Third { get; set; }
        public ushort Type;
        public ANL_Instruction(PrefixStructure second, PrefixStructure third, ushort type, int code_length, int line) : base(code_length, line)
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
                        (byte)(0x58+ Third.InnerToken.GetReg_Rn_index())
                    };

                case 1:
                    return new Byte[]
                    {
                       0x55,
                       Third.InnerToken.GetDirectByte()
                    };


                case 2:
                    return new Byte[]
                    {
                        (byte)(0x56+ Third.InnerToken.GetReg_Rn_index())
                    };
                case 3:
                    return new Byte[]
                    {
                       0x54,
                       Third.InnerToken.GetDataByte()
                    };
                case 4:
                    return new Byte[]
                    {
                       0x52,
                       Second.InnerToken.GetDirectByte()
                    };
                default:
                    return new Byte[]
                    {
                       0x53,
                       Second.InnerToken.GetDirectByte(),
                       Third.InnerToken.GetDataByte()
                    };
            }
        }


        public override string ToString()
        {
            return "{ANL_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }

}
