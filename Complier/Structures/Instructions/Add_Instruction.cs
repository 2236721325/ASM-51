using Complier.CodeAnalyzer;
using Complier.Exceptions;
using Complier.Helpers;
using Complier.Symbols;
using System;

namespace Complier.Structures.Instructions
{
    /// <summary>
    /// ADD,A,Rn                    0
    /// ADD A,direct                1
    /// Add A,@Ri                   2
    /// Add A,#data                 3
    /// </summary>
    public class ADD_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }

        public ushort Type; 
        public ADD_Instruction(PrefixStructure second, ushort type, int code_length, int line) : base(code_length,line)
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
                        (Byte)(0x28 + Second.InnerToken.GetReg_Rn_index())
                    };
                case 1:

                    var direct = Second.InnerToken.GetDirectByte();
                    return new byte[] { 0x25, direct };
                case 2:
                    return new Byte[]
                    {
                        (Byte)(0x26 + Second.InnerToken.GetReg_Rn_index())
                    };
                default:
                    var data = Second.InnerToken.GetDataByte();
                    return new byte[] { 0x24, data};
            }
        }


        public override string ToString()
        {
            return "{ADD_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }

}
