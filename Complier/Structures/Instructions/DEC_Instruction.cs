using Complier.CodeAnalyzer;
using Complier.Exceptions;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class DEC_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }


        public ushort Type;
        public DEC_Instruction(PrefixStructure second, ushort type, int line) : base(line)
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
                        0x14
                    };

                case 1:
                   
                    return new byte[] { (byte)(0x18+ TokenKindUtility.GetReg_Rn_index(Second.InnerToken.Kind)  )};

                case 2:

                    var direct = ByteHelper.NumberTokenToBytes(Second.InnerToken);
                    if (direct.Length != 1)
                    {
                        throw new SyntaxException("The direct is must 1 byte -> DEC direct ", Second.InnerToken.Line);
                    }
                    return new byte[] { 0x15, direct[0] };
                default:
                    return new byte[] { (byte)(0x16 + TokenKindUtility.GetReg_Rn_index(Second.InnerToken.Kind)) };
            }
        }


        public override string ToString()
        {
            return "{DEC_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }

}
