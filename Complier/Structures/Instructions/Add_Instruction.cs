using Complier.CodeAnalyzer;
using Complier.Exceptions;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    /// <summary>
    /// ADD,A,Rn                    0
    /// ADD A,direct                1
    /// Add A,@Ri                   2
    /// Add A,#data                 3
    /// </summary>
    public class Add_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }

        public ushort Type; 
        public Add_Instruction(PrefixStructure second, ushort type,int line) : base(line)
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
                        (Byte)(0x28 + TokenKindUtility.GetReg_Rn_index(Second.InnerToken.Kind)) 
                    };

                case 1:
                    var direct = ByteHelper.NumberTokenToBytes(Second.InnerToken);
                    if(direct.Length != 1)
                    {
                        throw new SyntaxException("The direct is must 1 byte -> ADD A,direct ",Second.InnerToken.Line);
                    }
                    return new byte[] { 0x25, direct[0] };

                case 2:
                    
                    return new byte[] { (byte)( 0x26 + TokenKindUtility.GetReg_Rn_index(Second.InnerToken.Kind)) };
                default:
                    direct = ByteHelper.NumberTokenToBytes(Second.InnerToken);
                    if (direct.Length != 1)
                    {
                        throw new SyntaxException("The direct is must 1 byte -> ADD A,#data ", Second.InnerToken.Line);
                    }
                    return new byte[] { 0x24, direct[0] };
            }
        }


        public override string ToString()
        {
            return "{ADD_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }

}
