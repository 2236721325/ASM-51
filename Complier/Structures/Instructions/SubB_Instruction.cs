using Complier.CodeAnalyzer;
using Complier.Exceptions;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class SubB_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }

        public ushort Type;
        public SubB_Instruction(PrefixStructure second, ushort type, int line) : base(line)
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
                        (Byte)(0x98 + TokenKindUtility.GetReg_Rn_index(Second.InnerToken.Kind))
                    };

                case 1:
                    var direct = ByteHelper.NumberTokenToBytes(Second.InnerToken);
                    if (direct.Length != 1)
                    {
                        throw new SyntaxException("The direct is must 1 byte -> ADD A,direct ", Second.InnerToken.Line);
                    }
                    return new byte[] { 0x95, direct[0] };

                case 2:

                    return new byte[] { (byte)(0x96 + TokenKindUtility.GetReg_Rn_index(Second.InnerToken.Kind)) };
                default:
                    direct = ByteHelper.NumberTokenToBytes(Second.InnerToken);
                    if (direct.Length != 1)
                    {
                        throw new SyntaxException("The direct is must 1 byte -> ADD A,#data ", Second.InnerToken.Line);
                    }
                    return new byte[] { 0x94, direct[0] };
            }
        }


        public override string ToString()
        {
            return "{SUBB_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }


}
