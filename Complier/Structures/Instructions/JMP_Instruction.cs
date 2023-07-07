using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class JMP_Instruction : Instruction
    {

        private int start_address;
        public Token Rel { get; set; }

        public int Type { get; set; }
        public JMP_Instruction(int start_address,Token rel,int type, int line,int code_length=1) : base(code_length, line)
        {
            Rel = rel;
            this.start_address = start_address;
            Type = type;
        }

        public override Byte[] GetHexCode()
        {
            switch (Type)
            {
                case 0:
                    return new byte[]
                    {
                        0x80,
                        Rel.GetRelByte(start_address+HexCodeLength)
                    };
                default:
                    return new byte[]
                    {
                        0x73,
                    };
            }
          
        }


        public override string ToString()
        {
            return "{JMP_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }



}
