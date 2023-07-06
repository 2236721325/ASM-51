using Complier.CodeAnalyzer;
using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
    public class CJNE_Instruction : Instruction
    {

        public Token Data { get; set; }
        public Token First { get; set; }
        public Token Rel { get; set; }
        private int start_address;
        public ushort Type { get; set; }
        public CJNE_Instruction(int start_address,Token first,Token data, Token rel, ushort type, int line) : base(3, line)
        {
            Rel = rel;
            this.start_address = start_address;
            Type = type;
            Data = data;
            First = first;
        }

        public override Byte[] GetHexCode()
        {
            switch (Type)
            {
                case 0:
                    return new byte[]
                    {
                        0xB5,
                        Data.GetDirectByte(),
                        Rel.GetRelByte(start_address+HexCodeLength)
                    };
                case 1:
                    return new byte[]
                    {
                        0xB4,
                        Data.GetDataByte(),
                        Rel.GetRelByte(start_address+HexCodeLength)
                    };
                case 2:
                    return new byte[]
                    {
                        (byte)(0xB8+First.GetReg_Rn_index()),
                        Data.GetDataByte(),
                        Rel.GetRelByte(start_address+HexCodeLength)
                    };
                default:
                    return new byte[]
                   {
                        (byte)(0xB6+First.GetReg_Rn_index()),
                        Data.GetDataByte(),
                        Rel.GetRelByte(start_address+HexCodeLength)
                   };

            }

        }



        public override string ToString()
        {
            return "{CJNE_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
        }
    }

}
