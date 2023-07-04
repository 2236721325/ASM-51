using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class INC_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }

        public ushort Type;
        public INC_Instruction(PrefixStructure second, ushort type, int line) : base(line)
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
                        0x04
                    };

                case 1:

                    return new byte[] { (byte)(0x08 + TokenKindUtility.GetReg_Rn_index(Second.InnerToken.Kind)) };

                case 2:
                    var direct = ByteHelper.NumberTokenToBytes(Second.InnerToken);


                    return new Byte[]
                    {
                        0x05,
                        direct[0]
                    };
                case 3:
                    return new byte[] { (byte)(0x06 + TokenKindUtility.GetReg_Rn_index(Second.InnerToken.Kind)) };
                default:
                    return new byte[] { 0xA3};
            }
        }


        public override string ToString()
        {
            return "{INC_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }


}
