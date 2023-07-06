using Complier.CodeAnalyzer;
using Complier.Exceptions;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class SUBB_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }

        public ushort Type;
        public SUBB_Instruction(PrefixStructure second, ushort type, int code_length, int line) : base(code_length, line)
        {
            Second = second;
            Type = type;
        }

        public override Byte[] GetHexCode()
        {
            switch (Type)
            {
                case 0:
                    return new Byte[]
                    {
                        (Byte)(0x98 + Second.InnerToken.GetReg_Rn_index())
                    };
                case 1:
                    var direct = Second.InnerToken.GetDirectByte();
                    return new byte[] { 0x95, direct };
                case 2:
                    return new Byte[]
                    {
                        (Byte)(0x96 + Second.InnerToken.GetReg_Rn_index())
                    };
                default:
                    var data = Second.InnerToken.GetDataByte();
                    return new byte[] { 0x94, data };
            }
        }


        public override string ToString()
        {
            return "{SUBB_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }


}
