using Complier.CodeAnalyzer;
using Complier.Exceptions;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    //指令
    public  class Instruction
    {
        public int Line { get; set; }

        public Instruction(int line)
        {
            Line = line;
        }
        /// <summary>
        /// will return null;
        /// </summary>
        /// <returns></returns>
        public virtual Byte[] GetHexCode()
        {
            return null;
        }

        public override string ToString()
        {
            return "{Instruction:{" + $"Line={Line},Code=null " + "} }";
        }
    }

    public class Nop_Instruction : Instruction
    {
        public Nop_Instruction(int line) : base(line)
        {
        }
        public override Byte[] GetHexCode()
        {
            return new byte[] { 0x00 };
        }
        public override string ToString()
        {
            return "{Nop_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }


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
