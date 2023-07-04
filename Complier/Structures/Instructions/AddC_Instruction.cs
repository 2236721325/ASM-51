using Complier.CodeAnalyzer;
using Complier.Exceptions;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class AddC_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }

        public ushort Type;
        public AddC_Instruction(PrefixStructure second, ushort type, int line) : base(line)
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
                        (Byte)(0x38 + TokenKindUtility.GetReg_Rn_index(Second.InnerToken.Kind))
                    };

                case 1:
                    var direct = ByteHelper.NumberTokenToBytes(Second.InnerToken);
                    if (direct.Length != 1)
                    {
                        throw new SyntaxException("The direct is must 1 byte -> ADD A,direct ", Second.InnerToken.Line);
                    }
                    return new byte[] { 0x35, direct[0] };

                case 2:

                    return new byte[] { (byte)(0x36 + TokenKindUtility.GetReg_Rn_index(Second.InnerToken.Kind)) };
                default:
                    direct = ByteHelper.NumberTokenToBytes(Second.InnerToken);
                    if (direct.Length != 1)
                    {
                        throw new SyntaxException("The direct is must 1 byte -> ADD A,#data ", Second.InnerToken.Line);
                    }
                    return new byte[] { 0x34, direct[0] };
            }
        }


        public override string ToString()
        {
            return "{ADDC_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }


}
